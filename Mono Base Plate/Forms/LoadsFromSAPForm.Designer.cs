using System.ComponentModel;
using System.Windows.Forms;

namespace Mono_Base_Plate.Forms
{
    partial class frmLoadsFromSAP
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
            this.dgvJoints = new System.Windows.Forms.DataGridView();
            this.colType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colJointsList = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBrace = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAttachToSAP = new System.Windows.Forms.Button();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.lbRegularLoadCombos = new System.Windows.Forms.ListBox();
            this.cbRegularLoadCombinationCheckAll = new System.Windows.Forms.CheckBox();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.GroupBox3 = new System.Windows.Forms.GroupBox();
            this.lbSpecialLoadCombos = new System.Windows.Forms.ListBox();
            this.cbSpecialLoadCombinationCheckAll = new System.Windows.Forms.CheckBox();
            this.btnSaveBaseLoads = new System.Windows.Forms.Button();
            this.btnOpenSAP = new System.Windows.Forms.Button();
            this.btnGetTypes = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvJoints)).BeginInit();
            this.GroupBox1.SuspendLayout();
            this.GroupBox2.SuspendLayout();
            this.GroupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvJoints
            // 
            this.dgvJoints.AllowUserToAddRows = false;
            this.dgvJoints.AllowUserToDeleteRows = false;
            this.dgvJoints.AllowUserToOrderColumns = true;
            this.dgvJoints.AllowUserToResizeColumns = false;
            this.dgvJoints.AllowUserToResizeRows = false;
            this.dgvJoints.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvJoints.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colType,
            this.colJointsList,
            this.colColumn,
            this.colBrace});
            this.dgvJoints.Location = new System.Drawing.Point(3, 15);
            this.dgvJoints.Name = "dgvJoints";
            this.dgvJoints.RowHeadersVisible = false;
            this.dgvJoints.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvJoints.Size = new System.Drawing.Size(252, 297);
            this.dgvJoints.TabIndex = 0;
            this.dgvJoints.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvJoints_CellContentClick);
            this.dgvJoints.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvJoints_CellEndEdit);
            // 
            // colType
            // 
            this.colType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridViewCellStyle1.NullValue = "Type1";
            this.colType.DefaultCellStyle = dataGridViewCellStyle1;
            this.colType.HeaderText = "Type";
            this.colType.Name = "colType";
            this.colType.ReadOnly = true;
            this.colType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.colType.Width = 56;
            // 
            // colJointsList
            // 
            this.colJointsList.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colJointsList.HeaderText = "Joint Name";
            this.colJointsList.Name = "colJointsList";
            this.colJointsList.ReadOnly = true;
            this.colJointsList.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colJointsList.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colColumn
            // 
            this.colColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.colColumn.HeaderText = "Column";
            this.colColumn.MinimumWidth = 50;
            this.colColumn.Name = "colColumn";
            this.colColumn.ReadOnly = true;
            this.colColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colColumn.Width = 50;
            // 
            // colBrace
            // 
            this.colBrace.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colBrace.DefaultCellStyle = dataGridViewCellStyle2;
            this.colBrace.HeaderText = "Brace";
            this.colBrace.MinimumWidth = 40;
            this.colBrace.Name = "colBrace";
            this.colBrace.ReadOnly = true;
            this.colBrace.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colBrace.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colBrace.Width = 40;
            // 
            // btnAttachToSAP
            // 
            this.btnAttachToSAP.Location = new System.Drawing.Point(5, 5);
            this.btnAttachToSAP.Name = "btnAttachToSAP";
            this.btnAttachToSAP.Size = new System.Drawing.Size(94, 55);
            this.btnAttachToSAP.TabIndex = 0;
            this.btnAttachToSAP.Text = "Attach To SAP2000 Model";
            this.btnAttachToSAP.UseVisualStyleBackColor = true;
            this.btnAttachToSAP.Click += new System.EventHandler(this.btnAttachToSAP_Click);
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.lbRegularLoadCombos);
            this.GroupBox1.Controls.Add(this.cbRegularLoadCombinationCheckAll);
            this.GroupBox1.Location = new System.Drawing.Point(270, 61);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(155, 318);
            this.GroupBox1.TabIndex = 5;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Regular Load Combo.";
            // 
            // lbRegularLoadCombos
            // 
            this.lbRegularLoadCombos.FormattingEnabled = true;
            this.lbRegularLoadCombos.Location = new System.Drawing.Point(6, 19);
            this.lbRegularLoadCombos.Name = "lbRegularLoadCombos";
            this.lbRegularLoadCombos.ScrollAlwaysVisible = true;
            this.lbRegularLoadCombos.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbRegularLoadCombos.Size = new System.Drawing.Size(143, 277);
            this.lbRegularLoadCombos.TabIndex = 0;
            // 
            // cbRegularLoadCombinationCheckAll
            // 
            this.cbRegularLoadCombinationCheckAll.AutoSize = true;
            this.cbRegularLoadCombinationCheckAll.Location = new System.Drawing.Point(6, 298);
            this.cbRegularLoadCombinationCheckAll.Name = "cbRegularLoadCombinationCheckAll";
            this.cbRegularLoadCombinationCheckAll.Size = new System.Drawing.Size(70, 17);
            this.cbRegularLoadCombinationCheckAll.TabIndex = 1;
            this.cbRegularLoadCombinationCheckAll.Text = "Select All";
            this.cbRegularLoadCombinationCheckAll.UseVisualStyleBackColor = true;
            this.cbRegularLoadCombinationCheckAll.CheckedChanged += new System.EventHandler(this.cbRegularLoadCombinationCheckAll_CheckedChanged);
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.dgvJoints);
            this.GroupBox2.Location = new System.Drawing.Point(5, 61);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(259, 318);
            this.GroupBox2.TabIndex = 4;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "Joint Name List";
            // 
            // GroupBox3
            // 
            this.GroupBox3.Controls.Add(this.lbSpecialLoadCombos);
            this.GroupBox3.Controls.Add(this.cbSpecialLoadCombinationCheckAll);
            this.GroupBox3.Location = new System.Drawing.Point(431, 61);
            this.GroupBox3.Name = "GroupBox3";
            this.GroupBox3.Size = new System.Drawing.Size(155, 318);
            this.GroupBox3.TabIndex = 6;
            this.GroupBox3.TabStop = false;
            this.GroupBox3.Text = "Special Load Combo.";
            // 
            // lbSpecialLoadCombos
            // 
            this.lbSpecialLoadCombos.FormattingEnabled = true;
            this.lbSpecialLoadCombos.Location = new System.Drawing.Point(6, 19);
            this.lbSpecialLoadCombos.Name = "lbSpecialLoadCombos";
            this.lbSpecialLoadCombos.ScrollAlwaysVisible = true;
            this.lbSpecialLoadCombos.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbSpecialLoadCombos.Size = new System.Drawing.Size(143, 277);
            this.lbSpecialLoadCombos.TabIndex = 0;
            // 
            // cbSpecialLoadCombinationCheckAll
            // 
            this.cbSpecialLoadCombinationCheckAll.AutoSize = true;
            this.cbSpecialLoadCombinationCheckAll.Location = new System.Drawing.Point(6, 298);
            this.cbSpecialLoadCombinationCheckAll.Name = "cbSpecialLoadCombinationCheckAll";
            this.cbSpecialLoadCombinationCheckAll.Size = new System.Drawing.Size(70, 17);
            this.cbSpecialLoadCombinationCheckAll.TabIndex = 1;
            this.cbSpecialLoadCombinationCheckAll.Text = "Select All";
            this.cbSpecialLoadCombinationCheckAll.UseVisualStyleBackColor = true;
            this.cbSpecialLoadCombinationCheckAll.CheckedChanged += new System.EventHandler(this.cbSpecialLoadCombinationCheckAll_CheckedChanged);
            // 
            // btnSaveBaseLoads
            // 
            this.btnSaveBaseLoads.Enabled = false;
            this.btnSaveBaseLoads.Location = new System.Drawing.Point(305, 5);
            this.btnSaveBaseLoads.Name = "btnSaveBaseLoads";
            this.btnSaveBaseLoads.Size = new System.Drawing.Size(94, 55);
            this.btnSaveBaseLoads.TabIndex = 3;
            this.btnSaveBaseLoads.Text = "Save Base Loads";
            this.btnSaveBaseLoads.UseVisualStyleBackColor = true;
            this.btnSaveBaseLoads.Click += new System.EventHandler(this.btnSaveBaseLoads_Click);
            // 
            // btnOpenSAP
            // 
            this.btnOpenSAP.Location = new System.Drawing.Point(105, 5);
            this.btnOpenSAP.Name = "btnOpenSAP";
            this.btnOpenSAP.Size = new System.Drawing.Size(94, 55);
            this.btnOpenSAP.TabIndex = 1;
            this.btnOpenSAP.Text = "Open SAP2000 Model";
            this.btnOpenSAP.UseVisualStyleBackColor = true;
            this.btnOpenSAP.Click += new System.EventHandler(this.btnOpenSAP_Click);
            // 
            // btnGetTypes
            // 
            this.btnGetTypes.Enabled = false;
            this.btnGetTypes.Location = new System.Drawing.Point(205, 5);
            this.btnGetTypes.Name = "btnGetTypes";
            this.btnGetTypes.Size = new System.Drawing.Size(94, 55);
            this.btnGetTypes.TabIndex = 2;
            this.btnGetTypes.Text = "Get Types";
            this.btnGetTypes.UseVisualStyleBackColor = true;
            this.btnGetTypes.Click += new System.EventHandler(this.btnGetTypes_Click);
            // 
            // frmLoadsFromSAP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 382);
            this.Controls.Add(this.btnGetTypes);
            this.Controls.Add(this.btnOpenSAP);
            this.Controls.Add(this.btnSaveBaseLoads);
            this.Controls.Add(this.btnAttachToSAP);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.GroupBox2);
            this.Controls.Add(this.GroupBox3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLoadsFromSAP";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Get Loads From SAP2000";
            this.Load += new System.EventHandler(this.frmLoadsFromSAP_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvJoints)).EndInit();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox3.ResumeLayout(false);
            this.GroupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal DataGridView dgvJoints;
        internal DataGridViewTextBoxColumn colType;
        internal DataGridViewTextBoxColumn colJointsList;
        internal DataGridViewTextBoxColumn colColumn;
        internal DataGridViewTextBoxColumn colBrace;
        internal Button btnAttachToSAP;
        internal GroupBox GroupBox1;
        internal ListBox lbRegularLoadCombos;
        internal CheckBox cbRegularLoadCombinationCheckAll;
        internal GroupBox GroupBox2;
        internal GroupBox GroupBox3;
        internal ListBox lbSpecialLoadCombos;
        internal CheckBox cbSpecialLoadCombinationCheckAll;
        internal Button btnSaveBaseLoads;
        internal Button btnOpenSAP;
        internal Button btnGetTypes;
    }
}