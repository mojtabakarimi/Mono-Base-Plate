using Mono_Base_Plate.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using Base_Plate_Engine.Common.Section.Shapes;
using Base_Plate_Engine.Design;
using DocumentFormat.OpenXml.Drawing.Charts;

namespace Mono_Base_Plate.Controls
{
    public partial class ViewBox : PictureBox
    {
        [DefaultValue(15)]
        public int MarginLeft { get; set; } = 15;

        [DefaultValue(15)]
        public int MarginRight { get; set; } = 15;

        [DefaultValue(15)]
        public int MarginTop { get; set; } = 15;

        [DefaultValue(15)]
        public int MarginBottom { get; set; } = 15;

        private Graphics graphics;
        private PointF centerPoint { get; set; }

        private int mouseX { get; set; }
        private int mouseY { get; set; }

        public float Scale { get; private set; }

        private bool isMouseDown;
        private const int defaultZoomLevelIndex = 12;
        private int zoomLevelIndex = defaultZoomLevelIndex;

        private static IReadOnlyList<float> ZoomLevels = new[] {0.01f, 0.02f, 0.04f, 0.06f, 0.08f, 0.08f, 0.1f,0.15f,0.2f,0.25f, 0.5f, 0.75f, 1f, 1.125f, 1.25f, 1.5f, 1.75f, 2f, 2.5f, 3f, 3.5f, 4f, 5f, 6f, 7f, 8f, 9f, 10f, 12f, 14f, 16f, 18f, 20f, 25f, 30f};

        private BasePlateInput Input { get; set; }
        private int ViewCode { get; set; }

        public ViewBox()
        {
            InitializeComponent();
            //this.ContextMenuStrip = contextMenuStripMain;

            centerPoint = new PointF(Convert.ToSingle(this.Width / 2), Convert.ToSingle(this.Height / 2));
        }

        #region Drawing Methods
        private Graphics GetGraphics()
        {
            var bitmap = new Bitmap(this.Width, this.Height);
            this.Image = bitmap;
            this.BackColor = Color.White;
            var graphics = Graphics.FromImage(bitmap);

            //graphics.CompositingQuality = CompositingQuality.AssumeLinear;
            graphics.Clear(this.BackColor);
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.TextRenderingHint = TextRenderingHint.SystemDefault;

            graphics = Graphics.FromImage(bitmap);
            graphics.Clear(this.BackColor);
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.TextRenderingHint = TextRenderingHint.SystemDefault;

            ////g.CompositingMode = Drawing2D.CompositingMode.SourceOver
            //graphics.CompositingQuality = CompositingQuality.HighQuality;
            //graphics.InterpolationMode = InterpolationMode.High;

            return graphics;
        }

        private void ResetDrawing()
        {
            var x = this.MarginLeft + (this.Width - this.MarginLeft - this.MarginRight) / 2f;
            var y = this.MarginTop + (this.Height - this.MarginTop - this.MarginBottom) / 2f;
            centerPoint = new PointF(x, y);

            zoomLevelIndex = defaultZoomLevelIndex;

            DrawBasePlate();
        }

        public void DoDraw(BasePlateInput basePlateInput, int viewCode)
        {
            if (basePlateInput == null)
            {
                return;
            }

            this.Input = basePlateInput;
            this.ViewCode = viewCode;
            
            DrawBasePlate();
        }
        
