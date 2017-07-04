using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;

namespace HCI_GAME
{
    public partial class Form1 : Form
    {
        private bool dragging;
        private Point dragging_start_point;

        private Capture capture;
        private Mat OriginalCAM;
        private Mat GRAYCAM;
        private int ms,s;
        private CascadeClassifier haarCascade;
        private Rectangle[] facesDetected;
        Form2 form2 = new Form2();

        public Form1()
        {
            InitializeComponent();
            this.haarCascade = new CascadeClassifier(@"haarcascade_frontalface_default.xml");
            this.capture = new Capture();
            this.dragging_start_point = new Point(0, 0);
            this.ms = 0;
            this.s = 0;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            capture.ImageGrabbed += processFunction;
            capture.FlipHorizontal = true;
            capture.Start();
        }

        private void processFunction(object obj, EventArgs e)
        {
            OriginalCAM = new Mat();
            GRAYCAM = new Mat();

            capture.Retrieve(OriginalCAM, 0);
            CvInvoke.CvtColor(OriginalCAM, GRAYCAM, ColorConversion.Bgr2Gray);
            CvInvoke.EqualizeHist(GRAYCAM, GRAYCAM);
            facesDetected = haarCascade.DetectMultiScale(GRAYCAM,1.1,3,new Size(70,70));
            if (facesDetected.Count() == 0)
            {
                ms = 0;
                s = 0;
                label1.Text = s.ToString();
            }
            foreach (Rectangle face in facesDetected)
            {
                timer1.Start();
                CvInvoke.Rectangle(OriginalCAM, face, new Bgr(Color.Red).MCvScalar, 2);
            }
            CameraBox.Image = OriginalCAM;
        }
        Form3 form3 = new Form3();
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (s == 5)
            {
                timer1.Stop();
                capture.Dispose();
                this.Hide();
                GC.Collect();
                form2.ShowDialog();
                this.Close();
            }
            GC.Collect();
            ms++;
            if (ms > 10)
            {
                s++;
                ms = 0;
            }
            label1.Text = s.ToString();
        }

        //Form Move

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this.dragging_start_point.X, p.Y - this.dragging_start_point.Y);
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragging_start_point = new Point(e.X, e.Y);
        }

        private void close_button_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            capture.Dispose();
            this.Hide();
            GC.Collect();
            this.Close();
        }
    }
}
