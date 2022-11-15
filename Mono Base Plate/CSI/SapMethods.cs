using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Mono_Base_Plate.CSI.Classes;
using Mono_Base_Plate.CSI.Enums;
using Mono_Base_Plate.CSI.Structs;
using SAP2000 = SAP2000v19;

namespace Mono_Base_Plate.CSI
{
    public static class SapMethods
    {
        public static SAP2000.cSapModel AttachModel()
        {
            const string progId = "CSI.SAP2000.API.SapObject";
            if (!(Marshal.GetActiveObject(progId) is SAP2000.cOAPI sapObject))
            {
                throw new Exception("No running instance of the program found or failed to attach.");
            }

            return sapObject.SapModel;
        }

        public static List<LoadCombinations> GetLoadCombinations(ref SAP2000.cSapModel sapModel)
        {
            var counter = 0;
            string[] MyName = { };

            var LoadCombinationList = new List<LoadCombinations>();

            var ret = sapModel.RespCombo.GetNameList(ref counter, ref MyName);
            if (ret != 0)
            {
                return null;
            }

            for (var i1 = 0; i1 < MyName.Length; i1++)
            {
                var lc = new LoadCombinations();

                var ComboType = 0;
                SAP2000.eCNameType[] eCNameType = { };
                string[] CName = { };
                double[] SF = { };

                lc.Name = MyName[i1];

                ret = sapModel.RespCombo.GetTypeOAPI(lc.Name, ref ComboType);
                if (ret != 0)
                {
                    return null;
                }

                switch (ComboType)
                {
                    case 0:
                        lc.CombinationType = CombinationTypes.LinearAdditive;
                        break;
                    case 1:
                        lc.CombinationType = CombinationTypes.Envelope;
                        break;
                    case 2:
                        lc.CombinationType = CombinationTypes.AbsoluteAdditive;
                        break;
                    case 3:
                        lc.CombinationType = CombinationTypes.SRSS;
                        break;
                    case 4:
                        lc.CombinationType = CombinationTypes.RangeAdditive;
                        break;
                    default:
                        MessageBox.Show("1");
                        break;
                }

                ret = sapModel.RespCombo.GetCaseList(lc.Name, ref counter, ref eCNameType, ref CName, ref SF);
                if (ret != 0)
                {
                    return null;
                }

                for (var i2 = 0; i2 < eCNameType.Count(); i2++)
                {
                    var lci = new LoadCombinationItems
                    {
                        eCNameType = eCNameType[i2],
                        CName = CName[i2],
                        SF = SF[i2]
                    };

                    lc.Items.Add(lci);
                }

                LoadCombinationList.Add(lc);
            }

            return LoadCombinationList;
        }

        public static List<PointLoads> GetLoads(string[] loadCombos, double baseElevation)
        {
            const double tolerance = 0.001;
            var sapModel = AttachModel();

            if (loadCombos.Length == 0)
            {
                return null;
            }

            var numberItems = 0;
            var objectType = new int[] { };
            var objectName = new string[] { };

            var ret = sapModel.SelectObj.GetSelected(ref numberItems, ref objectType, ref objectName);
            if (ret != 0)
            {
                throw new Exception("SAP Error");
            }

            if (numberItems == 0)
            {
                throw new Exception("No frame selected!\r\nPlease select some frame objects on SAP2000 program.");
            }

            ret = sapModel.SetPresentUnits(SAP2000.eUnits.kgf_m_C);
            if (ret != 0)
            {
                throw new Exception("SAP Error");
            }

            ret = sapModel.PointObj.GetNameList(ref numberItems, ref objectName);
            if (ret != 0)
            {
                throw new Exception("SAP Error");
            }
            
            var pointList = new List<Points>();
            for (var i = 0; i < objectName.Length; i++)
            {
                var x = 0.0;
                var y = 0.0;
                var z = 0.0;
                ret = sapModel.PointObj.GetCoordCartesian(objectName[i], ref x, ref y, ref z);
                if (ret != 0)
                {
                    throw new Exception("SAP Error");
                }

                if (Math.Abs(z - baseElevation) > tolerance)
                {
                    continue;
                }

                pointList.Add(new Points(objectName[i], x, y, z));
            }
            
            ret = sapModel.Results.Setup.DeselectAllCasesAndCombosForOutput();
            if (ret != 0)
            {
                throw new Exception("SAP Error");
            }

            for (var i = 0; i < loadCombos.Length; i++)
            {
                ret = sapModel.Results.Setup.SetComboSelectedForOutput(loadCombos[i]);
                if (ret != 0)
                {
                    throw new Exception("SAP Error");
                }
            }

            var obj = new string[] { };
            var elm = new string[] { };
            var pointElm = new string[] { };
            var loadCase = new string[] { };
            var stepType = new string[] { };
            var stepNum = new double[] { };
            var f1 = new double[] { };
            var f2 = new double[] { };
            var f3 = new double[] { };
            var m1 = new double[] { };
            var m2 = new double[] { };
            var m3 = new double[] { };

            ret = sapModel.Results.FrameJointForce("All", SAP2000.eItemTypeElm.SelectionElm, ref numberItems, ref obj, ref elm, ref pointElm, ref loadCase, ref stepType, ref stepNum, ref f1, ref f2, ref f3, ref m1, ref m2, ref m3);
            if (ret != 0)
            {
                throw new Exception("SAP Error");
            }

            var pointLoadList = new List<PointLoads>();
            for (var i = 0; i < numberItems; i++)
            {
                var iss = pointList.Any(p => p.Name == pointElm[i]);
                if (iss)
                {
                    pointLoadList.Add(new PointLoads()
                    {
                        LoadComboName = loadCase[i],
                        FrameName = obj[i],
                        PointName = pointElm[i],

                        F1 = f1[i],
                        F2 = f2[i],
                        F3 = f3[i],

                        M1 = m1[i],
                        M2 = m2[i],
                        M3 = m3[i],
                    });
                }
            }

            return pointLoadList;
        }

        public class PointLoads
        {
            public string LoadComboName { get; set; }
            public string PointName { get; set; }
            public string FrameName { get; set; }

            public double F1 { get; set; }
            public double F2 { get; set; }
            public double F3 { get; set; }

            public double M1 { get; set; }
            public double M2 { get; set; }
            public double M3 { get; set; }


        }
    }
}