        public void DrawBasePlate()
        {
            var xScale = (this.Width - MarginLeft - MarginRight) / (float)Input.Np;
            var yScale = (this.Height - MarginTop - MarginBottom) / (float)Input.Bp;
            var scaleFactor = Math.Min(xScale, yScale);
            var zoom = ZoomLevels[zoomLevelIndex];
            scaleFactor *= zoom;
            Scale = scaleFactor;
            
            graphics = GetGraphics();
            
            DrawPedestal((float)Input.Np, (float)Input.Bp, Color.Gray, Color.LightGray, 2);
            DrawAxis(Color.Pink, Color.Black, (float)Input.Np, (float)Input.Bp);

            DrawBasePlate((float)Input.N, (float)Input.B, Color.LightPink, Color.WhiteSmoke, 1);

            //if (ReferenceEquals(TabControlMain.SelectedTab, TabPageAddition))
            //{
            //    if (rdoShearKeyPipe.Checked)
            //    {
            //        //DrawCircle(BP.N_BPecc, BP.B_BPecc, Pipe(cboShearKeyPipe.SelectedIndex).od, Color.Red, 1)
            //    }
            //    else if (rdoShearKeyWideFlange.Checked)
            //    {
            //    }
            //    else if (rdoShearKeyTube.Checked)
            //    {
            //    }
            //}

            //var xx_anchor = new double[Input.nb];
            //var yy_anchor = new double[Input.nb];

            var anchors = new System.Windows.Point[Input.nb];

            var dx = (Input.N - 2 * Input.a_N) / (Input.nbN - 1);
            var dy = (Input.B - 2 * Input.a_B) / (Input.nbB - 1);

            var ii = 0;
            for (var i = 0; i < Input.nbN; i++)
            {
                for (var j = 0; j < Input.nbB; j++)
                {
                    if (i == 0 || i == Input.nbN - 1)
                    {
                        anchors[ii].X = -Input.N / 2 + Input.a_N + i * dx;
                        anchors[ii].Y = -Input.B / 2 + Input.a_B + j * dy;

                        ii++;
                    }
                    else if(j == 0 || j == Input.nbB - 1)
                    {
                        anchors[ii].X = -Input.N / 2 + Input.a_N + i * dx;
                        anchors[ii].Y = -Input.B / 2 + Input.a_B + j * dy;

                        ii++;
                    }
                }
            }

            for (var i = 0; i < Input.nb; i++)
            {
                DrawAnchorBolt(Pens.Red, Brushes.WhiteSmoke, centerPoint.X, centerPoint.Y, anchors[i].X, anchors[i].Y, (float)Input.AnchorBolt.da, (float)Input.AnchorBolt.e, (float)Input.AnchorBolt.S);
            }

            if (ViewCode == 1)
            {
                var rebars = new System.Windows.Point[Input.nr];

                dx = (Input.Np - 2 * Input.Cover) / (Input.nrN - 1);
                dy = (Input.Bp - 2 * Input.Cover) / (Input.nrB - 1);

                ii = 0;
                for (var i = 0; i < Input.nrN; i++)
                {
                    for (var j = 0; j < Input.nrB; j++)
                    {
                        if (i == 0 || i == Input.nrN - 1)
                        {
                            rebars[ii].X = -Input.Np / 2 + Input.Cover + i * dx;
                            rebars[ii].Y = -Input.Bp / 2 + Input.Cover + j * dy;

                            ii++;
                        }
                        else if (j == 0 || j == Input.nrB - 1)
                        {
                            rebars[ii].X = -Input.Np / 2 + Input.Cover + i * dx;
                            rebars[ii].Y = -Input.Bp / 2 + Input.Cover + j * dy;

                            ii++;
                        }
                    }
                }

                for (var i = 0; i < Input.nr; i++)
                {
                    DrawRebarBolt(Pens.Red, Brushes.Gray, centerPoint.X, centerPoint.Y, rebars[i].X, rebars[i].Y, (float)Input.dr);
                }

                for (var i = 0; i < Input.nb; i++)
                {
                    DrawSleeve(Pens.SlateGray, Brushes.WhiteSmoke, centerPoint.X, centerPoint.Y, anchors[i].X, anchors[i].Y, (float)Input.AnchorBolt.D);
                    DrawCapPlate(anchors[i].X, anchors[i].Y, (float)Input.AnchorBolt.W);
                }
            }
            else
            {
                DrawSection_I(Color.DarkGray, (float)Input.N_BPecc, (float)Input.B_BPecc, (float)Input.N, (float)Input.B, Input.Sec, (float)Input.Sec.tw, 90, Input.StiffnerType);
                DrawStiffener(Color.DarkGray, (float)Input.N_BPecc, (float)Input.B_BPecc, (float)Input.N, (float)Input.B, Input.Sec, (float)Input.Sec.tw, 90, Input.StiffnerType);
            }

            this.Refresh();
        }
        
