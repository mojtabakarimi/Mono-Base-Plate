namespace Mono_Base_Plate.Forms
{
    partial class FrmSAPLoads
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.label1 = new System.Windows.Forms.Label();
            this.lbSpecialLoadCombinations = new System.Windows.Forms.ListBox();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.Label6 = new System.Windows.Forms.Label();
            this.txtElevation = new System.Windows.Forms.TextBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.btnRun = new System.Windows.Forms.Button();
            this.btnAttachToModel = new System.Windows.Forms.Button();
            this.btnOpenExistingModel = new System.Windows.Forms.Button();
            this.Label3 = new System.Windows.Forms.Label();
            this.lbNormalLoadCombinations = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(184, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "Special Load Combinations";
            // 
            // lbSpecialLoadCombinations
            // 
            this.lbSpecialLoadCombinations.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbSpecialLoadCombinations.FormattingEnabled = true;
            this.lbSpecialLoadCombinations.Location = new System.Drawing.Point(187, 76);
            this.lbSpecialLoadCombinations.Name = "lbSpecialLoadCombinations";
            this.lbSpecialLoadCombinations.ScrollAlwaysVisible = true;
            this.lbSpecialLoadCombinations.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbSpecialLoadCombinations.Size = new System.Drawing.Size(167, 537);
            this.lbSpecialLoadCombinations.TabIndex = 24;
            this.lbSpecialLoadCombinations.SelectedIndexChanged += new System.EventHandler(this.lbNormalLoadCombinations_SelectedIndexChanged);
            // 
            // txtResult
            // 
            this.txtResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResult.BackColor = System.Drawing.Color.White;
            this.txtResult.Location = new System.Drawing.Point(360, 76);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ReadOnly = true;
            this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtResult.Size = new System.Drawing.Size(418, 542);
            this.txtResult.TabIndex = 23;
            this.txtResult.WordWrap = false;
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Location = new System.Drawing.Point(389, 41);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(153, 13);
            this.Label6.TabIndex = 20;
            this.Label6.Text = "Elevation of Objects to Export :";
            // 
            // txtElevation
            // 
            this.txtElevation.Location = new System.Drawing.Point(548, 38);
            this.txtElevation.Name = "txtElevation";
            this.txtElevation.Size = new System.Drawing.Size(68, 20);
            this.txtElevation.TabIndex = 21;
            this.txtElevation.Text = "6.60";
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(622, 41);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(15, 13);
            this.Label5.TabIndex = 22;
            this.Label5.Text = "m";
            // 
            // btnRun
            // 
            this.btnRun.Enabled = false;
            this.btnRun.Location = new System.Drawing.Point(643, 31);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(119, 33);
            this.btnRun.TabIndex = 19;
            this.btnRun.Text = "Run!";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // btnAttachToModel
            // 
            this.btnAttachToModel.Location = new System.Drawing.Point(14, 12);
            this.btnAttachToModel.Name = "btnAttachToModel";
            this.btnAttachToModel.Size = new System.Drawing.Size(119, 33);
            this.btnAttachToModel.TabIndex = 17;
            this.btnAttachToModel.Text = "Attach To Model";
            this.btnAttachToModel.UseVisualStyleBackColor = true;
            this.btnAttachToModel.Click += new System.EventHandler(this.btnAttachToModel_Click);
            // 
            // btnOpenExistingModel
            // 
            this.btnOpenExistingModel.Location = new System.Drawing.Point(142, 12);
            this.btnOpenExistingModel.Name = "btnOpenExistingModel";
            this.btnOpenExistingModel.Size = new System.Drawing.Size(119, 33);
            this.btnOpenExistingModel.TabIndex = 18;
            this.btnOpenExistingModel.Text = "Open Existing Model";
            this.btnOpenExistingModel.UseVisualStyleBackColor = true;
            this.btnOpenExistingModel.Click += new System.EventHandler(this.btnOpenExistingModel_Click);
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(11, 57);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(133, 13);
            this.Label3.TabIndex = 15;
            this.Label3.Text = "Normal Load Combinations";
            // 
            // lbNormalLoadCombinations
            // 
            this.lbNormalLoadCombinations.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbNormalLoadCombinations.FormattingEnabled = true;
            this.lbNormalLoadCombinations.Location = new System.Drawing.Point(14, 76);
            this.lbNormalLoadCombinations.Name = "lbNormalLoadCombinations";
            this.lbNormalLoadCombinations.ScrollAlwaysVisible = true;
            this.lbNormalLoadCombinations.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbNormalLoadCombinations.Size = new System.Drawing.Size(167, 537);
            this.lbNormalLoadCombinations.TabIndex = 16;
            this.lbNormalLoadCombinations.SelectedIndexChanged += new System.EventHandler(this.lbNormalLoadCombinations_SelectedIndexChanged);
            // 
            // FrmSAPLoads
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(788, 630);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbSpecialLoadCombinations);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.Label6);
            this.Controls.Add(this.txtElevation);
            this.Controls.Add(this.Label5);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.btnAttachToModel);
            this.Controls.Add(this.btnOpenExistingModel);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.lbNormalLoadCombinations);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSAPLoads";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmSAPLoads";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.ListBox lbSpecialLoadCombinations;
        internal System.Windows.Forms.TextBox txtResult;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.TextBox txtElevation;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.Button btnRun;
        internal System.Windows.Forms.Button btnAttachToModel;
        internal System.Windows.Forms.Button btnOpenExistingModel;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.ListBox lbNormalLoadCombinations;
    }
}