using System.ComponentModel;
using System.Windows.Forms;

namespace Mono_Base_Plate.Forms
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.components = new System.ComponentModel.Container();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
			this.txt_sec_d = new System.Windows.Forms.TextBox();
			this.Label30 = new System.Windows.Forms.Label();
			this.lblUnit22_D1 = new System.Windows.Forms.Label();
			this.lblUnit7_D1 = new System.Windows.Forms.Label();
			this.txt_B_BPecc = new System.Windows.Forms.TextBox();
			this.lblUnit12_D1 = new System.Windows.Forms.Label();
			this.Label12 = new System.Windows.Forms.Label();
			this.lblUnit21_D1 = new System.Windows.Forms.Label();
			this.txt_aN = new System.Windows.Forms.TextBox();
			this.txt_B_Cecc = new System.Windows.Forms.TextBox();
			this.rdoStiffnerNone = new System.Windows.Forms.RadioButton();
			this.rdoStiffnerType2 = new System.Windows.Forms.RadioButton();
			this.rdoStiffnerType1 = new System.Windows.Forms.RadioButton();
			this.txt_hs = new System.Windows.Forms.TextBox();
			this.lblUnit11_D1 = new System.Windows.Forms.Label();
			this.Label34 = new System.Windows.Forms.Label();
			this.TabPagePedestal = new System.Windows.Forms.TabPage();
			this.GroupBox4 = new System.Windows.Forms.GroupBox();
			this.lblRebarDistX = new System.Windows.Forms.Label();
			this.lblRebarDistY = new System.Windows.Forms.Label();
			this.Label45 = new System.Windows.Forms.Label();
			this.Label46 = new System.Windows.Forms.Label();
			this.lblRebarArea = new System.Windows.Forms.Label();
			this.txt_Hp = new System.Windows.Forms.TextBox();
			this.nud_nrB = new System.Windows.Forms.NumericUpDown();
			this.nud_nrN = new System.Windows.Forms.NumericUpDown();
			this.nud_nrs = new System.Windows.Forms.NumericUpDown();
			this.txt_rsS = new System.Windows.Forms.TextBox();
			this.Label25 = new System.Windows.Forms.Label();
			this.Label26 = new System.Windows.Forms.Label();
			this.Label24 = new System.Windows.Forms.Label();
			this.cbo_drs = new System.Windows.Forms.ComboBox();
			this.Label20 = new System.Windows.Forms.Label();
			this.cbo_dr = new System.Windows.Forms.ComboBox();
			this.Label19 = new System.Windows.Forms.Label();
			this.txtClearCover = new System.Windows.Forms.TextBox();
			this.Label1 = new System.Windows.Forms.Label();
			this.Label4 = new System.Windows.Forms.Label();
			this.Label15 = new System.Windows.Forms.Label();
			this.Label18 = new System.Windows.Forms.Label();
			this.GroupBox15 = new System.Windows.Forms.GroupBox();
			this.txtWeldSizeShearKey = new System.Windows.Forms.TextBox();
			this.Label51 = new System.Windows.Forms.Label();
			this.Label52 = new System.Windows.Forms.Label();
			this.cboWeldCheck = new System.Windows.Forms.ComboBox();
			this.Label43 = new System.Windows.Forms.Label();
			this.txtWeldSizeBasePlate = new System.Windows.Forms.TextBox();
			this.Label41 = new System.Windows.Forms.Label();
			this.rdoWeldFilletWeld = new System.Windows.Forms.RadioButton();
			this.Label42 = new System.Windows.Forms.Label();
			this.rdoWeldCJP = new System.Windows.Forms.RadioButton();
			this.GroupBox16 = new System.Windows.Forms.GroupBox();
			this.Label53 = new System.Windows.Forms.Label();
			this.GroupBox5 = new System.Windows.Forms.GroupBox();
			this.rdoShearByAnchorBolt = new System.Windows.Forms.RadioButton();
			this.rdoShearByShearKey = new System.Windows.Forms.RadioButton();
			this.txtGroutThickness = new System.Windows.Forms.TextBox();
			this.Label54 = new System.Windows.Forms.Label();
			this.lblBoltArea = new System.Windows.Forms.Label();
			this.chkBuiltUpGroutPad = new System.Windows.Forms.CheckBox();
			this.Label11 = new System.Windows.Forms.Label();
			this.chkThreadeExcluded = new System.Windows.Forms.CheckBox();
			this.nudBolts_nB = new System.Windows.Forms.NumericUpDown();
			this.cboBolts = new System.Windows.Forms.ComboBox();
			this.nudBolts_nN = new System.Windows.Forms.NumericUpDown();
			this.Label14 = new System.Windows.Forms.Label();
			this.Label33 = new System.Windows.Forms.Label();
			this.Label31 = new System.Windows.Forms.Label();
			this.cboShearKeyPipe = new System.Windows.Forms.ComboBox();
			this.rdoShearKeyWideFlange = new System.Windows.Forms.RadioButton();
			this.rdoShearKeyPipe = new System.Windows.Forms.RadioButton();
			this.Label47 = new System.Windows.Forms.Label();
			this.Label48 = new System.Windows.Forms.Label();
			this.txtFlangeThickness = new System.Windows.Forms.TextBox();
			this.Label49 = new System.Windows.Forms.Label();
			this.Label50 = new System.Windows.Forms.Label();
			this.txtOutsideLength = new System.Windows.Forms.TextBox();
			this.Label44 = new System.Windows.Forms.Label();
			this.txtShearKeyHeight = new System.Windows.Forms.TextBox();
			this.Label39 = new System.Windows.Forms.Label();
			this.gpStiffner = new System.Windows.Forms.GroupBox();
			this.rdoStiffnerType3 = new System.Windows.Forms.RadioButton();
			this.txt_sec_bf = new System.Windows.Forms.TextBox();
			this.lblUnit6_D1 = new System.Windows.Forms.Label();
			this.txt_N_BPecc = new System.Windows.Forms.TextBox();
			this.Label2 = new System.Windows.Forms.Label();
			this.txt_Np = new System.Windows.Forms.TextBox();
			this.lblUnit3_D1 = new System.Windows.Forms.Label();
			this.lblUnit1_D1 = new System.Windows.Forms.Label();
			this.txt_Bp = new System.Windows.Forms.TextBox();
			this.Label32 = new System.Windows.Forms.Label();
			this.txt_N = new System.Windows.Forms.TextBox();
			this.Label17 = new System.Windows.Forms.Label();
			this.lblUnit4_D1 = new System.Windows.Forms.Label();
			this.txt_aB = new System.Windows.Forms.TextBox();
			this.txt_B = new System.Windows.Forms.TextBox();
			this.Label13 = new System.Windows.Forms.Label();
			this.txt_N_Cecc = new System.Windows.Forms.TextBox();
			this.lblUnit13_D1 = new System.Windows.Forms.Label();
			this.rdoShearKeyTube = new System.Windows.Forms.RadioButton();
			this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.DesignToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.RealTimeDesignToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.DesignToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.ToolStripMenuItem11 = new System.Windows.Forms.ToolStripSeparator();
			this.AnchorBoltTableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ToolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
			this.BracingLoadsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ToolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
			this.GetLoadsFromSAP2000ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.getLoadsFromSAP2000ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.ResultsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.DesignDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.InteractiveCurveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.OptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.AlwaysOnTopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.HelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.AboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ToolTipMain = new System.Windows.Forms.ToolTip(this.components);
			this.btnDesign = new System.Windows.Forms.Button();
			this.ToolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
			this.MenuStripMain = new System.Windows.Forms.MenuStrip();
			this.FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.NewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.OpenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ToolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.ImportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ImportLoadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ToolStripMenuItem10 = new System.Windows.Forms.ToolStripSeparator();
			this.SaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.SaveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ToolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
			this.PrintGraphicToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.sendToAutoCADToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripSeparator();
			this.CalculationSheetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem12 = new System.Windows.Forms.ToolStripSeparator();
			this.lblUnit2_D1 = new System.Windows.Forms.Label();
			this.rdoDesignMethodASCE7_ASD = new System.Windows.Forms.RadioButton();
			this.GroupBox8 = new System.Windows.Forms.GroupBox();
			this.cboAnchorBoltMaterial = new System.Windows.Forms.ComboBox();
			this.label55 = new System.Windows.Forms.Label();
			this.txt_fyb = new System.Windows.Forms.TextBox();
			this.Label27 = new System.Windows.Forms.Label();
			this.lblUnit3_F1D2 = new System.Windows.Forms.Label();
			this.txt_fub = new System.Windows.Forms.TextBox();
			this.Label9 = new System.Windows.Forms.Label();
			this.lblUnit2_F1D2 = new System.Windows.Forms.Label();
			this.GroupBox7 = new System.Windows.Forms.GroupBox();
			this.lblColumnSteelMaterial = new System.Windows.Forms.Label();
			this.lblPlateSteelMaterial = new System.Windows.Forms.Label();
			this.cboColumnSteelMaterial = new System.Windows.Forms.ComboBox();
			this.label22 = new System.Windows.Forms.Label();
			this.cboPlateSteelMaterial = new System.Windows.Forms.ComboBox();
			this.label57 = new System.Windows.Forms.Label();
			this.txt_Es = new System.Windows.Forms.TextBox();
			this.Label37 = new System.Windows.Forms.Label();
			this.Label38 = new System.Windows.Forms.Label();
			this.GroupBox3 = new System.Windows.Forms.GroupBox();
			this.lblTransverseRebar = new System.Windows.Forms.Label();
			this.lblLongitudinalRebar = new System.Windows.Forms.Label();
			this.cboTransverseRebarMaterial = new System.Windows.Forms.ComboBox();
			this.label61 = new System.Windows.Forms.Label();
			this.cboLongitudinalRebarMaterial = new System.Windows.Forms.ComboBox();
			this.label58 = new System.Windows.Forms.Label();
			this.txt_fc = new System.Windows.Forms.TextBox();
			this.Label16 = new System.Windows.Forms.Label();
			this.lblUnit1_F1D2 = new System.Windows.Forms.Label();
			this.cboShearKeyWideFlange = new System.Windows.Forms.ComboBox();
			this.rdoDesignMethodASCE7_LRFD = new System.Windows.Forms.RadioButton();
			this.contextMenuStripImage = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.CopyImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ToolStripMenuItem7 = new System.Windows.Forms.ToolStripSeparator();
			this.SaveImageAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.TabControlMain = new System.Windows.Forms.TabControl();
			this.TabPageProject = new System.Windows.Forms.TabPage();
			this.GroupBox6 = new System.Windows.Forms.GroupBox();
			this.Label10 = new System.Windows.Forms.Label();
			this.txtCompany = new System.Windows.Forms.TextBox();
			this.txtNotes = new System.Windows.Forms.TextBox();
			this.Label3 = new System.Windows.Forms.Label();
			this.Label7 = new System.Windows.Forms.Label();
			this.txtProject = new System.Windows.Forms.TextBox();
			this.txtDescription = new System.Windows.Forms.TextBox();
			this.Label5 = new System.Windows.Forms.Label();
			this.Label6 = new System.Windows.Forms.Label();
			this.txtEngineer = new System.Windows.Forms.TextBox();
			this.TabPageGlobal = new System.Windows.Forms.TabPage();
			this.GroupBox10 = new System.Windows.Forms.GroupBox();
			this.groupBox18 = new System.Windows.Forms.GroupBox();
			this.groupBox14 = new System.Windows.Forms.GroupBox();
			this.rdoAISC360_16 = new System.Windows.Forms.RadioButton();
			this.rdoAISC360_10 = new System.Windows.Forms.RadioButton();
			this.groupBox13 = new System.Windows.Forms.GroupBox();
			this.rdoACI318_19 = new System.Windows.Forms.RadioButton();
			this.rdoACI318_14 = new System.Windows.Forms.RadioButton();
			this.TabPageMaterials = new System.Windows.Forms.TabPage();
			this.groupBox11 = new System.Windows.Forms.GroupBox();
			this.lblWeldMaterial = new System.Windows.Forms.Label();
			this.cboWeldMaterial = new System.Windows.Forms.ComboBox();
			this.label21 = new System.Windows.Forms.Label();
			this.TabPageLoads = new System.Windows.Forms.TabPage();
			this.GroupBox9 = new System.Windows.Forms.GroupBox();
			this.txtLREFOverASD = new System.Windows.Forms.TextBox();
			this.label56 = new System.Windows.Forms.Label();
			this.Label40 = new System.Windows.Forms.Label();
			this.dgvLoadCombo = new System.Windows.Forms.DataGridView();
			this.colRow = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colLoadCombination = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colPu = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colVu = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colMu = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.contextMenuStripLoading = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.CopyToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.PasteToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.ToolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
			this.SelectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.PictureBox1 = new System.Windows.Forms.PictureBox();
			this.TabPageGeometry = new System.Windows.Forms.TabPage();
			this.GroupBox2 = new System.Windows.Forms.GroupBox();
			this.lblUnit10_D1 = new System.Windows.Forms.Label();
			this.Label8 = new System.Windows.Forms.Label();
			this.GroupBox1 = new System.Windows.Forms.GroupBox();
			this.cboColumnSection = new System.Windows.Forms.ComboBox();
			this.lblColumnSection = new System.Windows.Forms.Label();
			this.btnColumnSection = new System.Windows.Forms.Button();
			this.TabPageAddition = new System.Windows.Forms.TabPage();
			this.GroupBox17 = new System.Windows.Forms.GroupBox();
			this.cboFrictionCoeff = new System.Windows.Forms.ComboBox();
			this.Label29 = new System.Windows.Forms.Label();
			this.Label59 = new System.Windows.Forms.Label();
			this.gpShearKeyTypes = new System.Windows.Forms.GroupBox();
			this.Panel1 = new System.Windows.Forms.Panel();
			this.rdoShearKeyWideFlangeMinor = new System.Windows.Forms.RadioButton();
			this.rdoShearKeyWideFlangeMajor = new System.Windows.Forms.RadioButton();
			this.rtbResult = new System.Windows.Forms.RichTextBox();
			this.groupBox12 = new System.Windows.Forms.GroupBox();
			this.label23 = new System.Windows.Forms.Label();
			this.txtPedestalXScale = new System.Windows.Forms.TextBox();
			this.label28 = new System.Windows.Forms.Label();
			this.txtPedestalYScale = new System.Windows.Forms.TextBox();
			this.viewBox1 = new Mono_Base_Plate.Controls.ViewBox();
			this.TabPagePedestal.SuspendLayout();
			this.GroupBox4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nud_nrB)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nud_nrN)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nud_nrs)).BeginInit();
			this.GroupBox15.SuspendLayout();
			this.GroupBox16.SuspendLayout();
			this.GroupBox5.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudBolts_nB)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nudBolts_nN)).BeginInit();
			this.gpStiffner.SuspendLayout();
			this.MenuStripMain.SuspendLayout();
			this.GroupBox8.SuspendLayout();
			this.GroupBox7.SuspendLayout();
			this.GroupBox3.SuspendLayout();
			this.contextMenuStripImage.SuspendLayout();
			this.TabControlMain.SuspendLayout();
			this.TabPageProject.SuspendLayout();
			this.GroupBox6.SuspendLayout();
			this.TabPageGlobal.SuspendLayout();
			this.GroupBox10.SuspendLayout();
			this.groupBox18.SuspendLayout();
			this.groupBox14.SuspendLayout();
			this.groupBox13.SuspendLayout();
			this.TabPageMaterials.SuspendLayout();
			this.groupBox11.SuspendLayout();
			this.TabPageLoads.SuspendLayout();
			this.GroupBox9.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvLoadCombo)).BeginInit();
			this.contextMenuStripLoading.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
			this.TabPageGeometry.SuspendLayout();
			this.GroupBox2.SuspendLayout();
			this.GroupBox1.SuspendLayout();
			this.TabPageAddition.SuspendLayout();
			this.GroupBox17.SuspendLayout();
			this.gpShearKeyTypes.SuspendLayout();
			this.Panel1.SuspendLayout();
			this.groupBox12.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.viewBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// txt_sec_d
			// 
			this.txt_sec_d.Enabled = false;
			this.txt_sec_d.Location = new System.Drawing.Point(125, 25);
			this.txt_sec_d.Name = "txt_sec_d";
			this.txt_sec_d.Size = new System.Drawing.Size(48, 20);
			this.txt_sec_d.TabIndex = 0;
			this.txt_sec_d.Text = "12.7";
			this.txt_sec_d.TextChanged += new System.EventHandler(this.GeometryTab);
			// 
			// Label30
			// 
			this.Label30.AutoSize = true;
			this.Label30.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label30.Location = new System.Drawing.Point(123, 10);
			this.Label30.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.Label30.Name = "Label30";
			this.Label30.Size = new System.Drawing.Size(53, 13);
			this.Label30.TabIndex = 0;
			this.Label30.Text = "   Width   ";
			// 
			// lblUnit22_D1
			// 
			this.lblUnit22_D1.AutoSize = true;
			this.lblUnit22_D1.Location = new System.Drawing.Point(272, 28);
			this.lblUnit22_D1.Name = "lblUnit22_D1";
			this.lblUnit22_D1.Size = new System.Drawing.Size(21, 13);
			this.lblUnit22_D1.TabIndex = 7;
			this.lblUnit22_D1.Text = "cm";
			// 
			// lblUnit7_D1
			// 
			this.lblUnit7_D1.AutoSize = true;
			this.lblUnit7_D1.Location = new System.Drawing.Point(272, 158);
			this.lblUnit7_D1.Name = "lblUnit7_D1";
			this.lblUnit7_D1.Size = new System.Drawing.Size(21, 13);
			this.lblUnit7_D1.TabIndex = 34;
			this.lblUnit7_D1.Text = "cm";
			// 
			// txt_B_BPecc
			// 
			this.txt_B_BPecc.Location = new System.Drawing.Point(218, 103);
			this.txt_B_BPecc.Name = "txt_B_BPecc";
			this.txt_B_BPecc.Size = new System.Drawing.Size(48, 20);
			this.txt_B_BPecc.TabIndex = 5;
			this.txt_B_BPecc.Text = "0";
			this.txt_B_BPecc.TextChanged += new System.EventHandler(this.GeometryTab);
			// 
			// lblUnit12_D1
			// 
			this.lblUnit12_D1.AutoSize = true;
			this.lblUnit12_D1.Location = new System.Drawing.Point(179, 106);
			this.lblUnit12_D1.Name = "lblUnit12_D1";
			this.lblUnit12_D1.Size = new System.Drawing.Size(21, 13);
			this.lblUnit12_D1.TabIndex = 22;
			this.lblUnit12_D1.Text = "cm";
			// 
			// Label12
			// 
			this.Label12.AutoSize = true;
			this.Label12.Location = new System.Drawing.Point(4, 132);
			this.Label12.Name = "Label12";
			this.Label12.Size = new System.Drawing.Size(115, 13);
			this.Label12.TabIndex = 25;
			this.Label12.Text = "Bolt Distanse to Edge :";
			// 
			// lblUnit21_D1
			// 
			this.lblUnit21_D1.AutoSize = true;
			this.lblUnit21_D1.Location = new System.Drawing.Point(179, 28);
			this.lblUnit21_D1.Name = "lblUnit21_D1";
			this.lblUnit21_D1.Size = new System.Drawing.Size(21, 13);
			this.lblUnit21_D1.TabIndex = 5;
			this.lblUnit21_D1.Text = "cm";
			// 
			// txt_aN
			// 
			this.txt_aN.Location = new System.Drawing.Point(125, 129);
			this.txt_aN.Name = "txt_aN";
			this.txt_aN.Size = new System.Drawing.Size(48, 20);
			this.txt_aN.TabIndex = 6;
			this.txt_aN.Text = "7.5";
			this.txt_aN.TextChanged += new System.EventHandler(this.GeometryTab);
			// 
			// txt_B_Cecc
			// 
			this.txt_B_Cecc.Enabled = false;
			this.txt_B_Cecc.Location = new System.Drawing.Point(218, 155);
			this.txt_B_Cecc.Name = "txt_B_Cecc";
			this.txt_B_Cecc.Size = new System.Drawing.Size(48, 20);
			this.txt_B_Cecc.TabIndex = 9;
			this.txt_B_Cecc.Text = "0";
			this.txt_B_Cecc.TextChanged += new System.EventHandler(this.GeometryTab);
			// 
			// rdoStiffnerNone
			// 
			this.rdoStiffnerNone.AutoSize = true;
			this.rdoStiffnerNone.Checked = true;
			this.rdoStiffnerNone.Location = new System.Drawing.Point(6, 19);
			this.rdoStiffnerNone.Name = "rdoStiffnerNone";
			this.rdoStiffnerNone.Size = new System.Drawing.Size(51, 17);
			this.rdoStiffnerNone.TabIndex = 0;
			this.rdoStiffnerNone.TabStop = true;
			this.rdoStiffnerNone.Text = "None";
			this.rdoStiffnerNone.UseVisualStyleBackColor = true;
			this.rdoStiffnerNone.CheckedChanged += new System.EventHandler(this.StiffenerTab);
			// 
			// rdoStiffnerType2
			// 
			this.rdoStiffnerType2.AutoSize = true;
			this.rdoStiffnerType2.Enabled = false;
			this.rdoStiffnerType2.Location = new System.Drawing.Point(87, 46);
			this.rdoStiffnerType2.Name = "rdoStiffnerType2";
			this.rdoStiffnerType2.Size = new System.Drawing.Size(58, 17);
			this.rdoStiffnerType2.TabIndex = 2;
			this.rdoStiffnerType2.Text = "Type 2";
			this.rdoStiffnerType2.UseVisualStyleBackColor = true;
			this.rdoStiffnerType2.CheckedChanged += new System.EventHandler(this.StiffenerTab);
			// 
			// rdoStiffnerType1
			// 
			this.rdoStiffnerType1.AutoSize = true;
			this.rdoStiffnerType1.Location = new System.Drawing.Point(6, 46);
			this.rdoStiffnerType1.Name = "rdoStiffnerType1";
			this.rdoStiffnerType1.Size = new System.Drawing.Size(58, 17);
			this.rdoStiffnerType1.TabIndex = 1;
			this.rdoStiffnerType1.Text = "Type 1";
			this.rdoStiffnerType1.UseVisualStyleBackColor = true;
			this.rdoStiffnerType1.CheckedChanged += new System.EventHandler(this.StiffenerTab);
			// 
			// txt_hs
			// 
			this.txt_hs.Enabled = false;
			this.txt_hs.Location = new System.Drawing.Point(296, 45);
			this.txt_hs.Name = "txt_hs";
			this.txt_hs.Size = new System.Drawing.Size(48, 20);
			this.txt_hs.TabIndex = 5;
			this.txt_hs.Text = "10";
			this.txt_hs.TextChanged += new System.EventHandler(this.GeometryTab);
			// 
			// lblUnit11_D1
			// 
			this.lblUnit11_D1.AutoSize = true;
			this.lblUnit11_D1.Location = new System.Drawing.Point(272, 80);
			this.lblUnit11_D1.Name = "lblUnit11_D1";
			this.lblUnit11_D1.Size = new System.Drawing.Size(21, 13);
			this.lblUnit11_D1.TabIndex = 17;
			this.lblUnit11_D1.Text = "cm";
			// 
			// Label34
			// 
			this.Label34.AutoSize = true;
			this.Label34.Location = new System.Drawing.Point(246, 48);
			this.Label34.Name = "Label34";
			this.Label34.Size = new System.Drawing.Size(44, 13);
			this.Label34.TabIndex = 4;
			this.Label34.Text = "Height :";
			// 
			// TabPagePedestal
			// 
			this.TabPagePedestal.BackColor = System.Drawing.Color.Transparent;
			this.TabPagePedestal.Controls.Add(this.groupBox12);
			this.TabPagePedestal.Controls.Add(this.GroupBox4);
			this.TabPagePedestal.Location = new System.Drawing.Point(4, 22);
			this.TabPagePedestal.Name = "TabPagePedestal";
			this.TabPagePedestal.Padding = new System.Windows.Forms.Padding(3);
			this.TabPagePedestal.Size = new System.Drawing.Size(381, 429);
			this.TabPagePedestal.TabIndex = 7;
			this.TabPagePedestal.Text = "Pedestal";
			// 
			// GroupBox4
			// 
			this.GroupBox4.Controls.Add(this.lblRebarDistX);
			this.GroupBox4.Controls.Add(this.lblRebarDistY);
			this.GroupBox4.Controls.Add(this.Label45);
			this.GroupBox4.Controls.Add(this.Label46);
			this.GroupBox4.Controls.Add(this.lblRebarArea);
			this.GroupBox4.Controls.Add(this.txt_Hp);
			this.GroupBox4.Controls.Add(this.nud_nrB);
			this.GroupBox4.Controls.Add(this.nud_nrN);
			this.GroupBox4.Controls.Add(this.nud_nrs);
			this.GroupBox4.Controls.Add(this.txt_rsS);
			this.GroupBox4.Controls.Add(this.Label25);
			this.GroupBox4.Controls.Add(this.Label26);
			this.GroupBox4.Controls.Add(this.Label24);
			this.GroupBox4.Controls.Add(this.cbo_drs);
			this.GroupBox4.Controls.Add(this.Label20);
			this.GroupBox4.Controls.Add(this.cbo_dr);
			this.GroupBox4.Controls.Add(this.Label19);
			this.GroupBox4.Controls.Add(this.txtClearCover);
			this.GroupBox4.Controls.Add(this.Label1);
			this.GroupBox4.Controls.Add(this.Label4);
			this.GroupBox4.Controls.Add(this.Label15);
			this.GroupBox4.Controls.Add(this.Label18);
			this.GroupBox4.Location = new System.Drawing.Point(6, 89);
			this.GroupBox4.Name = "GroupBox4";
			this.GroupBox4.Size = new System.Drawing.Size(369, 251);
			this.GroupBox4.TabIndex = 1;
			this.GroupBox4.TabStop = false;
			this.GroupBox4.Text = "Pedestal Design";
			// 
			// lblRebarDistX
			// 
			this.lblRebarDistX.AutoSize = true;
			this.lblRebarDistX.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
			this.lblRebarDistX.Location = new System.Drawing.Point(243, 74);
			this.lblRebarDistX.Name = "lblRebarDistX";
			this.lblRebarDistX.Size = new System.Drawing.Size(19, 13);
			this.lblRebarDistX.TabIndex = 22;
			this.lblRebarDistX.Text = "As";
			// 
			// lblRebarDistY
			// 
			this.lblRebarDistY.AutoSize = true;
			this.lblRebarDistY.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
			this.lblRebarDistY.Location = new System.Drawing.Point(243, 100);
			this.lblRebarDistY.Name = "lblRebarDistY";
			this.lblRebarDistY.Size = new System.Drawing.Size(19, 13);
			this.lblRebarDistY.TabIndex = 21;
			this.lblRebarDistY.Text = "As";
			// 
			// Label45
			// 
			this.Label45.AutoSize = true;
			this.Label45.Location = new System.Drawing.Point(90, 22);
			this.Label45.Name = "Label45";
			this.Label45.Size = new System.Drawing.Size(88, 13);
			this.Label45.TabIndex = 20;
			this.Label45.Text = "Pedestal Height :";
			// 
			// Label46
			// 
			this.Label46.AutoSize = true;
			this.Label46.Location = new System.Drawing.Point(246, 22);
			this.Label46.Name = "Label46";
			this.Label46.Size = new System.Drawing.Size(21, 13);
			this.Label46.TabIndex = 19;
			this.Label46.Text = "cm";
			// 
			// lblRebarArea
			// 
			this.lblRebarArea.AutoSize = true;
			this.lblRebarArea.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
			this.lblRebarArea.Location = new System.Drawing.Point(243, 127);
			this.lblRebarArea.Name = "lblRebarArea";
			this.lblRebarArea.Size = new System.Drawing.Size(19, 13);
			this.lblRebarArea.TabIndex = 19;
			this.lblRebarArea.Text = "As";
			// 
			// txt_Hp
			// 
			this.txt_Hp.Location = new System.Drawing.Point(184, 19);
			this.txt_Hp.Name = "txt_Hp";
			this.txt_Hp.Size = new System.Drawing.Size(56, 20);
			this.txt_Hp.TabIndex = 0;
			this.txt_Hp.Text = "130";
			this.txt_Hp.TextChanged += new System.EventHandler(this.PedestalTab);
			// 
			// nud_nrB
			// 
			this.nud_nrB.Location = new System.Drawing.Point(184, 98);
			this.nud_nrB.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
			this.nud_nrB.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
			this.nud_nrB.Name = "nud_nrB";
			this.nud_nrB.Size = new System.Drawing.Size(56, 20);
			this.nud_nrB.TabIndex = 3;
			this.nud_nrB.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
			this.nud_nrB.ValueChanged += new System.EventHandler(this.PedestalTab);
			// 
			// nud_nrN
			// 
			this.nud_nrN.Location = new System.Drawing.Point(184, 72);
			this.nud_nrN.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
			this.nud_nrN.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
			this.nud_nrN.Name = "nud_nrN";
			this.nud_nrN.Size = new System.Drawing.Size(56, 20);
			this.nud_nrN.TabIndex = 2;
			this.nud_nrN.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
			this.nud_nrN.ValueChanged += new System.EventHandler(this.PedestalTab);
			// 
			// nud_nrs
			// 
			this.nud_nrs.Location = new System.Drawing.Point(184, 170);
			this.nud_nrs.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.nud_nrs.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
			this.nud_nrs.Name = "nud_nrs";
			this.nud_nrs.Size = new System.Drawing.Size(56, 20);
			this.nud_nrs.TabIndex = 5;
			this.nud_nrs.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
			this.nud_nrs.ValueChanged += new System.EventHandler(this.PedestalTab);
			// 
			// txt_rsS
			// 
			this.txt_rsS.Location = new System.Drawing.Point(184, 225);
			this.txt_rsS.Name = "txt_rsS";
			this.txt_rsS.Size = new System.Drawing.Size(56, 20);
			this.txt_rsS.TabIndex = 7;
			this.txt_rsS.Text = "15";
			this.txt_rsS.TextChanged += new System.EventHandler(this.PedestalTab);
			// 
			// Label25
			// 
			this.Label25.AutoSize = true;
			this.Label25.Location = new System.Drawing.Point(51, 228);
			this.Label25.Name = "Label25";
			this.Label25.Size = new System.Drawing.Size(127, 13);
			this.Label25.TabIndex = 16;
			this.Label25.Text = "Transverse Bar Spacing :";
			// 
			// Label26
			// 
			this.Label26.AutoSize = true;
			this.Label26.Location = new System.Drawing.Point(246, 228);
			this.Label26.Name = "Label26";
			this.Label26.Size = new System.Drawing.Size(21, 13);
			this.Label26.TabIndex = 18;
			this.Label26.Text = "cm";
			// 
			// Label24
			// 
			this.Label24.AutoSize = true;
			this.Label24.Location = new System.Drawing.Point(52, 172);
			this.Label24.Name = "Label24";
			this.Label24.Size = new System.Drawing.Size(126, 13);
			this.Label24.TabIndex = 12;
			this.Label24.Text = "Transverse Bar Leg No. :";
			// 
			// cbo_drs
			// 
			this.cbo_drs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbo_drs.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cbo_drs.FormattingEnabled = true;
			this.cbo_drs.IntegralHeight = false;
			this.cbo_drs.Location = new System.Drawing.Point(184, 197);
			this.cbo_drs.MaxDropDownItems = 4;
			this.cbo_drs.Name = "cbo_drs";
			this.cbo_drs.Size = new System.Drawing.Size(56, 22);
			this.cbo_drs.TabIndex = 6;
			this.cbo_drs.SelectedIndexChanged += new System.EventHandler(this.PedestalTab);
			// 
			// Label20
			// 
			this.Label20.AutoSize = true;
			this.Label20.Location = new System.Drawing.Point(70, 200);
			this.Label20.Name = "Label20";
			this.Label20.Size = new System.Drawing.Size(108, 13);
			this.Label20.TabIndex = 14;
			this.Label20.Text = "Transverse Bar Size :";
			// 
			// cbo_dr
			// 
			this.cbo_dr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbo_dr.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cbo_dr.FormattingEnabled = true;
			this.cbo_dr.IntegralHeight = false;
			this.cbo_dr.Location = new System.Drawing.Point(184, 124);
			this.cbo_dr.MaxDropDownItems = 4;
			this.cbo_dr.Name = "cbo_dr";
			this.cbo_dr.Size = new System.Drawing.Size(56, 22);
			this.cbo_dr.TabIndex = 4;
			this.cbo_dr.SelectedIndexChanged += new System.EventHandler(this.PedestalTab);
			// 
			// Label19
			// 
			this.Label19.AutoSize = true;
			this.Label19.Location = new System.Drawing.Point(66, 127);
			this.Label19.Name = "Label19";
			this.Label19.Size = new System.Drawing.Size(112, 13);
			this.Label19.TabIndex = 10;
			this.Label19.Text = "Longitudinal Bar Size :";
			// 
			// txtClearCover
			// 
			this.txtClearCover.Location = new System.Drawing.Point(184, 45);
			this.txtClearCover.Name = "txtClearCover";
			this.txtClearCover.Size = new System.Drawing.Size(56, 20);
			this.txtClearCover.TabIndex = 1;
			this.txtClearCover.Text = "7.5";
			this.txtClearCover.TextChanged += new System.EventHandler(this.PedestalTab);
			// 
			// Label1
			// 
			this.Label1.AutoSize = true;
			this.Label1.Location = new System.Drawing.Point(110, 48);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(68, 13);
			this.Label1.TabIndex = 3;
			this.Label1.Text = "Clear Cover :";
			// 
			// Label4
			// 
			this.Label4.AutoSize = true;
			this.Label4.Location = new System.Drawing.Point(246, 48);
			this.Label4.Name = "Label4";
			this.Label4.Size = new System.Drawing.Size(21, 13);
			this.Label4.TabIndex = 5;
			this.Label4.Text = "cm";
			// 
			// Label15
			// 
			this.Label15.AutoSize = true;
			this.Label15.Location = new System.Drawing.Point(57, 100);
			this.Label15.Name = "Label15";
			this.Label15.Size = new System.Drawing.Size(121, 13);
			this.Label15.TabIndex = 8;
			this.Label15.Text = "Number of Bars in Y-dir :";
			// 
			// Label18
			// 
			this.Label18.AutoSize = true;
			this.Label18.Location = new System.Drawing.Point(57, 74);
			this.Label18.Name = "Label18";
			this.Label18.Size = new System.Drawing.Size(121, 13);
			this.Label18.TabIndex = 6;
			this.Label18.Text = "Number of Bars in X-dir :";
			// 
			// GroupBox15
			// 
			this.GroupBox15.Controls.Add(this.txtWeldSizeShearKey);
			this.GroupBox15.Controls.Add(this.Label51);
			this.GroupBox15.Controls.Add(this.Label52);
			this.GroupBox15.Controls.Add(this.cboWeldCheck);
			this.GroupBox15.Controls.Add(this.Label43);
			this.GroupBox15.Controls.Add(this.txtWeldSizeBasePlate);
			this.GroupBox15.Controls.Add(this.Label41);
			this.GroupBox15.Controls.Add(this.rdoWeldFilletWeld);
			this.GroupBox15.Controls.Add(this.Label42);
			this.GroupBox15.Controls.Add(this.rdoWeldCJP);
			this.GroupBox15.Location = new System.Drawing.Point(6, 280);
			this.GroupBox15.Name = "GroupBox15";
			this.GroupBox15.Size = new System.Drawing.Size(369, 143);
			this.GroupBox15.TabIndex = 2;
			this.GroupBox15.TabStop = false;
			this.GroupBox15.Text = "Weld Design";
			// 
			// txtWeldSizeShearKey
			// 
			this.txtWeldSizeShearKey.Location = new System.Drawing.Point(236, 117);
			this.txtWeldSizeShearKey.Name = "txtWeldSizeShearKey";
			this.txtWeldSizeShearKey.Size = new System.Drawing.Size(47, 20);
			this.txtWeldSizeShearKey.TabIndex = 4;
			this.txtWeldSizeShearKey.Text = "6";
			this.txtWeldSizeShearKey.Visible = false;
			this.txtWeldSizeShearKey.TextChanged += new System.EventHandler(this.cboWeldCheck_SelectedIndexChanged);
			// 
			// Label51
			// 
			this.Label51.AutoSize = true;
			this.Label51.Location = new System.Drawing.Point(96, 120);
			this.Label51.Name = "Label51";
			this.Label51.Size = new System.Drawing.Size(134, 13);
			this.Label51.TabIndex = 24;
			this.Label51.Text = "Weld Size (for Shear Key) :";
			this.Label51.Visible = false;
			// 
			// Label52
			// 
			this.Label52.AutoSize = true;
			this.Label52.Location = new System.Drawing.Point(289, 120);
			this.Label52.Name = "Label52";
			this.Label52.Size = new System.Drawing.Size(23, 13);
			this.Label52.TabIndex = 26;
			this.Label52.Text = "mm";
			this.Label52.Visible = false;
			// 
			// cboWeldCheck
			// 
			this.cboWeldCheck.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboWeldCheck.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cboWeldCheck.FormattingEnabled = true;
			this.cboWeldCheck.IntegralHeight = false;
			this.cboWeldCheck.Items.AddRange(new object[] {
            "0.75",
            "0.85",
            "1.0"});
			this.cboWeldCheck.Location = new System.Drawing.Point(236, 63);
			this.cboWeldCheck.MaxDropDownItems = 4;
			this.cboWeldCheck.Name = "cboWeldCheck";
			this.cboWeldCheck.Size = new System.Drawing.Size(47, 22);
			this.cboWeldCheck.TabIndex = 2;
			this.cboWeldCheck.SelectedIndexChanged += new System.EventHandler(this.cboWeldCheck_SelectedIndexChanged);
			// 
			// Label43
			// 
			this.Label43.AutoSize = true;
			this.Label43.Location = new System.Drawing.Point(155, 66);
			this.Label43.Name = "Label43";
			this.Label43.Size = new System.Drawing.Size(75, 13);
			this.Label43.TabIndex = 23;
			this.Label43.Text = "Check Coeff. :";
			// 
			// txtWeldSizeBasePlate
			// 
			this.txtWeldSizeBasePlate.Location = new System.Drawing.Point(236, 91);
			this.txtWeldSizeBasePlate.Name = "txtWeldSizeBasePlate";
			this.txtWeldSizeBasePlate.Size = new System.Drawing.Size(47, 20);
			this.txtWeldSizeBasePlate.TabIndex = 3;
			this.txtWeldSizeBasePlate.Text = "6";
			this.txtWeldSizeBasePlate.TextChanged += new System.EventHandler(this.cboWeldCheck_SelectedIndexChanged);
			// 
			// Label41
			// 
			this.Label41.AutoSize = true;
			this.Label41.Location = new System.Drawing.Point(94, 94);
			this.Label41.Name = "Label41";
			this.Label41.Size = new System.Drawing.Size(136, 13);
			this.Label41.TabIndex = 20;
			this.Label41.Text = "Weld Size (for Base Plate) :";
			// 
			// rdoWeldFilletWeld
			// 
			this.rdoWeldFilletWeld.AutoSize = true;
			this.rdoWeldFilletWeld.Checked = true;
			this.rdoWeldFilletWeld.Location = new System.Drawing.Point(17, 42);
			this.rdoWeldFilletWeld.Name = "rdoWeldFilletWeld";
			this.rdoWeldFilletWeld.Size = new System.Drawing.Size(74, 17);
			this.rdoWeldFilletWeld.TabIndex = 1;
			this.rdoWeldFilletWeld.TabStop = true;
			this.rdoWeldFilletWeld.Text = "Fillet Weld";
			this.rdoWeldFilletWeld.UseVisualStyleBackColor = true;
			this.rdoWeldFilletWeld.CheckedChanged += new System.EventHandler(this.cboWeldCheck_SelectedIndexChanged);
			// 
			// Label42
			// 
			this.Label42.AutoSize = true;
			this.Label42.Location = new System.Drawing.Point(289, 94);
			this.Label42.Name = "Label42";
			this.Label42.Size = new System.Drawing.Size(23, 13);
			this.Label42.TabIndex = 22;
			this.Label42.Text = "mm";
			// 
			// rdoWeldCJP
			// 
			this.rdoWeldCJP.AutoSize = true;
			this.rdoWeldCJP.Location = new System.Drawing.Point(17, 19);
			this.rdoWeldCJP.Name = "rdoWeldCJP";
			this.rdoWeldCJP.Size = new System.Drawing.Size(179, 17);
			this.rdoWeldCJP.TabIndex = 0;
			this.rdoWeldCJP.Text = "Complete-Joint-Penetration (CJP)";
			this.rdoWeldCJP.UseVisualStyleBackColor = true;
			this.rdoWeldCJP.CheckedChanged += new System.EventHandler(this.cboWeldCheck_SelectedIndexChanged);
			// 
			// GroupBox16
			// 
			this.GroupBox16.Controls.Add(this.Label53);
			this.GroupBox16.Controls.Add(this.GroupBox5);
			this.GroupBox16.Controls.Add(this.txtGroutThickness);
			this.GroupBox16.Controls.Add(this.Label54);
			this.GroupBox16.Controls.Add(this.lblBoltArea);
			this.GroupBox16.Controls.Add(this.chkBuiltUpGroutPad);
			this.GroupBox16.Controls.Add(this.Label11);
			this.GroupBox16.Controls.Add(this.chkThreadeExcluded);
			this.GroupBox16.Controls.Add(this.nudBolts_nB);
			this.GroupBox16.Controls.Add(this.cboBolts);
			this.GroupBox16.Controls.Add(this.nudBolts_nN);
			this.GroupBox16.Controls.Add(this.Label14);
			this.GroupBox16.Location = new System.Drawing.Point(6, 180);
			this.GroupBox16.Name = "GroupBox16";
			this.GroupBox16.Size = new System.Drawing.Size(357, 191);
			this.GroupBox16.TabIndex = 10;
			this.GroupBox16.TabStop = false;
			this.GroupBox16.Text = "Anchor Bolt";
			// 
			// Label53
			// 
			this.Label53.AutoSize = true;
			this.Label53.Location = new System.Drawing.Point(232, 148);
			this.Label53.Name = "Label53";
			this.Label53.Size = new System.Drawing.Size(21, 13);
			this.Label53.TabIndex = 52;
			this.Label53.Text = "cm";
			// 
			// GroupBox5
			// 
			this.GroupBox5.Controls.Add(this.rdoShearByAnchorBolt);
			this.GroupBox5.Controls.Add(this.rdoShearByShearKey);
			this.GroupBox5.Location = new System.Drawing.Point(6, 65);
			this.GroupBox5.Name = "GroupBox5";
			this.GroupBox5.Size = new System.Drawing.Size(132, 65);
			this.GroupBox5.TabIndex = 2;
			this.GroupBox5.TabStop = false;
			this.GroupBox5.Text = "Shear Resisting";
			// 
			// rdoShearByAnchorBolt
			// 
			this.rdoShearByAnchorBolt.AutoSize = true;
			this.rdoShearByAnchorBolt.Location = new System.Drawing.Point(17, 20);
			this.rdoShearByAnchorBolt.Name = "rdoShearByAnchorBolt";
			this.rdoShearByAnchorBolt.Size = new System.Drawing.Size(104, 17);
			this.rdoShearByAnchorBolt.TabIndex = 0;
			this.rdoShearByAnchorBolt.Text = "Anchor Bolt Only";
			this.rdoShearByAnchorBolt.UseVisualStyleBackColor = true;
			this.rdoShearByAnchorBolt.CheckedChanged += new System.EventHandler(this.AnchorBolts);
			// 
			// rdoShearByShearKey
			// 
			this.rdoShearByShearKey.AutoSize = true;
			this.rdoShearByShearKey.Checked = true;
			this.rdoShearByShearKey.Location = new System.Drawing.Point(16, 43);
			this.rdoShearByShearKey.Name = "rdoShearByShearKey";
			this.rdoShearByShearKey.Size = new System.Drawing.Size(74, 17);
			this.rdoShearByShearKey.TabIndex = 1;
			this.rdoShearByShearKey.TabStop = true;
			this.rdoShearByShearKey.Text = "Shear Key";
			this.rdoShearByShearKey.UseVisualStyleBackColor = true;
			this.rdoShearByShearKey.CheckedChanged += new System.EventHandler(this.AnchorBolts);
			// 
			// txtGroutThickness
			// 
			this.txtGroutThickness.Location = new System.Drawing.Point(175, 145);
			this.txtGroutThickness.Name = "txtGroutThickness";
			this.txtGroutThickness.Size = new System.Drawing.Size(52, 20);
			this.txtGroutThickness.TabIndex = 5;
			this.txtGroutThickness.Text = "4.0";
			this.txtGroutThickness.TextChanged += new System.EventHandler(this.AnchorBolts);
			// 
			// Label54
			// 
			this.Label54.AutoSize = true;
			this.Label54.Location = new System.Drawing.Point(78, 148);
			this.Label54.Name = "Label54";
			this.Label54.Size = new System.Drawing.Size(91, 13);
			this.Label54.TabIndex = 50;
			this.Label54.Text = "Grout Thickness :";
			// 
			// lblBoltArea
			// 
			this.lblBoltArea.AutoSize = true;
			this.lblBoltArea.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
			this.lblBoltArea.Location = new System.Drawing.Point(182, 47);
			this.lblBoltArea.Name = "lblBoltArea";
			this.lblBoltArea.Size = new System.Drawing.Size(19, 13);
			this.lblBoltArea.TabIndex = 45;
			this.lblBoltArea.Text = "As";
			// 
			// chkBuiltUpGroutPad
			// 
			this.chkBuiltUpGroutPad.AutoSize = true;
			this.chkBuiltUpGroutPad.Checked = true;
			this.chkBuiltUpGroutPad.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkBuiltUpGroutPad.Location = new System.Drawing.Point(175, 86);
			this.chkBuiltUpGroutPad.Name = "chkBuiltUpGroutPad";
			this.chkBuiltUpGroutPad.Size = new System.Drawing.Size(112, 17);
			this.chkBuiltUpGroutPad.TabIndex = 3;
			this.chkBuiltUpGroutPad.Text = "Built-up Grout Pad";
			this.chkBuiltUpGroutPad.UseVisualStyleBackColor = true;
			this.chkBuiltUpGroutPad.CheckedChanged += new System.EventHandler(this.AnchorBolts);
			// 
			// Label11
			// 
			this.Label11.AutoSize = true;
			this.Label11.Location = new System.Drawing.Point(40, 46);
			this.Label11.Name = "Label11";
			this.Label11.Size = new System.Drawing.Size(73, 13);
			this.Label11.TabIndex = 35;
			this.Label11.Text = "Diameter, da :";
			// 
			// chkThreadeExcluded
			// 
			this.chkThreadeExcluded.AutoSize = true;
			this.chkThreadeExcluded.Checked = true;
			this.chkThreadeExcluded.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkThreadeExcluded.Enabled = false;
			this.chkThreadeExcluded.Location = new System.Drawing.Point(175, 109);
			this.chkThreadeExcluded.Name = "chkThreadeExcluded";
			this.chkThreadeExcluded.Size = new System.Drawing.Size(112, 17);
			this.chkThreadeExcluded.TabIndex = 4;
			this.chkThreadeExcluded.Text = "Threads Excluded";
			this.chkThreadeExcluded.UseVisualStyleBackColor = true;
			this.chkThreadeExcluded.CheckedChanged += new System.EventHandler(this.AnchorBolts);
			// 
			// nudBolts_nB
			// 
			this.nudBolts_nB.BackColor = System.Drawing.Color.White;
			this.nudBolts_nB.Location = new System.Drawing.Point(212, 17);
			this.nudBolts_nB.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
			this.nudBolts_nB.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
			this.nudBolts_nB.Name = "nudBolts_nB";
			this.nudBolts_nB.ReadOnly = true;
			this.nudBolts_nB.Size = new System.Drawing.Size(48, 20);
			this.nudBolts_nB.TabIndex = 1;
			this.nudBolts_nB.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
			this.nudBolts_nB.ValueChanged += new System.EventHandler(this.AnchorBolts);
			// 
			// cboBolts
			// 
			this.cboBolts.DropDownHeight = 93;
			this.cboBolts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboBolts.FormattingEnabled = true;
			this.cboBolts.IntegralHeight = false;
			this.cboBolts.Location = new System.Drawing.Point(119, 43);
			this.cboBolts.Name = "cboBolts";
			this.cboBolts.Size = new System.Drawing.Size(60, 21);
			this.cboBolts.TabIndex = 1;
			this.cboBolts.SelectedIndexChanged += new System.EventHandler(this.AnchorBolts);
			// 
			// nudBolts_nN
			// 
			this.nudBolts_nN.BackColor = System.Drawing.Color.White;
			this.nudBolts_nN.Location = new System.Drawing.Point(119, 17);
			this.nudBolts_nN.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
			this.nudBolts_nN.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
			this.nudBolts_nN.Name = "nudBolts_nN";
			this.nudBolts_nN.ReadOnly = true;
			this.nudBolts_nN.Size = new System.Drawing.Size(48, 20);
			this.nudBolts_nN.TabIndex = 0;
			this.nudBolts_nN.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
			this.nudBolts_nN.ValueChanged += new System.EventHandler(this.AnchorBolts);
			// 
			// Label14
			// 
			this.Label14.AutoSize = true;
			this.Label14.Location = new System.Drawing.Point(40, 19);
			this.Label14.Name = "Label14";
			this.Label14.Size = new System.Drawing.Size(73, 13);
			this.Label14.TabIndex = 35;
			this.Label14.Text = "Anchor Bolts :";
			// 
			// Label33
			// 
			this.Label33.AutoSize = true;
			this.Label33.Location = new System.Drawing.Point(348, 48);
			this.Label33.Name = "Label33";
			this.Label33.Size = new System.Drawing.Size(21, 13);
			this.Label33.TabIndex = 6;
			this.Label33.Text = "cm";
			// 
			// Label31
			// 
			this.Label31.AutoSize = true;
			this.Label31.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label31.Location = new System.Drawing.Point(215, 10);
			this.Label31.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.Label31.Name = "Label31";
			this.Label31.Size = new System.Drawing.Size(52, 13);
			this.Label31.TabIndex = 1;
			this.Label31.Text = "  Length  ";
			// 
			// cboShearKeyPipe
			// 
			this.cboShearKeyPipe.DropDownHeight = 93;
			this.cboShearKeyPipe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboShearKeyPipe.FormattingEnabled = true;
			this.cboShearKeyPipe.IntegralHeight = false;
			this.cboShearKeyPipe.Location = new System.Drawing.Point(144, 16);
			this.cboShearKeyPipe.Name = "cboShearKeyPipe";
			this.cboShearKeyPipe.Size = new System.Drawing.Size(73, 21);
			this.cboShearKeyPipe.TabIndex = 42;
			this.cboShearKeyPipe.SelectedIndexChanged += new System.EventHandler(this.cboShearKeyWideFlange_SelectedIndexChanged);
			// 
			// rdoShearKeyWideFlange
			// 
			this.rdoShearKeyWideFlange.AutoSize = true;
			this.rdoShearKeyWideFlange.Location = new System.Drawing.Point(28, 47);
			this.rdoShearKeyWideFlange.Name = "rdoShearKeyWideFlange";
			this.rdoShearKeyWideFlange.Size = new System.Drawing.Size(93, 17);
			this.rdoShearKeyWideFlange.TabIndex = 6;
			this.rdoShearKeyWideFlange.TabStop = true;
			this.rdoShearKeyWideFlange.Text = "I/Wide Flange";
			this.rdoShearKeyWideFlange.UseVisualStyleBackColor = true;
			this.rdoShearKeyWideFlange.CheckedChanged += new System.EventHandler(this.rdoShearKeyPipe_CheckedChanged);
			// 
			// rdoShearKeyPipe
			// 
			this.rdoShearKeyPipe.AutoSize = true;
			this.rdoShearKeyPipe.Location = new System.Drawing.Point(28, 17);
			this.rdoShearKeyPipe.Name = "rdoShearKeyPipe";
			this.rdoShearKeyPipe.Size = new System.Drawing.Size(46, 17);
			this.rdoShearKeyPipe.TabIndex = 4;
			this.rdoShearKeyPipe.TabStop = true;
			this.rdoShearKeyPipe.Text = "Pipe";
			this.rdoShearKeyPipe.UseVisualStyleBackColor = true;
			this.rdoShearKeyPipe.CheckedChanged += new System.EventHandler(this.rdoShearKeyPipe_CheckedChanged);
			// 
			// Label47
			// 
			this.Label47.AutoSize = true;
			this.Label47.Location = new System.Drawing.Point(284, 105);
			this.Label47.Name = "Label47";
			this.Label47.Size = new System.Drawing.Size(21, 13);
			this.Label47.TabIndex = 9;
			this.Label47.Text = "cm";
			// 
			// Label48
			// 
			this.Label48.AutoSize = true;
			this.Label48.Location = new System.Drawing.Point(128, 105);
			this.Label48.Name = "Label48";
			this.Label48.Size = new System.Drawing.Size(89, 13);
			this.Label48.TabIndex = 8;
			this.Label48.Text = "Plate Thickness :";
			// 
			// txtFlangeThickness
			// 
			this.txtFlangeThickness.Location = new System.Drawing.Point(223, 102);
			this.txtFlangeThickness.Name = "txtFlangeThickness";
			this.txtFlangeThickness.Size = new System.Drawing.Size(59, 20);
			this.txtFlangeThickness.TabIndex = 7;
			this.txtFlangeThickness.Text = "1.5";
			// 
			// Label49
			// 
			this.Label49.AutoSize = true;
			this.Label49.Location = new System.Drawing.Point(284, 79);
			this.Label49.Name = "Label49";
			this.Label49.Size = new System.Drawing.Size(21, 13);
			this.Label49.TabIndex = 6;
			this.Label49.Text = "cm";
			// 
			// Label50
			// 
			this.Label50.AutoSize = true;
			this.Label50.Location = new System.Drawing.Point(132, 79);
			this.Label50.Name = "Label50";
			this.Label50.Size = new System.Drawing.Size(85, 13);
			this.Label50.TabIndex = 5;
			this.Label50.Text = "Outside Length :";
			// 
			// txtOutsideLength
			// 
			this.txtOutsideLength.Location = new System.Drawing.Point(223, 76);
			this.txtOutsideLength.Name = "txtOutsideLength";
			this.txtOutsideLength.Size = new System.Drawing.Size(59, 20);
			this.txtOutsideLength.TabIndex = 4;
			this.txtOutsideLength.Text = "15";
			// 
			// Label44
			// 
			this.Label44.AutoSize = true;
			this.Label44.Location = new System.Drawing.Point(295, 42);
			this.Label44.Name = "Label44";
			this.Label44.Size = new System.Drawing.Size(21, 13);
			this.Label44.TabIndex = 45;
			this.Label44.Text = "cm";
			// 
			// txtShearKeyHeight
			// 
			this.txtShearKeyHeight.Location = new System.Drawing.Point(238, 39);
			this.txtShearKeyHeight.Name = "txtShearKeyHeight";
			this.txtShearKeyHeight.Size = new System.Drawing.Size(52, 20);
			this.txtShearKeyHeight.TabIndex = 44;
			this.txtShearKeyHeight.Text = "25";
			// 
			// Label39
			// 
			this.Label39.AutoSize = true;
			this.Label39.Location = new System.Drawing.Point(136, 42);
			this.Label39.Name = "Label39";
			this.Label39.Size = new System.Drawing.Size(96, 13);
			this.Label39.TabIndex = 43;
			this.Label39.Text = "Shear Key Height :";
			// 
			// gpStiffner
			// 
			this.gpStiffner.Controls.Add(this.rdoStiffnerType3);
			this.gpStiffner.Controls.Add(this.rdoStiffnerNone);
			this.gpStiffner.Controls.Add(this.rdoStiffnerType2);
			this.gpStiffner.Controls.Add(this.rdoStiffnerType1);
			this.gpStiffner.Controls.Add(this.txt_hs);
			this.gpStiffner.Controls.Add(this.Label34);
			this.gpStiffner.Controls.Add(this.Label33);
			this.gpStiffner.Location = new System.Drawing.Point(6, 6);
			this.gpStiffner.Name = "gpStiffner";
			this.gpStiffner.Size = new System.Drawing.Size(369, 77);
			this.gpStiffner.TabIndex = 0;
			this.gpStiffner.TabStop = false;
			this.gpStiffner.Text = "Stiffner";
			// 
			// rdoStiffnerType3
			// 
			this.rdoStiffnerType3.AutoSize = true;
			this.rdoStiffnerType3.Enabled = false;
			this.rdoStiffnerType3.Location = new System.Drawing.Point(165, 46);
			this.rdoStiffnerType3.Name = "rdoStiffnerType3";
			this.rdoStiffnerType3.Size = new System.Drawing.Size(58, 17);
			this.rdoStiffnerType3.TabIndex = 3;
			this.rdoStiffnerType3.Text = "Type 3";
			this.rdoStiffnerType3.UseVisualStyleBackColor = true;
			this.rdoStiffnerType3.CheckedChanged += new System.EventHandler(this.StiffenerTab);
			// 
			// txt_sec_bf
			// 
			this.txt_sec_bf.Enabled = false;
			this.txt_sec_bf.Location = new System.Drawing.Point(218, 25);
			this.txt_sec_bf.Name = "txt_sec_bf";
			this.txt_sec_bf.Size = new System.Drawing.Size(48, 20);
			this.txt_sec_bf.TabIndex = 1;
			this.txt_sec_bf.Text = "12.2";
			this.txt_sec_bf.TextChanged += new System.EventHandler(this.GeometryTab);
			// 
			// lblUnit6_D1
			// 
			this.lblUnit6_D1.AutoSize = true;
			this.lblUnit6_D1.Location = new System.Drawing.Point(179, 158);
			this.lblUnit6_D1.Name = "lblUnit6_D1";
			this.lblUnit6_D1.Size = new System.Drawing.Size(21, 13);
			this.lblUnit6_D1.TabIndex = 32;
			this.lblUnit6_D1.Text = "cm";
			// 
			// txt_N_BPecc
			// 
			this.txt_N_BPecc.Location = new System.Drawing.Point(125, 103);
			this.txt_N_BPecc.Name = "txt_N_BPecc";
			this.txt_N_BPecc.Size = new System.Drawing.Size(48, 20);
			this.txt_N_BPecc.TabIndex = 4;
			this.txt_N_BPecc.Text = "0";
			this.txt_N_BPecc.TextChanged += new System.EventHandler(this.GeometryTab);
			// 
			// Label2
			// 
			this.Label2.AutoSize = true;
			this.Label2.Location = new System.Drawing.Point(28, 54);
			this.Label2.Name = "Label2";
			this.Label2.Size = new System.Drawing.Size(91, 13);
			this.Label2.TabIndex = 8;
			this.Label2.Text = "Steel Base Plate :";
			// 
			// txt_Np
			// 
			this.txt_Np.Location = new System.Drawing.Point(125, 77);
			this.txt_Np.Name = "txt_Np";
			this.txt_Np.Size = new System.Drawing.Size(48, 20);
			this.txt_Np.TabIndex = 2;
			this.txt_Np.Text = "90";
			this.txt_Np.TextChanged += new System.EventHandler(this.GeometryTab);
			// 
			// lblUnit3_D1
			// 
			this.lblUnit3_D1.AutoSize = true;
			this.lblUnit3_D1.Location = new System.Drawing.Point(179, 132);
			this.lblUnit3_D1.Name = "lblUnit3_D1";
			this.lblUnit3_D1.Size = new System.Drawing.Size(21, 13);
			this.lblUnit3_D1.TabIndex = 27;
			this.lblUnit3_D1.Text = "cm";
			// 
			// lblUnit1_D1
			// 
			this.lblUnit1_D1.AutoSize = true;
			this.lblUnit1_D1.Location = new System.Drawing.Point(179, 54);
			this.lblUnit1_D1.Name = "lblUnit1_D1";
			this.lblUnit1_D1.Size = new System.Drawing.Size(21, 13);
			this.lblUnit1_D1.TabIndex = 10;
			this.lblUnit1_D1.Text = "cm";
			// 
			// txt_Bp
			// 
			this.txt_Bp.Location = new System.Drawing.Point(218, 77);
			this.txt_Bp.Name = "txt_Bp";
			this.txt_Bp.Size = new System.Drawing.Size(48, 20);
			this.txt_Bp.TabIndex = 3;
			this.txt_Bp.Text = "90";
			this.txt_Bp.TextChanged += new System.EventHandler(this.GeometryTab);
			// 
			// Label32
			// 
			this.Label32.AutoSize = true;
			this.Label32.Location = new System.Drawing.Point(71, 28);
			this.Label32.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.Label32.Name = "Label32";
			this.Label32.Size = new System.Drawing.Size(48, 13);
			this.Label32.TabIndex = 3;
			this.Label32.Text = "Column :";
			// 
			// txt_N
			// 
			this.txt_N.Location = new System.Drawing.Point(125, 51);
			this.txt_N.Name = "txt_N";
			this.txt_N.Size = new System.Drawing.Size(48, 20);
			this.txt_N.TabIndex = 0;
			this.txt_N.Text = "60";
			this.txt_N.TextChanged += new System.EventHandler(this.GeometryTab);
			// 
			// Label17
			// 
			this.Label17.AutoSize = true;
			this.Label17.Location = new System.Drawing.Point(19, 80);
			this.Label17.Name = "Label17";
			this.Label17.Size = new System.Drawing.Size(100, 13);
			this.Label17.TabIndex = 13;
			this.Label17.Text = "Concrete Pedestal :";
			// 
			// lblUnit4_D1
			// 
			this.lblUnit4_D1.AutoSize = true;
			this.lblUnit4_D1.Location = new System.Drawing.Point(272, 132);
			this.lblUnit4_D1.Name = "lblUnit4_D1";
			this.lblUnit4_D1.Size = new System.Drawing.Size(21, 13);
			this.lblUnit4_D1.TabIndex = 29;
			this.lblUnit4_D1.Text = "cm";
			// 
			// txt_aB
			// 
			this.txt_aB.Location = new System.Drawing.Point(218, 129);
			this.txt_aB.Name = "txt_aB";
			this.txt_aB.Size = new System.Drawing.Size(48, 20);
			this.txt_aB.TabIndex = 7;
			this.txt_aB.Text = "7.5";
			this.txt_aB.TextChanged += new System.EventHandler(this.GeometryTab);
			// 
			// txt_B
			// 
			this.txt_B.Location = new System.Drawing.Point(218, 51);
			this.txt_B.Name = "txt_B";
			this.txt_B.Size = new System.Drawing.Size(48, 20);
			this.txt_B.TabIndex = 1;
			this.txt_B.Text = "60";
			this.txt_B.TextChanged += new System.EventHandler(this.GeometryTab);
			// 
			// Label13
			// 
			this.Label13.AutoSize = true;
			this.Label13.Location = new System.Drawing.Point(28, 106);
			this.Label13.Name = "Label13";
			this.Label13.Size = new System.Drawing.Size(91, 13);
			this.Label13.TabIndex = 20;
			this.Label13.Text = "B.P. Eccentricity :";
			// 
			// txt_N_Cecc
			// 
			this.txt_N_Cecc.Enabled = false;
			this.txt_N_Cecc.Location = new System.Drawing.Point(125, 155);
			this.txt_N_Cecc.Name = "txt_N_Cecc";
			this.txt_N_Cecc.Size = new System.Drawing.Size(48, 20);
			this.txt_N_Cecc.TabIndex = 8;
			this.txt_N_Cecc.Text = "0";
			this.txt_N_Cecc.TextChanged += new System.EventHandler(this.GeometryTab);
			// 
			// lblUnit13_D1
			// 
			this.lblUnit13_D1.AutoSize = true;
			this.lblUnit13_D1.Location = new System.Drawing.Point(272, 106);
			this.lblUnit13_D1.Name = "lblUnit13_D1";
			this.lblUnit13_D1.Size = new System.Drawing.Size(21, 13);
			this.lblUnit13_D1.TabIndex = 24;
			this.lblUnit13_D1.Text = "cm";
			// 
			// rdoShearKeyTube
			// 
			this.rdoShearKeyTube.AutoSize = true;
			this.rdoShearKeyTube.Location = new System.Drawing.Point(28, 76);
			this.rdoShearKeyTube.Name = "rdoShearKeyTube";
			this.rdoShearKeyTube.Size = new System.Drawing.Size(50, 17);
			this.rdoShearKeyTube.TabIndex = 5;
			this.rdoShearKeyTube.TabStop = true;
			this.rdoShearKeyTube.Text = "Tube";
			this.rdoShearKeyTube.UseVisualStyleBackColor = true;
			this.rdoShearKeyTube.CheckedChanged += new System.EventHandler(this.rdoShearKeyPipe_CheckedChanged);
			// 
			// ExitToolStripMenuItem
			// 
			this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
			this.ExitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
			this.ExitToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
			this.ExitToolStripMenuItem.Text = "E&xit";
			this.ExitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
			// 
			// DesignToolStripMenuItem
			// 
			this.DesignToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RealTimeDesignToolStripMenuItem,
            this.DesignToolStripMenuItem1,
            this.ToolStripMenuItem11,
            this.AnchorBoltTableToolStripMenuItem,
            this.ToolStripMenuItem4,
            this.BracingLoadsToolStripMenuItem,
            this.ToolStripMenuItem5,
            this.GetLoadsFromSAP2000ToolStripMenuItem,
            this.getLoadsFromSAP2000ToolStripMenuItem1});
			this.DesignToolStripMenuItem.Name = "DesignToolStripMenuItem";
			this.DesignToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
			this.DesignToolStripMenuItem.Text = "&Design";
			// 
			// RealTimeDesignToolStripMenuItem
			// 
			this.RealTimeDesignToolStripMenuItem.CheckOnClick = true;
			this.RealTimeDesignToolStripMenuItem.Name = "RealTimeDesignToolStripMenuItem";
			this.RealTimeDesignToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
			this.RealTimeDesignToolStripMenuItem.Text = "Real Time Design";
			this.RealTimeDesignToolStripMenuItem.CheckedChanged += new System.EventHandler(this.RealTimeDesignToolStripMenuItem_CheckedChanged);
			// 
			// DesignToolStripMenuItem1
			// 
			this.DesignToolStripMenuItem1.Name = "DesignToolStripMenuItem1";
			this.DesignToolStripMenuItem1.ShortcutKeys = System.Windows.Forms.Keys.F5;
			this.DesignToolStripMenuItem1.Size = new System.Drawing.Size(242, 22);
			this.DesignToolStripMenuItem1.Text = "Design";
			this.DesignToolStripMenuItem1.Click += new System.EventHandler(this.DesignToolStripMenuItem1_Click);
			// 
			// ToolStripMenuItem11
			// 
			this.ToolStripMenuItem11.Name = "ToolStripMenuItem11";
			this.ToolStripMenuItem11.Size = new System.Drawing.Size(239, 6);
			// 
			// AnchorBoltTableToolStripMenuItem
			// 
			this.AnchorBoltTableToolStripMenuItem.Name = "AnchorBoltTableToolStripMenuItem";
			this.AnchorBoltTableToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
			this.AnchorBoltTableToolStripMenuItem.Text = "Anchor Bolt Table...";
			this.AnchorBoltTableToolStripMenuItem.Click += new System.EventHandler(this.AnchorBoltTableToolStripMenuItem_Click);
			// 
			// ToolStripMenuItem4
			// 
			this.ToolStripMenuItem4.Name = "ToolStripMenuItem4";
			this.ToolStripMenuItem4.Size = new System.Drawing.Size(239, 6);
			// 
			// BracingLoadsToolStripMenuItem
			// 
			this.BracingLoadsToolStripMenuItem.Name = "BracingLoadsToolStripMenuItem";
			this.BracingLoadsToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F10;
			this.BracingLoadsToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
			this.BracingLoadsToolStripMenuItem.Text = "&Bracing Loads...";
			this.BracingLoadsToolStripMenuItem.Click += new System.EventHandler(this.BracingLoadsToolStripMenuItem_Click);
			// 
			// ToolStripMenuItem5
			// 
			this.ToolStripMenuItem5.Name = "ToolStripMenuItem5";
			this.ToolStripMenuItem5.Size = new System.Drawing.Size(239, 6);
			// 
			// GetLoadsFromSAP2000ToolStripMenuItem
			// 
			this.GetLoadsFromSAP2000ToolStripMenuItem.Name = "GetLoadsFromSAP2000ToolStripMenuItem";
			this.GetLoadsFromSAP2000ToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F7;
			this.GetLoadsFromSAP2000ToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
			this.GetLoadsFromSAP2000ToolStripMenuItem.Text = "Get Loads From SAP2000...";
			this.GetLoadsFromSAP2000ToolStripMenuItem.Click += new System.EventHandler(this.GetLoadsFromSAP2000ToolStripMenuItem_Click);
			// 
			// getLoadsFromSAP2000ToolStripMenuItem1
			// 
			this.getLoadsFromSAP2000ToolStripMenuItem1.Name = "getLoadsFromSAP2000ToolStripMenuItem1";
			this.getLoadsFromSAP2000ToolStripMenuItem1.ShortcutKeys = System.Windows.Forms.Keys.F8;
			this.getLoadsFromSAP2000ToolStripMenuItem1.Size = new System.Drawing.Size(242, 22);
			this.getLoadsFromSAP2000ToolStripMenuItem1.Text = "Get Loads From SAP2000 2...";
			this.getLoadsFromSAP2000ToolStripMenuItem1.Click += new System.EventHandler(this.getLoadsFromSAP2000ToolStripMenuItem1_Click);
			// 
			// ResultsToolStripMenuItem
			// 
			this.ResultsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DesignDetailsToolStripMenuItem,
            this.InteractiveCurveToolStripMenuItem});
			this.ResultsToolStripMenuItem.Name = "ResultsToolStripMenuItem";
			this.ResultsToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
			this.ResultsToolStripMenuItem.Text = "&Results";
			// 
			// DesignDetailsToolStripMenuItem
			// 
			this.DesignDetailsToolStripMenuItem.Enabled = false;
			this.DesignDetailsToolStripMenuItem.Name = "DesignDetailsToolStripMenuItem";
			this.DesignDetailsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
			this.DesignDetailsToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
			this.DesignDetailsToolStripMenuItem.Text = "Design Details...";
			this.DesignDetailsToolStripMenuItem.Click += new System.EventHandler(this.DesignDetailsToolStripMenuItem_Click);
			// 
			// InteractiveCurveToolStripMenuItem
			// 
			this.InteractiveCurveToolStripMenuItem.Enabled = false;
			this.InteractiveCurveToolStripMenuItem.Name = "InteractiveCurveToolStripMenuItem";
			this.InteractiveCurveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
			this.InteractiveCurveToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
			this.InteractiveCurveToolStripMenuItem.Text = "Interactive Curve...";
			this.InteractiveCurveToolStripMenuItem.Click += new System.EventHandler(this.InteractiveCurveToolStripMenuItem_Click);
			// 
			// OptionsToolStripMenuItem
			// 
			this.OptionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AlwaysOnTopToolStripMenuItem});
			this.OptionsToolStripMenuItem.Name = "OptionsToolStripMenuItem";
			this.OptionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
			this.OptionsToolStripMenuItem.Text = "&Options";
			// 
			// AlwaysOnTopToolStripMenuItem
			// 
			this.AlwaysOnTopToolStripMenuItem.CheckOnClick = true;
			this.AlwaysOnTopToolStripMenuItem.Name = "AlwaysOnTopToolStripMenuItem";
			this.AlwaysOnTopToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F12;
			this.AlwaysOnTopToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
			this.AlwaysOnTopToolStripMenuItem.Text = "&Always On Top";
			this.AlwaysOnTopToolStripMenuItem.Click += new System.EventHandler(this.AlwaysOnTopToolStripMenuItem_Click);
			// 
			// HelpToolStripMenuItem
			// 
			this.HelpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AboutToolStripMenuItem});
			this.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem";
			this.HelpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
			this.HelpToolStripMenuItem.Text = "&Help";
			// 
			// AboutToolStripMenuItem
			// 
			this.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem";
			this.AboutToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
			this.AboutToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
			this.AboutToolStripMenuItem.Text = "&About...";
			this.AboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
			// 
			// ToolTipMain
			// 
			this.ToolTipMain.AutoPopDelay = 5000;
			this.ToolTipMain.InitialDelay = 500;
			this.ToolTipMain.IsBalloon = true;
			this.ToolTipMain.ReshowDelay = 100;
			this.ToolTipMain.ShowAlways = true;
			// 
			// btnDesign
			// 
			this.btnDesign.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnDesign.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnDesign.Location = new System.Drawing.Point(825, 371);
			this.btnDesign.Name = "btnDesign";
			this.btnDesign.Size = new System.Drawing.Size(65, 23);
			this.btnDesign.TabIndex = 3;
			this.btnDesign.Text = "Design";
			this.btnDesign.UseVisualStyleBackColor = true;
			this.btnDesign.Click += new System.EventHandler(this.btnDesign_Click);
			// 
			// ToolStripMenuItem3
			// 
			this.ToolStripMenuItem3.Name = "ToolStripMenuItem3";
			this.ToolStripMenuItem3.Size = new System.Drawing.Size(190, 6);
			// 
			// MenuStripMain
			// 
			this.MenuStripMain.BackColor = System.Drawing.Color.White;
			this.MenuStripMain.Dock = System.Windows.Forms.DockStyle.None;
			this.MenuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileToolStripMenuItem,
            this.DesignToolStripMenuItem,
            this.ResultsToolStripMenuItem,
            this.OptionsToolStripMenuItem,
            this.HelpToolStripMenuItem});
			this.MenuStripMain.Location = new System.Drawing.Point(0, 1);
			this.MenuStripMain.MdiWindowListItem = this.FileToolStripMenuItem;
			this.MenuStripMain.Name = "MenuStripMain";
			this.MenuStripMain.Size = new System.Drawing.Size(261, 24);
			this.MenuStripMain.TabIndex = 0;
			this.MenuStripMain.Text = "MenuStrip1";
			// 
			// FileToolStripMenuItem
			// 
			this.FileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewToolStripMenuItem,
            this.OpenToolStripMenuItem,
            this.ToolStripMenuItem1,
            this.ImportToolStripMenuItem,
            this.ToolStripMenuItem10,
            this.SaveToolStripMenuItem,
            this.SaveAsToolStripMenuItem,
            this.ToolStripMenuItem2,
            this.PrintGraphicToolStripMenuItem,
            this.ToolStripMenuItem3,
            this.exportToolStripMenuItem,
            this.toolStripMenuItem12,
            this.ExitToolStripMenuItem});
			this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
			this.FileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.FileToolStripMenuItem.Text = "&File";
			// 
			// NewToolStripMenuItem
			// 
			this.NewToolStripMenuItem.Name = "NewToolStripMenuItem";
			this.NewToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
			this.NewToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
			this.NewToolStripMenuItem.Text = "&New";
			this.NewToolStripMenuItem.Click += new System.EventHandler(this.NewToolStripMenuItem_Click);
			// 
			// OpenToolStripMenuItem
			// 
			this.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem";
			this.OpenToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
			this.OpenToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
			this.OpenToolStripMenuItem.Text = "&Open...";
			this.OpenToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
			// 
			// ToolStripMenuItem1
			// 
			this.ToolStripMenuItem1.Name = "ToolStripMenuItem1";
			this.ToolStripMenuItem1.Size = new System.Drawing.Size(190, 6);
			// 
			// ImportToolStripMenuItem
			// 
			this.ImportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ImportLoadToolStripMenuItem});
			this.ImportToolStripMenuItem.Name = "ImportToolStripMenuItem";
			this.ImportToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
			this.ImportToolStripMenuItem.Text = "Import";
			// 
			// ImportLoadToolStripMenuItem
			// 
			this.ImportLoadToolStripMenuItem.Name = "ImportLoadToolStripMenuItem";
			this.ImportLoadToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F8;
			this.ImportLoadToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
			this.ImportLoadToolStripMenuItem.Text = "Import Load...";
			this.ImportLoadToolStripMenuItem.Click += new System.EventHandler(this.ImportLoadToolStripMenuItem_Click);
			// 
			// ToolStripMenuItem10
			// 
			this.ToolStripMenuItem10.Name = "ToolStripMenuItem10";
			this.ToolStripMenuItem10.Size = new System.Drawing.Size(190, 6);
			// 
			// SaveToolStripMenuItem
			// 
			this.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem";
			this.SaveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
			this.SaveToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
			this.SaveToolStripMenuItem.Text = "&Save";
			this.SaveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
			// 
			// SaveAsToolStripMenuItem
			// 
			this.SaveAsToolStripMenuItem.Name = "SaveAsToolStripMenuItem";
			this.SaveAsToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
			this.SaveAsToolStripMenuItem.Text = "Save &As...";
			this.SaveAsToolStripMenuItem.Click += new System.EventHandler(this.SaveAsToolStripMenuItem_Click);
			// 
			// ToolStripMenuItem2
			// 
			this.ToolStripMenuItem2.Name = "ToolStripMenuItem2";
			this.ToolStripMenuItem2.Size = new System.Drawing.Size(190, 6);
			// 
			// PrintGraphicToolStripMenuItem
			// 
			this.PrintGraphicToolStripMenuItem.Name = "PrintGraphicToolStripMenuItem";
			this.PrintGraphicToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
			this.PrintGraphicToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
			this.PrintGraphicToolStripMenuItem.Text = "Print Graphic...";
			this.PrintGraphicToolStripMenuItem.Click += new System.EventHandler(this.PrintGraphicToolStripMenuItem_Click);
			// 
			// exportToolStripMenuItem
			// 
			this.exportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sendToAutoCADToolStripMenuItem,
            this.toolStripMenuItem8,
            this.CalculationSheetToolStripMenuItem});
			this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
			this.exportToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
			this.exportToolStripMenuItem.Text = "&Export";
			// 
			// sendToAutoCADToolStripMenuItem
			// 
			this.sendToAutoCADToolStripMenuItem.Name = "sendToAutoCADToolStripMenuItem";
			this.sendToAutoCADToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F3;
			this.sendToAutoCADToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
			this.sendToAutoCADToolStripMenuItem.Text = "&Send to AutoCAD";
			this.sendToAutoCADToolStripMenuItem.Click += new System.EventHandler(this.SendToAutoCADToolStripMenuItem_Click);
			// 
			// toolStripMenuItem8
			// 
			this.toolStripMenuItem8.Name = "toolStripMenuItem8";
			this.toolStripMenuItem8.Size = new System.Drawing.Size(183, 6);
			// 
			// CalculationSheetToolStripMenuItem
			// 
			this.CalculationSheetToolStripMenuItem.Name = "CalculationSheetToolStripMenuItem";
			this.CalculationSheetToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F4;
			this.CalculationSheetToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
			this.CalculationSheetToolStripMenuItem.Text = "&Calculation Sheet";
			this.CalculationSheetToolStripMenuItem.Click += new System.EventHandler(this.CalculationSheetToolStripMenuItem_Click);
			// 
			// toolStripMenuItem12
			// 
			this.toolStripMenuItem12.Name = "toolStripMenuItem12";
			this.toolStripMenuItem12.Size = new System.Drawing.Size(190, 6);
			// 
			// lblUnit2_D1
			// 
			this.lblUnit2_D1.AutoSize = true;
			this.lblUnit2_D1.Location = new System.Drawing.Point(272, 54);
			this.lblUnit2_D1.Name = "lblUnit2_D1";
			this.lblUnit2_D1.Size = new System.Drawing.Size(21, 13);
			this.lblUnit2_D1.TabIndex = 12;
			this.lblUnit2_D1.Text = "cm";
			// 
			// rdoDesignMethodASCE7_ASD
			// 
			this.rdoDesignMethodASCE7_ASD.AutoSize = true;
			this.rdoDesignMethodASCE7_ASD.Location = new System.Drawing.Point(199, 19);
			this.rdoDesignMethodASCE7_ASD.Name = "rdoDesignMethodASCE7_ASD";
			this.rdoDesignMethodASCE7_ASD.Size = new System.Drawing.Size(105, 17);
			this.rdoDesignMethodASCE7_ASD.TabIndex = 12;
			this.rdoDesignMethodASCE7_ASD.TabStop = true;
			this.rdoDesignMethodASCE7_ASD.Text = "ASCE7-10 (ASD)";
			this.rdoDesignMethodASCE7_ASD.UseVisualStyleBackColor = true;
			this.rdoDesignMethodASCE7_ASD.CheckedChanged += new System.EventHandler(this.GlobalTab_CheckedChanged);
			// 
			// GroupBox8
			// 
			this.GroupBox8.Controls.Add(this.cboAnchorBoltMaterial);
			this.GroupBox8.Controls.Add(this.label55);
			this.GroupBox8.Controls.Add(this.txt_fyb);
			this.GroupBox8.Controls.Add(this.Label27);
			this.GroupBox8.Controls.Add(this.lblUnit3_F1D2);
			this.GroupBox8.Controls.Add(this.txt_fub);
			this.GroupBox8.Controls.Add(this.Label9);
			this.GroupBox8.Controls.Add(this.lblUnit2_F1D2);
			this.GroupBox8.Location = new System.Drawing.Point(6, 210);
			this.GroupBox8.Name = "GroupBox8";
			this.GroupBox8.Size = new System.Drawing.Size(369, 97);
			this.GroupBox8.TabIndex = 3;
			this.GroupBox8.TabStop = false;
			this.GroupBox8.Text = "Anchor Bolt";
			// 
			// cboAnchorBoltMaterial
			// 
			this.cboAnchorBoltMaterial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboAnchorBoltMaterial.FormattingEnabled = true;
			this.cboAnchorBoltMaterial.Location = new System.Drawing.Point(145, 15);
			this.cboAnchorBoltMaterial.Name = "cboAnchorBoltMaterial";
			this.cboAnchorBoltMaterial.Size = new System.Drawing.Size(100, 21);
			this.cboAnchorBoltMaterial.TabIndex = 9;
			this.cboAnchorBoltMaterial.SelectedIndexChanged += new System.EventHandler(this.cboAnchorBoltMaterial_SelectedIndexChanged);
			// 
			// label55
			// 
			this.label55.AutoSize = true;
			this.label55.Location = new System.Drawing.Point(101, 19);
			this.label55.Name = "label55";
			this.label55.Size = new System.Drawing.Size(38, 13);
			this.label55.TabIndex = 6;
			this.label55.Text = "Name:";
			// 
			// txt_fyb
			// 
			this.txt_fyb.Location = new System.Drawing.Point(145, 42);
			this.txt_fyb.Name = "txt_fyb";
			this.txt_fyb.ReadOnly = true;
			this.txt_fyb.Size = new System.Drawing.Size(53, 20);
			this.txt_fyb.TabIndex = 1;
			this.txt_fyb.Text = "2480";
			this.txt_fyb.TextChanged += new System.EventHandler(this.MaterialTab);
			// 
			// Label27
			// 
			this.Label27.AutoSize = true;
			this.Label27.Location = new System.Drawing.Point(37, 45);
			this.Label27.Name = "Label27";
			this.Label27.Size = new System.Drawing.Size(102, 13);
			this.Label27.TabIndex = 0;
			this.Label27.Text = "Yield Strength, Fya :";
			// 
			// lblUnit3_F1D2
			// 
			this.lblUnit3_F1D2.AutoSize = true;
			this.lblUnit3_F1D2.Location = new System.Drawing.Point(204, 71);
			this.lblUnit3_F1D2.Name = "lblUnit3_F1D2";
			this.lblUnit3_F1D2.Size = new System.Drawing.Size(41, 13);
			this.lblUnit3_F1D2.TabIndex = 5;
			this.lblUnit3_F1D2.Text = "kg/cm²";
			// 
			// txt_fub
			// 
			this.txt_fub.Location = new System.Drawing.Point(145, 68);
			this.txt_fub.Name = "txt_fub";
			this.txt_fub.ReadOnly = true;
			this.txt_fub.Size = new System.Drawing.Size(53, 20);
			this.txt_fub.TabIndex = 4;
			this.txt_fub.Text = "4000";
			this.txt_fub.TextChanged += new System.EventHandler(this.MaterialTab);
			// 
			// Label9
			// 
			this.Label9.AutoSize = true;
			this.Label9.Location = new System.Drawing.Point(21, 71);
			this.Label9.Name = "Label9";
			this.Label9.Size = new System.Drawing.Size(118, 13);
			this.Label9.TabIndex = 3;
			this.Label9.Text = "Ultimate Strength, Fua :";
			// 
			// lblUnit2_F1D2
			// 
			this.lblUnit2_F1D2.AutoSize = true;
			this.lblUnit2_F1D2.Location = new System.Drawing.Point(204, 45);
			this.lblUnit2_F1D2.Name = "lblUnit2_F1D2";
			this.lblUnit2_F1D2.Size = new System.Drawing.Size(41, 13);
			this.lblUnit2_F1D2.TabIndex = 2;
			this.lblUnit2_F1D2.Text = "kg/cm²";
			// 
			// GroupBox7
			// 
			this.GroupBox7.Controls.Add(this.lblColumnSteelMaterial);
			this.GroupBox7.Controls.Add(this.lblPlateSteelMaterial);
			this.GroupBox7.Controls.Add(this.cboColumnSteelMaterial);
			this.GroupBox7.Controls.Add(this.label22);
			this.GroupBox7.Controls.Add(this.cboPlateSteelMaterial);
			this.GroupBox7.Controls.Add(this.label57);
			this.GroupBox7.Controls.Add(this.txt_Es);
			this.GroupBox7.Controls.Add(this.Label37);
			this.GroupBox7.Controls.Add(this.Label38);
			this.GroupBox7.Location = new System.Drawing.Point(6, 106);
			this.GroupBox7.Name = "GroupBox7";
			this.GroupBox7.Size = new System.Drawing.Size(369, 104);
			this.GroupBox7.TabIndex = 1;
			this.GroupBox7.TabStop = false;
			this.GroupBox7.Text = "Steel";
			// 
			// lblColumnSteelMaterial
			// 
			this.lblColumnSteelMaterial.AutoSize = true;
			this.lblColumnSteelMaterial.ForeColor = System.Drawing.Color.Blue;
			this.lblColumnSteelMaterial.Location = new System.Drawing.Point(235, 50);
			this.lblColumnSteelMaterial.Name = "lblColumnSteelMaterial";
			this.lblColumnSteelMaterial.Size = new System.Drawing.Size(25, 13);
			this.lblColumnSteelMaterial.TabIndex = 21;
			this.lblColumnSteelMaterial.Text = "Info";
			// 
			// lblPlateSteelMaterial
			// 
			this.lblPlateSteelMaterial.AutoSize = true;
			this.lblPlateSteelMaterial.ForeColor = System.Drawing.Color.Blue;
			this.lblPlateSteelMaterial.Location = new System.Drawing.Point(235, 23);
			this.lblPlateSteelMaterial.Name = "lblPlateSteelMaterial";
			this.lblPlateSteelMaterial.Size = new System.Drawing.Size(25, 13);
			this.lblPlateSteelMaterial.TabIndex = 18;
			this.lblPlateSteelMaterial.Text = "Info";
			// 
			// cboColumnSteelMaterial
			// 
			this.cboColumnSteelMaterial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboColumnSteelMaterial.FormattingEnabled = true;
			this.cboColumnSteelMaterial.Location = new System.Drawing.Point(145, 46);
			this.cboColumnSteelMaterial.Name = "cboColumnSteelMaterial";
			this.cboColumnSteelMaterial.Size = new System.Drawing.Size(84, 21);
			this.cboColumnSteelMaterial.TabIndex = 20;
			this.cboColumnSteelMaterial.SelectedIndexChanged += new System.EventHandler(this.cboColumnSteelMaterial_SelectedIndexChanged);
			// 
			// label22
			// 
			this.label22.AutoSize = true;
			this.label22.Location = new System.Drawing.Point(2, 50);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(137, 13);
			this.label22.TabIndex = 19;
			this.label22.Text = "Column, Brace, Shear Key :";
			// 
			// cboPlateSteelMaterial
			// 
			this.cboPlateSteelMaterial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboPlateSteelMaterial.FormattingEnabled = true;
			this.cboPlateSteelMaterial.Location = new System.Drawing.Point(145, 19);
			this.cboPlateSteelMaterial.Name = "cboPlateSteelMaterial";
			this.cboPlateSteelMaterial.Size = new System.Drawing.Size(84, 21);
			this.cboPlateSteelMaterial.TabIndex = 11;
			this.cboPlateSteelMaterial.SelectedIndexChanged += new System.EventHandler(this.cboPlateSteelMaterial_SelectedIndexChanged);
			// 
			// label57
			// 
			this.label57.AutoSize = true;
			this.label57.Location = new System.Drawing.Point(45, 23);
			this.label57.Name = "label57";
			this.label57.Size = new System.Drawing.Size(94, 13);
			this.label57.TabIndex = 10;
			this.label57.Text = "Plate and Stiffner :";
			// 
			// txt_Es
			// 
			this.txt_Es.Location = new System.Drawing.Point(145, 73);
			this.txt_Es.Name = "txt_Es";
			this.txt_Es.Size = new System.Drawing.Size(84, 20);
			this.txt_Es.TabIndex = 4;
			this.txt_Es.Text = "2.1e+6";
			this.txt_Es.TextChanged += new System.EventHandler(this.MaterialTab);
			// 
			// Label37
			// 
			this.Label37.AutoSize = true;
			this.Label37.Location = new System.Drawing.Point(12, 76);
			this.Label37.Name = "Label37";
			this.Label37.Size = new System.Drawing.Size(127, 13);
			this.Label37.TabIndex = 3;
			this.Label37.Text = "Modulus of Elasticity, Es :";
			// 
			// Label38
			// 
			this.Label38.AutoSize = true;
			this.Label38.Location = new System.Drawing.Point(235, 76);
			this.Label38.Name = "Label38";
			this.Label38.Size = new System.Drawing.Size(41, 13);
			this.Label38.TabIndex = 5;
			this.Label38.Text = "kg/cm²";
			// 
			// GroupBox3
			// 
			this.GroupBox3.Controls.Add(this.lblTransverseRebar);
			this.GroupBox3.Controls.Add(this.lblLongitudinalRebar);
			this.GroupBox3.Controls.Add(this.cboTransverseRebarMaterial);
			this.GroupBox3.Controls.Add(this.label61);
			this.GroupBox3.Controls.Add(this.cboLongitudinalRebarMaterial);
			this.GroupBox3.Controls.Add(this.label58);
			this.GroupBox3.Controls.Add(this.txt_fc);
			this.GroupBox3.Controls.Add(this.Label16);
			this.GroupBox3.Controls.Add(this.lblUnit1_F1D2);
			this.GroupBox3.Location = new System.Drawing.Point(6, 6);
			this.GroupBox3.Name = "GroupBox3";
			this.GroupBox3.Size = new System.Drawing.Size(369, 100);
			this.GroupBox3.TabIndex = 0;
			this.GroupBox3.TabStop = false;
			this.GroupBox3.Text = "Support";
			// 
			// lblTransverseRebar
			// 
			this.lblTransverseRebar.AutoSize = true;
			this.lblTransverseRebar.ForeColor = System.Drawing.Color.Blue;
			this.lblTransverseRebar.Location = new System.Drawing.Point(228, 75);
			this.lblTransverseRebar.Name = "lblTransverseRebar";
			this.lblTransverseRebar.Size = new System.Drawing.Size(25, 13);
			this.lblTransverseRebar.TabIndex = 17;
			this.lblTransverseRebar.Text = "Info";
			// 
			// lblLongitudinalRebar
			// 
			this.lblLongitudinalRebar.AutoSize = true;
			this.lblLongitudinalRebar.ForeColor = System.Drawing.Color.Blue;
			this.lblLongitudinalRebar.Location = new System.Drawing.Point(228, 48);
			this.lblLongitudinalRebar.Name = "lblLongitudinalRebar";
			this.lblLongitudinalRebar.Size = new System.Drawing.Size(25, 13);
			this.lblLongitudinalRebar.TabIndex = 16;
			this.lblLongitudinalRebar.Text = "Info";
			// 
			// cboTransverseRebarMaterial
			// 
			this.cboTransverseRebarMaterial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboTransverseRebarMaterial.FormattingEnabled = true;
			this.cboTransverseRebarMaterial.Location = new System.Drawing.Point(138, 72);
			this.cboTransverseRebarMaterial.Name = "cboTransverseRebarMaterial";
			this.cboTransverseRebarMaterial.Size = new System.Drawing.Size(84, 21);
			this.cboTransverseRebarMaterial.TabIndex = 15;
			this.cboTransverseRebarMaterial.SelectedIndexChanged += new System.EventHandler(this.cboTransverseRebarMaterial_SelectedIndexChanged);
			// 
			// label61
			// 
			this.label61.AutoSize = true;
			this.label61.Location = new System.Drawing.Point(34, 76);
			this.label61.Name = "label61";
			this.label61.Size = new System.Drawing.Size(98, 13);
			this.label61.TabIndex = 14;
			this.label61.Text = "Transverse Rebar :";
			// 
			// cboLongitudinalRebarMaterial
			// 
			this.cboLongitudinalRebarMaterial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboLongitudinalRebarMaterial.FormattingEnabled = true;
			this.cboLongitudinalRebarMaterial.Location = new System.Drawing.Point(138, 45);
			this.cboLongitudinalRebarMaterial.Name = "cboLongitudinalRebarMaterial";
			this.cboLongitudinalRebarMaterial.Size = new System.Drawing.Size(84, 21);
			this.cboLongitudinalRebarMaterial.TabIndex = 13;
			this.cboLongitudinalRebarMaterial.SelectedIndexChanged += new System.EventHandler(this.cboLongitudinalRebarMaterial_SelectedIndexChanged);
			// 
			// label58
			// 
			this.label58.AutoSize = true;
			this.label58.Location = new System.Drawing.Point(30, 49);
			this.label58.Name = "label58";
			this.label58.Size = new System.Drawing.Size(102, 13);
			this.label58.TabIndex = 12;
			this.label58.Text = "Longitudinal Rebar :";
			// 
			// txt_fc
			// 
			this.txt_fc.Location = new System.Drawing.Point(138, 19);
			this.txt_fc.Name = "txt_fc";
			this.txt_fc.Size = new System.Drawing.Size(53, 20);
			this.txt_fc.TabIndex = 1;
			this.txt_fc.Text = "250";
			this.txt_fc.TextChanged += new System.EventHandler(this.MaterialTab);
			// 
			// Label16
			// 
			this.Label16.AutoSize = true;
			this.Label16.Location = new System.Drawing.Point(16, 22);
			this.Label16.Name = "Label16";
			this.Label16.Size = new System.Drawing.Size(116, 13);
			this.Label16.TabIndex = 0;
			this.Label16.Text = "Concrete Strength, f\'c :";
			// 
			// lblUnit1_F1D2
			// 
			this.lblUnit1_F1D2.AutoSize = true;
			this.lblUnit1_F1D2.Location = new System.Drawing.Point(197, 22);
			this.lblUnit1_F1D2.Name = "lblUnit1_F1D2";
			this.lblUnit1_F1D2.Size = new System.Drawing.Size(41, 13);
			this.lblUnit1_F1D2.TabIndex = 2;
			this.lblUnit1_F1D2.Text = "kg/cm²";
			// 
			// cboShearKeyWideFlange
			// 
			this.cboShearKeyWideFlange.DropDownHeight = 93;
			this.cboShearKeyWideFlange.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboShearKeyWideFlange.FormattingEnabled = true;
			this.cboShearKeyWideFlange.IntegralHeight = false;
			this.cboShearKeyWideFlange.Location = new System.Drawing.Point(144, 43);
			this.cboShearKeyWideFlange.Name = "cboShearKeyWideFlange";
			this.cboShearKeyWideFlange.Size = new System.Drawing.Size(73, 21);
			this.cboShearKeyWideFlange.TabIndex = 43;
			this.cboShearKeyWideFlange.SelectedIndexChanged += new System.EventHandler(this.cboShearKeyWideFlange_SelectedIndexChanged);
			// 
			// rdoDesignMethodASCE7_LRFD
			// 
			this.rdoDesignMethodASCE7_LRFD.AutoSize = true;
			this.rdoDesignMethodASCE7_LRFD.Location = new System.Drawing.Point(23, 19);
			this.rdoDesignMethodASCE7_LRFD.Name = "rdoDesignMethodASCE7_LRFD";
			this.rdoDesignMethodASCE7_LRFD.Size = new System.Drawing.Size(111, 17);
			this.rdoDesignMethodASCE7_LRFD.TabIndex = 11;
			this.rdoDesignMethodASCE7_LRFD.TabStop = true;
			this.rdoDesignMethodASCE7_LRFD.Text = "ASCE7-10 (LRFD)";
			this.rdoDesignMethodASCE7_LRFD.UseVisualStyleBackColor = true;
			this.rdoDesignMethodASCE7_LRFD.CheckedChanged += new System.EventHandler(this.GlobalTab_CheckedChanged);
			// 
			// contextMenuStripImage
			// 
			this.contextMenuStripImage.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CopyImageToolStripMenuItem,
            this.ToolStripMenuItem7,
            this.SaveImageAsToolStripMenuItem});
			this.contextMenuStripImage.Name = "ContextMenuImage";
			this.contextMenuStripImage.Size = new System.Drawing.Size(160, 54);
			// 
			// CopyImageToolStripMenuItem
			// 
			this.CopyImageToolStripMenuItem.Name = "CopyImageToolStripMenuItem";
			this.CopyImageToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
			this.CopyImageToolStripMenuItem.Text = "Copy Image";
			this.CopyImageToolStripMenuItem.Click += new System.EventHandler(this.CopyImageToolStripMenuItem_Click);
			// 
			// ToolStripMenuItem7
			// 
			this.ToolStripMenuItem7.Name = "ToolStripMenuItem7";
			this.ToolStripMenuItem7.Size = new System.Drawing.Size(156, 6);
			// 
			// SaveImageAsToolStripMenuItem
			// 
			this.SaveImageAsToolStripMenuItem.Name = "SaveImageAsToolStripMenuItem";
			this.SaveImageAsToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
			this.SaveImageAsToolStripMenuItem.Text = "Save Image As...";
			this.SaveImageAsToolStripMenuItem.Click += new System.EventHandler(this.SaveImageAsToolStripMenuItem_Click);
			// 
			// TabControlMain
			// 
			this.TabControlMain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.TabControlMain.Controls.Add(this.TabPageProject);
			this.TabControlMain.Controls.Add(this.TabPageGlobal);
			this.TabControlMain.Controls.Add(this.TabPageMaterials);
			this.TabControlMain.Controls.Add(this.TabPageLoads);
			this.TabControlMain.Controls.Add(this.TabPageGeometry);
			this.TabControlMain.Controls.Add(this.TabPageAddition);
			this.TabControlMain.Controls.Add(this.TabPagePedestal);
			this.TabControlMain.Location = new System.Drawing.Point(4, 32);
			this.TabControlMain.Name = "TabControlMain";
			this.TabControlMain.SelectedIndex = 0;
			this.TabControlMain.Size = new System.Drawing.Size(389, 455);
			this.TabControlMain.TabIndex = 1;
			this.TabControlMain.SelectedIndexChanged += new System.EventHandler(this.TabControlMain_SelectedIndexChanged);
			// 
			// TabPageProject
			// 
			this.TabPageProject.BackColor = System.Drawing.Color.Transparent;
			this.TabPageProject.Controls.Add(this.GroupBox6);
			this.TabPageProject.Location = new System.Drawing.Point(4, 22);
			this.TabPageProject.Name = "TabPageProject";
			this.TabPageProject.Padding = new System.Windows.Forms.Padding(3);
			this.TabPageProject.Size = new System.Drawing.Size(381, 429);
			this.TabPageProject.TabIndex = 5;
			this.TabPageProject.Text = "Project";
			// 
			// GroupBox6
			// 
			this.GroupBox6.Controls.Add(this.Label10);
			this.GroupBox6.Controls.Add(this.txtCompany);
			this.GroupBox6.Controls.Add(this.txtNotes);
			this.GroupBox6.Controls.Add(this.Label3);
			this.GroupBox6.Controls.Add(this.Label7);
			this.GroupBox6.Controls.Add(this.txtProject);
			this.GroupBox6.Controls.Add(this.txtDescription);
			this.GroupBox6.Controls.Add(this.Label5);
			this.GroupBox6.Controls.Add(this.Label6);
			this.GroupBox6.Controls.Add(this.txtEngineer);
			this.GroupBox6.Location = new System.Drawing.Point(6, 6);
			this.GroupBox6.Name = "GroupBox6";
			this.GroupBox6.Size = new System.Drawing.Size(369, 417);
			this.GroupBox6.TabIndex = 0;
			this.GroupBox6.TabStop = false;
			this.GroupBox6.Text = "Project Information";
			// 
			// Label10
			// 
			this.Label10.AutoSize = true;
			this.Label10.Location = new System.Drawing.Point(41, 128);
			this.Label10.Name = "Label10";
			this.Label10.Size = new System.Drawing.Size(41, 13);
			this.Label10.TabIndex = 8;
			this.Label10.Text = "Notes :";
			// 
			// txtCompany
			// 
			this.txtCompany.Location = new System.Drawing.Point(84, 21);
			this.txtCompany.Name = "txtCompany";
			this.txtCompany.Size = new System.Drawing.Size(262, 20);
			this.txtCompany.TabIndex = 1;
			this.txtCompany.Text = "HEDCO";
			// 
			// txtNotes
			// 
			this.txtNotes.AcceptsReturn = true;
			this.txtNotes.Location = new System.Drawing.Point(84, 125);
			this.txtNotes.Multiline = true;
			this.txtNotes.Name = "txtNotes";
			this.txtNotes.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtNotes.Size = new System.Drawing.Size(262, 118);
			this.txtNotes.TabIndex = 9;
			this.txtNotes.WordWrap = false;
			// 
			// Label3
			// 
			this.Label3.AutoSize = true;
			this.Label3.Location = new System.Drawing.Point(25, 24);
			this.Label3.Name = "Label3";
			this.Label3.Size = new System.Drawing.Size(57, 13);
			this.Label3.TabIndex = 0;
			this.Label3.Text = "Company :";
			// 
			// Label7
			// 
			this.Label7.AutoSize = true;
			this.Label7.Location = new System.Drawing.Point(10, 102);
			this.Label7.Name = "Label7";
			this.Label7.Size = new System.Drawing.Size(72, 13);
			this.Label7.TabIndex = 6;
			this.Label7.Text = "Desceription :";
			// 
			// txtProject
			// 
			this.txtProject.Location = new System.Drawing.Point(84, 47);
			this.txtProject.Name = "txtProject";
			this.txtProject.Size = new System.Drawing.Size(262, 20);
			this.txtProject.TabIndex = 3;
			this.txtProject.Text = "Your Project Name";
			// 
			// txtDescription
			// 
			this.txtDescription.Location = new System.Drawing.Point(84, 99);
			this.txtDescription.Name = "txtDescription";
			this.txtDescription.Size = new System.Drawing.Size(262, 20);
			this.txtDescription.TabIndex = 7;
			// 
			// Label5
			// 
			this.Label5.AutoSize = true;
			this.Label5.Location = new System.Drawing.Point(36, 50);
			this.Label5.Name = "Label5";
			this.Label5.Size = new System.Drawing.Size(46, 13);
			this.Label5.TabIndex = 2;
			this.Label5.Text = "Project :";
			// 
			// Label6
			// 
			this.Label6.AutoSize = true;
			this.Label6.Location = new System.Drawing.Point(27, 76);
			this.Label6.Name = "Label6";
			this.Label6.Size = new System.Drawing.Size(55, 13);
			this.Label6.TabIndex = 4;
			this.Label6.Text = "Engineer :";
			// 
			// txtEngineer
			// 
			this.txtEngineer.Location = new System.Drawing.Point(84, 73);
			this.txtEngineer.Name = "txtEngineer";
			this.txtEngineer.Size = new System.Drawing.Size(262, 20);
			this.txtEngineer.TabIndex = 5;
			this.txtEngineer.Text = "Your Name";
			// 
			// TabPageGlobal
			// 
			this.TabPageGlobal.BackColor = System.Drawing.Color.White;
			this.TabPageGlobal.Controls.Add(this.GroupBox10);
			this.TabPageGlobal.Location = new System.Drawing.Point(4, 22);
			this.TabPageGlobal.Name = "TabPageGlobal";
			this.TabPageGlobal.Padding = new System.Windows.Forms.Padding(3);
			this.TabPageGlobal.Size = new System.Drawing.Size(381, 429);
			this.TabPageGlobal.TabIndex = 6;
			this.TabPageGlobal.Text = "Global";
			// 
			// GroupBox10
			// 
			this.GroupBox10.BackColor = System.Drawing.Color.Transparent;
			this.GroupBox10.Controls.Add(this.groupBox18);
			this.GroupBox10.Controls.Add(this.groupBox14);
			this.GroupBox10.Controls.Add(this.groupBox13);
			this.GroupBox10.Location = new System.Drawing.Point(6, 6);
			this.GroupBox10.Name = "GroupBox10";
			this.GroupBox10.Size = new System.Drawing.Size(369, 417);
			this.GroupBox10.TabIndex = 0;
			this.GroupBox10.TabStop = false;
			this.GroupBox10.Text = "Design Options";
			// 
			// groupBox18
			// 
			this.groupBox18.Controls.Add(this.rdoDesignMethodASCE7_LRFD);
			this.groupBox18.Controls.Add(this.rdoDesignMethodASCE7_ASD);
			this.groupBox18.Location = new System.Drawing.Point(6, 19);
			this.groupBox18.Name = "groupBox18";
			this.groupBox18.Size = new System.Drawing.Size(357, 50);
			this.groupBox18.TabIndex = 17;
			this.groupBox18.TabStop = false;
			this.groupBox18.Text = "Design Type";
			// 
			// groupBox14
			// 
			this.groupBox14.Controls.Add(this.rdoAISC360_16);
			this.groupBox14.Controls.Add(this.rdoAISC360_10);
			this.groupBox14.Location = new System.Drawing.Point(6, 131);
			this.groupBox14.Name = "groupBox14";
			this.groupBox14.Size = new System.Drawing.Size(357, 50);
			this.groupBox14.TabIndex = 17;
			this.groupBox14.TabStop = false;
			this.groupBox14.Text = "Steel Design (Base Plate, Shear Key)";
			// 
			// rdoAISC360_16
			// 
			this.rdoAISC360_16.AutoSize = true;
			this.rdoAISC360_16.Checked = true;
			this.rdoAISC360_16.Location = new System.Drawing.Point(199, 19);
			this.rdoAISC360_16.Name = "rdoAISC360_16";
			this.rdoAISC360_16.Size = new System.Drawing.Size(82, 17);
			this.rdoAISC360_16.TabIndex = 14;
			this.rdoAISC360_16.TabStop = true;
			this.rdoAISC360_16.Text = "AISC360-16";
			this.rdoAISC360_16.UseVisualStyleBackColor = true;
			// 
			// rdoAISC360_10
			// 
			this.rdoAISC360_10.AutoSize = true;
			this.rdoAISC360_10.Enabled = false;
			this.rdoAISC360_10.Location = new System.Drawing.Point(23, 19);
			this.rdoAISC360_10.Name = "rdoAISC360_10";
			this.rdoAISC360_10.Size = new System.Drawing.Size(82, 17);
			this.rdoAISC360_10.TabIndex = 13;
			this.rdoAISC360_10.Text = "AISC360-10";
			this.rdoAISC360_10.UseVisualStyleBackColor = true;
			// 
			// groupBox13
			// 
			this.groupBox13.Controls.Add(this.rdoACI318_19);
			this.groupBox13.Controls.Add(this.rdoACI318_14);
			this.groupBox13.Location = new System.Drawing.Point(6, 75);
			this.groupBox13.Name = "groupBox13";
			this.groupBox13.Size = new System.Drawing.Size(357, 50);
			this.groupBox13.TabIndex = 16;
			this.groupBox13.TabStop = false;
			this.groupBox13.Text = "Concrete Design (Anchor Bolt, Pedestal)";
			// 
			// rdoACI318_19
			// 
			this.rdoACI318_19.AutoSize = true;
			this.rdoACI318_19.Checked = true;
			this.rdoACI318_19.Location = new System.Drawing.Point(199, 19);
			this.rdoACI318_19.Name = "rdoACI318_19";
			this.rdoACI318_19.Size = new System.Drawing.Size(75, 17);
			this.rdoACI318_19.TabIndex = 14;
			this.rdoACI318_19.TabStop = true;
			this.rdoACI318_19.Text = "ACI318-19";
			this.rdoACI318_19.UseVisualStyleBackColor = true;
			// 
			// rdoACI318_14
			// 
			this.rdoACI318_14.AutoSize = true;
			this.rdoACI318_14.Enabled = false;
			this.rdoACI318_14.Location = new System.Drawing.Point(23, 19);
			this.rdoACI318_14.Name = "rdoACI318_14";
			this.rdoACI318_14.Size = new System.Drawing.Size(75, 17);
			this.rdoACI318_14.TabIndex = 13;
			this.rdoACI318_14.Text = "ACI318-14";
			this.rdoACI318_14.UseVisualStyleBackColor = true;
			// 
			// TabPageMaterials
			// 
			this.TabPageMaterials.BackColor = System.Drawing.Color.Transparent;
			this.TabPageMaterials.Controls.Add(this.groupBox11);
			this.TabPageMaterials.Controls.Add(this.GroupBox8);
			this.TabPageMaterials.Controls.Add(this.GroupBox7);
			this.TabPageMaterials.Controls.Add(this.GroupBox3);
			this.TabPageMaterials.Location = new System.Drawing.Point(4, 22);
			this.TabPageMaterials.Name = "TabPageMaterials";
			this.TabPageMaterials.Padding = new System.Windows.Forms.Padding(3);
			this.TabPageMaterials.Size = new System.Drawing.Size(381, 429);
			this.TabPageMaterials.TabIndex = 3;
			this.TabPageMaterials.Text = "Materials";
			// 
			// groupBox11
			// 
			this.groupBox11.Controls.Add(this.lblWeldMaterial);
			this.groupBox11.Controls.Add(this.cboWeldMaterial);
			this.groupBox11.Controls.Add(this.label21);
			this.groupBox11.Location = new System.Drawing.Point(6, 307);
			this.groupBox11.Name = "groupBox11";
			this.groupBox11.Size = new System.Drawing.Size(369, 49);
			this.groupBox11.TabIndex = 4;
			this.groupBox11.TabStop = false;
			this.groupBox11.Text = "Welding";
			// 
			// lblWeldMaterial
			// 
			this.lblWeldMaterial.AutoSize = true;
			this.lblWeldMaterial.ForeColor = System.Drawing.Color.Blue;
			this.lblWeldMaterial.Location = new System.Drawing.Point(251, 23);
			this.lblWeldMaterial.Name = "lblWeldMaterial";
			this.lblWeldMaterial.Size = new System.Drawing.Size(25, 13);
			this.lblWeldMaterial.TabIndex = 22;
			this.lblWeldMaterial.Text = "Info";
			// 
			// cboWeldMaterial
			// 
			this.cboWeldMaterial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboWeldMaterial.FormattingEnabled = true;
			this.cboWeldMaterial.Location = new System.Drawing.Point(145, 19);
			this.cboWeldMaterial.Name = "cboWeldMaterial";
			this.cboWeldMaterial.Size = new System.Drawing.Size(100, 21);
			this.cboWeldMaterial.TabIndex = 11;
			this.cboWeldMaterial.SelectedIndexChanged += new System.EventHandler(this.cboWeldMaterial_SelectedIndexChanged);
			// 
			// label21
			// 
			this.label21.AutoSize = true;
			this.label21.Location = new System.Drawing.Point(61, 23);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(78, 13);
			this.label21.TabIndex = 10;
			this.label21.Text = "Weld Material :";
			// 
			// TabPageLoads
			// 
			this.TabPageLoads.BackColor = System.Drawing.Color.White;
			this.TabPageLoads.Controls.Add(this.GroupBox9);
			this.TabPageLoads.Location = new System.Drawing.Point(4, 22);
			this.TabPageLoads.Name = "TabPageLoads";
			this.TabPageLoads.Padding = new System.Windows.Forms.Padding(3);
			this.TabPageLoads.Size = new System.Drawing.Size(381, 429);
			this.TabPageLoads.TabIndex = 2;
			this.TabPageLoads.Text = "Loading";
			// 
			// GroupBox9
			// 
			this.GroupBox9.BackColor = System.Drawing.Color.Transparent;
			this.GroupBox9.Controls.Add(this.txtLREFOverASD);
			this.GroupBox9.Controls.Add(this.label56);
			this.GroupBox9.Controls.Add(this.Label40);
			this.GroupBox9.Controls.Add(this.dgvLoadCombo);
			this.GroupBox9.Controls.Add(this.PictureBox1);
			this.GroupBox9.Location = new System.Drawing.Point(6, 6);
			this.GroupBox9.Name = "GroupBox9";
			this.GroupBox9.Size = new System.Drawing.Size(369, 417);
			this.GroupBox9.TabIndex = 0;
			this.GroupBox9.TabStop = false;
			this.GroupBox9.Text = "Base Plate and Pedestal Loadings";
			// 
			// txtLREFOverASD
			// 
			this.txtLREFOverASD.Location = new System.Drawing.Point(261, 207);
			this.txtLREFOverASD.Name = "txtLREFOverASD";
			this.txtLREFOverASD.ReadOnly = true;
			this.txtLREFOverASD.Size = new System.Drawing.Size(78, 20);
			this.txtLREFOverASD.TabIndex = 17;
			this.txtLREFOverASD.Text = "1.5";
			// 
			// label56
			// 
			this.label56.Location = new System.Drawing.Point(4, 198);
			this.label56.Name = "label56";
			this.label56.Size = new System.Drawing.Size(251, 36);
			this.label56.TabIndex = 16;
			this.label56.Text = "Load factor for converting factored/service load when switching between LRFD/ASD " +
    "code:";
			this.label56.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// Label40
			// 
			this.Label40.AutoSize = true;
			this.Label40.Location = new System.Drawing.Point(184, 390);
			this.Label40.Name = "Label40";
			this.Label40.Size = new System.Drawing.Size(179, 13);
			this.Label40.TabIndex = 1;
			this.Label40.Text = "* Loads are positive as shown below";
			// 
			// dgvLoadCombo
			// 
			this.dgvLoadCombo.AllowUserToResizeColumns = false;
			this.dgvLoadCombo.AllowUserToResizeRows = false;
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dgvLoadCombo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			this.dgvLoadCombo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvLoadCombo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colRow,
            this.colLoadCombination,
            this.colPu,
            this.colVu,
            this.colMu});
			this.dgvLoadCombo.ContextMenuStrip = this.contextMenuStripLoading;
			this.dgvLoadCombo.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
			this.dgvLoadCombo.Location = new System.Drawing.Point(5, 19);
			this.dgvLoadCombo.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.dgvLoadCombo.Name = "dgvLoadCombo";
			this.dgvLoadCombo.RowHeadersWidth = 25;
			this.dgvLoadCombo.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
			dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Yellow;
			dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.dgvLoadCombo.RowsDefaultCellStyle = dataGridViewCellStyle3;
			this.dgvLoadCombo.Size = new System.Drawing.Size(359, 171);
			this.dgvLoadCombo.TabIndex = 0;
			this.dgvLoadCombo.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvLoadCombo_CellBeginEdit);
			this.dgvLoadCombo.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLoadCombo_CellContentClick);
			this.dgvLoadCombo.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLoadCombo_CellEndEdit);
			this.dgvLoadCombo.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgvLoadCombo_RowsAdded);
			this.dgvLoadCombo.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgvLoadCombo_RowsRemoved);
			// 
			// colRow
			// 
			this.colRow.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Blue;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.colRow.DefaultCellStyle = dataGridViewCellStyle2;
			this.colRow.HeaderText = "Row";
			this.colRow.MinimumWidth = 35;
			this.colRow.Name = "colRow";
			this.colRow.ReadOnly = true;
			this.colRow.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.colRow.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.colRow.Width = 35;
			// 
			// colLoadCombination
			// 
			this.colLoadCombination.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.colLoadCombination.HeaderText = "Load Combo";
			this.colLoadCombination.MaxInputLength = 25;
			this.colLoadCombination.Name = "colLoadCombination";
			this.colLoadCombination.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.colLoadCombination.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			// 
			// colPu
			// 
			this.colPu.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			this.colPu.HeaderText = "Pu [Ton]";
			this.colPu.MaxInputLength = 8;
			this.colPu.Name = "colPu";
			this.colPu.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.colPu.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.colPu.Width = 70;
			// 
			// colVu
			// 
			this.colVu.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			this.colVu.HeaderText = "Vu [Ton]";
			this.colVu.MaxInputLength = 8;
			this.colVu.Name = "colVu";
			this.colVu.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.colVu.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.colVu.Width = 70;
			// 
			// colMu
			// 
			this.colMu.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			this.colMu.HeaderText = "Mu [T.m]";
			this.colMu.MaxInputLength = 8;
			this.colMu.Name = "colMu";
			this.colMu.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.colMu.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.colMu.Width = 70;
			// 
			// contextMenuStripLoading
			// 
			this.contextMenuStripLoading.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CopyToolStripMenuItem1,
            this.PasteToolStripMenuItem1,
            this.ToolStripMenuItem6,
            this.SelectAllToolStripMenuItem});
			this.contextMenuStripLoading.Name = "ContextMenuStripMain";
			this.contextMenuStripLoading.Size = new System.Drawing.Size(165, 76);
			// 
			// CopyToolStripMenuItem1
			// 
			this.CopyToolStripMenuItem1.Name = "CopyToolStripMenuItem1";
			this.CopyToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
			this.CopyToolStripMenuItem1.Size = new System.Drawing.Size(164, 22);
			this.CopyToolStripMenuItem1.Text = "&Copy";
			this.CopyToolStripMenuItem1.Click += new System.EventHandler(this.CopyToolStripMenuItem1_Click);
			// 
			// PasteToolStripMenuItem1
			// 
			this.PasteToolStripMenuItem1.Name = "PasteToolStripMenuItem1";
			this.PasteToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
			this.PasteToolStripMenuItem1.Size = new System.Drawing.Size(164, 22);
			this.PasteToolStripMenuItem1.Text = "&Paste";
			this.PasteToolStripMenuItem1.Click += new System.EventHandler(this.PasteToolStripMenuItem1_Click);
			// 
			// ToolStripMenuItem6
			// 
			this.ToolStripMenuItem6.Name = "ToolStripMenuItem6";
			this.ToolStripMenuItem6.Size = new System.Drawing.Size(161, 6);
			// 
			// SelectAllToolStripMenuItem
			// 
			this.SelectAllToolStripMenuItem.Name = "SelectAllToolStripMenuItem";
			this.SelectAllToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
			this.SelectAllToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
			this.SelectAllToolStripMenuItem.Text = "&Select All";
			this.SelectAllToolStripMenuItem.Click += new System.EventHandler(this.SelectAllToolStripMenuItem_Click);
			// 
			// PictureBox1
			// 
			this.PictureBox1.Image = global::Mono_Base_Plate.Properties.Resources.Loads;
			this.PictureBox1.Location = new System.Drawing.Point(0, 238);
			this.PictureBox1.Name = "PictureBox1";
			this.PictureBox1.Size = new System.Drawing.Size(222, 179);
			this.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.PictureBox1.TabIndex = 3;
			this.PictureBox1.TabStop = false;
			// 
			// TabPageGeometry
			// 
			this.TabPageGeometry.BackColor = System.Drawing.Color.Transparent;
			this.TabPageGeometry.Controls.Add(this.GroupBox2);
			this.TabPageGeometry.Controls.Add(this.GroupBox1);
			this.TabPageGeometry.Location = new System.Drawing.Point(4, 22);
			this.TabPageGeometry.Name = "TabPageGeometry";
			this.TabPageGeometry.Padding = new System.Windows.Forms.Padding(3);
			this.TabPageGeometry.Size = new System.Drawing.Size(381, 429);
			this.TabPageGeometry.TabIndex = 0;
			this.TabPageGeometry.Text = "Geometry";
			// 
			// GroupBox2
			// 
			this.GroupBox2.Controls.Add(this.GroupBox16);
			this.GroupBox2.Controls.Add(this.txt_sec_d);
			this.GroupBox2.Controls.Add(this.Label30);
			this.GroupBox2.Controls.Add(this.lblUnit22_D1);
			this.GroupBox2.Controls.Add(this.lblUnit7_D1);
			this.GroupBox2.Controls.Add(this.txt_B_BPecc);
			this.GroupBox2.Controls.Add(this.lblUnit12_D1);
			this.GroupBox2.Controls.Add(this.Label12);
			this.GroupBox2.Controls.Add(this.lblUnit21_D1);
			this.GroupBox2.Controls.Add(this.txt_aN);
			this.GroupBox2.Controls.Add(this.lblUnit11_D1);
			this.GroupBox2.Controls.Add(this.txt_B_Cecc);
			this.GroupBox2.Controls.Add(this.Label31);
			this.GroupBox2.Controls.Add(this.txt_sec_bf);
			this.GroupBox2.Controls.Add(this.lblUnit6_D1);
			this.GroupBox2.Controls.Add(this.txt_N_BPecc);
			this.GroupBox2.Controls.Add(this.Label2);
			this.GroupBox2.Controls.Add(this.txt_Np);
			this.GroupBox2.Controls.Add(this.lblUnit3_D1);
			this.GroupBox2.Controls.Add(this.lblUnit1_D1);
			this.GroupBox2.Controls.Add(this.txt_Bp);
			this.GroupBox2.Controls.Add(this.Label32);
			this.GroupBox2.Controls.Add(this.txt_N);
			this.GroupBox2.Controls.Add(this.Label17);
			this.GroupBox2.Controls.Add(this.lblUnit4_D1);
			this.GroupBox2.Controls.Add(this.txt_aB);
			this.GroupBox2.Controls.Add(this.txt_B);
			this.GroupBox2.Controls.Add(this.Label13);
			this.GroupBox2.Controls.Add(this.txt_N_Cecc);
			this.GroupBox2.Controls.Add(this.lblUnit13_D1);
			this.GroupBox2.Controls.Add(this.lblUnit2_D1);
			this.GroupBox2.Controls.Add(this.lblUnit10_D1);
			this.GroupBox2.Controls.Add(this.Label8);
			this.GroupBox2.Location = new System.Drawing.Point(6, 46);
			this.GroupBox2.Name = "GroupBox2";
			this.GroupBox2.Size = new System.Drawing.Size(369, 377);
			this.GroupBox2.TabIndex = 1;
			this.GroupBox2.TabStop = false;
			this.GroupBox2.Text = "General";
			// 
			// lblUnit10_D1
			// 
			this.lblUnit10_D1.AutoSize = true;
			this.lblUnit10_D1.Location = new System.Drawing.Point(179, 80);
			this.lblUnit10_D1.Name = "lblUnit10_D1";
			this.lblUnit10_D1.Size = new System.Drawing.Size(21, 13);
			this.lblUnit10_D1.TabIndex = 15;
			this.lblUnit10_D1.Text = "cm";
			// 
			// Label8
			// 
			this.Label8.AutoSize = true;
			this.Label8.Location = new System.Drawing.Point(13, 158);
			this.Label8.Name = "Label8";
			this.Label8.Size = new System.Drawing.Size(106, 13);
			this.Label8.TabIndex = 30;
			this.Label8.Text = "Column Eccentricity :";
			// 
			// GroupBox1
			// 
			this.GroupBox1.Controls.Add(this.cboColumnSection);
			this.GroupBox1.Controls.Add(this.lblColumnSection);
			this.GroupBox1.Controls.Add(this.btnColumnSection);
			this.GroupBox1.Location = new System.Drawing.Point(6, 2);
			this.GroupBox1.Name = "GroupBox1";
			this.GroupBox1.Size = new System.Drawing.Size(369, 44);
			this.GroupBox1.TabIndex = 0;
			this.GroupBox1.TabStop = false;
			this.GroupBox1.Text = "Column Properties";
			// 
			// cboColumnSection
			// 
			this.cboColumnSection.DropDownHeight = 93;
			this.cboColumnSection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboColumnSection.FormattingEnabled = true;
			this.cboColumnSection.IntegralHeight = false;
			this.cboColumnSection.Location = new System.Drawing.Point(241, 18);
			this.cboColumnSection.Name = "cboColumnSection";
			this.cboColumnSection.Size = new System.Drawing.Size(88, 21);
			this.cboColumnSection.TabIndex = 53;
			// 
			// lblColumnSection
			// 
			this.lblColumnSection.AutoSize = true;
			this.lblColumnSection.ForeColor = System.Drawing.Color.DodgerBlue;
			this.lblColumnSection.Location = new System.Drawing.Point(152, 21);
			this.lblColumnSection.Name = "lblColumnSection";
			this.lblColumnSection.Size = new System.Drawing.Size(81, 13);
			this.lblColumnSection.TabIndex = 7;
			this.lblColumnSection.Text = "Column Section";
			// 
			// btnColumnSection
			// 
			this.btnColumnSection.Location = new System.Drawing.Point(28, 16);
			this.btnColumnSection.Name = "btnColumnSection";
			this.btnColumnSection.Size = new System.Drawing.Size(116, 23);
			this.btnColumnSection.TabIndex = 1;
			this.btnColumnSection.Text = "Select Section";
			this.btnColumnSection.UseVisualStyleBackColor = true;
			this.btnColumnSection.Click += new System.EventHandler(this.btnColumnSection_Click);
			// 
			// TabPageAddition
			// 
			this.TabPageAddition.BackColor = System.Drawing.Color.Transparent;
			this.TabPageAddition.Controls.Add(this.GroupBox15);
			this.TabPageAddition.Controls.Add(this.GroupBox17);
			this.TabPageAddition.Controls.Add(this.gpStiffner);
			this.TabPageAddition.Location = new System.Drawing.Point(4, 22);
			this.TabPageAddition.Name = "TabPageAddition";
			this.TabPageAddition.Padding = new System.Windows.Forms.Padding(3);
			this.TabPageAddition.Size = new System.Drawing.Size(381, 429);
			this.TabPageAddition.TabIndex = 8;
			this.TabPageAddition.Text = "Additional";
			// 
			// GroupBox17
			// 
			this.GroupBox17.Controls.Add(this.cboFrictionCoeff);
			this.GroupBox17.Controls.Add(this.Label29);
			this.GroupBox17.Controls.Add(this.Label59);
			this.GroupBox17.Controls.Add(this.gpShearKeyTypes);
			this.GroupBox17.Controls.Add(this.Label44);
			this.GroupBox17.Controls.Add(this.txtShearKeyHeight);
			this.GroupBox17.Controls.Add(this.Label39);
			this.GroupBox17.Location = new System.Drawing.Point(6, 83);
			this.GroupBox17.Name = "GroupBox17";
			this.GroupBox17.Size = new System.Drawing.Size(369, 197);
			this.GroupBox17.TabIndex = 1;
			this.GroupBox17.TabStop = false;
			this.GroupBox17.Text = "Shear Key Design";
			// 
			// cboFrictionCoeff
			// 
			this.cboFrictionCoeff.DropDownHeight = 93;
			this.cboFrictionCoeff.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboFrictionCoeff.FormattingEnabled = true;
			this.cboFrictionCoeff.IntegralHeight = false;
			this.cboFrictionCoeff.Items.AddRange(new object[] {
            "0.55",
            "0.70",
            "0.90"});
			this.cboFrictionCoeff.Location = new System.Drawing.Point(236, 13);
			this.cboFrictionCoeff.Name = "cboFrictionCoeff";
			this.cboFrictionCoeff.Size = new System.Drawing.Size(54, 21);
			this.cboFrictionCoeff.TabIndex = 44;
			// 
			// Label29
			// 
			this.Label29.AutoSize = true;
			this.Label29.Location = new System.Drawing.Point(295, 16);
			this.Label29.Name = "Label29";
			this.Label29.Size = new System.Drawing.Size(21, 13);
			this.Label29.TabIndex = 49;
			this.Label29.Text = "cm";
			// 
			// Label59
			// 
			this.Label59.AutoSize = true;
			this.Label59.Location = new System.Drawing.Point(154, 16);
			this.Label59.Name = "Label59";
			this.Label59.Size = new System.Drawing.Size(78, 13);
			this.Label59.TabIndex = 47;
			this.Label59.Text = "Friction Coeff. :";
			// 
			// gpShearKeyTypes
			// 
			this.gpShearKeyTypes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gpShearKeyTypes.Controls.Add(this.Panel1);
			this.gpShearKeyTypes.Controls.Add(this.cboShearKeyWideFlange);
			this.gpShearKeyTypes.Controls.Add(this.cboShearKeyPipe);
			this.gpShearKeyTypes.Controls.Add(this.rdoShearKeyTube);
			this.gpShearKeyTypes.Controls.Add(this.rdoShearKeyWideFlange);
			this.gpShearKeyTypes.Controls.Add(this.rdoShearKeyPipe);
			this.gpShearKeyTypes.Controls.Add(this.Label47);
			this.gpShearKeyTypes.Controls.Add(this.Label48);
			this.gpShearKeyTypes.Controls.Add(this.txtFlangeThickness);
			this.gpShearKeyTypes.Controls.Add(this.Label49);
			this.gpShearKeyTypes.Controls.Add(this.Label50);
			this.gpShearKeyTypes.Controls.Add(this.txtOutsideLength);
			this.gpShearKeyTypes.Location = new System.Drawing.Point(6, 64);
			this.gpShearKeyTypes.Name = "gpShearKeyTypes";
			this.gpShearKeyTypes.Size = new System.Drawing.Size(357, 128);
			this.gpShearKeyTypes.TabIndex = 46;
			this.gpShearKeyTypes.TabStop = false;
			this.gpShearKeyTypes.Text = "Shear Key Types";
			// 
			// Panel1
			// 
			this.Panel1.Controls.Add(this.rdoShearKeyWideFlangeMinor);
			this.Panel1.Controls.Add(this.rdoShearKeyWideFlangeMajor);
			this.Panel1.Location = new System.Drawing.Point(226, 41);
			this.Panel1.Name = "Panel1";
			this.Panel1.Size = new System.Drawing.Size(128, 29);
			this.Panel1.TabIndex = 46;
			// 
			// rdoShearKeyWideFlangeMinor
			// 
			this.rdoShearKeyWideFlangeMinor.AutoSize = true;
			this.rdoShearKeyWideFlangeMinor.Location = new System.Drawing.Point(70, 3);
			this.rdoShearKeyWideFlangeMinor.Name = "rdoShearKeyWideFlangeMinor";
			this.rdoShearKeyWideFlangeMinor.Size = new System.Drawing.Size(51, 17);
			this.rdoShearKeyWideFlangeMinor.TabIndex = 45;
			this.rdoShearKeyWideFlangeMinor.Text = "Minor";
			this.rdoShearKeyWideFlangeMinor.UseVisualStyleBackColor = true;
			this.rdoShearKeyWideFlangeMinor.CheckedChanged += new System.EventHandler(this.cboShearKeyWideFlange_SelectedIndexChanged);
			// 
			// rdoShearKeyWideFlangeMajor
			// 
			this.rdoShearKeyWideFlangeMajor.AutoSize = true;
			this.rdoShearKeyWideFlangeMajor.Checked = true;
			this.rdoShearKeyWideFlangeMajor.Location = new System.Drawing.Point(13, 3);
			this.rdoShearKeyWideFlangeMajor.Name = "rdoShearKeyWideFlangeMajor";
			this.rdoShearKeyWideFlangeMajor.Size = new System.Drawing.Size(51, 17);
			this.rdoShearKeyWideFlangeMajor.TabIndex = 44;
			this.rdoShearKeyWideFlangeMajor.TabStop = true;
			this.rdoShearKeyWideFlangeMajor.Text = "Major";
			this.rdoShearKeyWideFlangeMajor.UseVisualStyleBackColor = true;
			this.rdoShearKeyWideFlangeMajor.CheckedChanged += new System.EventHandler(this.cboShearKeyWideFlange_SelectedIndexChanged);
			// 
			// rtbResult
			// 
			this.rtbResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.rtbResult.BackColor = System.Drawing.Color.White;
			this.rtbResult.Font = new System.Drawing.Font("Monospac821 BT", 8.25F);
			this.rtbResult.Location = new System.Drawing.Point(393, 370);
			this.rtbResult.Name = "rtbResult";
			this.rtbResult.ReadOnly = true;
			this.rtbResult.Size = new System.Drawing.Size(496, 117);
			this.rtbResult.TabIndex = 2;
			this.rtbResult.Text = "";
			this.rtbResult.WordWrap = false;
			// 
			// groupBox12
			// 
			this.groupBox12.Controls.Add(this.label28);
			this.groupBox12.Controls.Add(this.txtPedestalYScale);
			this.groupBox12.Controls.Add(this.label23);
			this.groupBox12.Controls.Add(this.txtPedestalXScale);
			this.groupBox12.Enabled = false;
			this.groupBox12.Location = new System.Drawing.Point(6, 6);
			this.groupBox12.Name = "groupBox12";
			this.groupBox12.Size = new System.Drawing.Size(369, 77);
			this.groupBox12.TabIndex = 0;
			this.groupBox12.TabStop = false;
			this.groupBox12.Text = "Scale";
			// 
			// label23
			// 
			this.label23.AutoSize = true;
			this.label23.Location = new System.Drawing.Point(113, 22);
			this.label23.Name = "label23";
			this.label23.Size = new System.Drawing.Size(65, 13);
			this.label23.TabIndex = 22;
			this.label23.Text = "X Direction :";
			// 
			// txtPedestalXScale
			// 
			this.txtPedestalXScale.Location = new System.Drawing.Point(184, 19);
			this.txtPedestalXScale.Name = "txtPedestalXScale";
			this.txtPedestalXScale.Size = new System.Drawing.Size(56, 20);
			this.txtPedestalXScale.TabIndex = 0;
			this.txtPedestalXScale.Text = "1.0";
			// 
			// label28
			// 
			this.label28.AutoSize = true;
			this.label28.Location = new System.Drawing.Point(113, 48);
			this.label28.Name = "label28";
			this.label28.Size = new System.Drawing.Size(65, 13);
			this.label28.TabIndex = 24;
			this.label28.Text = "Y Direction :";
			// 
			// txtPedestalYScale
			// 
			this.txtPedestalYScale.Location = new System.Drawing.Point(184, 45);
			this.txtPedestalYScale.Name = "txtPedestalYScale";
			this.txtPedestalYScale.Size = new System.Drawing.Size(56, 20);
			this.txtPedestalYScale.TabIndex = 1;
			this.txtPedestalYScale.Text = "1.0";
			// 
			// viewBox1
			// 
			this.viewBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.viewBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.viewBox1.Cursor = System.Windows.Forms.Cursors.NoMove2D;
			this.viewBox1.Location = new System.Drawing.Point(393, 1);
			this.viewBox1.Name = "viewBox1";
			this.viewBox1.Size = new System.Drawing.Size(496, 369);
			this.viewBox1.TabIndex = 34;
			this.viewBox1.TabStop = false;
			// 
			// frmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(890, 489);
			this.Controls.Add(this.TabControlMain);
			this.Controls.Add(this.viewBox1);
			this.Controls.Add(this.btnDesign);
			this.Controls.Add(this.MenuStripMain);
			this.Controls.Add(this.rtbResult);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmMain";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Mono Base Plate";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.Shown += new System.EventHandler(this.MainForm_Shown);
			this.TabPagePedestal.ResumeLayout(false);
			this.GroupBox4.ResumeLayout(false);
			this.GroupBox4.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.nud_nrB)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nud_nrN)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nud_nrs)).EndInit();
			this.GroupBox15.ResumeLayout(false);
			this.GroupBox15.PerformLayout();
			this.GroupBox16.ResumeLayout(false);
			this.GroupBox16.PerformLayout();
			this.GroupBox5.ResumeLayout(false);
			this.GroupBox5.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudBolts_nB)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nudBolts_nN)).EndInit();
			this.gpStiffner.ResumeLayout(false);
			this.gpStiffner.PerformLayout();
			this.MenuStripMain.ResumeLayout(false);
			this.MenuStripMain.PerformLayout();
			this.GroupBox8.ResumeLayout(false);
			this.GroupBox8.PerformLayout();
			this.GroupBox7.ResumeLayout(false);
			this.GroupBox7.PerformLayout();
			this.GroupBox3.ResumeLayout(false);
			this.GroupBox3.PerformLayout();
			this.contextMenuStripImage.ResumeLayout(false);
			this.TabControlMain.ResumeLayout(false);
			this.TabPageProject.ResumeLayout(false);
			this.GroupBox6.ResumeLayout(false);
			this.GroupBox6.PerformLayout();
			this.TabPageGlobal.ResumeLayout(false);
			this.GroupBox10.ResumeLayout(false);
			this.groupBox18.ResumeLayout(false);
			this.groupBox18.PerformLayout();
			this.groupBox14.ResumeLayout(false);
			this.groupBox14.PerformLayout();
			this.groupBox13.ResumeLayout(false);
			this.groupBox13.PerformLayout();
			this.TabPageMaterials.ResumeLayout(false);
			this.groupBox11.ResumeLayout(false);
			this.groupBox11.PerformLayout();
			this.TabPageLoads.ResumeLayout(false);
			this.GroupBox9.ResumeLayout(false);
			this.GroupBox9.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvLoadCombo)).EndInit();
			this.contextMenuStripLoading.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
			this.TabPageGeometry.ResumeLayout(false);
			this.GroupBox2.ResumeLayout(false);
			this.GroupBox2.PerformLayout();
			this.GroupBox1.ResumeLayout(false);
			this.GroupBox1.PerformLayout();
			this.TabPageAddition.ResumeLayout(false);
			this.GroupBox17.ResumeLayout(false);
			this.GroupBox17.PerformLayout();
			this.gpShearKeyTypes.ResumeLayout(false);
			this.gpShearKeyTypes.PerformLayout();
			this.Panel1.ResumeLayout(false);
			this.Panel1.PerformLayout();
			this.groupBox12.ResumeLayout(false);
			this.groupBox12.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.viewBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        internal TextBox txt_sec_d;
        internal Label Label30;
        internal Label lblUnit22_D1;
        internal Label lblUnit7_D1;
        internal TextBox txt_B_BPecc;
        internal Label lblUnit12_D1;
        internal Label Label12;
        internal Label lblUnit21_D1;
        internal TextBox txt_aN;
        internal TextBox txt_B_Cecc;
        internal RadioButton rdoStiffnerNone;
        internal RadioButton rdoStiffnerType2;
        internal RadioButton rdoStiffnerType1;
        internal TextBox txt_hs;
        internal Label lblUnit11_D1;
        internal Label Label34;
        internal TabPage TabPagePedestal;
        internal GroupBox GroupBox15;
        internal TextBox txtWeldSizeShearKey;
        internal Label Label51;
        internal Label Label52;
        internal ComboBox cboWeldCheck;
        internal Label Label43;
        internal TextBox txtWeldSizeBasePlate;
        internal Label Label41;
        internal RadioButton rdoWeldFilletWeld;
        internal Label Label42;
        internal RadioButton rdoWeldCJP;
        internal GroupBox GroupBox4;
        internal Label lblRebarDistX;
        internal Label lblRebarDistY;
        internal Label Label45;
        internal Label Label46;
        internal Label lblRebarArea;
        internal TextBox txt_Hp;
        internal NumericUpDown nud_nrB;
        internal NumericUpDown nud_nrN;
        internal NumericUpDown nud_nrs;
        internal TextBox txt_rsS;
        internal Label Label25;
        internal Label Label26;
        internal Label Label24;
        internal ComboBox cbo_drs;
        internal Label Label20;
        internal ComboBox cbo_dr;
        internal Label Label19;
        internal TextBox txtClearCover;
        internal Label Label1;
        internal Label Label4;
        internal Label Label15;
        internal Label Label18;
        internal GroupBox GroupBox16;
        internal Label Label53;
        internal GroupBox GroupBox5;
        internal RadioButton rdoShearByAnchorBolt;
        internal RadioButton rdoShearByShearKey;
        internal TextBox txtGroutThickness;
        internal Label Label54;
        internal Label lblBoltArea;
        internal CheckBox chkBuiltUpGroutPad;
        internal Label Label11;
        internal CheckBox chkThreadeExcluded;
        internal NumericUpDown nudBolts_nB;
        internal ComboBox cboBolts;
        internal NumericUpDown nudBolts_nN;
        internal Label Label14;
        internal Label Label33;
        internal Label Label31;
        internal ComboBox cboShearKeyPipe;
        internal RadioButton rdoShearKeyWideFlange;
        internal RadioButton rdoShearKeyPipe;
        internal Label Label47;
        internal Label Label48;
        internal TextBox txtFlangeThickness;
        internal Label Label49;
        internal Label Label50;
        internal TextBox txtOutsideLength;
        internal Label Label44;
        internal TextBox txtShearKeyHeight;
        internal Label Label39;
        internal GroupBox gpStiffner;
        internal RadioButton rdoStiffnerType3;
        internal TextBox txt_sec_bf;
        internal Label lblUnit6_D1;
        internal TextBox txt_N_BPecc;
        internal Label Label2;
        internal TextBox txt_Np;
        internal Label lblUnit3_D1;
        internal Label lblUnit1_D1;
        internal TextBox txt_Bp;
        internal Label Label32;
        internal TextBox txt_N;
        internal Label Label17;
        internal Label lblUnit4_D1;
        internal TextBox txt_aB;
        internal TextBox txt_B;
        internal Label Label13;
        internal TextBox txt_N_Cecc;
        internal Label lblUnit13_D1;
        internal RadioButton rdoShearKeyTube;
        internal ToolStripMenuItem ExitToolStripMenuItem;
        internal ToolStripMenuItem DesignToolStripMenuItem;
        internal ToolStripMenuItem RealTimeDesignToolStripMenuItem;
        internal ToolStripMenuItem DesignToolStripMenuItem1;
        internal ToolStripSeparator ToolStripMenuItem11;
        internal ToolStripMenuItem AnchorBoltTableToolStripMenuItem;
        internal ToolStripSeparator ToolStripMenuItem4;
        internal ToolStripMenuItem BracingLoadsToolStripMenuItem;
        internal ToolStripSeparator ToolStripMenuItem5;
        internal ToolStripMenuItem GetLoadsFromSAP2000ToolStripMenuItem;
        internal ToolStripMenuItem ResultsToolStripMenuItem;
        internal ToolStripMenuItem DesignDetailsToolStripMenuItem;
        internal ToolStripMenuItem InteractiveCurveToolStripMenuItem;
        internal ToolStripMenuItem OptionsToolStripMenuItem;
        internal ToolStripMenuItem AlwaysOnTopToolStripMenuItem;
        internal ToolStripMenuItem HelpToolStripMenuItem;
        internal ToolStripMenuItem AboutToolStripMenuItem;
        internal ToolTip ToolTipMain;
        internal Button btnDesign;
        internal ToolStripSeparator ToolStripMenuItem3;
        internal MenuStrip MenuStripMain;
        internal ToolStripMenuItem FileToolStripMenuItem;
        internal ToolStripMenuItem NewToolStripMenuItem;
        internal ToolStripMenuItem OpenToolStripMenuItem;
        internal ToolStripSeparator ToolStripMenuItem1;
        internal ToolStripMenuItem ImportToolStripMenuItem;
        internal ToolStripMenuItem ImportLoadToolStripMenuItem;
        internal ToolStripSeparator ToolStripMenuItem10;
        internal ToolStripMenuItem SaveToolStripMenuItem;
        internal ToolStripMenuItem SaveAsToolStripMenuItem;
        internal ToolStripSeparator ToolStripMenuItem2;
        internal ToolStripMenuItem PrintGraphicToolStripMenuItem;
        internal Label lblUnit2_D1;
        internal RadioButton rdoDesignMethodASCE7_ASD;
        internal GroupBox GroupBox8;
        internal TextBox txt_fyb;
        internal Label Label27;
        internal Label lblUnit3_F1D2;
        internal TextBox txt_fub;
        internal Label Label9;
        internal Label lblUnit2_F1D2;
        internal GroupBox GroupBox7;
        internal TextBox txt_Es;
        internal Label Label37;
        internal Label Label38;
        internal GroupBox GroupBox3;
        internal TextBox txt_fc;
        internal Label Label16;
        internal Label lblUnit1_F1D2;
        internal ComboBox cboShearKeyWideFlange;
        internal RadioButton rdoDesignMethodASCE7_LRFD;
        internal ContextMenuStrip contextMenuStripImage;
        internal ToolStripMenuItem CopyImageToolStripMenuItem;
        internal ToolStripSeparator ToolStripMenuItem7;
        internal ToolStripMenuItem SaveImageAsToolStripMenuItem;
        internal TabPage TabPageProject;
        internal GroupBox GroupBox6;
        internal Label Label10;
        internal TextBox txtCompany;
        internal TextBox txtNotes;
        internal Label Label3;
        internal Label Label7;
        internal TextBox txtProject;
        internal TextBox txtDescription;
        internal Label Label5;
        internal Label Label6;
        internal TextBox txtEngineer;
        internal TabPage TabPageGlobal;
        internal GroupBox GroupBox10;
        internal TabPage TabPageMaterials;
        internal TabPage TabPageLoads;
        internal GroupBox GroupBox9;
        internal Label Label40;
        internal DataGridView dgvLoadCombo;
        internal DataGridViewTextBoxColumn colRow;
        internal DataGridViewTextBoxColumn colLoadCombination;
        internal DataGridViewTextBoxColumn colPu;
        internal DataGridViewTextBoxColumn colVu;
        internal DataGridViewTextBoxColumn colMu;
        internal ContextMenuStrip contextMenuStripLoading;
        internal ToolStripMenuItem CopyToolStripMenuItem1;
        internal ToolStripMenuItem PasteToolStripMenuItem1;
        internal ToolStripSeparator ToolStripMenuItem6;
        internal ToolStripMenuItem SelectAllToolStripMenuItem;
        internal PictureBox PictureBox1;
        internal TabPage TabPageGeometry;
        internal GroupBox GroupBox2;
        internal Label lblUnit10_D1;
        internal Label Label8;
        internal GroupBox GroupBox1;
        internal Label lblColumnSection;
        internal Button btnColumnSection;
        internal TabPage TabPageAddition;
        internal GroupBox GroupBox17;
        internal ComboBox cboFrictionCoeff;
        internal Label Label29;
        internal Label Label59;
        internal GroupBox gpShearKeyTypes;
        internal Panel Panel1;
        internal RadioButton rdoShearKeyWideFlangeMinor;
        internal RadioButton rdoShearKeyWideFlangeMajor;
        internal RichTextBox rtbResult;
        private ToolStripMenuItem exportToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem12;
        private ToolStripMenuItem sendToAutoCADToolStripMenuItem;
        private ToolStripMenuItem CalculationSheetToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem8;
        private TabControl TabControlMain;
        internal GroupBox groupBox11;
        private ToolStripMenuItem getLoadsFromSAP2000ToolStripMenuItem1;
        private ComboBox cboAnchorBoltMaterial;
        internal Label label55;
        internal ComboBox cboColumnSection;
        private TextBox txtLREFOverASD;
        private Label label56;
        private Controls.ViewBox viewBox1;
        private ComboBox cboPlateSteelMaterial;
        internal Label label57;
        private ComboBox cboLongitudinalRebarMaterial;
        internal Label label58;
        private ComboBox cboTransverseRebarMaterial;
        internal Label label61;
        private GroupBox groupBox13;
        internal RadioButton rdoACI318_19;
        internal RadioButton rdoACI318_14;
        private GroupBox groupBox14;
        internal RadioButton rdoAISC360_16;
        internal RadioButton rdoAISC360_10;
        private GroupBox groupBox18;
        internal Label lblTransverseRebar;
        internal Label lblLongitudinalRebar;
        internal Label lblPlateSteelMaterial;
        internal Label lblColumnSteelMaterial;
        private ComboBox cboColumnSteelMaterial;
        internal Label label22;
        private ComboBox cboWeldMaterial;
        internal Label label21;
        internal Label lblWeldMaterial;
		private GroupBox groupBox12;
		internal Label label28;
		internal TextBox txtPedestalYScale;
		internal Label label23;
		internal TextBox txtPedestalXScale;
	}
}