        public void DrawAxis(Color axisColor, Color AxisTextColor, double Np, double Bp)
        {
            const string axisXString = "X";
            const string axisYString = "Y";

            var font = new Font("Times New Roman", 12);
            var pen = new Pen(axisColor, 0.5f);
            var brush = new SolidBrush(AxisTextColor);
            
            Np = Np * Scale;
            Bp = Bp * Scale;

            var w1X = Convert.ToSingle(graphics.MeasureString(axisXString, font).Width);
            var h1X = Convert.ToSingle(graphics.MeasureString(axisXString, font).Height);
            var w1Y = Convert.ToSingle(graphics.MeasureString(axisYString, font).Width);
            var h1Y = Convert.ToSingle(graphics.MeasureString(axisYString, font).Height);

            var x1 = (float)centerPoint.X;
            var x2 = (float)(centerPoint.X + Np / 2 + w1X);
            var y1 = (float)centerPoint.Y;
            var y2 = (float)centerPoint.Y;
            graphics.DrawLine(pen, x1, y1,x2, y2);
            graphics.DrawString(axisXString, font, brush, x2 - w1X, y1 - h1X);

            x1 = (float)centerPoint.X;
            x2 = (float)centerPoint.X;
            y1 = (float)centerPoint.Y;
            y2 = (float)(centerPoint.Y - Bp / 2 - h1Y);
            graphics.DrawLine(pen, x1, y1, x2, y2);
            graphics.DrawString(axisYString, font, brush, x1, y2);
        }

        public void DrawCircle(double x_c, double y_c, double width, Color lineColor, float lineWidth)
        {
            var myPen = new Pen(lineColor, lineWidth)
            {
                DashCap = DashCap.Flat,
                DashStyle = DashStyle.Dot
            };

            x_c = x_c * Scale;
            y_c = y_c * Scale;

            width = width * Scale;

            graphics.DrawEllipse(myPen, (float)(x_c - width / 2), (float)(y_c - width / 2), (float)width, (float)width);
        }

        public void DrawRectangleByCenter(double x, double y, double width, double height, Color lineColor, double lineWidth)
        {
            var MyPen = new Pen(lineColor, (float)lineWidth);

            x = centerPoint.X + (x - width / 2) * Scale;
            y = centerPoint.Y + (y - height / 2) * Scale;

            width *= Scale;
            height *= Scale;

            graphics.DrawRectangle(MyPen, (float) x, (float) y, (float) width, (float) height);
        }

        public void DrawCapPlate(double x, double y, double w)
        {
            var myPen = new Pen(Color.DarkGreen, 1)
            {
                DashCap = DashCap.Triangle,
                DashStyle = DashStyle.DashDotDot
            };

            x = centerPoint.X + (x - w / 2) * Scale;
            y = centerPoint.Y + (y - w / 2) * Scale;
            w = w * Scale;
            graphics.DrawRectangle(myPen, (float)x, (float)y, (float)w, (float)w);
        }

        public void DrawSleeve(Pen pen, Brush brush, double x_c, double y_c, double x, double y, double d)
        {
            var myPen = new Pen(pen.Color);

            x = x * Scale;
            y = y * Scale;

            d = d * Scale;

            myPen.DashCap = DashCap.Flat;
            myPen.DashStyle = DashStyle.Dot;
            myPen.Color = Color.Green;

            graphics.DrawEllipse(pen, (float) (x_c + x - d / 2), (float) (y_c + y - d / 2), (float) d, (float) d);
        }

        public void FillRectangle(double x_c, double y_c, double width, double height, Color backColor)
        {
            var myBrush = new SolidBrush(backColor);

            x_c = x_c * Scale;
            y_c = y_c * Scale;

            width = width * Scale;
            height = height * Scale;

            graphics.FillRectangle(myBrush, (float)(x_c - width / 2), (float)(y_c - height / 2), (float)width, (float)height);
        }

