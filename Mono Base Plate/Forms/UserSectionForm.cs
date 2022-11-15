using System;
using System.Windows.Forms;
using Base_Plate_Engine.Common.Section.Shapes;
using Mono_Base_Plate.Factory;

namespace Mono_Base_Plate.Forms
{
    public partial class frmUserSection : System.Windows.Forms.Form
    {
        public frmUserSection()
        {
            InitializeComponent();
        }

        private void frmUserSection_Load(object sender, EventArgs e)
        {
            txt_d.Text = $"{SectionIFactory.Items[SectionIFactory.Items.Length - 1].h}";
            txt_bf.Text = $"{SectionIFactory.Items[SectionIFactory.Items.Length - 1].bf}";
            txt_tf.Text = $"{SectionIFactory.Items[SectionIFactory.Items.Length - 1].tf}";
            txt_tw.Text = $"{SectionIFactory.Items[SectionIFactory.Items.Length - 1].tw}";
            txt_r.Text = $"{SectionIFactory.Items[SectionIFactory.Items.Length - 1].r}";

            btnOk.Select();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                var name = SectionIFactory.Items[SectionIFactory.Items.Length - 1].Name;

                var h = Convert.ToSingle(txt_d.Text);
                var bf = Convert.ToSingle(txt_bf.Text);
                var tf = Convert.ToSingle(txt_tf.Text);
                var tw = Convert.ToSingle(txt_tw.Text);
                var kc = Convert.ToSingle(txt_r.Text);

                var sec = SectionI.Create(name, h, bf, tf, tw, kc);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
