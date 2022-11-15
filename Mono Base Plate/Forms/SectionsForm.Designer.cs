using System.ComponentModel;
using System.Windows.Forms;

namespace Mono_Base_Plate.Forms
{
    partial class frmSections
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
            var dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            var dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            var dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            var dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            var dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            var dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            var dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            var dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            var dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            var dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            var dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnSelect = new System.Windows.Forms.Button();
            this.col_ry = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_rx = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Zy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Zx = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Sy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Sx = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnCancel = new System.Windows.Forms.Button();
            this.col_Iy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_A = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Section_tw = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Section_tf = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Section_bf = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Section_h = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_IX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvSections = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSections)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSelect
            // 
            this.btnSelect.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnSelect.Location = new System.Drawing.Point(349, 371);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(75, 23);
            this.btnSelect.TabIndex = 27;
            this.btnSelect.Text = "Select";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // col_ry
            // 
            this.col_ry.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle1.Format = "N3";
            this.col_ry.DefaultCellStyle = dataGridViewCellStyle1;
            this.col_ry.HeaderText = "ry [cm]";
            this.col_ry.MinimumWidth = 60;
            this.col_ry.Name = "col_ry";
            this.col_ry.ReadOnly = true;
            this.col_ry.Width = 60;
            // 
            // col_rx
            // 
            this.col_rx.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle2.Format = "N3";
            this.col_rx.DefaultCellStyle = dataGridViewCellStyle2;
            this.col_rx.HeaderText = "rx [cm]";
            this.col_rx.MinimumWidth = 60;
            this.col_rx.Name = "col_rx";
            this.col_rx.ReadOnly = true;
            this.col_rx.Width = 60;
            // 
            // col_Zy
            // 
            this.col_Zy.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle3.Format = "N1";
            this.col_Zy.DefaultCellStyle = dataGridViewCellStyle3;
            this.col_Zy.HeaderText = "Zy [cm3]";
            this.col_Zy.MinimumWidth = 60;
            this.col_Zy.Name = "col_Zy";
            this.col_Zy.ReadOnly = true;
            this.col_Zy.Width = 60;
            // 
            // col_Zx
            // 
            this.col_Zx.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle4.Format = "N1";
            this.col_Zx.DefaultCellStyle = dataGridViewCellStyle4;
            this.col_Zx.HeaderText = "Zx [cm3]";
            this.col_Zx.MinimumWidth = 60;
            this.col_Zx.Name = "col_Zx";
            this.col_Zx.ReadOnly = true;
            this.col_Zx.Width = 60;
            // 
            // col_Sy
            // 
            this.col_Sy.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle5.Format = "N1";
            this.col_Sy.DefaultCellStyle = dataGridViewCellStyle5;
            this.col_Sy.HeaderText = "Sy [cm3]";
            this.col_Sy.MinimumWidth = 60;
            this.col_Sy.Name = "col_Sy";
            this.col_Sy.ReadOnly = true;
            this.col_Sy.Width = 60;
            // 
            // col_Sx
            // 
            this.col_Sx.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle6.Format = "N1";
            this.col_Sx.DefaultCellStyle = dataGridViewCellStyle6;
            this.col_Sx.HeaderText = "Sx [cm3]";
            this.col_Sx.MinimumWidth = 60;
            this.col_Sx.Name = "col_Sx";
            this.col_Sx.ReadOnly = true;
            this.col_Sx.Width = 60;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(430, 371);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 28;
            this.btnCancel.Text = "Quit";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // col_Iy
            // 
            this.col_Iy.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle7.Format = "N0";
            this.col_Iy.DefaultCellStyle = dataGridViewCellStyle7;
            this.col_Iy.HeaderText = "Iy [cm4]";
            this.col_Iy.MinimumWidth = 60;
            this.col_Iy.Name = "col_Iy";
            this.col_Iy.ReadOnly = true;
            this.col_Iy.Width = 60;
            // 
            // col_A
            // 
            this.col_A.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle8.Format = "N2";
            dataGridViewCellStyle8.NullValue = null;
            this.col_A.DefaultCellStyle = dataGridViewCellStyle8;
            this.col_A.HeaderText = "A [cm2]";
            this.col_A.MinimumWidth = 60;
            this.col_A.Name = "col_A";
            this.col_A.ReadOnly = true;
            this.col_A.Width = 60;
            // 
            // col_Section_tw
            // 
            this.col_Section_tw.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.col_Section_tw.HeaderText = "tw [cm]";
            this.col_Section_tw.Name = "col_Section_tw";
            this.col_Section_tw.ReadOnly = true;
            this.col_Section_tw.Width = 50;
            // 
            // col_Section_tf
            // 
            this.col_Section_tf.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.col_Section_tf.HeaderText = "tf [cm]";
            this.col_Section_tf.Name = "col_Section_tf";
            this.col_Section_tf.ReadOnly = true;
            this.col_Section_tf.Width = 50;
            // 
            // col_Section_bf
            // 
            this.col_Section_bf.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.col_Section_bf.HeaderText = "bf [cm]";
            this.col_Section_bf.Name = "col_Section_bf";
            this.col_Section_bf.ReadOnly = true;
            this.col_Section_bf.Width = 50;
            // 
            // col_Section_h
            // 
            this.col_Section_h.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.col_Section_h.HeaderText = "h [cm]";
            this.col_Section_h.Name = "col_Section_h";
            this.col_Section_h.ReadOnly = true;
            this.col_Section_h.Width = 50;
            // 
            // colName
            // 
            this.colName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colName.HeaderText = "Section Name";
            this.colName.MinimumWidth = 80;
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            // 
            // col_IX
            // 
            this.col_IX.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle9.Format = "N0";
            this.col_IX.DefaultCellStyle = dataGridViewCellStyle9;
            this.col_IX.HeaderText = "Ix [cm4]";
            this.col_IX.MinimumWidth = 60;
            this.col_IX.Name = "col_IX";
            this.col_IX.ReadOnly = true;
            this.col_IX.Width = 60;
            // 
            // dgvSections
            // 
            this.dgvSections.AllowUserToAddRows = false;
            this.dgvSections.AllowUserToDeleteRows = false;
            this.dgvSections.AllowUserToResizeColumns = false;
            this.dgvSections.AllowUserToResizeRows = false;
            this.dgvSections.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSections.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvSections.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSections.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colName,
            this.col_Section_h,
            this.col_Section_bf,
            this.col_Section_tf,
            this.col_Section_tw,
            this.col_A,
            this.col_IX,
            this.col_Iy,
            this.col_Sx,
            this.col_Sy,
            this.col_Zx,
            this.col_Zy,
            this.col_rx,
            this.col_ry});
            this.dgvSections.Location = new System.Drawing.Point(4, 4);
            this.dgvSections.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dgvSections.MultiSelect = false;
            this.dgvSections.Name = "dgvSections";
            this.dgvSections.ReadOnly = true;
            this.dgvSections.RowHeadersVisible = false;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.Yellow;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.dgvSections.RowsDefaultCellStyle = dataGridViewCellStyle11;
            this.dgvSections.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSections.Size = new System.Drawing.Size(846, 360);
            this.dgvSections.TabIndex = 26;
            this.dgvSections.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSections_CellContentClick);
            this.dgvSections.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSections_CellContentDoubleClick);
            // 
            // frmSections
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 398);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.dgvSections);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(400, 200);
            this.Name = "frmSections";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "User Section";
            this.Load += new System.EventHandler(this.frmSections_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSections)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal Button btnSelect;
        internal DataGridViewTextBoxColumn col_ry;
        internal DataGridViewTextBoxColumn col_rx;
        internal DataGridViewTextBoxColumn col_Zy;
        internal DataGridViewTextBoxColumn col_Zx;
        internal DataGridViewTextBoxColumn col_Sy;
        internal DataGridViewTextBoxColumn col_Sx;
        internal Button btnCancel;
        internal DataGridViewTextBoxColumn col_Iy;
        internal DataGridViewTextBoxColumn col_A;
        internal DataGridViewTextBoxColumn col_Section_tw;
        internal DataGridViewTextBoxColumn col_Section_tf;
        internal DataGridViewTextBoxColumn col_Section_bf;
        internal DataGridViewTextBoxColumn col_Section_h;
        internal DataGridViewTextBoxColumn colName;
        internal DataGridViewTextBoxColumn col_IX;
        internal DataGridView dgvSections;
    }
}