using System.ComponentModel;
using System.Windows.Forms;

namespace Mono_Base_Plate.Forms
{
    partial class frmUserSection
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.Label10 = new System.Windows.Forms.Label();
            this.Label9 = new System.Windows.Forms.Label();
            this.Label8 = new System.Windows.Forms.Label();
            this.Label7 = new System.Windows.Forms.Label();
            this.Label6 = new System.Windows.Forms.Label();
            this.txt_r = new System.Windows.Forms.TextBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.txt_tw = new System.Windows.Forms.TextBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.txt_tf = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.txt_bf = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.txt_d = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.Pic = new System.Windows.Forms.PictureBox();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.Pic)).BeginInit();
            this.GroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(58, 246);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnOk.Location = new System.Drawing.Point(58, 217);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 8;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // Label10
            // 
            this.Label10.AutoSize = true;
            this.Label10.Location = new System.Drawing.Point(121, 130);
            this.Label10.Name = "Label10";
            this.Label10.Size = new System.Drawing.Size(21, 13);
            this.Label10.TabIndex = 14;
            this.Label10.Text = "cm";
            // 
            // Label9
            // 
            this.Label9.AutoSize = true;
            this.Label9.Location = new System.Drawing.Point(121, 104);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(21, 13);
            this.Label9.TabIndex = 13;
            this.Label9.Text = "cm";
            // 
            // Label8
            // 
            this.Label8.AutoSize = true;
            this.Label8.Location = new System.Drawing.Point(121, 78);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(21, 13);
            this.Label8.TabIndex = 12;
            this.Label8.Text = "cm";
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.Location = new System.Drawing.Point(121, 52);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(21, 13);
            this.Label7.TabIndex = 11;
            this.Label7.Text = "cm";
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Location = new System.Drawing.Point(121, 26);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(21, 13);
            this.Label6.TabIndex = 10;
            this.Label6.Text = "cm";
            // 
            // txt_r
            // 
            this.txt_r.Enabled = false;
            this.txt_r.Location = new System.Drawing.Point(57, 127);
            this.txt_r.Name = "txt_r";
            this.txt_r.Size = new System.Drawing.Size(58, 20);
            this.txt_r.TabIndex = 8;
            this.txt_r.Text = "0";
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(35, 130);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(16, 13);
            this.Label5.TabIndex = 9;
            this.Label5.Text = "r :";
            // 
            // txt_tw
            // 
            this.txt_tw.Location = new System.Drawing.Point(57, 101);
            this.txt_tw.Name = "txt_tw";
            this.txt_tw.Size = new System.Drawing.Size(58, 20);
            this.txt_tw.TabIndex = 6;
            this.txt_tw.Text = "1";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(27, 104);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(24, 13);
            this.Label4.TabIndex = 7;
            this.Label4.Text = "tw :";
            // 
            // txt_tf
            // 
            this.txt_tf.Location = new System.Drawing.Point(57, 75);
            this.txt_tf.Name = "txt_tf";
            this.txt_tf.Size = new System.Drawing.Size(58, 20);
            this.txt_tf.TabIndex = 4;
            this.txt_tf.Text = "1.2";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(32, 78);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(19, 13);
            this.Label3.TabIndex = 5;
            this.Label3.Text = "tf :";
            // 
            // txt_bf
            // 
            this.txt_bf.Location = new System.Drawing.Point(57, 49);
            this.txt_bf.Name = "txt_bf";
            this.txt_bf.Size = new System.Drawing.Size(58, 20);
            this.txt_bf.TabIndex = 2;
            this.txt_bf.Text = "25";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(29, 52);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(22, 13);
            this.Label2.TabIndex = 3;
            this.Label2.Text = "bf :";
            // 
            // txt_d
            // 
            this.txt_d.Location = new System.Drawing.Point(57, 23);
            this.txt_d.Name = "txt_d";
            this.txt_d.Size = new System.Drawing.Size(58, 20);
            this.txt_d.TabIndex = 0;
            this.txt_d.Text = "30";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(32, 26);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(19, 13);
            this.Label1.TabIndex = 1;
            this.Label1.Text = "h :";
            // 
            // Pic
            // 
            this.Pic.BackColor = System.Drawing.Color.White;
            this.Pic.Location = new System.Drawing.Point(198, 6);
            this.Pic.Name = "Pic";
            this.Pic.Size = new System.Drawing.Size(332, 291);
            this.Pic.TabIndex = 7;
            this.Pic.TabStop = false;
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.Label10);
            this.GroupBox1.Controls.Add(this.Label9);
            this.GroupBox1.Controls.Add(this.Label8);
            this.GroupBox1.Controls.Add(this.Label7);
            this.GroupBox1.Controls.Add(this.Label6);
            this.GroupBox1.Controls.Add(this.txt_r);
            this.GroupBox1.Controls.Add(this.Label5);
            this.GroupBox1.Controls.Add(this.txt_tw);
            this.GroupBox1.Controls.Add(this.Label4);
            this.GroupBox1.Controls.Add(this.txt_tf);
            this.GroupBox1.Controls.Add(this.Label3);
            this.GroupBox1.Controls.Add(this.txt_bf);
            this.GroupBox1.Controls.Add(this.Label2);
            this.GroupBox1.Controls.Add(this.txt_d);
            this.GroupBox1.Controls.Add(this.Label1);
            this.GroupBox1.Location = new System.Drawing.Point(10, 6);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(182, 174);
            this.GroupBox1.TabIndex = 6;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "General";
            // 
            // frmUserSection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 315);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.Pic);
            this.Controls.Add(this.GroupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmUserSection";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "User Section";
            this.Load += new System.EventHandler(this.frmUserSection_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Pic)).EndInit();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Button btnCancel;
        internal Button btnOk;
        internal Label Label10;
        internal Label Label9;
        internal Label Label8;
        internal Label Label7;
        internal Label Label6;
        internal TextBox txt_r;
        internal Label Label5;
        internal TextBox txt_tw;
        internal Label Label4;
        internal TextBox txt_tf;
        internal Label Label3;
        internal TextBox txt_bf;
        internal Label Label2;
        internal TextBox txt_d;
        internal Label Label1;
        internal PictureBox Pic;
        internal GroupBox GroupBox1;
    }
}