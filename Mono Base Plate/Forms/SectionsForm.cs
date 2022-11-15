using System;
using System.Windows.Forms;
using Base_Plate_Engine.Common.Section.Shapes;
using Mono_Base_Plate.Class;
using Mono_Base_Plate.Factory;

namespace Mono_Base_Plate.Forms
{
    public partial class frmSections : System.Windows.Forms.Form
    {
        public int SelectedIndex { get; private set; }

        public frmSections(int selectedIndex)
        {
            InitializeComponent();

            this.SelectedIndex = selectedIndex;
        }

        private void frmSections_Load(object sender, EventArgs e)
        {
            dgvSections.Rows.Clear();

            for (var i = 0; i < SectionIFactory.Items.Length - 1; i++)
            {
                var section = SectionIFactory.Items[i];
                dgvSections.Rows.Add();

                dgvSections.Rows[i].Cells[colName.Index].Value = section.Name;
                dgvSections.Rows[i].Cells[col_Section_h.Index].Value = section.h;
                dgvSections.Rows[i].Cells[col_Section_bf.Index].Value = section.bf;
                dgvSections.Rows[i].Cells[col_Section_tf.Index].Value = section.tf;
                dgvSections.Rows[i].Cells[col_Section_tw.Index].Value = section.tw;

                dgvSections.Rows[i].Cells[col_A.Index].Value = section.A;
                dgvSections.Rows[i].Cells[col_IX.Index].Value = section.Ix;
                dgvSections.Rows[i].Cells[col_Iy.Index].Value = section.Iy;
                dgvSections.Rows[i].Cells[col_Sx.Index].Value = section.Sx;
                dgvSections.Rows[i].Cells[col_Sy.Index].Value = section.Sy;
                dgvSections.Rows[i].Cells[col_Zx.Index].Value = section.Zx;
                dgvSections.Rows[i].Cells[col_Zy.Index].Value = section.Zy;
                dgvSections.Rows[i].Cells[col_rx.Index].Value = section.rx;
                dgvSections.Rows[i].Cells[col_ry.Index].Value = section.ry;
            }

            dgvSections.FirstDisplayedScrollingRowIndex = this.SelectedIndex;
            dgvSections.Rows[this.SelectedIndex].Selected = true;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            SelectedIndex = dgvSections.SelectedRows[0].Index;

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void dgvSections_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvSections_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            SelectedIndex = e.RowIndex;

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
