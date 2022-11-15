using System;
using Base_Plate_Engine.Common.Section.Shapes;
using Mono_Base_Plate.Class;
using Mono_Base_Plate.Factory;

namespace Mono_Base_Plate.Forms
{
    public partial class frmBracingLoads : System.Windows.Forms.Form
    {
        private SectionI section;

        public frmBracingLoads(SectionI section)
        {
            InitializeComponent();

            this.section = section;

            txt_H.TextChanged += txt_H_TextChanged;
            txt_Angle.TextChanged += txt_H_TextChanged;
            txtMaximumBraceForce.TextChanged += txt_H_TextChanged;
            txt_Ry.TextChanged += txt_H_TextChanged;
            txt_fy.TextChanged += txt_H_TextChanged;
            cbo_Section.SelectedIndexChanged += txt_H_TextChanged;

            rdoDirX.CheckedChanged += txt_H_TextChanged;
            rdoDirY.CheckedChanged += txt_H_TextChanged;
        }

        private void frmBracingLoads_Load(object sender, EventArgs e)
        {
            if (cbo_Section.Items.Count != 0)
            {
                return;
            }

            cbo_Section.Items.Clear();
            for (var i = 0; i < SectionPipeFactory.Items.Length; i++)
            {
                cbo_Section.Items.Add(SectionPipeFactory.Items[i].Name);
            }

            cbo_Section.Items.Add("None");
            cbo_Section.SelectedIndex = 0;
        }

        private void txt_H_TextChanged(object sender, EventArgs e)
        {
            const double tolerance = 0.000001;
            
            try
            {
                txtColumnForce.Clear();
                txtBraceCapacity.Clear();
                txt_Vmax.Clear();

                var h = Convert.ToDouble(txt_H.Text);
                var Fy = Convert.ToDouble(txt_fy.Text);
                var Ry = Convert.ToDouble(txt_Ry.Text);
                var alpha = Convert.ToDouble(txt_Angle.Text);
                var selectedIndex = cbo_Section.SelectedIndex;

                //Brace load
                var T = Convert.ToDouble(txtMaximumBraceForce.Text) * 1000;
                var V1 = 2 * (rdoDirX.Checked 
                             ? this.section.Zx
                             : this.section.Zy) * Fy / h;

                var V2 = selectedIndex == SectionPipeFactory.Items.Length
                    ? 0
                    : Ry * Fy * SectionPipeFactory.Items[selectedIndex].A * Math.Cos(alpha * Math.PI / 180);

                T = T * Math.Cos(alpha * Math.PI / 180);
                var Vu_max = Math.Abs(T) > tolerance
                    ? V1 + Math.Min(V2, T)
                    : V1 + V2;

                txtColumnForce.Text = $"{V1 / 1000:0.00}";
                txtBraceCapacity.Text = $"{V2 / 1000:0.00}";

                txt_Vmax.Text = $"{Vu_max / 1000:0.00}";
            }
            catch
            {
                ;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
