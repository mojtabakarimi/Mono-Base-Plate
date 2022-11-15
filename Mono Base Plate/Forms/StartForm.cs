using System;
using System.Reflection;

namespace Mono_Base_Plate.Forms
{
    public partial class frmStart : System.Windows.Forms.Form
    {
        public frmStart()
        {
            InitializeComponent();
        }

        private void frmStart_Load(object sender, EventArgs e)
        {
            var version = Assembly.GetEntryAssembly().GetName().Version;

            lblProgramName.Text += $" v{version.Major}{'.'}{version.Minor}{'.'}{version.Build}";
        }

        private void TimerMain_Tick(object sender, EventArgs e)
        {
            TimerMain.Enabled = false;
            this.Close();
        }
    }
}
