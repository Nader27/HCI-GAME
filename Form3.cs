using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace HCI_GAME
{
    public partial class Form3 : Form
    {
        private Mat Difference;
        private int x, y, counts, tries;
        private List<Rectangle> RectangleList;
        private float diffHeight, diffWidth;

        public Form3()
        {
            InitializeComponent();
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            imageBox1.Height = this.Height;
            imageBox2.Height = this.Height;
            imageBox1.Width = this.Width / 2;
            imageBox2.Width = this.Width / 2;
            imageBox2.Location = new Point(this.Width / 2, 0);
            counts = 0;
            tries = 3;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            imageBox1.Image = new Mat("image1.png", LoadImageType.Color);
            imageBox2.Image = new Mat("image2.png", LoadImageType.Color);

            Difference = new Mat(imageBox1.Height, imageBox1.Width, DepthType.Cv8U, 3);
            CvInvoke.AbsDiff(imageBox1.Image, imageBox2.Image, Difference);
            CvInvoke.Threshold(Difference, Difference, 60, 255, ThresholdType.Binary);
            CvInvoke.CvtColor(Difference, Difference, ColorConversion.Bgr2Gray);
            diffHeight = (float)Difference.Height / (float)imageBox1.Height;
            diffWidth = (float)Difference.Width / (float)imageBox1.Width;
            VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint();
            CvInvoke.FindContours(Difference, contours, null, RetrType.List, ChainApproxMethod.ChainApproxNone);
            VectorOfPoint contour;
            VectorOfPoint approxContour;
            RectangleList = new List<Rectangle>();
            int count = contours.Size;
            for (int i = 0; i < count; i++)
            {
                contour = contours[i];
                approxContour = new VectorOfPoint();
                CvInvoke.ApproxPolyDP(contour, approxContour, CvInvoke.ArcLength(contour, true) * 0.05, true);
                if (CvInvoke.ContourArea(approxContour, false) > 220)
                {
                    RectangleList.Add(CvInvoke.BoundingRectangle(approxContour));
                }
            }
            counts = RectangleList.Count();
            countlabel.Text = counts.ToString();
            trylabel.Text = tries.ToString();
        }


        private void close_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void imageBox_MouseClick(object sender, MouseEventArgs e)
        {
            x = (int)((float)e.Location.X * (float)diffWidth);
            y = (int)((float)e.Location.Y * (float)diffHeight);
            IImage image1 = imageBox1.Image;
            IImage image2 = imageBox2.Image;
            if (tries >= 1)
            {
                foreach (Rectangle rectangle in RectangleList)
                {
                    if (rectangle.Contains(x, y))
                    {
                        CvInvoke.Rectangle(image1, rectangle, new Bgr(Color.Green).MCvScalar, 2);
                        CvInvoke.Rectangle(image2, rectangle, new Bgr(Color.Green).MCvScalar, 2);
                        imageBox1.Image = image1;
                        imageBox2.Image = image2;
                        RectangleList.Remove(rectangle);
                        counts--;
                        countlabel.Text = counts.ToString();
                        if (counts == 0)
                        {
                            MessageBox.Show("Game Over !! You Won ^_^", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            tries = 0;
                        }
                        return;
                    }
                }
                if (tries == 1)
                {
                    tries--;
                    trylabel.Text = tries.ToString();
                    MessageBox.Show("Game Over !! You Lose -_-", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    foreach (Rectangle rectangle in RectangleList)
                    {
                        CvInvoke.Rectangle(image1, rectangle, new Bgr(Color.Red).MCvScalar, 2);
                        CvInvoke.Rectangle(image2, rectangle, new Bgr(Color.Red).MCvScalar, 2);
                        imageBox1.Image = image1;
                        imageBox2.Image = image2;
                    }
                }
                else
                {
                    tries--;
                    trylabel.Text = tries.ToString();
                }
            }
        }
    }
}
