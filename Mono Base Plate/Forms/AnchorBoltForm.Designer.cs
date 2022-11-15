using System.ComponentModel;
using System.Windows.Forms;

namespace Mono_Base_Plate.Forms
{
    partial class frmAnchorBolt
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
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.colBoltDia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNetArea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colArea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colW = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cole = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.AllowUserToResizeColumns = false;
            this.dgvData.AllowUserToResizeRows = false;
            this.dgvData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colBoltDia,
            this.colNetArea,
            this.colArea,
            this.colH,
            this.colSL,
            this.colD,
            this.colW,
            this.colT,
            this.cole,
            this.colS});
            this.dgvData.Location = new System.Drawing.Point(6, 5);
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.RowHeadersVisible = false;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(541, 337);
            this.dgvData.TabIndex = 3;
            // 
            // colBoltDia
            // 
            this.colBoltDia.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colBoltDia.HeaderText = "Bolt Dia.  [mm]";
            this.colBoltDia.MinimumWidth = 50;
            this.colBoltDia.Name = "colBoltDia";
            this.colBoltDia.ReadOnly = true;
            this.colBoltDia.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colBoltDia.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colNetArea
            // 
            this.colNetArea.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.colNetArea.HeaderText = "As [mm2]";
            this.colNetArea.Name = "colNetArea";
            this.colNetArea.ReadOnly = true;
            this.colNetArea.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colNetArea.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colNetArea.Width = 56;
            // 
            // colArea
            // 
            this.colArea.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.colArea.HeaderText = "As0 [mm2]";
            this.colArea.Name = "colArea";
            this.colArea.ReadOnly = true;
            this.colArea.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colArea.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colArea.Width = 62;
            // 
            // colH
            // 
            this.colH.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.colH.HeaderText = "H [mm]";
            this.colH.Name = "colH";
            this.colH.ReadOnly = true;
            this.colH.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colH.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colH.Width = 46;
            // 
            // colSL
            // 
            this.colSL.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.colSL.HeaderText = "SL [mm]";
            this.colSL.Name = "colSL";
            this.colSL.ReadOnly = true;
            this.colSL.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colSL.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colSL.Width = 51;
            // 
            // colD
            // 
            this.colD.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.colD.HeaderText = "D [mm]";
            this.colD.Name = "colD";
            this.colD.ReadOnly = true;
            this.colD.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colD.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colD.Width = 46;
            // 
            // colW
            // 
            this.colW.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.colW.HeaderText = "W [mm]";
            this.colW.Name = "colW";
            this.colW.ReadOnly = true;
            this.colW.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colW.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colW.Width = 49;
            // 
            // colT
            // 
            this.colT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.colT.HeaderText = "T [mm]";
            this.colT.Name = "colT";
            this.colT.ReadOnly = true;
            this.colT.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colT.Width = 45;
            // 
            // cole
            // 
            this.cole.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.cole.HeaderText = "e [mm]";
            this.cole.Name = "cole";
            this.cole.ReadOnly = true;
            this.cole.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.cole.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.cole.Width = 44;
            // 
            // colS
            // 
            this.colS.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.colS.HeaderText = "S [mm]";
            this.colS.Name = "colS";
            this.colS.ReadOnly = true;
            this.colS.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colS.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colS.Width = 45;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(239, 348);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // frmAnchorBolt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 376);
            this.Controls.Add(this.dgvData);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAnchorBolt";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Anchor Bolt";
            this.Load += new System.EventHandler(this.frmAnchorBolt_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal DataGridView dgvData;
        internal DataGridViewTextBoxColumn colBoltDia;
        internal DataGridViewTextBoxColumn colNetArea;
        internal DataGridViewTextBoxColumn colArea;
        internal DataGridViewTextBoxColumn colH;
        internal DataGridViewTextBoxColumn colSL;
        internal DataGridViewTextBoxColumn colD;
        internal DataGridViewTextBoxColumn colW;
        internal DataGridViewTextBoxColumn colT;
        internal DataGridViewTextBoxColumn cole;
        internal DataGridViewTextBoxColumn colS;
        internal Button btnClose;
    }
}