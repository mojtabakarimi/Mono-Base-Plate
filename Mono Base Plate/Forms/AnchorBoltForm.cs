using System;
using Base_Plate_Engine.Common;
using Mono_Base_Plate.Factory;

namespace Mono_Base_Plate.Forms
{
    public partial class frmAnchorBolt : System.Windows.Forms.Form
    {
        public frmAnchorBolt()
        {
            InitializeComponent();
        }

        private void frmAnchorBolt_Load(object sender, EventArgs e)
        {
            dgvData.Rows.Clear();
            for (var i = 0; i < AnchorBoltFactory.Items.Length; i++)
            {
                dgvData.Rows.Add();

                dgvData.Rows[i].Cells[colBoltDia.Index].Value = (AnchorBoltFactory.Items[i].da * 10).ToString("0");
                dgvData.Rows[i].Cells[colNetArea.Index].Value = (AnchorBoltFactory.Items[i].Ase * 100).ToString("0.0");
                dgvData.Rows[i].Cells[colArea.Index].Value = (AnchorBoltFactory.Items[i].As0 * 100).ToString("0.0");

                dgvData.Rows[i].Cells[colH.Index].Value = (AnchorBoltFactory.Items[i].H * 10).ToString("0.0");
                dgvData.Rows[i].Cells[colSL.Index].Value = (AnchorBoltFactory.Items[i].SL * 10).ToString("0.0");
                dgvData.Rows[i].Cells[colD.Index].Value = (AnchorBoltFactory.Items[i].D * 10).ToString("0.0");
                dgvData.Rows[i].Cells[colW.Index].Value = (AnchorBoltFactory.Items[i].W * 10).ToString("0.0");
                dgvData.Rows[i].Cells[colT.Index].Value = (AnchorBoltFactory.Items[i].T * 10).ToString("0.0");
                dgvData.Rows[i].Cells[cole.Index].Value = (AnchorBoltFactory.Items[i].e * 10).ToString("0.0");
                dgvData.Rows[i].Cells[colS.Index].Value = (AnchorBoltFactory.Items[i].S * 10).ToString("0.0");

            }
        }
    }
}
