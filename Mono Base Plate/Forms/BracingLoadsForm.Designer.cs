using System.ComponentModel;
using System.Windows.Forms;

namespace Mono_Base_Plate.Forms
{
    partial class frmBracingLoads
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.Label5 = new System.Windows.Forms.Label();
            this.Label8 = new System.Windows.Forms.Label();
            this.txt_Ry = new System.Windows.Forms.TextBox();
            this.txtBraceCapacity = new System.Windows.Forms.TextBox();
            this.Label9 = new System.Windows.Forms.Label();
            this.Label18 = new System.Windows.Forms.Label();
            this.rdoDirX = new System.Windows.Forms.RadioButton();
            this.txt_fy = new System.Windows.Forms.TextBox();
            this.Label19 = new System.Windows.Forms.Label();
            this.rdoDirY = new System.Windows.Forms.RadioButton();
            this.txt_Angle = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.txt_Vmax = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.Label22 = new System.Windows.Forms.Label();
            this.txt_H = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label26 = new System.Windows.Forms.Label();
            this.txtColumnForce = new System.Windows.Forms.TextBox();
            this.Label11 = new System.Windows.Forms.Label();
            this.Label20 = new System.Windows.Forms.Label();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.cbo_Section = new System.Windows.Forms.ComboBox();
            this.Label25 = new System.Windows.Forms.Label();
            this.Label7 = new System.Windows.Forms.Label();
            this.txtMaximumBraceForce = new System.Windows.Forms.TextBox();
            this.Label6 = new System.Windows.Forms.Label();
            this.Label10 = new System.Windows.Forms.Label();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.gbBracedBasePlate = new System.Windows.Forms.GroupBox();
            this.GroupBox1.SuspendLayout();
            this.GroupBox2.SuspendLayout();
            this.gbBracedBasePlate.SuspendLayout();
            this.SuspendLayout();
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(26, 50);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(98, 13);
            this.Label5.TabIndex = 18;
            this.Label5.Text = "Brace Connection :";
            // 
            // Label8
            // 
            this.Label8.AutoSize = true;
            this.Label8.Location = new System.Drawing.Point(174, 98);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(26, 13);
            this.Label8.TabIndex = 24;
            this.Label8.Text = "Ton";
            // 
            // txt_Ry
            // 
            this.txt_Ry.Location = new System.Drawing.Point(109, 16);
            this.txt_Ry.MaxLength = 8;
            this.txt_Ry.Name = "txt_Ry";
            this.txt_Ry.Size = new System.Drawing.Size(59, 20);
            this.txt_Ry.TabIndex = 0;
            this.txt_Ry.Text = "1.6";
            // 
            // txtBraceCapacity
            // 
            this.txtBraceCapacity.Location = new System.Drawing.Point(109, 95);
            this.txtBraceCapacity.MaxLength = 8;
            this.txtBraceCapacity.Name = "txtBraceCapacity";
            this.txtBraceCapacity.ReadOnly = true;
            this.txtBraceCapacity.Size = new System.Drawing.Size(59, 20);
            this.txtBraceCapacity.TabIndex = 4;
            this.txtBraceCapacity.Text = "0";
            // 
            // Label9
            // 
            this.Label9.AutoSize = true;
            this.Label9.Location = new System.Drawing.Point(22, 98);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(85, 13);
            this.Label9.TabIndex = 22;
            this.Label9.Text = "Brace Capacity :";
            // 
            // Label18
            // 
            this.Label18.AutoSize = true;
            this.Label18.Location = new System.Drawing.Point(81, 19);
            this.Label18.Name = "Label18";
            this.Label18.Size = new System.Drawing.Size(26, 13);
            this.Label18.TabIndex = 3;
            this.Label18.Text = "Ry :";
            // 
            // rdoDirX
            // 
            this.rdoDirX.AutoSize = true;
            this.rdoDirX.Checked = true;
            this.rdoDirX.Location = new System.Drawing.Point(130, 46);
            this.rdoDirX.Name = "rdoDirX";
            this.rdoDirX.Size = new System.Drawing.Size(77, 17);
            this.rdoDirX.TabIndex = 1;
            this.rdoDirX.TabStop = true;
            this.rdoDirX.Text = "X Direction";
            this.rdoDirX.UseVisualStyleBackColor = true;
            this.rdoDirX.CheckedChanged += new System.EventHandler(this.txt_H_TextChanged);
            // 
            // txt_fy
            // 
            this.txt_fy.Location = new System.Drawing.Point(109, 42);
            this.txt_fy.MaxLength = 8;
            this.txt_fy.Name = "txt_fy";
            this.txt_fy.Size = new System.Drawing.Size(59, 20);
            this.txt_fy.TabIndex = 1;
            this.txt_fy.Text = "2400";
            // 
            // Label19
            // 
            this.Label19.AutoSize = true;
            this.Label19.Location = new System.Drawing.Point(421, 18);
            this.Label19.Name = "Label19";
            this.Label19.Size = new System.Drawing.Size(119, 13);
            this.Label19.TabIndex = 9;
            this.Label19.Text = "Degree (by the Horizon)";
            // 
            // rdoDirY
            // 
            this.rdoDirY.AutoSize = true;
            this.rdoDirY.Location = new System.Drawing.Point(130, 69);
            this.rdoDirY.Name = "rdoDirY";
            this.rdoDirY.Size = new System.Drawing.Size(77, 17);
            this.rdoDirY.TabIndex = 2;
            this.rdoDirY.Text = "Y Direction";
            this.rdoDirY.UseVisualStyleBackColor = true;
            this.rdoDirY.CheckedChanged += new System.EventHandler(this.txt_H_TextChanged);
            // 
            // txt_Angle
            // 
            this.txt_Angle.Location = new System.Drawing.Point(356, 15);
            this.txt_Angle.MaxLength = 8;
            this.txt_Angle.Name = "txt_Angle";
            this.txt_Angle.Size = new System.Drawing.Size(59, 20);
            this.txt_Angle.TabIndex = 4;
            this.txt_Angle.Text = "45";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(421, 267);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(26, 13);
            this.Label2.TabIndex = 17;
            this.Label2.Text = "Ton";
            // 
            // txt_Vmax
            // 
            this.txt_Vmax.BackColor = System.Drawing.Color.White;
            this.txt_Vmax.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Vmax.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txt_Vmax.Location = new System.Drawing.Point(326, 264);
            this.txt_Vmax.MaxLength = 8;
            this.txt_Vmax.Name = "txt_Vmax";
            this.txt_Vmax.ReadOnly = true;
            this.txt_Vmax.Size = new System.Drawing.Size(89, 20);
            this.txt_Vmax.TabIndex = 7;
            this.txt_Vmax.Text = "0";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(281, 267);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(39, 13);
            this.Label1.TabIndex = 15;
            this.Label1.Text = "Vmax :";
            // 
            // Label22
            // 
            this.Label22.AutoSize = true;
            this.Label22.Location = new System.Drawing.Point(195, 22);
            this.Label22.Name = "Label22";
            this.Label22.Size = new System.Drawing.Size(21, 13);
            this.Label22.TabIndex = 2;
            this.Label22.Text = "cm";
            // 
            // txt_H
            // 
            this.txt_H.Location = new System.Drawing.Point(130, 19);
            this.txt_H.MaxLength = 8;
            this.txt_H.Name = "txt_H";
            this.txt_H.Size = new System.Drawing.Size(59, 20);
            this.txt_H.TabIndex = 0;
            this.txt_H.Text = "215";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(245, 305);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(86, 45);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(21, 13);
            this.Label4.TabIndex = 5;
            this.Label4.Text = "fy :";
            // 
            // Label26
            // 
            this.Label26.AutoSize = true;
            this.Label26.Location = new System.Drawing.Point(27, 71);
            this.Label26.Name = "Label26";
            this.Label26.Size = new System.Drawing.Size(80, 13);
            this.Label26.TabIndex = 12;
            this.Label26.Text = "Brace Section :";
            // 
            // txtColumnForce
            // 
            this.txtColumnForce.Location = new System.Drawing.Point(130, 114);
            this.txtColumnForce.MaxLength = 8;
            this.txtColumnForce.Name = "txtColumnForce";
            this.txtColumnForce.ReadOnly = true;
            this.txtColumnForce.Size = new System.Drawing.Size(59, 20);
            this.txtColumnForce.TabIndex = 3;
            this.txtColumnForce.Text = "0";
            // 
            // Label11
            // 
            this.Label11.AutoSize = true;
            this.Label11.Location = new System.Drawing.Point(50, 117);
            this.Label11.Name = "Label11";
            this.Label11.Size = new System.Drawing.Size(78, 13);
            this.Label11.TabIndex = 26;
            this.Label11.Text = "Column Force :";
            // 
            // Label20
            // 
            this.Label20.AutoSize = true;
            this.Label20.Location = new System.Drawing.Point(283, 18);
            this.Label20.Name = "Label20";
            this.Label20.Size = new System.Drawing.Size(71, 13);
            this.Label20.TabIndex = 7;
            this.Label20.Text = "Brace Angle :";
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.Label8);
            this.GroupBox1.Controls.Add(this.txt_Ry);
            this.GroupBox1.Controls.Add(this.txtBraceCapacity);
            this.GroupBox1.Controls.Add(this.Label9);
            this.GroupBox1.Controls.Add(this.Label18);
            this.GroupBox1.Controls.Add(this.txt_fy);
            this.GroupBox1.Controls.Add(this.Label4);
            this.GroupBox1.Controls.Add(this.cbo_Section);
            this.GroupBox1.Controls.Add(this.Label26);
            this.GroupBox1.Location = new System.Drawing.Point(247, 100);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(293, 148);
            this.GroupBox1.TabIndex = 6;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Capacity";
            // 
            // cbo_Section
            // 
            this.cbo_Section.DropDownHeight = 93;
            this.cbo_Section.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_Section.FormattingEnabled = true;
            this.cbo_Section.IntegralHeight = false;
            this.cbo_Section.ItemHeight = 13;
            this.cbo_Section.Location = new System.Drawing.Point(109, 68);
            this.cbo_Section.MaxDropDownItems = 7;
            this.cbo_Section.Name = "cbo_Section";
            this.cbo_Section.Size = new System.Drawing.Size(86, 21);
            this.cbo_Section.TabIndex = 3;
            // 
            // Label25
            // 
            this.Label25.AutoSize = true;
            this.Label25.Location = new System.Drawing.Point(57, 22);
            this.Label25.Name = "Label25";
            this.Label25.Size = new System.Drawing.Size(71, 13);
            this.Label25.TabIndex = 0;
            this.Label25.Text = "Story Height :";
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.Location = new System.Drawing.Point(174, 21);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(26, 13);
            this.Label7.TabIndex = 21;
            this.Label7.Text = "Ton";
            // 
            // txtMaximumBraceForce
            // 
            this.txtMaximumBraceForce.Location = new System.Drawing.Point(109, 18);
            this.txtMaximumBraceForce.MaxLength = 8;
            this.txtMaximumBraceForce.Name = "txtMaximumBraceForce";
            this.txtMaximumBraceForce.Size = new System.Drawing.Size(59, 20);
            this.txtMaximumBraceForce.TabIndex = 0;
            this.txtMaximumBraceForce.Text = "0";
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Location = new System.Drawing.Point(16, 21);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(87, 13);
            this.Label6.TabIndex = 14;
            this.Label6.Text = "Maximum Force :";
            // 
            // Label10
            // 
            this.Label10.AutoSize = true;
            this.Label10.Location = new System.Drawing.Point(195, 117);
            this.Label10.Name = "Label10";
            this.Label10.Size = new System.Drawing.Size(26, 13);
            this.Label10.TabIndex = 27;
            this.Label10.Text = "Ton";
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.Label7);
            this.GroupBox2.Controls.Add(this.txtMaximumBraceForce);
            this.GroupBox2.Controls.Add(this.Label6);
            this.GroupBox2.Location = new System.Drawing.Point(247, 50);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(293, 44);
            this.GroupBox2.TabIndex = 5;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "Maximum Brace Force due to amplified combinations";
            // 
            // gbBracedBasePlate
            // 
            this.gbBracedBasePlate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbBracedBasePlate.Controls.Add(this.Label10);
            this.gbBracedBasePlate.Controls.Add(this.GroupBox2);
            this.gbBracedBasePlate.Controls.Add(this.txtColumnForce);
            this.gbBracedBasePlate.Controls.Add(this.Label11);
            this.gbBracedBasePlate.Controls.Add(this.Label20);
            this.gbBracedBasePlate.Controls.Add(this.GroupBox1);
            this.gbBracedBasePlate.Controls.Add(this.Label5);
            this.gbBracedBasePlate.Controls.Add(this.rdoDirX);
            this.gbBracedBasePlate.Controls.Add(this.Label19);
            this.gbBracedBasePlate.Controls.Add(this.rdoDirY);
            this.gbBracedBasePlate.Controls.Add(this.txt_Angle);
            this.gbBracedBasePlate.Controls.Add(this.Label2);
            this.gbBracedBasePlate.Controls.Add(this.txt_Vmax);
            this.gbBracedBasePlate.Controls.Add(this.Label1);
            this.gbBracedBasePlate.Controls.Add(this.Label22);
            this.gbBracedBasePlate.Controls.Add(this.txt_H);
            this.gbBracedBasePlate.Controls.Add(this.Label25);
            this.gbBracedBasePlate.Location = new System.Drawing.Point(7, 4);
            this.gbBracedBasePlate.Name = "gbBracedBasePlate";
            this.gbBracedBasePlate.Size = new System.Drawing.Size(555, 297);
            this.gbBracedBasePlate.TabIndex = 2;
            this.gbBracedBasePlate.TabStop = false;
            // 
            // frmBracingLoads
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 332);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.gbBracedBasePlate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBracingLoads";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Bracing Loads";
            this.Load += new System.EventHandler(this.frmBracingLoads_Load);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox2.PerformLayout();
            this.gbBracedBasePlate.ResumeLayout(false);
            this.gbBracedBasePlate.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Label Label5;
        internal Label Label8;
        internal TextBox txt_Ry;
        internal TextBox txtBraceCapacity;
        internal Label Label9;
        internal Label Label18;
        internal RadioButton rdoDirX;
        internal TextBox txt_fy;
        internal Label Label19;
        internal RadioButton rdoDirY;
        internal TextBox txt_Angle;
        internal Label Label2;
        internal TextBox txt_Vmax;
        internal Label Label1;
        internal Label Label22;
        internal TextBox txt_H;
        internal Button btnClose;
        internal Label Label4;
        internal Label Label26;
        internal TextBox txtColumnForce;
        internal Label Label11;
        internal Label Label20;
        internal GroupBox GroupBox1;
        internal ComboBox cbo_Section;
        internal Label Label25;
        internal Label Label7;
        internal TextBox txtMaximumBraceForce;
        internal Label Label6;
        internal Label Label10;
        internal GroupBox GroupBox2;
        internal GroupBox gbBracedBasePlate;
    }
}