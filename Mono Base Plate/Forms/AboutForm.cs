using System;
using System.Management;
using System.Windows.Forms;
using Mono_Base_Plate.Class;

namespace Mono_Base_Plate.Forms
{
    public partial class frmAbout : System.Windows.Forms.Form
    {
        public frmAbout()
        {
            InitializeComponent();
        }

        private void frmAbout_Load(object sender, EventArgs e)
        {
            Text = $"About \"{Application.ProductName}\"";

            lblProgramName.Text = $"{Application.ProductName}  ({(Environment.Is64BitProcess ? "64 bit" : "32 bit")})";
            lblVersion.Text = Application.ProductVersion;
            lblLicensedTo.Text = "HEDCO";

            //============================================================================================================================================
            lblWindowsName.Text = GetOSFriendlyName();
            lblWindowsProcess.Text = Environment.Is64BitOperatingSystem
                ? "64 bit"
                : "32 bit";

            //============================================================================================================================================
            //lblTotalPhysicalMemory.Text = Math.Round( .Computer.Info.TotalPhysicalMemory / 1024 / 1024, 0).ToString() + " MB";
            //lblAvailablePhysicalMemory.Text = Math.Round(SEFD.My.MyProject.Computer.Info.AvailablePhysicalMemory / 1024 / 1024, 0).ToString() + " MB";
            lblProcessorCount.Text = Environment.ProcessorCount.ToString();

            //============================================================================================================================================
            lblDomainName.Text = Environment.UserDomainName;
            lblNetworkName.Text = Environment.MachineName;
            lblUserName.Text = Environment.UserName;
        }

        public static string GetOSFriendlyName()
        {
            var result = string.Empty;
            try
            {
                var searcher = new ManagementObjectSearcher("SELECT Caption FROM Win32_OperatingSystem");
                foreach (var o in searcher.Get())
                {
                    var os = (ManagementObject)o;
                    result = os["Caption"].ToString();
                    break;
                }
                return result;
            }
            catch (Exception e)
            {
                return "";
            }
        }
    }
}