        public void DrawLine(double x1, double y1, double x2, double y2, Color lineColor, float lineWidth)
        {
            var myPen = new Pen(lineColor, lineWidth);

            x1 = x1 * Scale;
            y1 = y1 * Scale;
            x2 = x2 * Scale;
            y2 = y2 * Scale;

            graphics.DrawLine(myPen, (float)(Left + x1), (float)(y1), (float)(x2), (float)(y2));
        }

        public void DrawPedestal(double width, double height, Color lineColor, Color backColor, float lineWidth)
        {
            //FillRectangle(1, 0, 0, BP.Np, BP.Bp, New Drawing2D.HatchBrush(Drawing2D.HatchStyle.DottedGrid, Color.WhiteSmoke, Color.LightGray))
            var myPen = new Pen(lineColor, lineWidth);
            var myBrush = new SolidBrush(backColor);

            var x = centerPoint.X - (width / 2) * Scale;
            var y = centerPoint.Y - (height / 2) * Scale;
            width = width * Scale;
            height = height * Scale;

            graphics.DrawRectangle(myPen, (float) x, (float) y, (float) width, (float) height);
            graphics.FillRectangle(myBrush, (float) x, (float) y, (float) width, (float) height);
        }

        public void DrawBasePlate(double width, double height, Color lineColor, Color backColor, float lineWidth)
        {
            var myPen = new Pen(lineColor, lineWidth);
            var myBrush = new SolidBrush(backColor);

            var x = centerPoint.X - (width / 2) * Scale;
            var y = centerPoint.Y - (height / 2) * Scale;
            width = width * Scale;
            height = height * Scale;

            graphics.DrawRectangle(myPen, (float)x, (float)y, (float)width, (float)height);
            graphics.FillRectangle(myBrush, (float)x, (float)y, (float)width, (float)height);
        }

        public void DrawAnchorBolt(Pen Pen, Brush Brush, double x_c, double y_c, double x, double y, double D, double e, double s)
        {
            var myPen = new Pen(Pen.Color);
            var COS = Convert.ToSingle(Math.Cos(Math.PI / 3));

            x = x * Scale;
            y = y * Scale;
            D = D * Scale;
            var D1 = 2 * D;

            s = s * Scale;
            e = e * Scale;

            var pointList = new List<PointF>
            {
                new PointF((float) (x_c + x + e / 2), (float) (y_c + y + 0)),
                new PointF((float) (x_c + x + e / 2 * COS), (float) (y_c + y + s / 2)),
                new PointF((float) (x_c + x + -e / 2 * COS), (float) (y_c + y + s / 2)),
                new PointF((float) (x_c + x + -e / 2), (float) (y_c + y + 0)),
                new PointF((float) (x_c + x + -e / 2 * COS), (float) (y_c + y + -s / 2)),
                new PointF((float) (x_c + x + e / 2 * COS), (float) (y_c + y + -s / 2))
            };

            myPen.DashCap = DashCap.Flat;
            myPen.DashStyle = DashStyle.Dot;
            myPen.Color = Color.Green;

            graphics.FillPolygon(Brush, pointList.ToArray());
            graphics.DrawPolygon(myPen, pointList.ToArray());

            graphics.FillEllipse(Brush, (float)(x_c + x - D / 2), (float)(y_c + y - D / 2), (float)D, (float)D);
            graphics.DrawEllipse(Pen, (float)(x_c + x - D / 2), (float)(y_c + y - D / 2), (float)D, (float)D);
        }

        public void DrawRebarBolt(Pen pen, Brush brush, double x_c, double y_c, double x, double y, double D)
        {
            x = x * Scale;
            y = y * Scale;
            D = D * Scale;
            var D1 = 2 * D;

            graphics.FillEllipse(brush, (float)(x_c + x - D / 2), (float)(y_c + y - D / 2), (float)D, (float)D);
            //graphics.DrawEllipse(Pen, Left + X - D / 2, Top + Y - D / 2, D, D)
        }

