using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using Base_Plate_Engine.Common.Materials;
using Base_Plate_Engine.Common.Section.Interfaces;
using Base_Plate_Engine.Common.Section.Shapes;
using Base_Plate_Engine.Design;
using EngineeringUnits;
using EngineeringUnits.Units;
using Mono_Base_Plate.AutoCAD;
using Mono_Base_Plate.Class;
using Mono_Base_Plate.Controls;
using Mono_Base_Plate.Factory;
using Newtonsoft.Json;
using AnchorBolt = Base_Plate_Engine.Common.AnchorBolt;
using Application = System.Windows.Forms.Application;
using BasePlateLoad = Base_Plate_Engine.Design.BasePlateLoad;

namespace Mono_Base_Plate.Forms
{
    public partial class frmMain : Form
    {
        private void Pic_Click(object sender, EventArgs e)
        {
        }

        #region Variables

        private const string NewLineString = "$%!|";
        
        public int SectionIndex { get; set; }

        private const string ProjectDefaultFileName = "Untitled";

        private string projectFileName { get; set; } = ProjectDefaultFileName;


        private bool IsLoaded { get; set; }
        private bool IsFileChanged { get; set; }

        private bool IsAvailable { get; set; }

        private bool IsRealTimeDesignEnable { get; set; }

        private DesignResult designResult;
        private DesignResult[] designResults;

        //public static frmMain FormMain = new frmMain();
        //public static frmInteractiveCurve FormInteractiveCurve = new frmInteractiveCurve();


        #endregion

        #region Form Events

        public frmMain()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            SectionIndex = 24;

            cboSteelMaterial.Items.Clear();
            cboSteelMaterial.Items.AddRange(SteelMaterialFactory.Items.Select(p => (object)p.Name).ToArray());
            cboSteelMaterial.SelectedItem = SteelMaterialFactory.Items.Single(p => p.Name == "S235 t≤t16mm").Name;

            cboRebarMaterial.Items.Clear();
            cboRebarMaterial.Items.AddRange(RebarMaterialFactory.Items.Select(p => (object)p.Name).ToArray());
            cboRebarMaterial.SelectedItem = RebarMaterialFactory.Items[1].Name;
            

            cboBolts.Items.AddRange(AnchorBoltFactory.Items.Select(p => p.Name).Cast<object>().ToArray());

            cboAnchorBoltMaterial.Items.Clear();
            cboAnchorBoltMaterial.Items.AddRange(AnchorBoltMaterialFactory.Items.Select(p => p.Name).Cast<object>().ToArray());
            cboAnchorBoltMaterial.SelectedIndex = 0;

            cboColumnSection.Items.AddRange(SectionIFactory.Items.Select(p => p.Name).Cast<object>().ToArray());
            cboColumnSection.SelectedItem = SectionIFactory.Items[SectionIndex].Name;

            var rebars = Array.AsReadOnly(new[] {8, 10, 12, 14, 16, 18, 20, 22, 25, 28, 30, 32, 36});
            cbo_dr.Items.AddRange(rebars.Cast<object>().ToArray());
            cbo_drs.Items.AddRange(rebars.Cast<object>().ToArray());

            cboShearKeyPipe.Items.AddRange(SectionPipeFactory.Items.Select(p => p.Name).Cast<object>().ToArray());
            cboShearKeyWideFlange.Items.AddRange(SectionIFactory.Items.Select(p => p.Name).Cast<object>().ToArray());
            
            LoadDefaults();

            IsFileChanged = false;
            rtbResult.Clear();

            if (IsRealTimeDesignEnable)
            {
                RunDesign();
            }
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            try
            {
                Licensing.CheckExpire();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }

            var thread = new Thread(Licensing.Contribute);
            thread.Start();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!IsFileChanged)
            {
                return;
            }

            switch (MessageBox.Show($"Save Project?\r\nDo you want to save your project?", Application.ProductName, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
            {
                case DialogResult.Yes:
                    var saveFileDialog = new SaveFileDialog
                    {
                        Filter = @"Mono Base Plate files|*.mbp",
                        FileName = projectFileName
                    };

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        SaveProject(saveFileDialog.FileName);
                    }
                    else
                    {
                        e.Cancel = true;
                    }

                    break;
                case DialogResult.No:
                    break; //Do nothing and let the program to close!
                case DialogResult.Cancel:
                    e.Cancel = true;
                    return;
                default:
                    return;
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnDesign_Click(object sender, EventArgs e)
        {
            rtbResult.Text = @"Calculating ...";
            Application.DoEvents();

            RunDesign();
        }

        private void btnColumnSection_Click(object sender, EventArgs e)
        {
            var f = new frmSections(this.SectionIndex)
            {
                TopMost = TopMost
            };

            if (f.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            this.SectionIndex = f.SelectedIndex;

            lblColumnSection.Text = SectionIFactory.Items[SectionIndex].Name;

            txt_sec_bf.Text = SectionIFactory.Items[SectionIndex].bf.ToString("");
            txt_sec_d.Text = SectionIFactory.Items[SectionIndex].h.ToString("");

            IsFileChanged = true;

            RunDesign();
        }

        private void GlobalTab_CheckedChanged(object sender, EventArgs e)
        {
            IsFileChanged = true;
            rtbResult.Clear();

            if (IsRealTimeDesignEnable)
            {
                RunDesign();
            }
        }

        private void GeometryTab(object sender, EventArgs e)
        {
            try
            {
                PedestalTab(this, e);

                IsFileChanged = true;
                rtbResult.Clear();

                if (IsRealTimeDesignEnable)
                {
                    RunDesign();
                }
            }
            catch
            {
                ;
            }
        }

        private void MaterialTab(object sender, EventArgs e)
        {
            try
            {
                IsFileChanged = true;
                rtbResult.Clear();

                if (IsRealTimeDesignEnable)
                {
                    RunDesign();
                }
            }
            catch
            {
                ;
            }
        }

        private void StiffenerTab(object sender, EventArgs e)
        {
            if (sender is RadioButton radioButton)
            {
                if (!radioButton.Checked)
                {
                    return;
                }
            }

            try
            {
                txt_hs.Enabled = !rdoStiffnerNone.Checked;

                IsFileChanged = true;
                rtbResult.Clear();

                if (IsRealTimeDesignEnable)
                {
                    RunDesign();
                }
            }
            catch
            {
                ;
            }
        }

        private void AnchorBolts(object sender, EventArgs e)
        {
            txtWeldSizeShearKey.Enabled = rdoShearByShearKey.Checked;

            try
            {
                var nbN = Convert.ToInt32(nudBolts_nN.Value);
                var nbB = Convert.ToInt32(nudBolts_nB.Value);
                var Bolt = AnchorBoltFactory.Items[cboBolts.SelectedIndex];

                var threadExcluded = chkThreadeExcluded.Checked;
                var groutPad = chkBuiltUpGroutPad.Checked;

                var n = 2 * (nbN + (nbB - 2));
                lblBoltArea.Text = $@"{n * Bolt.Ase / 100:F2} cm²";

                IsFileChanged = true;
                rtbResult.Clear();

                if (IsRealTimeDesignEnable)
                {
                    RunDesign();
                }
            }
            catch
            {
                ;
            }
        }

        private void PedestalTab(object sender, EventArgs e)
        {
            try
            {
                IsFileChanged = true;
                rtbResult.Clear();

                var nrN = Convert.ToInt32(nud_nrN.Value);
                var nrB = Convert.ToInt32(nud_nrB.Value);

                var dr = Convert.ToDouble(cbo_dr.SelectedItem.ToString()) / 10;

                var drs = Convert.ToDouble(cbo_drs.SelectedItem.ToString()) / 10;

                var Np = Convert.ToDouble(txt_Np.Text);
                var Bp = Convert.ToDouble(txt_Bp.Text);

                var clearCover = Convert.ToDouble(txtClearCover.Text);

                var cover = clearCover + dr / 2 + drs;

                var n = 2 * (nrN + (nrB - 2));
                var As = n * Math.PI * Math.Pow(dr, 2) / 4;

                lblRebarArea.Text = As.ToString("0.00") + " cm² (" + (As / (Np * Bp)).ToString("0.00%") + ")";

                lblRebarDistX.Text = ((Np - 2 * cover) / (nrN - 1)).ToString("0.0#") + " cm";
                lblRebarDistY.Text = ((Bp - 2 * cover) / (nrB - 1)).ToString("0.0#") + " cm";
            }
            catch
            {
                lblRebarArea.Text = string.Empty;

                lblRebarDistX.Text = string.Empty;
                lblRebarDistY.Text = string.Empty;
            }

            try
            {
                if (IsRealTimeDesignEnable)
                {
                    RunDesign();
                }
            }
            catch
            {
                ;
            }
        }

        private void rdoShearKeyPipe_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoShearKeyPipe.Checked)
            {
                cboShearKeyPipe.Enabled = true;
                cboShearKeyWideFlange.Enabled = false;
                txtOutsideLength.Enabled = false;
                txtFlangeThickness.Enabled = false;
            }
            else if (rdoShearKeyWideFlange.Checked)
            {
                cboShearKeyPipe.Enabled = false;
                cboShearKeyWideFlange.Enabled = true;
                txtOutsideLength.Enabled = false;
                txtFlangeThickness.Enabled = false;
            }
            else if (rdoShearKeyTube.Checked)
            {
                cboShearKeyPipe.Enabled = false;
                cboShearKeyWideFlange.Enabled = false;
                txtOutsideLength.Enabled = true;
                txtFlangeThickness.Enabled = true;
            }

            IsFileChanged = true;
            rtbResult.Clear();

            if (IsRealTimeDesignEnable)
            {
                RunDesign();
            }
        }

        private void cboWeldCheck_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sender is RadioButton {Checked: false})
            {
                return;
            }

            cboWeldCheck.Enabled = rdoWeldFilletWeld.Checked;
            txtWeldSizeBasePlate.Enabled = rdoWeldFilletWeld.Checked;
            txtWeldSizeShearKey.Enabled = rdoWeldFilletWeld.Checked;
            txt_fuw.Enabled = rdoWeldFilletWeld.Checked;

