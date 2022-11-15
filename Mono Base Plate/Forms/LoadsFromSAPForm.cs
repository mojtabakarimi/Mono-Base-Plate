using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using SAP2000v19;

namespace Mono_Base_Plate.Forms
{
    public partial class frmLoadsFromSAP : System.Windows.Forms.Form
    {
        private cOAPI sapObject;
        private cSapModel sapModel;

        private List<Points> pointList;
        private List<Points> restraintPointList;
        private List<Frames> frameList;
        private List<BasePlateTypes> basePlateTypeList;

        private const int toleranceDigitNo = 3;           //for meter -> 0.001
        private const double tolerance = 0.001;

        public frmLoadsFromSAP()
        {
            InitializeComponent();
        }

        private void frmLoadsFromSAP_Load(object sender, EventArgs e)
        {

        }

        private void btnAttachToSAP_Click(object sender, EventArgs e)
        {
            try
            {
                sapObject = Marshal.GetActiveObject("CSI.SAP2000.API.SapObject") as cOAPI;
                if (sapObject == null)
                {
                    MessageBox.Show(@"Can not attach to SAP2000 program", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                sapModel = sapObject.SapModel;

                btnGetTypes.Enabled = true;
                btnSaveBaseLoads.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.Contains("0x800401E3")
                    ? @"Can not attach to SAP2000 program, it may be close or inactive, try to close all SAP2000 models and open just one model."
                    : ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnOpenSAP_Click(object sender, EventArgs e)
        {
            try
            {
                var openFileDialog = new OpenFileDialog
                {
                    Title = @"Open SAP Model file",
                    Filter = @"SAP2000 Model Files|*.sdb"
                };

                if(openFileDialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                var FilePath = openFileDialog.FileName;
                var ProgramPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles), "Computers and Structures", "SAP2000 19", "SAP2000.exe");

                if (!File.Exists(ProgramPath))
                {
                    openFileDialog.Title = @"Locate SAP.exe path";
                    openFileDialog.Filter = @"SAP Executable file|SAP2000.exe";
                    openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);

                    if (openFileDialog.ShowDialog() != DialogResult.OK)
                    {
                        return;
                    }

                    ProgramPath = openFileDialog.FileName;
                }

                cHelper myHelper = new Helper();
                sapObject = myHelper.CreateObject(ProgramPath);

                if (sapObject.ApplicationStart() != 0)
                {
                    MessageBox.Show(@"Could not start program", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                sapModel = sapObject.SapModel;
                sapModel.File.OpenFile(FilePath);

                btnGetTypes.Enabled = true;
                btnSaveBaseLoads.Enabled = false;
            }
            catch (Exception ex)
            {
                try
                {
                    sapObject.ApplicationExit(false);
                }
                catch
                {
                    ;
                }
                sapObject = null;
                sapModel = null;

                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGetTypes_Click(object sender, EventArgs e)
        {
            dgvJoints.Rows.Clear();

            lbRegularLoadCombos.Items.Clear();
            lbSpecialLoadCombos.Items.Clear();

            Application.DoEvents();

            try
            {
                if (GetJointNames() != 0 || GetLoadCombos() != 0)
                {
                    MessageBox.Show(@"An error has been occurred", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                btnSaveBaseLoads.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSaveBaseLoads_Click(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog
            {
                Filter = @"Mono Base Plate Loadings file|*.mbpl"
            };

            if (lbRegularLoadCombos.SelectedItems.Count == 0)
            {
                MessageBox.Show(@"At least one regular combination should be selected.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (sfd.ShowDialog() == DialogResult.OK)
            {
                //BasePlateTypeList = New List(Of BasePlateTypes)
                //For i1 As Integer = 0 To dgvJoints.Rows.Count - 1
                //    For i2 As Integer = 0 To RestraintPointList.Count - 1
                //        If dgvJoints.Rows(i1).Cells(colJointsList.Index).Value.ToString = RestraintPointList(i2).Name Then
                //            Dim bpType As BasePlateTypes
                //            Dim j As Integer = -1

                //            For i3 As Integer = 0 To BasePlateTypeList.Count - 1
                //                If dgvJoints.Rows(i1).Cells(colType.Index).Value.ToString = BasePlateTypeList(i3).Name Then
                //                    j = i3
                //                    Exit For
                //                End If
                //            Next i3

                //            If j > -1 Then
                //                bpType = BasePlateTypeList(j)

                //                bpType.JointList.Add(dgvJoints.Rows(i1).Cells(colJointsList.Index).Value.ToString)

                //                BasePlateTypeList(j) = bpType
                //            Else
                //                bpType = New BasePlateTypes

                //                bpType.Name = dgvJoints.Rows(i1).Cells(colType.Index).Value.ToString
                //                bpType.JointList.Add(dgvJoints.Rows(i1).Cells(colJointsList.Index).Value.ToString)
                //                bpType.Column = dgvJoints.Rows(i1).Cells(colColumn.Index).Value.ToString
                //                If dgvJoints.Rows(i1).Cells(colBrace.Index).Value.ToString = "Yes" Then
                //                    bpType.Brace = True
                //                Else
                //                    bpType.Brace = False
                //                End If

                //                BasePlateTypeList.Add(bpType)
                //            End If

                //            Exit For
                //        End If
                //    Next i2
                //Next i1


                var numberResults = 0;
                string[] obj = {};
                string[] elm = {};
                string[] loadCase = {};
                string[] stepType = {};
                double[] stepNum = {};
                double[] f1 = {};
                double[] f2 = {};
                double[] f3 = {};
                double[] m1 = {};
                double[] m2 = {};
                double[] m3 = {};

                var ret = sapModel.Analyze.RunAnalysis();

                sapModel.SetPresentUnits(eUnits.kgf_m_C);

                //Dim DOF() As Boolean = {True, True, True, False, False, False}
                //ret = SapModel.SelectObj.SupportedPoints(DOF)

                for (var i = 0; i < basePlateTypeList.Count; i++)
                {
                    var results = new StringBuilder();

                    sapModel.SelectObj.ClearSelection();
                    for (var j = 0; j < basePlateTypeList[i].JointList.Count; j++)
                    {
                        sapModel.PointObj.SetSelected(basePlateTypeList[i].JointList[j], true, eItemType.Objects);
                    }

                    for (var j = 0; j <= 1; j++)
                    {
                        sapModel.Results.Setup.DeselectAllCasesAndCombosForOutput();
                        switch (j)
                        {
                            case 0:
                                for (var k = 0; k < lbRegularLoadCombos.SelectedItems.Count; k++)
                                {
                                    ret = sapModel.Results.Setup.SetComboSelectedForOutput(lbRegularLoadCombos.SelectedItems[k].ToString(), true);
                                }

                                break;
                            case 1:
                                if (lbSpecialLoadCombos.SelectedItems.Count == 0)
                                {
                                    break;
                                }
                                for (var k = 0; k < lbSpecialLoadCombos.SelectedItems.Count; k++)
                                {
                                    ret = sapModel.Results.Setup.SetComboSelectedForOutput(lbSpecialLoadCombos.SelectedItems[k].ToString(), true);
                                }

                                break;
                        }

                        ret = sapModel.Results.JointReact("", eItemTypeElm.SelectionElm, ref numberResults, ref obj, ref elm, ref loadCase, ref stepType, ref stepNum, ref f1, ref f2,
                        ref f3, ref m1, ref m2, ref m3);

                        if (ret != 0)
                        {
                            MessageBox.Show("Error getting loads!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }

                        switch (j)
                        {
                            case 0:
                                for (var k = 0; k < loadCase.Length; k++)
                                {
                                    results.AppendLine($"{loadCase[k]}\t{(f3[k] / 1000):0.00}\t{(Math.Sqrt(Math.Pow(f1[k], 2) + Math.Pow(f2[k], 2)) / 1000):0.00}\t0");
                                }

                                break;
                            case 1:
                                for (var k = 0; k < loadCase.Length; k++)
                                {
                                    results.AppendLine($"{loadCase[k]}\t{(f3[k] / 1000):0.00}\t0\t0");
                                }

                                break;
                        }
                    }

                    var FileName = Path.GetDirectoryName(sfd.FileName);
                    if (FileName != null && !FileName.EndsWith(Path.DirectorySeparatorChar.ToString()))
                    {
                        FileName += Path.DirectorySeparatorChar;
                    }

                    FileName += Path.GetFileNameWithoutExtension(sfd.FileName) + " - " + basePlateTypeList[i].Name + " [" + basePlateTypeList[i].Column + "]" + (basePlateTypeList[i].BraceX || basePlateTypeList[i].BraceY ? " {BR}" : "") + Path.GetExtension(sfd.FileName);

                    File.WriteAllText(FileName, results.ToString());
                }

                sapModel.SelectObj.ClearSelection();

                MessageBox.Show($@"{basePlateTypeList.Count} files have been saved!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private int GetSectionGeneralProperty(string FrameName, ref SectionProperties secProp)
        {
            try
            {
                secProp = new SectionProperties();

                var propName = "";
                var sAuto = "";

                double area = 0;
                double as2 = 0;
                double as3 = 0;
                double torsion = 0;
                double I22 = 0;
                double I33 = 0;
                double S22 = 0;
                double S33 = 0;
                double Z22 = 0;
                double Z33 = 0;
                double R22 = 0;
                double R33 = 0;

                //ret = SapModel.SetPresentUnits(eUnits.kgf_cm_C)
                //If Not ret = 0 Then
                //    Return 10
                //End If

                var ret = sapModel.FrameObj.GetSection(FrameName, ref propName, ref sAuto);
                if (ret != 0)
                {
                    throw new Exception();
                }

                ret = sapModel.PropFrame.GetSectProps(propName, ref area, ref as2, ref as3, ref torsion, ref I22, ref I33, ref S22, ref S33, ref Z22,
                    ref Z33, ref R22, ref R33);
                if (ret != 0)
                {
                    throw new Exception();
                }

                secProp.Area = area;
                secProp.as2 = as2;
                secProp.as3 = as3;
                secProp.Torsion = torsion;
                secProp.I22 = I22;
                secProp.I33 = I33;
                secProp.S22 = S22;
                secProp.S33 = S33;
                secProp.Z22 = Z22;
                secProp.Z33 = Z33;
                secProp.R22 = R22;
                secProp.R33 = R33;

                //ret = SapModel.SetPresentUnits(eUnits.kgf_cm_C)
                return 0;
            }
            catch (Exception e)
            {
                sapModel.SetPresentUnits(eUnits.kgf_cm_C);

                return 1;
            } 
        }

        private int GetLoadCombos()
        {
            var numberNames = 0;
            var myName = new string [] { };

            var ret = sapModel.Results.Setup.DeselectAllCasesAndCombosForOutput();
            ret = sapModel.RespCombo.GetNameList(ref numberNames, ref myName);

            lbRegularLoadCombos.Items.Clear();
            lbSpecialLoadCombos.Items.Clear();

            for (var i = 0; i < numberNames; i++)
            {
                lbRegularLoadCombos.Items.Add(myName[i]);
                lbSpecialLoadCombos.Items.Add(myName[i]);
            }

            return 0;
        }

        private int GetFramePoints()
        {
            var numberNames = 0;
            var myName = new string[] { };

            var ret = sapModel.PointObj.GetNameList(ref numberNames, ref myName);
            if (ret != 0)
            {
                return 101;
            }

            pointList = new List<Points>();
            for (var i = 0; i < numberNames; i++)
            {
                var point = new Points();
                var x = 0.0;
                var y = 0.0;
                var z = 0.0;
                var values = new bool[6];

                point.Name = myName[i];

                ret = sapModel.PointObj.GetCoordCartesian(myName[i], ref x, ref y, ref z);
                if (ret != 0)
                {
                    return 1011;
                }

                point.X = Math.Round(x, toleranceDigitNo);
                point.Y = Math.Round(y, toleranceDigitNo);
                point.Z = Math.Round(z, toleranceDigitNo);

                ret = sapModel.PointObj.GetRestraint(myName[i], ref values);
                if (ret != 0)
                {
                    return 1012;
                }

                point.Restraints = values;

                pointList.Add(point);
            }

            ret = sapModel.FrameObj.GetNameList(ref numberNames, ref myName);
            if (ret != 0)
            {
                return 102;
            }

            frameList = new List<Frames>();
            for (var i = 0; i < numberNames; i++)
            {
                var point1 = string.Empty;
                var point2 = string.Empty;

                ret = sapModel.FrameObj.GetPoints(myName[i], ref point1, ref point2);
                if (ret != 0)
                {
                    return 1023;
                }

                var fr = new Frames
                {
                    Name = myName[i]
                };

                GetSectionGeneralProperty(fr.Name, ref fr.SectionProp);

                fr.Point1Index = pointList.FindIndex(p => p.Name == point1);
                fr.Point2Index = pointList.FindIndex(p => p.Name == point2);

                if (fr.Point1Index == -1 || fr.Point2Index == -1)
                {
                    return 1024;
                }

                fr.Point1 = pointList[fr.Point1Index].Name;
                fr.Point2 = pointList[fr.Point2Index].Name;

                if (Math.Abs(pointList[fr.Point1Index].Z - pointList[fr.Point2Index].Z) > tolerance && (Math.Abs(pointList[fr.Point1Index].X - pointList[fr.Point2Index].X) < tolerance && Math.Abs(pointList[fr.Point1Index].Y - pointList[fr.Point2Index].Y) < tolerance))
                {
                    fr.FrameType = FrameTypes.Column;
                }
                else if (Math.Abs(pointList[fr.Point1Index].Z - pointList[fr.Point2Index].Z) < tolerance)
                {
                    fr.FrameType = FrameTypes.Beam;
                }
                else if (Math.Abs(pointList[fr.Point1Index].Z - pointList[fr.Point2Index].Z) > tolerance && !(Math.Abs(pointList[fr.Point1Index].X - pointList[fr.Point2Index].X) < tolerance && Math.Abs(pointList[fr.Point1Index].Y - pointList[fr.Point2Index].Y) < tolerance))
                {
                    if (Math.Abs(pointList[fr.Point1Index].X - pointList[fr.Point2Index].X) < tolerance)
                    {
                        fr.FrameType = FrameTypes.BraceY;
                    }
                    else if (Math.Abs(pointList[fr.Point1Index].Y - pointList[fr.Point2Index].Y) < tolerance)
                    {
                        fr.FrameType = FrameTypes.BraceX;
                    }
                    else
                    {
                        fr.FrameType = FrameTypes.BraceXY;
                    }
                }
                else
                {
                    fr.FrameType = FrameTypes.None;
                }

                var PropName = string.Empty;
                var SAuto = string.Empty;

                ret = sapModel.FrameObj.GetSection(myName[i], ref PropName, ref SAuto);
                if (ret != 0)
                {
                    return 1031;
                }

                fr.ProfileSection = PropName;

                var po1 = pointList[fr.Point1Index];
                var po2 = pointList[fr.Point2Index];

                var index = po1.FrameList.FindIndex(element => element.Name == fr.Name);
                if (index == -1)
                {
                    po1.FrameList.Add(fr);
                }

                index = po2.FrameList.FindIndex(element => element.Name == fr.Name);
                if (index == -1)
                {
                    po2.FrameList.Add(fr);
                }

                frameList.Add(fr);
            }

            return 0;
        }

        private int GetJointNames()
        {
            basePlateTypeList = new List<BasePlateTypes>();
            pointList = new List<Points>();
            restraintPointList = new List<Points>();

            if (GetFramePoints() != 0)
            {
                return 99;
            }

            for (var i = 0; i < pointList.Count; i++)
            {
                if (pointList[i].Restraint)
                {
                    restraintPointList.Add(pointList[i]);
                }
            }

            if (restraintPointList.Count == 0)
            {
                return 5001;
            }

            var braceDefault = MessageBox.Show(@"Seprate types for base plate with/without brace in base?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) != DialogResult.Yes;

            var index = 0;
            for (var i = 0; i < restraintPointList.Count; i++)
            {
                var bpType = new BasePlateTypes();

                for (var j = 0; j < restraintPointList[i].FrameList.Count; j++)
                {
                    if (restraintPointList[i].FrameList[j].FrameType == FrameTypes.Column)
                    {
                        bpType.Column = restraintPointList[i].FrameList[j].ProfileSection;
                        break;
                    }
                }

                bpType.BraceX = braceDefault;
                bpType.BraceY = braceDefault;

                if (!braceDefault)
                {
                    for (var j = 0; j < restraintPointList[i].FrameList.Count; j++)
                    {
                        if (restraintPointList[i].FrameList[j].FrameType == FrameTypes.BraceX)
                        {
                            bpType.BraceX = true;
                        }
                        if (restraintPointList[i].FrameList[j].FrameType == FrameTypes.BraceY)
                        {
                            bpType.BraceY = true;
                        }
                    }
                }

                var basePlateTypeIndex = -1;
                for (var j = 0; j < basePlateTypeList.Count; j++)
                {
                    if (basePlateTypeList[j].Column == bpType.Column && basePlateTypeList[j].BraceX == bpType.BraceX && basePlateTypeList[j].BraceY == bpType.BraceY)
                    {
                        basePlateTypeIndex = j;
                    }
                }

                if (basePlateTypeIndex == -1)
                {
                    index++;
                    bpType.Name = $"Type{index}";

                    bpType.JointList.Add(restraintPointList[i].Name);
                    basePlateTypeList.Add(bpType);
                }
                else
                {
                    bpType = basePlateTypeList[basePlateTypeIndex];
                    bpType.JointList.Add(restraintPointList[i].Name);
                    basePlateTypeList[basePlateTypeIndex] = bpType;
                }
            }

            index = 0;
            for (var i = 0; i < basePlateTypeList.Count; i++)
            {
                for (var j = 0; j < basePlateTypeList[i].JointList.Count; j++)
                {
                    dgvJoints.Rows.Add();

                    dgvJoints.Rows[index].Cells[colJointsList.Index].Value = basePlateTypeList[i].JointList[j];
                    dgvJoints.Rows[index].Cells[colColumn.Index].Value = basePlateTypeList[i].Column;

                    if (braceDefault == false && basePlateTypeList[i].BraceX && basePlateTypeList[i].BraceY)
                    {
                        dgvJoints.Rows[index].Cells[colBrace.Index].Value = "XY";
                    }
                    else if (braceDefault == false && basePlateTypeList[i].BraceX)
                    {
                        dgvJoints.Rows[index].Cells[colBrace.Index].Value = "X";
                    }
                    else if (braceDefault == false && basePlateTypeList[i].BraceY)
                    {
                        dgvJoints.Rows[index].Cells[colBrace.Index].Value = "Y";
                    }
                    else
                    {
                        dgvJoints.Rows[index].Cells[colBrace.Index].Value = "";
                    }

                    dgvJoints.Rows[index].Cells[colType.Index].Value = basePlateTypeList[i].Name;

                    index++;
                }
            }

            return 0;
        }

        private void cbRegularLoadCombinationCheckAll_CheckedChanged(object sender, EventArgs e)
        {
            for (var i = 0; i < lbRegularLoadCombos.Items.Count; i++)
            {
                lbRegularLoadCombos.SetSelected(i, cbRegularLoadCombinationCheckAll.Checked);
            }
        }

        private void cbSpecialLoadCombinationCheckAll_CheckedChanged(object sender, EventArgs e)
        {
            for (var i = 0; i < lbSpecialLoadCombos.Items.Count; i++)
            {
                lbSpecialLoadCombos.SetSelected(i, cbSpecialLoadCombinationCheckAll.Checked);
            }
        }

        #region
        private class Frames
        {
            public string Name;
            public string Point1;
            public string Point2;
            public int Point1Index = -1;
            public int Point2Index = -1;
            public string ProfileSection;

            public FrameTypes FrameType = FrameTypes.None;
            public SectionProperties SectionProp;
        }

        private class SectionProperties
        {

            public SectionProperties()
            {
                Area = 0;
                as2 = 0;
                as3 = 0;
                Torsion = 0;
                I22 = 0;
                I33 = 0;
                S22 = 0;
                S33 = 0;
                Z22 = 0;
                Z33 = 0;
                R22 = 0;
                R33 = 0;
            }

            public double Area;
            public double as2;
            public double as3;
            public double Torsion;
            public double I22;
            public double I33;
            public double S22;
            public double S33;
            public double Z22;
            public double Z33;
            public double R22;
            public double R33;
        }

        private class Points
        {
            public string Name;

            public double X;
            public double Y;
            public double Z;

            public bool[] Restraints;

            public readonly List<Frames> FrameList;

            public Points()
            {
                FrameList = new List<Frames>();
                Restraints = new bool[6];
            }

            public bool Restraint
            {
                get
                {
                    if (Restraints != null && (Restraints[0] && Restraints[1] && Restraints[2]))
                    {
                        return true;
                    }

                    return false;
                }
            }

        }

        private class BasePlateTypes //: IComparer<BasePlateTypes>
        {
            public string Name;
            public string Column;

            public bool BraceX;
            public bool BraceY;

            public List<string> JointList = new List<string>();

            //public int Compare(BasePlateTypes x, BasePlateTypes y)
            //{
            //    return 1;
            //}
        }

        public enum FrameTypes
        {
            None = 0,
            Column = 1,
            Beam = 2,
            BraceX = 11,
            BraceY = 12,
            BraceXY = 13
        }
        #endregion

        private void dgvJoints_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvJoints_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == colType.Index)
            {
                var Index = -1;
                for (var i = 0; i < basePlateTypeList.Count; i++)
                {
                    if (basePlateTypeList[i].Name == dgvJoints.Rows[e.RowIndex].Cells[colType.Index].Value.ToString())
                    {
                        Index = i;
                        break;
                    }
                }

                if (basePlateTypeList[Index].Column != dgvJoints.Rows[e.RowIndex].Cells[colColumn.Index].Value.ToString())
                {
                    MessageBox.Show("22131");
                    dgvJoints.Focus();
                }
            }
        }


    }
}
