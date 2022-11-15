using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using Base_Plate_Engine.Design;

namespace Mono_Base_Plate.Forms
{
    public partial class frmInteractiveCurve : System.Windows.Forms.Form
    {
        private int PointCount;
        private double[] icM;
        private double[] icP;
        private double[] icM_phi;
        private double[] icP_phi;

        public BasePlateInput BasePlateInput { get; set; }

        public frmInteractiveCurve()
        {
            InitializeComponent();
        }

        private void frmInteractiveCurve_Load(object sender, EventArgs e)
        {
            //var InteractiveCurve = new InteractiveCurves[input.InteractiveCurve.Count];
            //for (var i = 0; i < input.InteractiveCurve.Count; i++)
            //{
            //    InteractiveCurve[i] = input.InteractiveCurve[i];
            //}

            //PointCount = InteractiveCurve.Length;

            //icM = new double[PointCount];
            //icP = new double[PointCount];
            //icM_phi = new double[PointCount];
            //icP_phi = new double[PointCount];

            //for (var i = 0; i < PointCount; i++)
            //{
            //    icM[i] = Math.Round(InteractiveCurve[i].M / 1000 / 100, 3);
            //    icP[i] = Math.Round(InteractiveCurve[i].P / 1000, 3);

            //    icM_phi[i] = Math.Round(InteractiveCurve[i].M_Phi / 1000 / 100, 3);
            //    icP_phi[i] = Math.Round(InteractiveCurve[i].P_Phi / 1000, 3);
            //}

            //ChartInteractiveCurve.Series[0].Points.Clear();
            //ChartInteractiveCurve.Series[1].Points.Clear();
            //ChartInteractiveCurve.Series[2].Points.Clear();

            //for (var i = 0; i < PointCount; i++)
            //{
            //    ChartInteractiveCurve.Series[0].Points.AddXY(icM_phi[i], icP_phi[i]);
            //    ChartInteractiveCurve.Series[1].Points.AddXY(icM[i], icP[i]);
            //}

            //rdoPhi.Checked = true;

            //for (var i = 0; i < input.LoadsList.Count; i++)
            //{
            //    ChartInteractiveCurve.Series[2].Points.AddXY((input.LoadsList[i].Muy + input.LoadsList[i].Vux * input.Hp) / 100 / 1000, input.LoadsList[i].Pu / 1000);
            //}

            //ChartInteractiveCurve.ChartAreas[0].AxisY.Title = "P [Ton]";
            //ChartInteractiveCurve.ChartAreas[0].AxisX.Title = "M [T.m]";

            //ChartInteractiveCurve.ChartAreas[0].AxisX.Minimum = 0;
            //ChartInteractiveCurve.ChartAreas[0].AxisX.MaximumAutoSize = 1f;
        }

        private void btnCloase_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void rdoPhi_CheckedChanged(object sender, EventArgs e)
        {
            dgvData.Rows.Clear();
            for (var i = 0; i < PointCount; i++)
            {
                dgvData.Rows.Add();
                if (rdoPhi.Checked)
                {
                    dgvData.Rows[i].Cells[colMoment.Index].Value = icM_phi[i];
                    dgvData.Rows[i].Cells[colAxialForce.Index].Value = icP_phi[i];
                }
                else
                {
                    dgvData.Rows[i].Cells[colMoment.Index].Value = icM[i];
                    dgvData.Rows[i].Cells[colAxialForce.Index].Value = icP[i];
                }
            }
        }

        private void CopyImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var bitmap = new Bitmap(ChartInteractiveCurve.DisplayRectangle.Width, ChartInteractiveCurve.DisplayRectangle.Height);
                ChartInteractiveCurve.DrawToBitmap(bitmap, ChartInteractiveCurve.DisplayRectangle);
                var image = (Image)bitmap;
                Clipboard.SetImage(image);
            }
            catch
            {
                MessageBox.Show(@"An eeror has been occured!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void SaveImageAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var bitmap = new Bitmap(ChartInteractiveCurve.DisplayRectangle.Width, ChartInteractiveCurve.DisplayRectangle.Height);
                var saveFileDialog = new SaveFileDialog
                {
                    Filter = $@"PNG Format|*.png|Jpeg Format|*.jpg|Bmp Format|*.bmp|Gif Format|*.gif|Tiff Format|*.tiff|Emf Format|*.emf"
                };

                ChartInteractiveCurve.DrawToBitmap(bitmap, ChartInteractiveCurve.DisplayRectangle);

                if (saveFileDialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
                switch (saveFileDialog.FilterIndex)
                {
                    case 1:
                        bitmap.Save(saveFileDialog.FileName, ImageFormat.Png);
                        break;
                    case 2:
                        bitmap.Save(saveFileDialog.FileName, ImageFormat.Jpeg);
                        break;
                    case 3:
                        bitmap.Save(saveFileDialog.FileName, ImageFormat.Bmp);
                        break;
                    case 4:
                        bitmap.Save(saveFileDialog.FileName, ImageFormat.Gif);
                        break;
                    case 5:
                        bitmap.Save(saveFileDialog.FileName, ImageFormat.Tiff);
                        break;
                    case 6:
                        bitmap.Save(saveFileDialog.FileName, ImageFormat.Emf);
                        break;
                }
            }
            catch
            {
                MessageBox.Show(@"An eeror has been occured!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }
    }
}