            RunDesign();
        }

        private void dgvLoadCombo_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            IsAvailable = false;
            IsFileChanged = true;
            rtbResult.Clear();
        }

        private void dgvLoadCombo_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == colVu.Index || e.ColumnIndex == colMu.Index)
                {
                    var Num = dgvLoadCombo.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                    if (double.TryParse(Num, out var x))
                    {
                        if (x <= 0)
                        {
                            dgvLoadCombo.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = dgvLoadCombo.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Replace("-", "");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid value!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        dgvLoadCombo.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0;
                    }
                }

                IsFileChanged = true;
                rtbResult.Clear();

                IsAvailable = true;
            }
            catch
            {
                ;
            }

            if (IsRealTimeDesignEnable)
            {
                RunDesign();
            }
        }

        private void dgvLoadCombo_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            ReorderRows();

            IsFileChanged = true;
            rtbResult.Clear();

            if (IsRealTimeDesignEnable)
            {
                RunDesign();
            }
        }

        private void dgvLoadCombo_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            ReorderRows();

            IsFileChanged = true;
            rtbResult.Clear();

            if (IsRealTimeDesignEnable)
            {
                RunDesign();
            }
        }

        private void dgvLoadCombo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void TabControlMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            BasePlateInput basePlateInput;
            IList<BasePlateLoad> LoadsList;
            try
            {
                basePlateInput = GetInputData(out _, out _);
                DoDraw(basePlateInput);

            }
            catch (Exception ex)
            {
                rtbResult.ForeColor = Color.Red;
                rtbResult.Text = ex.Message;

                return;
            }
        }

        #endregion

        #region Helper

        private void SetTitle()
        {
            var version = Assembly.GetEntryAssembly().GetName().Version;
            Text = Application.ProductName + " " + version.Major + '.' + version.Minor + '.' + version.Build + " - " + Path.GetFileName(projectFileName);
        }

        private void ReorderRows()
        {
            if (dgvLoadCombo.RowCount == 0)
            {
                return;
            }

            for (var i = 0; i < dgvLoadCombo.RowCount; i++)
            {
                dgvLoadCombo.Rows[i].Cells[colRow.Index].Value = i + 1;
            }
        }

        private void LoadDefaults()
        {
            //input.Sec = Sections_IWideFlnage.Section[SectionIndex];

            cboBolts.SelectedIndex = 6;

            cbo_dr.SelectedIndex = 8;
            cbo_drs.SelectedIndex = 2;

            cboShearKeyPipe.SelectedIndex = 3;
            cboFrictionCoeff.SelectedIndex = 0;
            cboShearKeyWideFlange.SelectedIndex = 0;
            rdoShearKeyPipe.Checked = true;
            rdoShearByAnchorBolt.Checked = true;

            dgvLoadCombo.Rows.Add(1, "Combo01", 25, 32, 0);
            dgvLoadCombo.Rows.Add(2, "Combo02", 65, 0, 0);
            dgvLoadCombo.Rows.Add(3, "Combo03", -90, 6, 0);
            dgvLoadCombo.Rows.Add(4, "Combo04", 0, 67, 0);

            lblColumnSection.Text = SectionIFactory.Items[SectionIndex].Name;
            
            txt_sec_bf.Text = SectionIFactory.Items[SectionIndex].bf.ToString("");
            txt_sec_d.Text = SectionIFactory.Items[SectionIndex].h.ToString("");

            cboWeldCheck.SelectedIndex = 1;

            TabControlMain.SelectedTab = TabPageGlobal;
            rdoDesignMethodASCE7_LRFD.Checked = true;

            RealTimeDesignToolStripMenuItem.Checked = true;

            SetTitle();
            IsFileChanged = false;

            IsLoaded = true;

            txtEngineer.Text = Environment.UserName.Replace(".", " ");
            //.ToUpper()

            IsAvailable = true;
        }

        private BasePlateInput GetInputData(out string[] Errors, out string[] Warnings)
        {
            var warningList = new List<string>();
            var errorList = new List<string>();

            if (!rdoDesignMethodASCE7_LRFD.Checked && !rdoDesignMethodASCE7_ASD.Checked)
            {
                throw new Exception("Please Select Design Method!");
            }
            
            //Global Tab
            var pressureUnit = PressureUnit.NewtonPerSquareMillimeter;
            var lengthUnit = LengthUnit.Millimeter;

            // Material Tab
            var fc = 0.0;
            if (double.TryParse(txt_fc.Text, out var x) && x is > 200 and < 800)
            {
                fc = Pressure
                    .From(x, PressureUnit.KilogramForcePerSquareCentimeter)
                    .As(pressureUnit);
            }
            else
            {
                errorList.Add($"\'{txt_fc.Text}' is illegal value for parameter 'Concrete Strength, f'c'");
            }

            var fyr = 0.0;
            if (double.TryParse(txt_fyr.Text, out x) && x is > 2000 and < 5200)
            {
                fyr = Pressure
                    .From(x, PressureUnit.KilogramForcePerSquareCentimeter)
                    .As(pressureUnit);
            }
            else
            {
                errorList.Add($"'{txt_fyr.Text}' is illegal value for parameter 'Longitudinal Rebars Yield Strength, Fyb'");
            }

            var fyrs = 0.0;
            if (double.TryParse(txt_fyrs.Text, out x) && x is > 2000 and < 5200)
            {
               fyrs = Pressure
                    .From(x, PressureUnit.KilogramForcePerSquareCentimeter)
                    .As(pressureUnit);
            }
            else
            {
                errorList.Add("\'" + txt_fyrs.Text + "\' is illegal value for parameter \'Longitudinal Rebars Yield Strength, Fyb\'");
            }

            var fyp = 0.0;
            if (double.TryParse(txt_fyp.Text, out x) && x is > 2000 and < 4000)
            {
                fyp = Pressure
                    .From(x, PressureUnit.KilogramForcePerSquareCentimeter)
                    .As(pressureUnit);
            }
            else
            {
                errorList.Add("\'" + txt_fyp.Text + "\' is illegal value for parameter \'Yield Strength, Fyp\'");
            }

            var Es = 0.0;
            if (double.TryParse(txt_Es.Text, out x) && x is > 2000000 and < 2500000)
            {
               Es = EngineeringUnits
                    .Pressure
                    .From(x, PressureUnit.KilogramForcePerSquareCentimeter)
                    .As(pressureUnit);
            }
            else
            {
                errorList.Add("\'" + txt_Es.Text + "\' is illegal value for parameter \'Modulus of Elasticity, Es\'");
            }

            var fyc = 0.0;
            if (double.TryParse(txt_fyc.Text, out x) && x is > 2000 and < 4000)
            {
               fyc = Pressure
                    .From(x, PressureUnit.KilogramForcePerSquareCentimeter)
                    .As(pressureUnit);
            }
            else
            {
                errorList.Add("\'" + txt_fyc.Text + "\' is illegal value for parameter \'Steel Strength, Fyc\'");
            }

            var fyb = 0.0;
            if (double.TryParse(txt_fyb.Text, out x) && x is > 1000 and < 10000)
            {
               fyb = Pressure
                    .From(x, PressureUnit.KilogramForcePerSquareCentimeter)
                    .As(pressureUnit);
            }
            else
            {
                errorList.Add($"\'{txt_fyb.Text}' is illegal value for parameter 'Yield Strength, {nameof(fyb)}'");
            }

            var fub = 0.0;
            if (double.TryParse(txt_fub.Text, out x) && x is > 2000 and < 15000)
            {
               fub = Pressure
                    .From(x, PressureUnit.KilogramForcePerSquareCentimeter)
                    .As(pressureUnit);
            }
            else
            {
                errorList.Add("\'" + txt_fub.Text + "\' is illegal value for parameter \'Ultimate Strength, Fua\'");
            }


            //Geometry Tab
           var Sec = SectionIFactory.Items[SectionIndex];
           var AnalysisType = PressureDistribution.Rectangular;

           var N = 0.0;
            if (double.TryParse(txt_N.Text, out x) && x > 0)
            {
               N = Length
                    .From(x, LengthUnit.Centimeter)
                    .As(lengthUnit);
            }
            else
            {
               N = -1;
            }

            var B = 0.0;
            if (double.TryParse(txt_B.Text, out x) && x > 0)
            {
               B = Length
                    .From(x, LengthUnit.Centimeter)
                    .As(lengthUnit);
            }
            else
            {
               B = -1;
            }

            var Np = 0.0;
            if (double.TryParse(txt_Np.Text, out x) && x > 0)
            {
               Np = Length
                    .From(x, LengthUnit.Centimeter)
                    .As(lengthUnit);
            }
            else
            {
               Np = -1;
            }

            var Bp = 0.0;
            if (double.TryParse(txt_Bp.Text, out x) && x > 0)
            {
               Bp = Length
                    .From(x, LengthUnit.Centimeter)
                    .As(lengthUnit);
            }
            else
            {
               Bp = -1;
            }

            var N_BPecc = double.TryParse(txt_N_BPecc.Text, out x)
                ? Length
                    .From(x, LengthUnit.Centimeter)
                    .As(lengthUnit)
                : double.MaxValue;

           var B_BPecc = double.TryParse(txt_B_BPecc.Text, out x)
                ? Length
                    .From(x, LengthUnit.Centimeter)
                    .As(lengthUnit)
                : double.MaxValue;

           var N_Cecc = double.TryParse(txt_N_Cecc.Text, out x)
                ? Length
                    .From(x, LengthUnit.Centimeter)
                    .As(lengthUnit)
                : double.MaxValue;

           var B_Cecc = double.TryParse(txt_B_Cecc.Text, out x)
                ? Length
                    .From(x, LengthUnit.Centimeter)
                    .As(lengthUnit)
                : double.MaxValue;

           var a_N = double.TryParse(txt_aN.Text, out x)
                ? Length
                    .From(x, LengthUnit.Centimeter)
                    .As(lengthUnit)
                : double.MaxValue;

           var a_B = double.TryParse(txt_aB.Text, out x)
                ? Length
                    .From(x, LengthUnit.Centimeter)
                    .As(lengthUnit)
                : double.MaxValue;

           var StiffnerType = 0;
            if (rdoStiffnerNone.Checked)
            {
               StiffnerType = 0;
            }
            else if (rdoStiffnerType1.Checked)
            {
               StiffnerType = 1;
            }
            else if (rdoStiffnerType2.Checked)
            {
               StiffnerType = 2;
            }
            else if (rdoStiffnerType3.Checked)
            {
               StiffnerType = 3;
            }

            var hs = 0.0;
            if (double.TryParse(txt_hs.Text, out x) && x > 0)
            {
                hs = Length
                    .From(x, LengthUnit.Centimeter)
                    .As(lengthUnit);
            }
            else
            {
                errorList.Add("\'" + txt_hs.Text + "\' is illegal value for parameter \'Shear key height, hs\'");
            }
            
            if (rdoStiffnerNone.Checked)
            {
               StiffnerType = 0;
               hs = 0.0;
            }
            else if (rdoStiffnerType1.Checked)
            {
               StiffnerType = 1;
            }
            else if (rdoStiffnerType2.Checked)
            {
               StiffnerType = 2;
            }
            else if (rdoStiffnerType3.Checked)
            {
               StiffnerType = 3;
            }

            //Geometry (AnchorBolt)
           var nbN = Convert.ToInt32(nudBolts_nN.Value);
           var nbB = Convert.ToInt32(nudBolts_nB.Value);
           var Bolt = AnchorBoltFactory.Items[cboBolts.SelectedIndex];
           var GroutPad = chkBuiltUpGroutPad.Checked;
           var ThreadeExcluded = chkThreadeExcluded.Checked;

           var GroutThickness = 0.0;
            if (double.TryParse(txtGroutThickness.Text, out x))
            {
               GroutThickness = Length
                   .From(x, LengthUnit.Centimeter)
                   .As(lengthUnit);
            }
            else
            {
                errorList.Add("Grout Thickness is not valid!");
            }

            //Addition Tab
            if (rdoStiffnerNone.Checked)
            {
               hs = 0;
            }
            else
            {
                if (double.TryParse(txt_hs.Text, out x) && x > 0)
                {
                   hs = Length
                        .From(x, LengthUnit.Centimeter)
                        .As(lengthUnit);
                }
                else
                {
                    errorList.Add("Stiffener height not valid!");
                }
            }

            //Pedestal Tab
            var Hp = 0.0;
            if (double.TryParse(txt_Hp.Text, out x))
            {
               Hp = Length
                    .From(x, LengthUnit.Centimeter)
                    .As(lengthUnit);
            }
            else
            {
                errorList.Add("Pedestal Height is not valid!");
            }

            var nrN = Convert.ToInt32(nud_nrN.Value);
            var nrB = Convert.ToInt32(nud_nrB.Value);
            var dr = Convert.ToDouble(cbo_dr.SelectedItem.ToString());

            var drs = Convert.ToDouble(cbo_drs.SelectedItem.ToString());
            var nrS = Convert.ToInt32(nud_nrs.Value);

            var rsS = 0.0;
            if (double.TryParse(txt_rsS.Text, out x))
            {
               rsS = Length
                    .From(x, LengthUnit.Centimeter)
                    .As(lengthUnit);
            }
            else
            {
                errorList.Add("Transverse Bar Spacing is not valid!");
            }

            var ClearCover = 0.0;
            if (double.TryParse(txtClearCover.Text, out x))
            {
               ClearCover = Length
                    .From(x, LengthUnit.Centimeter)
                    .As(lengthUnit);
            }
            else
            {
                errorList.Add("Clear Cover is not valid!");
            }

            var ShearResistance = Base_Plate_Engine.Design.ShearResistance.ShearKey;
            ISection ShearKeySection = SectionIFactory.Items[cboShearKeyWideFlange.SelectedIndex];
            var ShearKeyHeight = 0.0;
            var ShearKeyOrientation = 0;
            if (rdoShearByShearKey.Checked)
            {
               ShearResistance = ShearResistance.ShearKey;
                if (rdoShearKeyPipe.Checked)
                {
                   ShearKeySection = SectionPipeFactory.Items[cboShearKeyPipe.SelectedIndex];
                }
                else if (rdoShearKeyWideFlange.Checked)
                {
                   ShearKeySection = SectionIFactory.Items[cboShearKeyWideFlange.SelectedIndex];
                    if (rdoShearKeyWideFlangeMajor.Checked)
                    {
                       ShearKeyOrientation = 0;
                    }
                    else if (rdoShearKeyWideFlangeMinor.Checked)
                    {
                       ShearKeyOrientation = 1;
                    }
                }
                else if (rdoShearKeyTube.Checked)
                {
                    try
                    {
                        if (!double.TryParse(txtOutsideLength.Text, out var h))
                        {
                            errorList.Add("");
                        }
                        if (!double.TryParse(txtOutsideLength.Text, out var bf))
                        {
                            errorList.Add("");
                        }
                        if (!double.TryParse(txtFlangeThickness.Text, out var tf))
                        {
                            errorList.Add("");
                        }
                        if (!double.TryParse(txtFlangeThickness.Text, out var tw))
                        {
                            errorList.Add("");
                        }

                        var name = $"Box{h}X{tw}-{bf}X{tw}";

                        var tube = SectionTube.Create("ShearKey", (float)h, (float)bf, (float)tf, (float)tw);

                        if (Convert.ToDouble(tube.h) <= 0 || Convert.ToDouble(tube.tf) <= 0)
                        {
                            errorList.Add("Shear Properties are not valid!");
                        }

                       ShearKeySection = tube;
                    }
                    catch
                    {
                        errorList.Add("Shear Properties are not valid!");
                    }
                }

                if (double.TryParse(txtShearKeyHeight.Text, out x))
                {
                   ShearKeyHeight = Length
                        .From(x, LengthUnit.Centimeter)
                        .As(lengthUnit);
                }
                else
                {
                    errorList.Add("Shear Key Height is not valid!");
                }

                if (GroutThickness >=ShearKeyHeight)
                {
                    errorList.Add("Shear key height must be grater than grout thickness!");
                }
            }
            else if (rdoShearByAnchorBolt.Checked)
            {
               ShearResistance = ShearResistance.AnchorBolt;
            }

            //Welding
            var WeldType = Base_Plate_Engine.Design.WeldType.CJP;
            var Betta_Weld = 0.0;
            var Fuw = 0.0;
            var WeldSzie_BasePlate = 0.0;
            var WeldSize_ShearKey = 0.0;
            if (rdoWeldCJP.Checked)
            {
               WeldType = WeldType.CJP;
            }
            else if (rdoWeldFilletWeld.Checked)
            {
               WeldType = WeldType.Fillet;

               Betta_Weld = Convert.ToDouble(cboWeldCheck.SelectedItem.ToString());
               Fuw = Convert.ToDouble(txt_fuw.Text);

               WeldSzie_BasePlate = Convert.ToDouble(txtWeldSizeBasePlate.Text) / 10.0;
               WeldSize_ShearKey = Convert.ToDouble(txtWeldSizeShearKey.Text) / 10.0;
            }
            else
            {
                errorList.Add("Please select welding type!");
            }

            if (rdoStiffnerType2.Checked || rdoStiffnerType3.Checked)
            {
                errorList.Add("Type 2 and Type 3 are not applicable yet!!");
            }

            var designMethod = rdoDesignMethodASCE7_LRFD.Checked
                ? DesignMethod.ASCE7_LRFD
                : DesignMethod.ASCE7_ASD;

            var basePlateDesign = BasePlateDesign.AISC360_10;
            var anchorBoltAndPedestalDesign = AnchorBoltAndPedestalDesignMethod.ACI318_14;

            var Fnw_BP = 0.0;
            var Fnw_SK = 0.0;

            var input = new BasePlateInput(
                designMethod: designMethod,
                basePlateDesign: basePlateDesign,
                anchorBoltAndPedestalDesign: anchorBoltAndPedestalDesign,
                analysisType: AnalysisType,
                stiffnerType: StiffnerType,
                shearResistance: ShearResistance,
                weldType: WeldType,
                shearKeySection: ShearKeySection,
                sec: Sec,
                anchorBolt: Bolt,
                N: N,
                B: B,
                Hp: Hp,
                Np: Np,
                Bp: Bp,
                N_BPecc: N_BPecc,
                B_BPecc: B_BPecc,
                N_Cecc: N_Cecc,
                B_Cecc: B_Cecc,
                a_N: a_N,
                a_B: a_B,
                hs: hs,
                clearCover: ClearCover,
                dr: dr,
                drs: drs,
                rsS: rsS,
                nbN: nbN,
                nbB: nbB,
                nrN: nrN,
                nrB: nrB,
                nrS: nrS,
                fnwBp: Fnw_BP,
                fnwSk: Fnw_SK,
                fuw: Fuw,
                weldSzieBasePlate: WeldSzie_BasePlate,
                weldSizeShearKey: WeldSize_ShearKey,
                bettaWeld: Betta_Weld,
                groutPad: GroutPad,
                threadeExcluded: ThreadeExcluded,
                shearKeyOrientation: ShearKeyOrientation,
                shearKeyHeight: ShearKeyHeight,
                groutThickness: GroutThickness,
                fc: fc,
                fyp: fyp,
                fyc: fyc,
                es: Es,
                fub: fub,
                fyb: fyb,
                fyr: fyr,
                fyrs: fyrs)
            {
                // Project Tab
                CompanyName = txtCompany.Text,
                ProjectName = txtProject.Text,
                EngineerName = txtEngineer.Text,
                Description = txtDescription.Text,
                Notes = txtNotes.Text
            };
            
            Warnings = warningList.ToArray();
            Errors = errorList.ToArray();

            return input;
        }

        private IList<BasePlateLoad> GetLoads(out string[] Errors, out string[] Warnings)
        {
            var forceUnit = ForceUnit.Newton;
            var torqueUnit = TorqueUnit.NewtonMillimeter;

            var warningList = new List<string>();
            var errorList = new List<string>();

            var loadsList = new List<BasePlateLoad>();

            for (var i = 0; i < dgvLoadCombo.RowCount - 1; i++)
            {
                if (dgvLoadCombo.Rows[i].Cells[colLoadCombination.Index].Value != null)
                {
                    if (double.TryParse(dgvLoadCombo.Rows[i].Cells[colPu.Index].Value.ToString(), out var pu) && double.TryParse(dgvLoadCombo.Rows[i].Cells[colVu.Index].Value.ToString(), out var vu) && double.TryParse(dgvLoadCombo.Rows[i].Cells[colMu.Index].Value.ToString(), out var mu))
                    {
                        var Pu = Force
                            .From(pu, ForceUnit.TonneForce)
                            .As(forceUnit);

                        var Vux = Force
                            .From(Math.Abs(vu), ForceUnit.TonneForce)
                            .As(forceUnit);

                        var Muy = Torque
                            .From(Math.Abs(mu), TorqueUnit.TonneForceMeter)
                            .As(torqueUnit);

                        var load = new BasePlateLoad
                        (
                            Name = dgvLoadCombo.Rows[i].Cells[colLoadCombination.Index].Value.ToString(),
                            Pu,
                            Vux,
                            Muy
                        );

                        loadsList.Add(load);
                    }
                    else
                    {
                        errorList.Add("Editing load combinations ...");
                    }
                }
                else
                {
                    errorList.Add("Editing load combinations ...");
                }
            }

            if (loadsList.Count == 0)
            {
                errorList.Add("Editing load combinations ...");
            }

            Errors = errorList.ToArray();
            Warnings = warningList.ToArray();
            return loadsList;
        }

        private void ErrorCheck(BasePlateInput input, IList<BasePlateLoad> LoadsList, out string[] Errors, out string[] Warnings)
        {
            //Error checking
            var warningList = new List<string>();
            var errorList = new List<string>();

            if (input.StiffnerType > 0)
            {
                errorList.AddRange(from t in LoadsList where t.Muy != 0 select "Moment with Stiffener can't be considers!!");
            }

            var f_N = input.N - 2 * input.a_N;
            var f_B = input.B - 2 * input.a_B;

            var N_Bolt = (input.N - 2 * input.a_N) / (input.nbB - 1);
            var B_Bolt = (input.B - 2 * input.a_B) / (input.nbN - 1);

            if (input.N < input.Sec.h || input.B < input.Sec.bf)
            {
                errorList.Add("Base plate dimensions should be grater than column.");
            }

            // Dim n As Integer = 2 * (Bp.nbN + (Bp.nbB - 2))
            // lblBoltArea.Text = (n * Bp.Bolt.Ase).ToString("0.00") && " cm²"

            if (input.nb * input.AnchorBolt.Ase * input.fub > 2 * (input.nrB + input.nrN - 2) * (Math.PI * Math.Pow(input.dr, 2) / 4) * input.fyr)
            {
                warningList.Add("Rebar area is not adequate for anchor bolts");
            }

            if (input.a_N < 2 * input.AnchorBolt.da || input.a_B < 2 * input.AnchorBolt.da)
            {
                warningList.Add("Anchor bolts should have min. distance 2d frm B.P. edge");
            }

            if (input.Np < input.N || input.Bp < input.B)
            {
                errorList.Add("Pedestal dimensions should be grater than base plate.");
            }

            if (input.Np < f_N + 12 * input.AnchorBolt.da || input.Bp < f_B + 12 * input.AnchorBolt.da)
            {
                warningList.Add("Pedestal edge should have minimum distance 6d from bolts.");
            }

            if (N_Bolt < 4 * input.AnchorBolt.da || B_Bolt < 4 * input.AnchorBolt.da)
            {
                warningList.Add("Anchor Bolt should have minimum distance 4d from each other.");
            }

            var _WarningHappened = false;
            if (!_WarningHappened && input.N_BPecc + (input.Np - input.N) / 2 + input.a_N - input.AnchorBolt.W / 2 - (input.Cover + input.dr / 2) <= 0)
            {
                warningList.Add("Bolts plate cap conflict with main rebars");
                _WarningHappened = true;
            }
            else if (!_WarningHappened && input.N_BPecc + (input.Np - input.N) / 2 + input.N - input.a_N + input.AnchorBolt.W / 2 - (input.Np - input.Cover - input.dr / 2) >= 0)
            {
                warningList.Add("Bolts plate cap conflict with main rebars");
                _WarningHappened = true;
            }

            if (!_WarningHappened && input.B_BPecc + (input.Bp - input.B) / 2 + input.a_B - input.AnchorBolt.W / 2 - (input.Cover + input.dr / 2) <= 0)
            {
                warningList.Add("Bolts plate cap conflict with main rebars");
                _WarningHappened = true;
            }
            else if (!_WarningHappened && input.B_BPecc + (input.Bp - input.B) / 2 + input.B - input.a_B + input.AnchorBolt.W / 2 - (input.Bp - input.Cover - input.dr / 2) >= 0)
            {
                warningList.Add("Bolts plate cap conflict with main rebars");
                _WarningHappened = true;
            }
            
            //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

            if (Math.Abs(input.N_BPecc) > Math.Abs((input.Np - input.N) / 2) || Math.Abs(input.B_BPecc) > Math.Abs((input.Bp - input.B) / 2))
            {
                errorList.Add("Base plate is out of pedestal region!");
            }

            Errors = errorList.ToArray();
            Warnings = warningList.ToArray();
        }

        private void RunDesign()
        {
            string[] warnings;
            string[] errors;

            DesignDetailsToolStripMenuItem.Enabled = false;
            InteractiveCurveToolStripMenuItem.Enabled = false;
            sendToAutoCADToolStripMenuItem.Enabled = false;
            CalculationSheetToolStripMenuItem.Enabled = false;

            rtbResult.Clear();
            rtbResult.ForeColor = Color.Black;

            if (!IsAvailable)
            {
                return;
            }

            BasePlateInput basePlateInput;
            IList<BasePlateLoad> LoadsList;
            try
            {
                basePlateInput = GetInputData(out var errors1, out var warnings1);
                LoadsList = GetLoads(out var errors2, out var warnings2);
                ErrorCheck(basePlateInput, LoadsList, out var errors3, out var warnings3);
                DoDraw(basePlateInput);

                errors = errors1.Union(errors2).Union(errors3).ToArray();
                warnings = warnings1.Union(warnings2).Union(warnings3).ToArray();
            }
            catch (Exception ex)
            {
                rtbResult.ForeColor = Color.Red;
                rtbResult.Text = ex.Message;

                return;
            }

            if (errors.Length > 0)
            {
                var report = new StringBuilder();
                foreach (var error in errors)
                {
                    report.AppendLine(error);
                }

                rtbResult.ForeColor = Color.Red;
                rtbResult.Text = report.ToString();

                return;
            }

            //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            var columnBase = new ColumnBase();
            columnBase.Design(basePlateInput, LoadsList, out designResults);
            designResult = DesignResult.GetCritical(designResults);

            if (designResult.Succeed)
            {
                CreateInputReport(basePlateInput, LoadsList);
                CreateOutputReport(basePlateInput, LoadsList, designResults);
                var shortDesignReport = CreateShortReport(basePlateInput, designResult);

                if (designResult.WarningMessages.Count > 0 || warnings.Length > 0)
                {
                    var warningReport = new StringBuilder();
                    warningReport.Append("Warning");

                    foreach (var warningMessage in designResult.WarningMessages)
                    {
                        warningReport.Append($"\r\n{warningMessage}");
                    }

                    foreach (var warning in warnings)
                    {
                        warningReport.Append($"\r\n{warning}");
                    }

                    rtbResult.Text = $"{shortDesignReport}\r\n{warningReport}";
                }
                else
                {
                    rtbResult.Text = shortDesignReport;
                }

                var regex = new Regex("\\[OK]|\\[NG]|\\bNOT APPLICABLE\\b|\\bAPPLICABLE\\b");
                var matchCollection = regex.Matches(rtbResult.Text);

                foreach (Match match in matchCollection)
                {
                    if (match.Success && match.Value.Length > 0)
                    {
                        rtbResult.SelectionStart = match.Index;
                        rtbResult.SelectionLength = match.Length;

                        switch (match.Value)
                        {
                            case "[OK]":
                                rtbResult.SelectionColor = Color.Green;
                                break;
                            case "[NG]":
                                rtbResult.SelectionColor = Color.Red;
                                break;
                            case "APPLICABLE":
                                rtbResult.SelectionColor = Color.Green;
                                break;
                            case "NOT APPLICABLE":
                                rtbResult.SelectionColor = Color.Red;
                                break;
                        }
                    }
                }

                regex = new Regex("\\bWarning\\b");
                matchCollection = regex.Matches(rtbResult.Text);

                foreach (Match match in matchCollection)
                {
                    if (match.Success && match.Value.Length > 0)
                    {
                        rtbResult.SelectionStart = match.Index;
                        rtbResult.SelectionLength = rtbResult.TextLength - rtbResult.SelectionStart;
                        rtbResult.SelectionColor = Color.Orange;
                    }
                }

                rtbResult.SelectionStart = rtbResult.TextLength;
                rtbResult.SelectionLength = 0;
                rtbResult.ScrollToCaret();

                DesignDetailsToolStripMenuItem.Enabled = true;
                InteractiveCurveToolStripMenuItem.Enabled = true;
                sendToAutoCADToolStripMenuItem.Enabled = true;
                CalculationSheetToolStripMenuItem.Enabled = true;
            }
            else
            {
                var errorReport = new StringBuilder();

                foreach (var errorMessage in designResult.ErrorMessages)
                {
                    errorReport.AppendLine(errorMessage);
                }

                foreach (var warningMessage in designResult.WarningMessages)
                {
                    errorReport.AppendLine(warningMessage);
                }

                rtbResult.Text = errorReport.ToString();
                rtbResult.ForeColor = Color.Red;
                rtbResult.SelectionStart = rtbResult.TextLength;
                rtbResult.ScrollToCaret();
            }
        }

        private static string CreateInputReport(BasePlateInput basePlateInput, IList<BasePlateLoad> LoadsList)
        {
            var report = new StringBuilder();

            report.AppendLine($"  Company Name: {basePlateInput.CompanyName}");
            report.AppendLine($"  Project Name: {basePlateInput.ProjectName}");
            report.AppendLine($" Engineer Name: {basePlateInput.EngineerName}");
            report.AppendLine($"   Description: {basePlateInput.Description}");
            // Dim NoteLines() As String = BP.Notes.Split({vbNewLine}, StringSplitOptions.RemoveEmptyEntries) '.Replace(NewLineString, vbNewLine)

            //strInput &= String.Format("{0,15} {1,10}", "Note:", NoteLines(0)) && vbNewLine
            //For i1 As Integer = 1 To NoteLines.Length - 1
            //    strInput &= String.Format("{0,15}", "") && """" && NoteLines[i1] && """" && vbNewLine
            //Next

            report.AppendLine();

            report.AppendLine("(Column)");
            report.AppendLine($"       Section: {basePlateInput.Sec.Name,10}");
            report.AppendLine($"             d: {basePlateInput.Sec.h,10:N2} mm");
            report.AppendLine($"            bf: {basePlateInput.Sec.bf,10:N2} mm");
            report.AppendLine($"            tf: {basePlateInput.Sec.tf,10:N2} mm");
            report.AppendLine($"            tw: {basePlateInput.Sec.tw,10:N2} mm");

            report.AppendLine();
            report.AppendLine("(Base Plate Dimensions)");
            report.AppendLine($"             N: {basePlateInput.N,10:N0}" + " mm");
            report.AppendLine($"             B: {basePlateInput.B,10:N0}" + " mm");
            report.AppendLine();

            report.AppendLine("(Pedestal Dimensions)");
            report.AppendLine($"            Np: {basePlateInput.Np,10:N0}" + " mm");
            report.AppendLine($"            Bp: {basePlateInput.Bp,10:N0}" + " mm");
            report.AppendLine($"            Hp: {basePlateInput.Hp,10:N0}" + " mm");
            report.AppendLine();

            report.AppendLine("(Base Plate Eccentricity)");
            report.AppendLine($"          Necc: {basePlateInput.N_BPecc,10:N2}" + " mm");
            report.AppendLine($"          Becc: {basePlateInput.B_BPecc,10:N2}" + " mm");
            report.AppendLine();

            report.AppendLine("(Edge Distance)");
            report.AppendLine($"           a_X: {basePlateInput.a_N,10:N2} mm");
            report.AppendLine($"           a_Y: {basePlateInput.a_B,10:N2} mm");
            report.AppendLine();

            report.AppendLine("(Anchor Bolt)");
            report.AppendLine($"          Bolt: {basePlateInput.AnchorBolt.Name,10}");
            report.AppendLine($"  L/R Bolt No.: {basePlateInput.nbN,10:N0}");
            report.AppendLine($"  T/B Bolt No.: {basePlateInput.nbB,10:N0}");

            report.AppendLine();
            report.AppendLine("(Stiffener)");

            report.AppendLine($"          Type: {(basePlateInput.StiffnerType == 0 ? "None" : basePlateInput.StiffnerType.ToString()),10}");

            report.AppendLine("(Pedestal)");
            report.AppendLine($"    Main Rebar: {basePlateInput.dr * 10,10:N0}");
            report.AppendLine($"   L/R Bar No.: {basePlateInput.nrN,10:N0}");
            report.AppendLine($"   T/B Bar No.: {basePlateInput.nrB,10:N0}");
            report.AppendLine($"         Cover: {basePlateInput.ClearCover,10:N0} mm");

            report.AppendLine($" Stirrup Rebar: {basePlateInput.drs * 10,10:N0}");
            report.AppendLine($"   Stirrup Leg: {basePlateInput.nrS,10:N0}");
            report.AppendLine($" Stirrup Dist.: {basePlateInput.rsS,10:N0} mm");

            report.AppendLine();
            report.AppendLine("(Materials)");
            report.AppendLine($"                 fc: {basePlateInput.fc,10:N0} kg/cm²");
            report.AppendLine($"    Main Rebar, fyr: {basePlateInput.fyr,10:N0} kg/cm²");
            report.AppendLine($"      Stirrup, fyrs: {basePlateInput.fyrs,10:N0} kg/cm²");
            report.AppendLine($"    Base Plate, fyp: {basePlateInput.fyp,10:N0} kg/cm²");
            report.AppendLine($"   Anchor Bolt, fyb: {basePlateInput.fyb,10:N0} kg/cm²");
            report.AppendLine($"   Anchor Bolt, fub: {basePlateInput.fub,10:N0} kg/cm²");
            report.AppendLine();

            report.AppendLine("(Loadings)");
            for (var i = 0; i < LoadsList.Count; i++)
            {
                report.AppendLine($"Combo No. \" {i + 1,10} \"");
                report.AppendLine($"            Pu: {LoadsList[i].Pu,10:N0} kg");
                report.AppendLine($"            Vu: {LoadsList[i].Vux,10:N0} kg");
                report.AppendLine($"            Mu: {LoadsList[i].Muy,10:N0} kg.cm");
            }

            report.AppendLine();
            report.AppendLine();

            switch (basePlateInput.DesignMethod)
            {
                case DesignMethod.ASCE7_LRFD:
                    report.AppendLine("Design Method : ASCE7-LRFD");
                    break;
                case DesignMethod.ASCE7_ASD:
                    report.AppendLine("Design Method : ASCE7-ASD");
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            report.AppendLine($"Design Method : {basePlateInput.DesignMethod}");

            return report.ToString();
        }

        private static string CreateOutputReport(BasePlateInput basePlateInput, IList<BasePlateLoad> LoadsList, IReadOnlyList<DesignResult> dcs)
        {
            var strOutput = new StringBuilder();

            strOutput.AppendLine();

            strOutput.AppendLine($"{"+++++  (Design Results)  +++++",0}");
            strOutput.AppendLine();

            strOutput.AppendLine($"{"Fp:",15} {basePlateInput.Fp_max,10:N2}" + " kg/cm²");
            strOutput.AppendLine($"{"Pp:",15} {basePlateInput.Pp_max,10:N2}" + " kg");
            strOutput.AppendLine();

            for (var i = 0; i < LoadsList.Count; i++)
            {
                strOutput.AppendLine($"{"Combo No. " + (i + 1),10}" + " : " + "\"" + LoadsList[i].Name + "\"");
                strOutput.AppendLine($"{"t:",15} {dcs[i].t,10:N2}" + " mm");
                if (basePlateInput.StiffnerType > 0)
                {
                    strOutput.AppendLine($"            ts: {dcs[i].ts,10:N2} cm");
                }

                if (dcs[i].fup > 0)
                {
                    strOutput.AppendLine($"           fup:{dcs[i].fup,11:0.00} kg/cm²");
                }

                strOutput.AppendLine($"            Tu: {dcs[i].Tu,10:N0}" + " kg");
                strOutput.AppendLine($"          Bolt: {dcs[i].BoltRatio,10:N3}");

                if (basePlateInput.ShearResistance == ShearResistance.ShearKey)
                {
                    strOutput.AppendLine($"{"Shear Key:",15} {dcs[i].ShearKeyRatio,10:N3}");
                }

                if (basePlateInput.WeldType == WeldType.Fillet)
                {
                    strOutput.AppendLine($"          Weld: {dcs[i].WeldRatio_SK,10:N3}");
                    if (basePlateInput.ShearResistance == ShearResistance.ShearKey)
                    {
                        strOutput.AppendLine($"          Weld: {dcs[i].WeldRatio_SK,10:N3}");
                    }
                }

                strOutput.AppendLine($"          Weld: {dcs[i].WeldRatio_BP,10:N3}");

                strOutput.AppendLine($"    Ped. Bend.: {dcs[i].PedestalRatio,10:N3}");
                strOutput.AppendLine($"    Ped. Shear: {dcs[i].PedestalShearRatio,10:N3}");
            }

            strOutput.AppendLine();
            strOutput.AppendLine();

            strOutput.AppendLine("--------------------------------------------------------------------");
            strOutput.AppendLine("DDD  EEEE  SS  I   GGG  N     N    RRR   EEEE   SS  U   U L    TTTTT");
            strOutput.AppendLine("D  D E    S  S I  G   G NN    N    R  R  E     S  S U   U L      T  ");
            strOutput.AppendLine("D  D E    S    I G    G N N   N    R  R  E     S    U   U L      T  ");
            strOutput.AppendLine("D  D EEEE  SS  I G      N  N  N    RRR   EEEE   SS  U   U L      T  ");
            strOutput.AppendLine("D  D E       S I G   GG N   N N    R R   E        S U   U L      T  ");
            strOutput.AppendLine("D  D E    S  S I  G   G N    NN    R  R  E     S  S U   U L      T  ");
            strOutput.AppendLine("DDD  EEEE  SS  I   GGG  N     N    R   R EEEE   SS   UUU  LLLLL  T  ");
            strOutput.AppendLine("--------------------------------------------------------------------");
            strOutput.AppendLine();

            strOutput.AppendLine("  Total Summary");

            return strOutput.ToString();
        }

        private static string CreateShortReport(BasePlateInput basePlateInput, DesignResult dc)
        {
            var report = new StringBuilder();
            const string myFormat = "{0,15} {1,10:N3}";

            if (dc.t > 0)
            {
                report.Append(string.Format(myFormat, "t:", $"{dc.t:F2}") + " mm\r\n");
                if (basePlateInput.StiffnerType > 0)
                {
                    report.Append(string.Format(myFormat, "ts:", dc.ts) + " mm\r\n");
                }

                if (dc.BearingRatio > 0)
                {
                    report.Append(string.Format(myFormat, "Bearing Ratio:", dc.BearingRatio) + " [" + (dc.BearingRatio <= 1 ? "OK" : "NG") + "]\r\n");
                }
            }

            report.Append(string.Format(myFormat, "Bolt:", dc.BoltRatio) + " [" + (dc.BoltRatio <= 1 ? "OK" : "NG") + "]\r\n");
            if (basePlateInput.ShearResistance == ShearResistance.ShearKey)
            {
                report.Append(string.Format(myFormat, "Shear Key:", dc.ShearKeyRatio) + " [" + (dc.ShearKeyRatio <= 1 ? "OK" : "NG") + "]\r\n");
            }

            if (basePlateInput.WeldType == WeldType.Fillet)
            {
                report.Append(string.Format(myFormat, "Weld:", dc.WeldRatio_BP) + " [" + (dc.WeldRatio_BP <= 1 ? "OK" : "NG") + "]\r\n");
                if (basePlateInput.ShearResistance == ShearResistance.ShearKey)
                {
                    //ShortDesignDetail.Append(string.Format(MyFormat, "Weld:", dc.WeldRatio_SK) + " [" + (dc.WeldRatio_SK <= 1 ? "OK" : "NG").ToString() + "]" + "\r\n");
                }
            }

            report.Append(string.Format(myFormat, "Ped. Bend.:", dc.PedestalRatio) + " [" + (dc.PedestalRatio <= 1 ? "OK" : "NG") + "]" + "\r\n");
            report.Append(string.Format(myFormat, "Ped. Shear:", dc.PedestalShearRatio) + " [" + (dc.PedestalShearRatio <= 1 ? "OK" : "NG") + "]" + "\r\n");

            if (dc.t <= 80 && dc.BearingRatio <= 1 && dc.BoltRatio <= 1 && dc.ShearKeyRatio <= 1 && dc.PedestalRatio <= 1 && dc.PedestalShearRatio <= 1)
            {
                report.Append(string.Format(myFormat, "Status:", "APPLICABLE"));
            }
            else
            {
                report.Append(string.Format(myFormat, "Status:", "NOT APPLICABLE!"));
            }

            return report.ToString();
        }

        private string ShortenFilePath(string filePath)
        {
            var maxPathLength = 60;
            while (filePath.Length > maxPathLength)
            {
                var parts = filePath.Split(new[] { Path.DirectorySeparatorChar }, StringSplitOptions.RemoveEmptyEntries);
                var partsLength = parts.Length;

                filePath = parts[0] + Path.DirectorySeparatorChar;
                filePath += "..." + Path.DirectorySeparatorChar;
                for (var i = 3; i < partsLength - 1; i++)
                {
                    filePath += parts[i] + Path.DirectorySeparatorChar;
                }

                filePath += parts[partsLength - 1];
            }

            return filePath;
        }

        public void DoDraw(BasePlateInput input)
        {
            var viewCode = (ReferenceEquals(TabControlMain.SelectedTab, TabPagePedestal)) ? 1 : 0;
            viewBox1.DoDraw(input, viewCode);
        }

        //private int SaveProject1(string fileName)
        //{
        //    var rep = new SaveModel()
        //    {
        //        Name = "Mono Base Plate Design",
        //        Creator = "Mojtaba Kaimi",
        //        Date = DateTime.Now,
        //        ProgramVersion = Application.ProductVersion,
        //        CompanyName = txtCompany.Text,
        //        ProjectName = txtProject.Text,
        //        EngineerName = txtEngineer.Text,
        //        Description = txtDescription.Text,
        //        Notes = txtNotes.Text,

        //        Section = Sections_IWideFlnage.Section[SectionIndex],
        //        N = Convert.ToDouble(txt_N.Text),
        //        B = Convert.ToDouble(txt_B.Text),

        //        Np = Convert.ToDouble(txt_Np.Text),
        //        Bp = Convert.ToDouble(txt_Bp.Text),
        //        Hp = Convert.ToDouble(txt_Hp.Text),
        //        Cover = Convert.ToDouble(txtClearCover.Text),

        //        Necc = Convert.ToDouble(txt_N_BPecc.Text),
        //        Becc = Convert.ToDouble(txt_B_BPecc.Text),


        //        a_N = Convert.ToDouble(txt_aN.Text),
        //        a_B = Convert.ToDouble(txt_aB.Text),

        //        l_N = 0,
        //        l_B = 0,

        //        fc = Convert.ToDouble(txt_fc.Text),
        //        fyr = Convert.ToDouble(txt_fyr.Text),
        //        fyrs = Convert.ToDouble(txt_fyrs.Text),
        //        fyp = Convert.ToDouble(txt_fyp.Text),
        //        fyc = Convert.ToDouble(txt_fyc.Text),
        //        fyb = Convert.ToDouble(txt_fyb.Text),
        //        fub = Convert.ToDouble(txt_fub.Text),

        //        nbN = Convert.ToInt32(nudBolts_nN.Value.ToString()),
        //        nbB = Convert.ToInt32(nudBolts_nB.Value.ToString()),
        //        Bolt = cboBolts.SelectedItem.ToString(),
        //        nrN = Convert.ToInt32(nud_nrN.Value.ToString()),
        //        nrB = Convert.ToInt32(nud_nrB.Value.ToString()),
        //        dr = Convert.ToInt32(cbo_dr.SelectedItem.ToString()),
        //        drs = Convert.ToInt32(cbo_drs.SelectedItem.ToString()),
        //        nrs = Convert.ToInt32(nud_nrs.Value.ToString()),
        //        rsS = Convert.ToDouble(txt_rsS.Text),
        //        Stiffener = rdoStiffnerNone.Checked
        //            ? 0
        //            : rdoStiffnerType1.Checked
        //                ? 1
        //                : rdoStiffnerType2.Checked
        //                    ? 2
        //                    : rdoStiffnerType3.Checked
        //                        ? 3
        //                        : 0,
        //        hs = Convert.ToDouble(txt_hs.Text),
        //        //ThreadsExcluded = Convert.ToInt32(chkThreadeExcluded.Checked),
        //        //BuiltUpGroutPad = Convert.ToInt32(chkBuiltUpGroutPad.Checked),
        //        //GroutThickness = Convert.ToDouble(txtGroutThickness.Text),)


        //    };

        //    var report = new StringBuilder();

        //    if (rdoShearByAnchorBolt.Checked)
        //    {
        //        rep.ShearResisting = "Bolts";
        //    }
        //    else if (rdoShearByShearKey.Checked)
        //    {
        //        rep.ShearResisting = "ShearKey";
        //        rep.ShearKeyHeight = txtShearKeyHeight.Text;

        //        if (rdoShearKeyPipe.Checked)
        //        {
        //            rep.ShearKeySection = cboShearKeyPipe.SelectedItem;
        //        }
        //        //else if (rdoShearKeyWideFlange.Checked)
        //        //{
        //        //    rep.ShearKeySection = cboShearKeyPipe.SelectedItem;
        //        //    report.AppendLine(" : WideFlange " + cboShearKeyWideFlange.SelectedItem + " " + (rdoShearKeyWideFlangeMajor.Checked ? "Major" : "Minor"));
        //        //}
        //        //else if (rdoShearKeyTube.Checked)
        //        //{
        //        //    rep.ShearKeySection = cboShearKeyPipe.SelectedItem;
        //        //    report.AppendLine("ShearKeySection : Tube " + txtOutsideLength.Text + " " + txtFlangeThickness.Text);
        //        //}
        //    }

        //    report.AppendLine();
        //    if (rdoWeldCJP.Checked)
        //    {
        //        report.AppendLine("WeldType : " + "CJP");
        //    }
        //    else if (rdoWeldFilletWeld.Checked)
        //    {
        //        report.AppendLine("WeldType : " + "Fillet");
        //        report.AppendLine("WeldUltimateStregth : " + txt_fuw.Text);
        //        report.AppendLine("WeldCheckCoeff : " + cboWeldCheck.SelectedItem);
        //        report.AppendLine("WeldSize : " + txtWeldSizeBasePlate.Text);
        //    }

        //    report.AppendLine();
        //    for (var i = 0; i < dgvLoadCombo.RowCount; i++)
        //    {
        //        if (dgvLoadCombo.Rows[i].Cells[colLoadCombination.Index].Value != null)
        //        {
        //            if (Main.IsNumeric(dgvLoadCombo.Rows[i].Cells[colPu.Index].Value.ToString().Trim()) && Main.IsNumeric(dgvLoadCombo.Rows[i].Cells[colVu.Index].Value.ToString().Trim()) && Main.IsNumeric(dgvLoadCombo.Rows[i].Cells[colMu.Index].Value.ToString().Trim()))
        //            {
        //                report.AppendLine($"Loads : \t{dgvLoadCombo.Rows[i].Cells[colLoadCombination.Index].Value}\t{dgvLoadCombo.Rows[i].Cells[colPu.Index].Value}\t{dgvLoadCombo.Rows[i].Cells[colVu.Index].Value}\t{dgvLoadCombo.Rows[i].Cells[colMu.Index].Value}");
        //            }
        //            else
        //            {
        //                break;
        //            }
        //        }
        //    }

        //    report.AppendLine("");

        //    //strText &= "DesignMethod : " && {"LRFD", "ASD"}(cboDesignMethod.SelectedIndex) && vbNewLine

        //    if (rdoDesignMethodASCE7_LRFD.Checked)
        //    {
        //        report.Append("DesignMethod : ASCE7-2010 LRFD");
        //    }
        //    else if (rdoDesignMethodASCE7_ASD.Checked)
        //    {
        //        report.Append("DesignMethod : ASCE7-2010 ASD");
        //    }
        //    report.AppendLine("");

        //    try
        //    {
        //        File.WriteAllText(fileName, report.ToString());

        //        isChangedFile = false;

        //        return 0;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return 99;
        //    }
        //}

        private int SaveProject(string fileName)
        {
            var report = new StringBuilder();
            report.AppendLine("Mono Base Plate Design");
            report.AppendLine("Mojtaba Kaimi");
            report.AppendLine();

            report.AppendLine("Date : " + DateTime.Now.Date);
            report.AppendLine("Time : " + DateTime.Now.ToLongTimeString());
            report.AppendLine();

            report.AppendLine("ProgramVersion : " + Application.ProductVersion);
            report.AppendLine();

            report.AppendLine("CompanyName : " + txtCompany.Text);
            report.AppendLine("ProjectName : " + txtProject.Text);
            report.AppendLine("EngineerName : " + txtEngineer.Text);
            report.AppendLine("Description : " + txtDescription.Text);
            report.AppendLine("Notes : " + txtNotes.Text.Replace("\r\n", NewLineString));
            report.AppendLine();

            report.AppendLine("SectionName : " + SectionIFactory.Items[SectionIndex].Name);

            report.AppendLine("$BasePlate");
            report.AppendLine("N : " + txt_N.Text);
            report.AppendLine("B : " + txt_B.Text);

            report.AppendLine("$Pedestal");
            report.AppendLine("Np : " + txt_Np.Text);
            report.AppendLine("Bp : " + txt_Bp.Text);
            report.AppendLine("Hp : " + txt_Hp.Text);

            report.AppendLine("Cover : " + txtClearCover.Text);

            report.AppendLine("$BasePlateEccentricity");
            report.AppendLine("Necc : " + txt_N_BPecc.Text);
            report.AppendLine("Becc : " + txt_B_BPecc.Text);

            report.AppendLine("$RodsDistance");
            report.AppendLine("a_N : " + txt_aN.Text);
            report.AppendLine("a_B : " + txt_aB.Text);

            report.AppendLine("$LoadEccentricity");
            report.AppendLine("l_N : " + 0);
            report.AppendLine("l_B : " + 0);

            report.AppendLine("$Material");
            report.AppendLine("fc : " + txt_fc.Text);
            report.AppendLine("fyr : " + txt_fyr.Text);
            report.AppendLine("fyrs : " + txt_fyrs.Text);
            report.AppendLine("fyp : " + txt_fyp.Text);
            report.AppendLine("fyc : " + txt_fyc.Text);
            report.AppendLine("fyb : " + txt_fyb.Text);
            report.AppendLine("fub : " + txt_fub.Text);

            report.AppendLine("");
            report.AppendLine("nbN : " + nudBolts_nN.Value);
            report.AppendLine("nbB : " + nudBolts_nB.Value);
            report.AppendLine("Bolt : " + cboBolts.SelectedItem);

            report.AppendLine("");
            report.AppendLine("nrN : " + nud_nrN.Value);
            report.AppendLine("nrB : " + nud_nrB.Value);
            report.AppendLine("dr : " + cbo_dr.SelectedItem);

            report.AppendLine("");
            report.AppendLine("drs : " + cbo_drs.SelectedItem);
            report.AppendLine("nrs : " + nud_nrs.Value);
            report.AppendLine("rsS : " + txt_rsS.Text);
            report.AppendLine();

            report.AppendLine("Stiffener : " + (rdoStiffnerNone.Checked
                                  ? "0"
                                  : rdoStiffnerType1.Checked
                                      ? "1"
                                      : rdoStiffnerType2.Checked
                                          ? "2"
                                          : rdoStiffnerType3.Checked
                                              ? "3"
                                              : "0"));

            report.AppendLine("hs : " + txt_hs.Text);
            report.AppendLine();

            report.AppendLine("ThreadsExcluded : " + Convert.ToInt32(chkThreadeExcluded.Checked));
            report.AppendLine("BuiltUpGroutPad : " + Convert.ToInt32(chkBuiltUpGroutPad.Checked));
            report.AppendLine();

            report.AppendLine("GroutThickness : " + Convert.ToDouble(txtGroutThickness.Text));
            report.AppendLine();

            if (rdoShearByAnchorBolt.Checked)
            {
                report.AppendLine("ShearResisting : " + "Bolts");
            }
            else if (rdoShearByShearKey.Checked)
            {
                report.AppendLine("ShearResisting : " + "ShearKey");
                report.AppendLine("ShearKeyHeight : " + txtShearKeyHeight.Text);

                if (rdoShearKeyPipe.Checked)
                {
                    report.AppendLine("ShearKeySection : Pipe " + cboShearKeyPipe.SelectedItem);
                }
                else if (rdoShearKeyWideFlange.Checked)
                {
                    report.AppendLine("ShearKeySection : WideFlange " + cboShearKeyWideFlange.SelectedItem + " " + (rdoShearKeyWideFlangeMajor.Checked ? "Major" : "Minor"));
                }
                else if (rdoShearKeyTube.Checked)
                {
                    report.AppendLine("ShearKeySection : Tube " + txtOutsideLength.Text + " " + txtFlangeThickness.Text);
                }
            }

            report.AppendLine();
            if (rdoWeldCJP.Checked)
            {
                report.AppendLine("WeldType : " + "CJP");
            }
            else if (rdoWeldFilletWeld.Checked)
            {
                report.AppendLine("WeldType : " + "Fillet");
                report.AppendLine("WeldUltimateStregth : " + txt_fuw.Text);
                report.AppendLine("WeldCheckCoeff : " + cboWeldCheck.SelectedItem);
                report.AppendLine("WeldSize : " + txtWeldSizeBasePlate.Text);
            }

            report.AppendLine();
            for (var i = 0; i < dgvLoadCombo.RowCount; i++)
            {
                if (dgvLoadCombo.Rows[i].Cells[colLoadCombination.Index].Value != null)
                {
                    if (double.TryParse(dgvLoadCombo.Rows[i].Cells[colPu.Index].Value.ToString().Trim(), out _)
                        && double.TryParse(dgvLoadCombo.Rows[i].Cells[colVu.Index].Value.ToString().Trim(), out _) 
                        && double.TryParse(dgvLoadCombo.Rows[i].Cells[colMu.Index].Value.ToString().Trim(), out _))
                    {
                        report.AppendLine($"Loads : \t{dgvLoadCombo.Rows[i].Cells[colLoadCombination.Index].Value}\t{dgvLoadCombo.Rows[i].Cells[colPu.Index].Value}\t{dgvLoadCombo.Rows[i].Cells[colVu.Index].Value}\t{dgvLoadCombo.Rows[i].Cells[colMu.Index].Value}");
                    }
                    else
                    {
                        break;
                    }
                }
            }

            report.AppendLine("");

            //strText &= "DesignMethod : " && {"LRFD", "ASD"}(cboDesignMethod.SelectedIndex) && vbNewLine

            if (rdoDesignMethodASCE7_LRFD.Checked)
            {
                report.Append("DesignMethod : ASCE7-2010 LRFD");
            }
            else if (rdoDesignMethodASCE7_ASD.Checked)
            {
                report.Append("DesignMethod : ASCE7-2010 ASD");
            }
            report.AppendLine("");

            try
            {
                File.WriteAllText(fileName, report.ToString());

                IsFileChanged = false;

                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 99;
            }
        }
        
        //private int SaveProjectJson(string fileName)
        //{
        //    var bp = new BasePl
        //    {
        //        Version = Application.ProductVersion,
        //        General = new
        //        {
        //            Date = $"{DateTime.Now:yyyy/MM/dd}",
        //            Time = $"{DateTime.Now:hh:mm:ss}"
        //        },
        //        CompanyName = txtCompany.Text,
        //        ProjectName = txtProject.Text,
        //        EngineerName = txtEngineer.Text,
        //        Description = txtDescription.Text,
        //        Notes = txtNotes.Text.Replace("\r\n", NewLineString),

        //        SectionName = SectionIFactory.Items[SectionIndex].Name,

        //        N = double.Parse(txt_N.Text),
        //        B = double.Parse(txt_B.Text),

        //        Np = double.Parse(txt_Np.Text),
        //        Bp = double.Parse(txt_Bp.Text),
        //        Hp = double.Parse(txt_Hp.Text),

        //        Cover = double.Parse(txtClearCover.Text),

        //        Necc = double.Parse(txt_N_BPecc.Text),
        //        Becc = double.Parse(txt_B_BPecc.Text),


        //        //
        //        a_N = double.Parse(txt_aN.Text),
        //        a_B = double.Parse(txt_aB.Text),


        //        l_N = 0,
        //        l_B = 0,

        //        fc = double.Parse(txt_fc.Text),
        //        fyr = double.Parse(txt_fyr.Text),
        //        fyrs = double.Parse(txt_fyrs.Text),
        //        fyp = double.Parse(txt_fyp.Text),
        //        fyc = double.Parse(txt_fyc.Text),
        //        fyb = double.Parse(txt_fyb.Text),
        //        fub = double.Parse(txt_fub.Text),

        //        nbN = (int)nudBolts_nN.Value,
        //        nbB = (int)nudBolts_nB.Value,
        //        Bolt = cboBolts.SelectedItem,

        //        nrN = (int)nud_nrN.Value,
        //        nrB = (int)nud_nrB.Value,
        //        dr = double.Parse(cbo_dr.SelectedItem.ToString()),

        //        drs = double.Parse(cbo_drs.SelectedItem.ToString()),
        //        nrs = (int)(nud_nrs.Value),
        //        rsS = double.Parse(txt_rsS.Text),

        //        Stiffener = (rdoStiffnerNone.Checked
        //            ? 0
        //            : rdoStiffnerType1.Checked
        //                ? 1
        //                : rdoStiffnerType2.Checked
        //                    ? 2
        //                    : rdoStiffnerType3.Checked
        //                        ? 3
        //                        : 0),


        //        hs = double.Parse(txt_hs.Text),
                
        //        ThreadsExcluded = Convert.ToInt32(chkThreadeExcluded.Checked),
        //        BuiltUpGroutPad = Convert.ToInt32(chkBuiltUpGroutPad.Checked),

        //        GroutThickness = Convert.ToDouble(txtGroutThickness.Text),

        //        ShearResisting = new ShearResisting()
        //        {
        //            Type = rdoShearByAnchorBolt.Checked 
        //                ? "Bolts" 
        //                : "ShearKey",
        //            Height = txtShearKeyHeight.Text,
        //            Section = rdoShearKeyPipe.Checked
        //                ? $"Pipe {cboShearKeyPipe.SelectedItem}" 
        //                : rdoShearKeyWideFlange.Checked 
        //                    ? $"WideFlange {cboShearKeyWideFlange.SelectedItem} {(rdoShearKeyWideFlangeMajor.Checked ? "Major" : "Minor")}"
        //                    : $"Tube {txtOutsideLength.Text} {txtFlangeThickness.Text}"
        //        },

        //        Weld = new Weld()
        //        {
        //            Type = rdoWeldCJP.Checked ? "CJP" : "Fillet",
        //            UltimateStrength = txt_fuw.Text,
        //            CheckCoefficient =  cboWeldCheck.SelectedItem.ToString(),
        //            Size = txtWeldSizeBasePlate.Text,
        //        },
                
        //        Loads = new List<Class.BasePlateLoad>(),

        //        DesignMethod = rdoDesignMethodASCE7_LRFD.Checked ? "ASCE7-2010 LRFD" : "ASCE7-2010 ASD",
        //    };

        //    for (var i = 0; i < dgvLoadCombo.RowCount; i++)
        //    {
        //        if (dgvLoadCombo.Rows[i].Cells[colLoadCombination.Index].Value != null)
        //        {
        //            if (double.TryParse(dgvLoadCombo.Rows[i].Cells[colPu.Index].Value.ToString().Trim(), out _) 
        //                && double.TryParse(dgvLoadCombo.Rows[i].Cells[colVu.Index].Value.ToString().Trim(), out _)
        //                && double.TryParse(dgvLoadCombo.Rows[i].Cells[colMu.Index].Value.ToString().Trim(), out _))
        //            {
        //                bp.Loads.Add(new Class.BasePlateLoad()
        //                {
        //                    Name = dgvLoadCombo.Rows[i].Cells[colLoadCombination.Index].Value.ToString(),
        //                    T = double.Parse(dgvLoadCombo.Rows[i].Cells[colPu.Index].Value.ToString()),
        //                    V = double.Parse(dgvLoadCombo.Rows[i].Cells[colVu.Index].Value.ToString()),
        //                    M = double.Parse(dgvLoadCombo.Rows[i].Cells[colMu.Index].Value.ToString()),
        //                });
        //            }
        //            else
        //            {
        //                break;
        //            }
        //        }
        //    }

        //    try
        //    {
        //        File.WriteAllText(fileName, Newtonsoft.Json.JsonConvert.SerializeObject(bp));
        //        IsFileChanged = false;

        //        return 0;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return 99;
        //    }
        //}

        //private int OpenProject(string strFile)
        //{
        //    //var newBp = new ColumnBases();
        //    var newLoads = new List<Loads>();
        //    var newSectionIndex = -1;

        //    var designMethod = DesignMethods.ASCE7_LRFD;
        //    var newBp = new Inputs(designMethod);

        //    string[] lines;
        //    try
        //    {
        //        lines = File.ReadAllLines(strFile);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return 1;
        //    }

        //    for (var i = 0; i < lines.Length; i++)
        //    {
        //        var parts = lines[i].Split(new[] { ":", "," }, StringSplitOptions.RemoveEmptyEntries);

        //        if (parts.Length == 0)
        //        {
        //            continue;
        //        }

        //        for (var j = 0; j < parts.Length; j++)
        //        {
        //            parts[j] = parts[j].Trim();
        //        }

        //        if (i == 0 && parts[0] != "Mono Base Plate Design")
        //        {
        //            MessageBox.Show($@"Can not open file ""{strFile}""", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            return 101;
        //        }

        //        switch (parts[0])
        //        {
        //            case "Mono Base Plate Design":
        //                break;
        //            case "Mojtaba Kaimi":
        //                break;
        //            case "Date":
        //                break;
        //            case "Time":
        //                break;
        //            case "ProgramVersion":
        //                try
        //                {
        //                    var version = Assembly.GetEntryAssembly().GetName().Version;

        //                    var VersionMajor = Convert.ToInt32(parts[1].Split(new[] { "." }, StringSplitOptions.RemoveEmptyEntries)[0]);
        //                    var VersionMinor = Convert.ToInt32(parts[1].Split(new[] { "." }, StringSplitOptions.RemoveEmptyEntries)[1]);

        //                    //if (VersionMajor <= version.Major)
        //                    //{
        //                    //    if (VersionMinor <= version.Minor)
        //                    //    {
        //                    //    }
        //                    //    else
        //                    //    {
        //                    //        MessageBox.Show("This file can not open in this version of program" + "\r\n" + "Please con", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                    //        return 99;
        //                    //    }
        //                    //}
        //                    //else
        //                    //{
        //                    //    MessageBox.Show("", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                    //    return 99;
        //                    //}
        //                }
        //                catch
        //                {
        //                    return 99;
        //                }

        //                break;
        //            case "CompanyName":
        //                newBp.CompanyName = parts[1];
        //                break;
        //            case "ProjectName":
        //                newBp.ProjectName = parts[1];
        //                break;
        //            case "EngineerName":
        //                newBp.EngineerName = parts[1];
        //                break;
        //            case "Description":
        //                newBp.Description = parts[1];
        //                break;
        //            case "Notes":
        //                newBp.Notes = parts[1].Replace(NewLineString, "\r\n");
        //                break;
        //            case "DesignMethod":
        //                switch (parts[1])
        //                {
        //                    case "LRFD":
        //                    case "ASCE7-LRFD":
        //                        designMethod = DesignMethods.ASCE7_LRFD;
        //                        break;
        //                    case "ASD":
        //                    case "ASCE7-ASD":
        //                        designMethod = DesignMethods.ASCE7_ASD;
        //                        break;
        //                }

        //                break;
        //            case "BasePlateDesign":
        //                switch (parts[1])
        //                {
        //                    case "AISC 360-10":
        //                        newBp.BasePlateDesign = BasePlateDesigns.AISC360_10;
        //                        break;
        //                    case "AISC 360-05":
        //                        newBp.BasePlateDesign = BasePlateDesigns.AISC360_05;
        //                        break;
        //                }

        //                break;
        //            case "AnchorBoltAndPedestalDesign":
        //                switch (parts[1])
        //                {
        //                    case "ACI318-14":
        //                        newBp.AnchorBoltAndPedestalDesign = AnchorBoltAndPedestalDesignMethods.ACI318_14;
        //                        break;
        //                    case "ACI318-11":
        //                        newBp.AnchorBoltAndPedestalDesign = AnchorBoltAndPedestalDesignMethods.ACI318_11;
        //                        break;
        //                    case "ACI318-08":
        //                        newBp.AnchorBoltAndPedestalDesign = AnchorBoltAndPedestalDesignMethods.ACI318_08;
        //                        break;
        //                }

        //                break;
        //            case "PressureDistribution":
        //                switch (parts[1])
        //                {
        //                    case "Rectangular":
        //                        newBp.AnalysisType = PressureDistributions.Rectangular;
        //                        break;
        //                    case "Triangular":
        //                        newBp.AnalysisType = PressureDistributions.Triangular;
        //                        break;
        //                }

        //                break;
        //            case "SectionName":
        //                for (var j = 0; j < Sections_IWideFlnage.Section.Count; j++)
        //                {
        //                    if (parts[1] == Sections_IWideFlnage.Section[j].Name)
        //                    {
        //                        newSectionIndex = j;
        //                        break;
        //                    }
        //                }

        //                break;
        //            case "N":
        //                newBp.N = Convert.ToDouble(parts[1]);
        //                break;
        //            case "B":
        //                newBp.B = Convert.ToDouble(parts[1]);
        //                break;
        //            case "Np":
        //                newBp.Np = Convert.ToDouble(parts[1]);
        //                break;
        //            case "Bp":
        //                newBp.Bp = Convert.ToDouble(parts[1]);
        //                break;
        //            case "Hp":
        //                newBp.Hp = Convert.ToDouble(parts[1]);
        //                break;
        //            case "Cover":
        //                newBp.ClearCover = Convert.ToDouble(parts[1]);
        //                break;
        //            case "Necc":
        //                newBp.N_BPecc = Convert.ToDouble(parts[1]);
        //                break;
        //            case "Becc":
        //                newBp.B_BPecc = Convert.ToDouble(parts[1]);
        //                break;
        //            case "a_N":
        //                newBp.a_N = Convert.ToDouble(parts[1]);
        //                break;
        //            case "a_B":
        //                newBp.a_B = Convert.ToDouble(parts[1]);
        //                break;
        //            case "l_N":
        //                break;
        //            //Do Nothing!
        //            case "l_B":
        //                break;
        //            //Do Nothing!
        //            case "LoadEccentricity":
        //                break;
        //            //Need To Be Fixed
        //            case "fc":
        //                newBp.fc = Convert.ToDouble(parts[1]);
        //                break;
        //            case "fyr":
        //                newBp.fyr = Convert.ToDouble(parts[1]);
        //                break;
        //            case "fyrs":
        //                newBp.fyrs = Convert.ToDouble(parts[1]);
        //                break;
        //            case "fyp":
        //                newBp.fyp = Convert.ToDouble(parts[1]);
        //                break;
        //            case "fyc":
        //                newBp.fyc = Convert.ToDouble(parts[1]);
        //                break;
        //            case "fub":
        //                newBp.fub = Convert.ToDouble(parts[1]);
        //                break;
        //            case "fyb":
        //                newBp.fyb = Convert.ToDouble(parts[1]);
        //                break;
        //            case "WeldUltimateStregth":
        //            case "fuw":
        //                newBp.Fuw = Convert.ToDouble(parts[1]);
        //                break;
        //            case "nbN":
        //                newBp.nbN = Convert.ToInt32(parts[1]);
        //                break;
        //            case "nbB":
        //                newBp.nbB = Convert.ToInt32(parts[1]);
        //                break;
        //            case "nrN":
        //                newBp.nrN = Convert.ToInt32(parts[1]);
        //                break;
        //            case "nrB":
        //                newBp.nrB = Convert.ToInt32(parts[1]);
        //                break;
        //            case "Bolt":
        //                for (var j = 0; j < Bolts.Bolt.Count; j++)
        //                {
        //                    if (parts[1] == Bolts.Bolt[j].Name)
        //                    {
        //                        newBp.Bolt = Bolts.Bolt[j];
        //                        break;
        //                    }
        //                }

        //                break;
        //            case "dr":
        //                newBp.dr = Convert.ToInt32(parts[1]);
        //                break;
        //            case "drs":
        //                newBp.drs = Convert.ToInt32(parts[1]);
        //                break;
        //            case "nrs":
        //                newBp.nrS = Convert.ToInt32(parts[1]);
        //                break;
        //            case "rsS":
        //                newBp.rsS = Convert.ToInt32(parts[1]);

        //                break;
        //            case "ThreadsExcluded":
        //                newBp.ThreadeExcluded = Convert.ToBoolean(Convert.ToInt32(parts[1]));
        //                break;
        //            case "BuiltUpGroutPad":
        //                newBp.GroutPad = Convert.ToBoolean(Convert.ToInt32(parts[1]));
        //                break;
        //            case "GroutThickness":
        //                newBp.GroutThickness = Convert.ToDouble(parts[1]);
        //                break;
        //            case "ShearResisting":
        //                switch (parts[1])
        //                {
        //                    case "ShearKey":
        //                        newBp.ShearResistance = ShearResistances.ShearKey;
        //                        break;
        //                    case "Bolts":
        //                        newBp.ShearResistance = ShearResistances.AnchorBolt;
        //                        break;
        //                }

        //                break;
        //            case "ShearKeyHeight":
        //                newBp.ShearKeyHeight = Convert.ToDouble(parts[1]);
        //                break;
        //            case "ShearKeySection":
        //                var Col1 = parts[1].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        //                switch (Col1[0])
        //                {
        //                    case "Pipe":
        //                        newBp.ShearKeySection = Sections_Pipe.Pipe[0];
        //                        for (var j = 0; j < Sections_Pipe.Pipe.Count; j++)
        //                        {
        //                            if (Col1[1] == Sections_Pipe.Pipe[j].Name)
        //                            {
        //                                newBp.ShearKeySection = Sections_Pipe.Pipe[j];
        //                                break;
        //                            }
        //                        }

        //                        break;
        //                    case "WideFlange":
        //                        newBp.ShearKeySection = Sections_IWideFlnage.Section[0];
        //                        for (var j = 0; j < Sections_IWideFlnage.Section.Count; j++)
        //                        {
        //                            if (Col1[1] == Sections_IWideFlnage.Section[j].Name)
        //                            {
        //                                newBp.ShearKeySection = Sections_IWideFlnage.Section[j];
        //                                break;
        //                            }
        //                        }

        //                        newBp.ShearKeyOrientation = Col1[2] == "Major"
        //                            ? 0
        //                            : 1;
        //                        break;
        //                    case "Tube":
        //                        Sections_Tube Tube;

        //                        var name = "Tube";
        //                        var bf = Convert.ToSingle(Col1[1]);
        //                        var h = Convert.ToSingle(Col1[1]);
        //                        var tf = Convert.ToSingle(Col1[2]);
        //                        var tw = Convert.ToSingle(Col1[2]);

        //                        Tube = new Sections_Tube(name, h, bf, tf, tw, AllSections.SectionTypes.UserDefined);

        //                        newBp.ShearKeySection = Tube;
        //                        break;
        //                    default:
        //                        newBp.ShearKeySection = Sections_Pipe.Pipe[0];
        //                        break;
        //                }

        //                break;
        //            case "WeldType":
        //                switch (parts[1])
        //                {
        //                    case "CJP":
        //                        newBp.WeldType = WeldTypes.CJP;
        //                        break;
        //                    case "FilletWeld":
        //                    case "Fillet":
        //                        newBp.WeldType = WeldTypes.Fillet;
        //                        break;
        //                }

        //                break;
        //            case "WeldCheckCoeff":
        //                newBp.Betta_Weld = Convert.ToDouble(parts[1]);
        //                break;
        //            case "WeldSize":
        //                newBp.WeldSzie_BasePlate = Convert.ToDouble(parts[1]);
        //                break;
        //            case "Loads":
        //                var l = new Loads();
        //                parts = parts[1].Trim().Split(new[] { "\t" }, StringSplitOptions.RemoveEmptyEntries);
        //                l.Name = parts[0];
        //                l.Pu = Convert.ToDouble(parts[1]);
        //                l.Vux = Math.Abs(Convert.ToDouble(parts[2]));
        //                l.Muy = Math.Abs(Convert.ToDouble(parts[3]));
        //                newLoads.Add(l);
        //                break;
        //            case "Mu":
        //                break;
        //            // New_BP.Muy = CDec(Col(1)) * 1000 * 100
        //            case "Stiffener":
        //            case "Stiffner":
        //                newBp.StiffnerType = Convert.ToInt32(parts[1]);
        //                break;
        //            case "hs":
        //                newBp.hs = Convert.ToInt32(parts[1]);
        //                break;
        //            default:
        //                if (!parts[0].StartsWith("$"))
        //                {
        //                    if (MessageBox.Show("Unknown command : " + lines[i] + "\r\n" + "this line ignord!", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
        //                    {
        //                        return 1;
        //                    }
        //                }

        //                break;
        //        }
        //    }
        //    // BP = DirectCast(New_BP, BasePlates)

        //    txtCompany.Text = newBp.CompanyName;
        //    txtProject.Text = newBp.ProjectName;
        //    txtEngineer.Text = newBp.EngineerName;
        //    txtDescription.Text = newBp.Description;
        //    txtNotes.Text = newBp.Notes;


        //    SectionIndex = newSectionIndex;
        //    IsAvailable = false;

        //    lblColumnSection.Text = Sections_IWideFlnage.Section[SectionIndex].Name;
        //    cboColumnSection.SelectedItem = Sections_IWideFlnage.Section[SectionIndex].Name;

        //    txt_sec_bf.Text = Sections_IWideFlnage.Section[SectionIndex].bf.ToString("");
        //    txt_sec_d.Text = Sections_IWideFlnage.Section[SectionIndex].h.ToString("");

        //    txt_N.Text = newBp.N.ToString();
        //    txt_B.Text = newBp.B.ToString();

        //    txt_Hp.Text = newBp.Hp.ToString();
        //    txt_Np.Text = newBp.Np.ToString();
        //    txt_Bp.Text = newBp.Bp.ToString();
        //    txtClearCover.Text = newBp.ClearCover.ToString();

        //    txt_N_BPecc.Text = newBp.N_BPecc.ToString();
        //    txt_B_BPecc.Text = newBp.B_BPecc.ToString();

        //    txt_aN.Text = newBp.a_N.ToString();
        //    txt_aB.Text = newBp.a_B.ToString();

        //    switch (newBp.StiffnerType)
        //    {
        //        case 0:
        //            rdoStiffnerNone.Checked = true;
        //            break;
        //        case 1:
        //            rdoStiffnerType1.Checked = true;
        //            break;
        //        case 2:
        //            rdoStiffnerType2.Checked = true;
        //            break;
        //        case 3:
        //            rdoStiffnerType3.Checked = true;
        //            break;
        //        default:
        //            rdoStiffnerNone.Checked = true;
        //            break;
        //    }

        //    txt_hs.Text = newBp.hs.ToString();
        //    nudBolts_nN.Value = newBp.nbN;
        //    nudBolts_nB.Value = newBp.nbB;
        //    cboBolts.SelectedItem = newBp.Bolt.Name;

        //    txtGroutThickness.Text = newBp.GroutThickness.ToString();

        //    nud_nrN.Value = newBp.nrN;
        //    nud_nrB.Value = newBp.nrB;

        //    for (var i = 0; i <= Main.Rebar.Count - 1; i++)
        //    {
        //        if (Main.Rebar[i] == Convert.ToInt32(newBp.dr))
        //        {
        //            cbo_dr.SelectedIndex = i;
        //        }
        //    }

        //    for (var i = 0; i < Main.Rebar.Count; i++)
        //    {
        //        if (Main.Rebar[i] == Convert.ToInt32(newBp.drs))
        //        {
        //            cbo_drs.SelectedIndex = i;
        //        }
        //    }

        //    nud_nrs.Value = newBp.nrS;
        //    txt_rsS.Text = newBp.rsS.ToString();

        //    if (newBp.ShearResistance == ShearResistances.AnchorBolt)
        //    {
        //        rdoShearByAnchorBolt.Checked = true;
        //    }
        //    else
        //    {
        //        rdoShearByShearKey.Checked = true;
        //        txtShearKeyHeight.Text = newBp.ShearKeyHeight.ToString();

        //        if (newBp.ShearKeySection is Sections_IWideFlnage)
        //        {
        //            rdoShearKeyWideFlange.Checked = true;
        //            cboShearKeyWideFlange.SelectedItem = newBp.ShearKeySection.Name;
        //            if (newBp.ShearKeyOrientation == 0)
        //            {
        //                rdoShearKeyWideFlangeMajor.Checked = true;
        //            }
        //            else
        //            {
        //                rdoShearKeyWideFlangeMinor.Checked = true;
        //            }
        //        }
        //        else if (newBp.ShearKeySection is Sections_Pipe)
        //        {
        //            rdoShearKeyPipe.Checked = true;
        //            cboShearKeyPipe.SelectedItem = newBp.ShearKeySection.Name;
        //        }
        //        else if (newBp.ShearKeySection is Sections_Tube Tube)
        //        {
        //            rdoShearKeyTube.Checked = true;

        //            txtOutsideLength.Text = Tube.h.ToString();
        //            txtFlangeThickness.Text = Tube.tf.ToString();
        //        }
        //    }

        //    txt_fc.Text = newBp.fc.ToString("");
        //    txt_fyr.Text = newBp.fyr.ToString("");
        //    txt_fyrs.Text = newBp.fyrs.ToString("");
        //    txt_fyp.Text = newBp.fyp.ToString("");
        //    txt_fub.Text = newBp.fub.ToString("");
        //    txt_fyb.Text = newBp.fyb.ToString("");
        //    txt_fuw.Text = newBp.Fuw.ToString("");

        //    if (newBp.WeldType == WeldTypes.CJP)
        //    {
        //        rdoWeldCJP.Checked = true;
        //    }
        //    else
        //    {
        //        rdoWeldFilletWeld.Checked = true;
        //        cboWeldCheck.SelectedItem = newBp.Betta_Weld.ToString("");
        //        txtWeldSizeBasePlate.Text = newBp.WeldSzie_BasePlate.ToString("");
        //    }

        //    dgvLoadCombo.Rows.Clear();
        //    for (var i = 0; i < newLoads.Count; i++)
        //    {
        //        dgvLoadCombo.Rows.Add();
        //        dgvLoadCombo.Rows[i].Cells[colRow.Index].Value = i + 1;
        //        dgvLoadCombo.Rows[i].Cells[colLoadCombination.Index].Value = newLoads[i].Name;
        //        dgvLoadCombo.Rows[i].Cells[colPu.Index].Value = newLoads[i].Pu;
        //        dgvLoadCombo.Rows[i].Cells[colVu.Index].Value = newLoads[i].Vux;
        //        dgvLoadCombo.Rows[i].Cells[colMu.Index].Value = newLoads[i].Muy;
        //    }

        //    IsFileChanged = false;

        //    projectFileName = strFile;
        //    SetTitle();

        //    IsAvailable = true;

        //    if (IsRealTimeDesignEnable)
        //    {
        //        RunDesign();
        //    }

        //    return 0;
        //}

        #endregion

        #region Menu

        private void NewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            projectFileName = ProjectDefaultFileName;
            SetTitle();
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = "Mono Base Plate files|*.mbp",
                Multiselect = false,
                CheckFileExists = true
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //OpenProject(openFileDialog.FileName);
            }
        }

        private void ImportLoadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog
            {
                Filter = "Mono Base Plate Loadings file|*.mbpl"
            };

            if (ofd.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            string[] lines;

            try
            {
                lines = File.ReadAllLines(ofd.FileName);
            }
            catch (Exception ex1)
            {
                MessageBox.Show(ex1.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            var loadCombo = new string[lines.Length];
            var f1 = new double[lines.Length];
            var f2 = new double[lines.Length];
            var f3 = new double[lines.Length];

            try
            {
                for (var i = 0; i < lines.Length; i++)
                {
                    var parts = lines[i].Split(new[] { "\t" }, StringSplitOptions.RemoveEmptyEntries);
                    if (parts.Length == 4)
                    {
                        loadCombo[i] = parts[0];
                        f1[i] = Convert.ToDouble(parts[1]);
                        f2[i] = Convert.ToDouble(parts[2]);
                        f3[i] = Convert.ToDouble(parts[3]);
                    }
                    else
                    {
                        MessageBox.Show("Load format is not correct!" + "\r\n" + "Importing will be aborted.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }
                }

                IsAvailable = false;

                if (MessageBox.Show("Do you want to clear loads?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    dgvLoadCombo.Rows.Clear();
                }

                var j = Math.Max(dgvLoadCombo.Rows.Count - 1, 0);
                for (var i = 0; i < loadCombo.Length; i++)
                {
                    dgvLoadCombo.Rows.Add();
                    dgvLoadCombo.Rows[j + i].Cells[colRow.Index].Value = j + i + 1;
                    dgvLoadCombo.Rows[j + i].Cells[colLoadCombination.Index].Value = loadCombo[i];
                    dgvLoadCombo.Rows[j + i].Cells[colPu.Index].Value = f1[i];
                    dgvLoadCombo.Rows[j + i].Cells[colVu.Index].Value = f2[i];
                    dgvLoadCombo.Rows[j + i].Cells[colMu.Index].Value = f3[i];
                }
            }
            catch
            {
                MessageBox.Show("Load format is not correct!" + "\r\n" + "Importing will be aborted.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            finally
            {
                IsAvailable = true;
                if (IsRealTimeDesignEnable)
                {
                    RunDesign();
                }
            }
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (projectFileName == ProjectDefaultFileName)
            {
                var saveFileDialog = new SaveFileDialog
                {
                    Filter = "Mono Base Plate files|*.mbp",
                    FileName = projectFileName
                };

                if (saveFileDialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                SaveProject(saveFileDialog.FileName);
                projectFileName = saveFileDialog.FileName;
                SetTitle();
            }
            else
            {
                SaveProject(projectFileName);
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var saveFileDialog = new SaveFileDialog
            {
                Filter = "Mono Base Plate files|*.mbp",
                FileName = projectFileName
            };

            if (saveFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            SaveProject(saveFileDialog.FileName);

            //TODO:make it possible!!
            var json = JsonConvert.SerializeObject(GetInputData(out _, out _), Formatting.Indented);
            File.WriteAllText(@"D:\json.json", json);

            projectFileName = saveFileDialog.FileName;
            SetTitle();
        }

        private void PrintGraphicToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RealTimeDesignToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            IsRealTimeDesignEnable = RealTimeDesignToolStripMenuItem.Checked;
            btnDesign.Visible = !IsRealTimeDesignEnable;
        }

        private void DesignToolStripMenuItem1_Click(object sender, EventArgs e)
        {
        }

        private void AnchorBoltTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new frmAnchorBolt();
            f.ShowDialog();
        }

        private void BracingLoadsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new frmBracingLoads(SectionIFactory.Items[this.SectionIndex])
            {
                TopMost = this.TopMost
            };

            f.ShowDialog();
        }

        private void GetLoadsFromSAP2000ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new frmLoadsFromSAP();
            f.ShowDialog();
        }

        private void getLoadsFromSAP2000ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var f = new FrmSAPLoads
            {
                TopMost = TopMost
            };
            f.ShowDialog();
        }

        private void DesignDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BasePlateInput basePlateInput;
            IList<BasePlateLoad> loadList;
            try
            {
                basePlateInput = GetInputData(out _, out _);
                loadList = GetLoads(out _, out _);
            }
            catch (Exception ex)
            {
                return;
            }

            var f = new frmResults(designResults, basePlateInput, loadList);
            f.ShowDialog();
        }

        private void InteractiveCurveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new frmInteractiveCurve();
            f.ShowDialog();
        }

        private void SendToAutoCADToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var sfdAutoCAD = new SaveFileDialog
            {
                Filter = @"DXF AutoCAD files|*.dxf",
                FileName = Path.GetFileNameWithoutExtension(projectFileName)
            };

            //if (projectFileName == ProjectDefaultFileName)
            //{
            //    MessageBox.Show(@"You must save project.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1);
            //    return;
            //}

            if (sfdAutoCAD.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    DxfWriter.Create(GetInputData(out _, out _), designResult, sfdAutoCAD.FileName);

                    if (MessageBox.Show(@"Do you want to open the drawing?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        try
                        {
                            Process.Start(sfdAutoCAD.FileName);
                        }
                        catch
                        {
                            MessageBox.Show(@"Can not open file!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                }
            }
        }

        private void CalculationSheetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
            const string templateFilePath = "Baseplate Template.docx";
            const string finalFilePath = "File1.docx";

            //MessageBox.Show(@"This option will be available in next version", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);

            var columnBases = new ColumnBase();
            var input = GetInputData(out _, out _);
            //columnBases.Design(input, loadList, out var rets);
            
            //wordCreator.CreateCalculationSheet(System.IO.Path.GetFullPath("Baseplate Template.docx"), System.IO.Path.GetFullPath("NewFile.docx"));
        }

        private void PrintCalculationSheetToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void AlwaysOnTopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TopMost = AlwaysOnTopToolStripMenuItem.Checked;
        }

        private void ContentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new frmAbout();
            f.ShowDialog();
        }

        private void CopyImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //Clipboard.SetImage(m_BufferBitmap);
            }
            catch (Exception)
            {
                MessageBox.Show(@"An error has been occluded during copy!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveImageAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var imageSaveFileDialog = new SaveFileDialog
            {
                Title = Application.ProductName,
                FileName = Path.GetFileNameWithoutExtension(projectFileName),
                Filter = @"PNG Format|*.png|Jpeg Format|*.jpg|Bmp Format|*.bmp|Gif Format|*.gif|Tiff Format|*.tiff|Emf Format|*.emf"
            };

            try
            {
                if (imageSaveFileDialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                //switch (imageSaveFileDialog.FilterIndex)
                //{
                //    case 1:
                //        m_BufferBitmap.Save(imageSaveFileDialog.FileName, ImageFormat.Png);
                //        break;
                //    case 2:
                //        m_BufferBitmap.Save(imageSaveFileDialog.FileName, ImageFormat.Jpeg);
                //        break;
                //    case 3:
                //        m_BufferBitmap.Save(imageSaveFileDialog.FileName, ImageFormat.Bmp);
                //        break;
                //    case 4:
                //        m_BufferBitmap.Save(imageSaveFileDialog.FileName, ImageFormat.Gif);
                //        break;
                //    case 5:
                //        m_BufferBitmap.Save(imageSaveFileDialog.FileName, ImageFormat.Tiff);
                //        break;
                //    case 6:
                //        m_BufferBitmap.Save(imageSaveFileDialog.FileName, ImageFormat.Emf);
                //        break;
                //    default:
                //        m_BufferBitmap.Save(imageSaveFileDialog.FileName, ImageFormat.Png);
                //        break;
                //}
            }
            catch
            {
                MessageBox.Show(@"An error has been occluded during copy!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CopyToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                var data = dgvLoadCombo.GetClipboardContent();
                if (data == null)
                {
                    return;
                }

                Clipboard.SetDataObject(data);
            }
            catch
            {
                MessageBox.Show(@"An error has been occurred!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PasteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                var strText = Clipboard.GetText(TextDataFormat.Text);
                var lines = strText.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                
                var list = new List<(string, double, double, double)>();
                for (var i = 0; i < lines.Length; i++)
                {
                    var parts = lines[i].Split(new[] { "\t" }, StringSplitOptions.RemoveEmptyEntries);
                    if (parts.Length == 4 && double.TryParse(parts[1], out var pu) && double.TryParse(parts[2], out var vu) && double.TryParse(parts[3], out var mu))
                    {
                        list.Add((parts[0], pu, vu, mu));
                        continue;
                    }

                    MessageBox.Show(@"Contents are not in correct format!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                dgvLoadCombo.Rows.AddRange(list.Select((p, j) => new DataGridViewRow()
                {
                    Cells =
                    {
                        new DataGridViewTextBoxCell() {Value = j + 1},
                        new DataGridViewTextBoxCell() {Value = p.Item1},
                        new DataGridViewTextBoxCell() {Value = Math.Round(p.Item2, 3)},
                        new DataGridViewTextBoxCell() {Value = Math.Round(p.Item3, 3)},
                        new DataGridViewTextBoxCell() {Value = Math.Round(p.Item4, 3)}
                    },
                }).ToArray());

                if (IsRealTimeDesignEnable)
                {
                    RunDesign();
                }
            }
            catch
            {
                MessageBox.Show(@"An error has been occurred!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SelectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dgvLoadCombo.SelectAll();
        }

        #endregion

        private void cboAnchorBoltMaterial_SelectedIndexChanged(object sender, EventArgs e)
        {
            var anchorBolt = AnchorBoltMaterialFactory.Items.Single(p => p.Name == cboAnchorBoltMaterial.SelectedItem.ToString());

            var fy = Pressure
                .From(anchorBolt.Fyb, PressureUnit.Megapascal)
                .As(PressureUnit.KilogramForcePerSquareCentimeter);

            var fu = Pressure
                .From(anchorBolt.Fub, PressureUnit.Megapascal)
                .As(PressureUnit.KilogramForcePerSquareCentimeter);

            fy = anchorBolt.Fyb * 10;
            fu = anchorBolt.Fub * 10;

            txt_fyb.Text = $@"{fy:F0}";
            txt_fub.Text = $@"{fu:F0}";

            var anchorBolt11 = AnchorBoltMaterialFactory.Items.Single(p => p.Name == cboAnchorBoltMaterial.SelectedItem.ToString());
        }

        private void cboShearKeyWideFlange_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsRealTimeDesignEnable)
            {
                RunDesign();
            }
        }
    }
}