        public void DrawSection_I(Color color, double ex, double ey, double N, double B, SectionI sec, double ts, int rotation, int stiffener)
        {
            ex *= Scale;
            ey *= Scale;

            var bf = (float)sec.bf * Scale;
            var d = (float)sec.h * Scale;
            var tf = (float)sec.tf * Scale;
            var tw = (float)sec.tw * Scale;
            var kc = (float)sec.r * Scale;

            N *= Scale;
            B *= Scale;
            
            //Rotation = 0
            var pointList = new List<PointF>
            {
                new PointF(-tw / 2, d / 2 - tf),
                new PointF(-bf / 2, d / 2 - tf),
                new PointF(-bf / 2, d / 2),
                new PointF(bf / 2, d / 2),
                new PointF(bf / 2, d / 2 - tf),
                new PointF(tw / 2, d / 2 - tf),
                new PointF(tw / 2, -d / 2 + tf),
                new PointF(bf / 2, -d / 2 + tf),
                new PointF(bf / 2, -d / 2),
                new PointF(-bf / 2, -d / 2),
                new PointF(-bf / 2, -d / 2 + tf),
                new PointF(-tw / 2, -d / 2 + tf),
                new PointF(-tw / 2, d / 2 - tf)
            };

            //*****************************************************************************
            if (rotation == 0)
            {
                for (var i = 0; i < pointList.Count; i++)
                {
                    var x = centerPoint.X + ex + pointList[i].X;
                    var y = centerPoint.Y - ey + pointList[i].Y;
                    pointList[i] = new PointF((float)x, (float)y);

                    pointList[i] = new PointF((float)x, (float)y);
                }
            }
            else if (rotation == 90)
            {
                for (var i = 0; i < pointList.Count; i++)
                {
                    var x = centerPoint.X + ex + pointList[i].Y;
                    var y = centerPoint.Y - ey  + pointList[i].X;
                    pointList[i] = new PointF((float) x, (float) y);
                }
            }

            var graphicsPath = new GraphicsPath();
            graphicsPath.AddLines(pointList.ToArray());

            //graphics.FillPath(Brushes.LightBlue, gp)
            graphics.DrawLines(new Pen(color, 0.5f), pointList.ToArray());
        }

        public void DrawStiffener(Color color, double ex, double ey, double N, double B, SectionI sec, double ts, int rotation, int stiffener)
        {
            var bf = (float)sec.bf;
            var d = (float)sec.h;
            var tf = (float)sec.tf;
            var tw = (float)sec.tw;
            var kc = (float)sec.r;

            float hhh;
            switch (stiffener)
            {
                case 0:
                    break;              //Draw Nothing!
                case 1:
                    hhh = (float)(B / 2 - bf / 2 - ts);

                    DrawRectangleByCenter(ex + -d / 2 + ts / 2, ey + bf / 2 + ts + hhh / 2, ts, hhh, color, 1);
                    DrawRectangleByCenter(ex + +d / 2 - ts / 2, ey + bf / 2 + ts + hhh / 2, ts, hhh, color, 1);

                    DrawRectangleByCenter(ex + -d / 2 + ts / 2, ey - bf / 2 - ts - hhh / 2, ts, hhh, color, 1);
                    DrawRectangleByCenter(ex + +d / 2 - ts / 2, ey - bf / 2 - ts - hhh / 2, ts, hhh, color, 1);

                    DrawRectangleByCenter(ex, ey + bf / 2 + ts / 2, N, ts, color, 1);
                    DrawRectangleByCenter(ex, ey - bf / 2 - ts / 2, N, ts, color, 1);
                    break;
                case 2:
                    DrawRectangleByCenter(ex, ey + bf / 2 + ts / 2, N, ts, color, 1);
                    DrawRectangleByCenter(ex, ey - bf / 2 - ts / 2, N, ts, color, 1);
                    break;
                case 3:
                    hhh = (float)(B / 2 - bf / 2 - ts);

                    DrawRectangleByCenter(ex + -d / 2 + ts / 2, ey + bf / 2 + ts + hhh / 2, ts, hhh, color, 1);
                    DrawRectangleByCenter(ex + +d / 2 - ts / 2, ey + bf / 2 + ts + hhh / 2, ts, hhh, color, 1);

                    DrawRectangleByCenter(ex + -d / 2 + ts / 2, ey - bf / 2 - ts - hhh / 2, ts, hhh, color, 1);
                    DrawRectangleByCenter(ex + +d / 2 - ts / 2, ey - bf / 2 - ts - hhh / 2, ts, hhh, color, 1);

                    DrawRectangleByCenter(ex, ey + bf / 2 + ts / 2, N, ts, color, 1);
                    DrawRectangleByCenter(ex, ey - bf / 2 - ts / 2, N, ts, color, 1);

                    DrawRectangleByCenter(ex, ey + bf / 2 + ts + hhh / 2, ts, hhh, color, 1);
                    DrawRectangleByCenter(ex, ey - bf / 2 - ts - hhh / 2, ts, hhh, color, 1);
                    break;
            }
        }

