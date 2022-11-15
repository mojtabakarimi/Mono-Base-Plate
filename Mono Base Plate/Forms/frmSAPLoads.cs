using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Mono_Base_Plate.CSI;

namespace Mono_Base_Plate.Forms
{
    public partial class FrmSAPLoads : Form
    {
        public FrmSAPLoads()
        {
            InitializeComponent();
        }

        private void btnAttachToModel_Click(object sender, System.EventArgs e)
        {
            var sapModel = SapMethods.AttachModel();

            var list = SapMethods.GetLoadCombinations(ref sapModel);

            lbNormalLoadCombinations.Items.Clear();
            lbSpecialLoadCombinations.Items.Clear();

            for (var i = 0; i < list.Count; i++)
            {
                lbNormalLoadCombinations.Items.Add(list[i].Name);
                lbSpecialLoadCombinations.Items.Add(list[i].Name);
            }

            btnRun.Enabled = false;
        }

        private void btnOpenExistingModel_Click(object sender, System.EventArgs e)
        {

        }

        private void btnRun_Click(object sender, System.EventArgs e)
        {
            txtResult.Clear();

            if (lbNormalLoadCombinations.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select at least one load combination", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            var baseElevation = double.Parse(txtElevation.Text);
            var normalLoadCombos = lbNormalLoadCombinations.SelectedItems.Cast<string>().ToArray();
            var specialLoadCombos = lbSpecialLoadCombinations.SelectedItems.Cast<string>().ToArray();

            if (normalLoadCombos.Any(p => specialLoadCombos.Contains(p)))
            {
                MessageBox.Show("Duplicate selection", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var loadCombos = normalLoadCombos.Concat(specialLoadCombos).ToArray();
            List<SapMethods.PointLoads> list;
            try
            {
                list = SapMethods.GetLoads(loadCombos, baseElevation);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            var rep = new StringBuilder();
            for (var i = 0; i < list.Count; i++)
            {
                var v = Math.Sqrt(Math.Pow(list[i].F1, 2) + Math.Pow(list[i].F2, 2));
                var t = -list[i].F3;
                var m = 0.0;

                var isSpecial = specialLoadCombos.Any(p => list[i].LoadComboName == p);
                if (isSpecial)
                {
                    v = 0;
                }

                rep.AppendLine($"{list[i].PointName}-{list[i].LoadComboName}\t{t / 1000:N3}\t{v / 1000:N3}\t{m:N3}");
            }

            txtResult.Text = rep.ToString();
        }

        private void lbNormalLoadCombinations_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnRun.Enabled = true;
        }

    }
}