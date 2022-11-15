using System.ComponentModel;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Mono_Base_Plate.Forms
{
    partial class frmInteractiveCurve
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
            var chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            var legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            var series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            var series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            var series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.ChartInteractiveCurve = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.ContextMenuImage = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.CopyImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem7 = new System.Windows.Forms.ToolStripSeparator();
            this.SaveImageAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.colMoment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAxialForce = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnCloase = new System.Windows.Forms.Button();
            this.rdoNoPhi = new System.Windows.Forms.RadioButton();
            this.rdoPhi = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.ChartInteractiveCurve)).BeginInit();
            this.ContextMenuImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // ChartInteractiveCurve
            // 
            this.ChartInteractiveCurve.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea1.AxisY.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartArea1.AxisY.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartArea1.Name = "ChartArea1";
            this.ChartInteractiveCurve.ChartAreas.Add(chartArea1);
            this.ChartInteractiveCurve.ContextMenuStrip = this.ContextMenuImage;
            legend1.Name = "Legend1";
            this.ChartInteractiveCurve.Legends.Add(legend1);
            this.ChartInteractiveCurve.Location = new System.Drawing.Point(6, 4);
            this.ChartInteractiveCurve.Name = "ChartInteractiveCurve";
            series1.BorderWidth = 2;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.IsVisibleInLegend = false;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            series1.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            series2.BorderWidth = 2;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Color = System.Drawing.Color.DarkGray;
            series2.IsVisibleInLegend = false;
            series2.Legend = "Legend1";
            series2.Name = "Series2";
            series3.BorderWidth = 2;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastPoint;
            series3.Color = System.Drawing.Color.Magenta;
            series3.IsVisibleInLegend = false;
            series3.Legend = "Legend1";
            series3.MarkerSize = 8;
            series3.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Cross;
            series3.Name = "Series3";
            series3.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright;
            this.ChartInteractiveCurve.Series.Add(series1);
            this.ChartInteractiveCurve.Series.Add(series2);
            this.ChartInteractiveCurve.Series.Add(series3);
            this.ChartInteractiveCurve.Size = new System.Drawing.Size(557, 425);
            this.ChartInteractiveCurve.TabIndex = 16;
            this.ChartInteractiveCurve.Text = "Chart1";
            // 
            // ContextMenuImage
            // 
            this.ContextMenuImage.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CopyImageToolStripMenuItem,
            this.ToolStripMenuItem7,
            this.SaveImageAsToolStripMenuItem});
            this.ContextMenuImage.Name = "ContextMenuImage";
            this.ContextMenuImage.Size = new System.Drawing.Size(160, 76);
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
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.AllowUserToResizeColumns = false;
            this.dgvData.AllowUserToResizeRows = false;
            this.dgvData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMoment,
            this.colAxialForce});
            this.dgvData.Location = new System.Drawing.Point(574, 6);
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.RowHeadersVisible = false;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(204, 406);
            this.dgvData.TabIndex = 17;
            // 
            // colMoment
            // 
            this.colMoment.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colMoment.HeaderText = "Moment";
            this.colMoment.MinimumWidth = 80;
            this.colMoment.Name = "colMoment";
            this.colMoment.ReadOnly = true;
            this.colMoment.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colMoment.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colAxialForce
            // 
            this.colAxialForce.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.colAxialForce.HeaderText = "Axial Force";
            this.colAxialForce.MinimumWidth = 80;
            this.colAxialForce.Name = "colAxialForce";
            this.colAxialForce.ReadOnly = true;
            this.colAxialForce.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colAxialForce.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colAxialForce.Width = 80;
            // 
            // btnCloase
            // 
            this.btnCloase.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCloase.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCloase.Location = new System.Drawing.Point(356, 436);
            this.btnCloase.Name = "btnCloase";
            this.btnCloase.Size = new System.Drawing.Size(75, 23);
            this.btnCloase.TabIndex = 18;
            this.btnCloase.Text = "Close";
            this.btnCloase.UseVisualStyleBackColor = true;
            this.btnCloase.Click += new System.EventHandler(this.btnCloase_Click);
            // 
            // rdoNoPhi
            // 
            this.rdoNoPhi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.rdoNoPhi.AutoSize = true;
            this.rdoNoPhi.Location = new System.Drawing.Point(655, 434);
            this.rdoNoPhi.Name = "rdoNoPhi";
            this.rdoNoPhi.Size = new System.Drawing.Size(63, 17);
            this.rdoNoPhi.TabIndex = 20;
            this.rdoNoPhi.TabStop = true;
            this.rdoNoPhi.Text = "No - Phi";
            this.rdoNoPhi.UseVisualStyleBackColor = true;
            // 
            // rdoPhi
            // 
            this.rdoPhi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.rdoPhi.AutoSize = true;
            this.rdoPhi.Location = new System.Drawing.Point(586, 434);
            this.rdoPhi.Name = "rdoPhi";
            this.rdoPhi.Size = new System.Drawing.Size(40, 17);
            this.rdoPhi.TabIndex = 19;
            this.rdoPhi.TabStop = true;
            this.rdoPhi.Text = "Phi";
            this.rdoPhi.UseVisualStyleBackColor = true;
            this.rdoPhi.CheckedChanged += new System.EventHandler(this.rdoPhi_CheckedChanged);
            // 
            // frmInteractiveCurve
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 462);
            this.Controls.Add(this.ChartInteractiveCurve);
            this.Controls.Add(this.dgvData);
            this.Controls.Add(this.btnCloase);
            this.Controls.Add(this.rdoNoPhi);
            this.Controls.Add(this.rdoPhi);
            this.MinimizeBox = false;
            this.Name = "frmInteractiveCurve";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Interactive Curve";
            this.Load += new System.EventHandler(this.frmInteractiveCurve_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ChartInteractiveCurve)).EndInit();
            this.ContextMenuImage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal Chart ChartInteractiveCurve;
        internal ContextMenuStrip ContextMenuImage;
        internal ToolStripMenuItem CopyImageToolStripMenuItem;
        internal ToolStripSeparator ToolStripMenuItem7;
        internal ToolStripMenuItem SaveImageAsToolStripMenuItem;
        internal DataGridView dgvData;
        internal DataGridViewTextBoxColumn colMoment;
        internal DataGridViewTextBoxColumn colAxialForce;
        internal Button btnCloase;
        internal RadioButton rdoNoPhi;
        internal RadioButton rdoPhi;
    }
}