        private static PointF[] Rotate(PointF[] points, PointF centerPoint, double angle)
        {
            return points.Select(p => Rotate(p, centerPoint, angle)).ToArray();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="points"></param>
        /// <param name="centerPoint"></param>
        /// <param name="angle">in degree</param>
        /// <returns></returns>
        private static PointF Rotate(PointF points, PointF centerPoint, double angle)
        {
            angle *= Math.PI / 180;

            double x = points.X - centerPoint.X;
            double y = points.Y - centerPoint.Y;

            var l = Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
            var a = y >= 0
                ? Math.Abs(Math.Acos(x / l))
                : 2 * Math.PI - Math.Abs(Math.Acos(x / l));

            return new PointF((float)(centerPoint.X + l * Math.Cos(a + angle)), (float)(centerPoint.Y + l * Math.Sin(a + angle)));
        }

        private static PointF[] ScaleTo(PointF[] points, PointF centerPoint, double scaleFactor)
        {
            return points.Select(p => ScaleTo(p, centerPoint, scaleFactor)).ToArray();
        }

        private static PointF ScaleTo(PointF points, PointF centerPoint, double scaleFactor)
        {
            double x = points.X - centerPoint.X;
            double y = points.Y - centerPoint.Y;

            var l = Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
            var a = y >= 0
                ? Math.Abs(Math.Acos(x / l))
                : 2 * Math.PI - Math.Abs(Math.Acos(x / l));

            return new PointF((float)(centerPoint.X + l * scaleFactor * Math.Cos(a)), (float)(centerPoint.Y + l * scaleFactor * Math.Sin(a)));
        }
        #endregion

        #region Events
        private void ViewBox_SizeChanged(object sender, EventArgs e)
        {
            try
            {
                var x = this.MarginLeft + (this.Width - this.MarginLeft - this.MarginRight) / 2f;
                var y = this.MarginTop + (this.Height - this.MarginTop - this.MarginBottom) / 2f;
                centerPoint = new PointF(x, y);

                DrawBasePlate();
            }
            catch
            {

            }
        }

        private void ViewBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown)
            {
                centerPoint = new PointF(e.X - mouseX, e.Y - mouseY);

                DrawBasePlate();
            }
        }

        private void ViewBox_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;
        }

        private void ViewBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left || e.Button == MouseButtons.Middle)
            {
                isMouseDown = true;
                mouseX = Convert.ToInt32(-centerPoint.X + e.X);
                mouseY = Convert.ToInt32(-centerPoint.Y + e.Y);
            }
            else if (e.Button == MouseButtons.Right)
            {
                ResetDrawing();
            }
        }

        private void ViewBox_MouseEnter(object sender, EventArgs e)
        {
            this.Focus();
        }

        private void ViewBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ResetDrawing();
            }
        }

        private void ViewBox_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void ViewBox_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                if (zoomLevelIndex < ZoomLevels.Count - 1)
                {
                    zoomLevelIndex++;
                }
                else
                {
                    return;
                }
            }
            else
            {
                if (zoomLevelIndex > 0)
                {
                    zoomLevelIndex--;
                }
                else
                {
                    return;
                }
            }

            try
            {
                DrawBasePlate();
            }
            catch (Exception)
            {
                
            }
        }

        #endregion
    }
}
