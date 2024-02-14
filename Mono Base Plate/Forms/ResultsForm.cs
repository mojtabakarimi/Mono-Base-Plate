using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Base_Plate_Engine.Design;

namespace Mono_Base_Plate.Forms
{
    public partial class frmResults : System.Windows.Forms.Form
    {
        private DesignResult[] DesignResults { get; }
        private BasePlateInput BasePlateInput { get; }
        private IList<BasePlateLoad> LoadsList { get; }

        public string Results { get; set; }

        public frmResults(DesignResult[] designResults, BasePlateInput basePlateInput, IList<BasePlateLoad> LoadsList)
        {
            InitializeComponent();

            this.DesignResults = designResults;
            this.BasePlateInput = basePlateInput;
            this.LoadsList = LoadsList;
        }

        private void frmResults_Load(object sender, EventArgs e)
        {
            //txtResults.Text = Results;
            //txtResults.SelectionStart = txtResults.TextLength;

            dgvResults.Rows.Clear();
            for (var i = 0; i < DesignResults.Length; i++)
            {
                dgvResults.Rows.Add();

                dgvResults.Rows[i].Cells[colRow.Index].Value = i + 1;

                dgvResults.Rows[i].Cells[colCombination.Index].Value = LoadsList[i].Name;
                dgvResults.Rows[i].Cells[colPu.Index].Value = Math.Round(LoadsList[i].Pu / 1000, 2);
                dgvResults.Rows[i].Cells[colVu.Index].Value = Math.Round(LoadsList[i].Vux / 1000, 2);
                dgvResults.Rows[i].Cells[colMu.Index].Value = Math.Round(LoadsList[i].Muy / 1000, 2);

                dgvResults.Rows[i].Cells[colThickness.Index].Value = Math.Round(DesignResults[i].t, 3);
                dgvResults.Rows[i].Cells[colBoltRatio.Index].Value = Math.Round(DesignResults[i].BoltRatio, 3);
            }

            dgvResults.Rows.Add();
            dgvResults.Rows[DesignResults.Length].Cells[colRow.Index].Value = DesignResults.Length + 1;
            dgvResults.Rows[DesignResults.Length].Cells[colCombination.Index].Value = "Overall";
            dgvResults.Rows[DesignResults.Length].Cells[colThickness.Index].Value = Math.Round(DesignResults.Max(p => p.t), 3);
            dgvResults.Rows[DesignResults.Length].Cells[colBoltRatio.Index].Value = Math.Round(DesignResults.Max(p => p.BoltRatio), 3);


            for (var i = 0; i < dgvResults.RowCount; i++)
            {
                dgvResults.Rows[i].Selected = false;
            }

            dgvResults.Rows[DesignResults.Length].Selected = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmResults_Shown(object sender, EventArgs e)
        {
            txtResults.ScrollToCaret();
        }
    }
}
