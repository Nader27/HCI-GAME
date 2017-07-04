using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;

namespace HCI_GAME
{
    public partial class Form2 : Form
    {
        private bool _dragging;
        private Point dragging_start_point;

        private double cannyThreshold1 = 120.0;
        private double cannyThreshold2 = 180.0;
        private double circleAccumulatorThreshold = 120;

        private Capture capture;
        private Mat OriginalCAM;
        private Mat GRAYCAM;
        private Mat pyrDown;
        private Mat cannyEdges;
        private int choice;
        private VectorOfVectorOfPoint contours;
        private VectorOfPoint contour;
        private VectorOfPoint approxContour;

        List<Triangle2DF> triangleList;
        List<RotatedRect> boxList;
        CircleF[] circles;

        Form3 form3 = new Form3();

        public Form2()
        {
            InitializeComponent();
            dragging_start_point = new Point(0, 0);
            choice = 0;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            capture = new Capture();
            capture.ImageGrabbed += processFunction;
            capture.FlipHorizontal = true;
            capture.Start();
        }

        private void processFunction(object obj, EventArgs e)
        {
            try
            {
                OriginalCAM = new Mat();
                GRAYCAM = new Mat();
                pyrDown = new Mat();
                cannyEdges = new Mat();

                capture.Retrieve(OriginalCAM, 0);
                CvInvoke.CvtColor(OriginalCAM, GRAYCAM, ColorConversion.Bgr2Gray);
                CvInvoke.EqualizeHist(GRAYCAM, GRAYCAM);
                CvInvoke.PyrDown(GRAYCAM, pyrDown);
                CvInvoke.PyrUp(pyrDown, GRAYCAM);
                CvInvoke.Canny(GRAYCAM, cannyEdges, cannyThreshold1, cannyThreshold2);
                CameraBox.Image = cannyEdges;
            }
            catch {}

            triangleList = new List<Triangle2DF>();
            boxList = new List<RotatedRect>();

            if (choice == 2 || choice == 3)
            {
                contours = new VectorOfVectorOfPoint();
                CvInvoke.FindContours(cannyEdges, contours, null, RetrType.List, ChainApproxMethod.ChainApproxSimple);
                int count = contours.Size;
                for (int i = 0; i < count; i++)
                {
                    contour = contours[i];
                    approxContour = new VectorOfPoint();
                    CvInvoke.ApproxPolyDP(contour, approxContour, CvInvoke.ArcLength(contour, true) * 0.05, true);
                    if (CvInvoke.ContourArea(approxContour, false) > 250) //only consider contours with area greater than 250
                    {
                        if (approxContour.Size == 3) //The contour has 3 vertices, it is a triangle
                        {
                            Point[] pts = approxContour.ToArray();
                            triangleList.Add(new Triangle2DF(pts[0], pts[1], pts[2]));
                        }
                        else if (approxContour.Size == 4) //The contour has 4 vertices.
                        {
                            bool isRectangle = true;
                            Point[] pts = approxContour.ToArray();
                            LineSegment2D[] edges = PointCollection.PolyLine(pts, true);

                            for (int j = 0; j < edges.Length; j++)
                            {
                                double angle = Math.Abs(
                                   edges[(j + 1) % edges.Length].GetExteriorAngleDegree(edges[j]));
                                if (angle < 80 || angle > 100)
                                {
                                    isRectangle = false;
                                    break;
                                }
                            }

                            if (isRectangle)
                                boxList.Add(CvInvoke.MinAreaRect(approxContour));
                        }
                    }
                }
            }
            switch (choice)
            {
                case 1:
                    circles = CvInvoke.HoughCircles(GRAYCAM, HoughType.Gradient, 2.0, 20.0, cannyThreshold2, circleAccumulatorThreshold, 5);
                    foreach (CircleF circle in circles)
                        CvInvoke.Circle(OriginalCAM, Point.Round(circle.Center), (int)circle.Radius, new Bgr(Color.Red).MCvScalar, 2);
                    break;
                case 2:
                    foreach (Triangle2DF triangle in triangleList)
                        CvInvoke.Polylines(OriginalCAM, Array.ConvertAll(triangle.GetVertices(), Point.Round), true, new Bgr(Color.Green).MCvScalar, 2);
                    break;
                case 3:
                    foreach (RotatedRect box in boxList)
                        CvInvoke.Polylines(OriginalCAM, Array.ConvertAll(box.GetVertices(), Point.Round), true, new Bgr(Color.Blue).MCvScalar, 2);
                    break;
                default:
                    break;
            }
            //CameraBox.Image = OriginalCAM;
            GC.Collect();
        }

        private void CircleBtn_Click(object sender, EventArgs e)
        {
            this.choice = 1;

            CircleBtn.Enabled = false;
            TriangleBtn.Enabled = true;
            RecTangleBtn.Enabled = true;

            CircleBtn.BackgroundImage = global::HCI_GAME.Properties.Resources.circle_red;
            TriangleBtn.BackgroundImage = global::HCI_GAME.Properties.Resources.triangle;
            RecTangleBtn.BackgroundImage = global::HCI_GAME.Properties.Resources.Rectangle;
        }

        private void TriangleBtn_Click(object sender, EventArgs e)
        {
            this.choice = 2;

            CircleBtn.Enabled = true;
            TriangleBtn.Enabled = false;
            RecTangleBtn.Enabled = true;

            CircleBtn.BackgroundImage = global::HCI_GAME.Properties.Resources.circle;
            TriangleBtn.BackgroundImage = global::HCI_GAME.Properties.Resources.triangle_green;
            RecTangleBtn.BackgroundImage = global::HCI_GAME.Properties.Resources.Rectangle;
        }

        private void RectangleBtn_Click(object sender, EventArgs e)
        {
            this.choice = 3;

            CircleBtn.Enabled = true;
            TriangleBtn.Enabled = true;
            RecTangleBtn.Enabled = false;

            CircleBtn.BackgroundImage = global::HCI_GAME.Properties.Resources.circle;
            TriangleBtn.BackgroundImage = global::HCI_GAME.Properties.Resources.triangle;
            RecTangleBtn.BackgroundImage = global::HCI_GAME.Properties.Resources.Rectangle_blue;
        }

        private void StartGame_Click(object sender, EventArgs e)
        {
            capture.Dispose();
            this.Hide();
            GC.Collect();
            form3.ShowDialog();
            this.Close();
        }

        //Form Move

        private void Form2_MouseMove(object sender, MouseEventArgs e)
        {
            if (_dragging)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this.dragging_start_point.X, p.Y - this.dragging_start_point.Y);
            }
        }

        private void Form2_MouseUp(object sender, MouseEventArgs e)
        {
            _dragging = false;
        }

        private void Form2_MouseDown(object sender, MouseEventArgs e)
        {
            _dragging = true;
            dragging_start_point = new Point(e.X, e.Y);
        }

        private void close_button_Click(object sender, EventArgs e)
        {
            capture.Dispose();
            this.Close();
        }
    }
}
