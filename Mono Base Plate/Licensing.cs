using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mono_Base_Plate
{
    public class Licensing
    {
        public static void CheckExpire()
        {
            if ((DateTime.Now.Date - new DateTime(2024, 1, 1)).TotalDays > 0)
            {
                throw new Exception($"Your program version is out of date!\r\nPlease contact your administrator to upgrade the program");
            }

            string[] lines;
            try
            {
                lines = File.ReadAllLines(@"\\192.168.0.44\st\(Department Assets)\Engineering Softwares\MyProgramsPermissions");
            }
            catch
            {
                try
                {
                    lines = File.ReadAllLines(@"\\W10-ST-33\Permission\MyProgramsPermissions");
                }
                catch
                {
                    throw new Exception($"Network Error!\r\nAuthentication Error Occurred");
                }
            }

            foreach (var line in lines)
            {
                var parts = line.Split(new[] { "\t" }, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length != 2)
                {
                    continue;
                }
                if (parts[0] == Application.ProductName && parts[1] == "23")
                {
                    return;
                }
            }

            throw new Exception($"Your program version has expired!\r\nPlease contact your administrator to get new version");
        }

        public static void Contribute()
        {
            if (Environment.UserName.ToLower() == "karimi.mojtaba")
            {
                return;
            }
            try
            {
                File.AppendAllText(@"\\W10-ST-33\Shared Folder\Contribute\Results", $"{Environment.UserName}\t{Application.ProductName}\t{DateTime.Now:MM/dd/yyyy}\t{DateTime.Now:HH:mm:ss}\r\n");
            }
            catch (Exception)
            {
            }
        }
    }
}
