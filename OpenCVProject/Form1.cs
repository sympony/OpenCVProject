using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenCvSharp;
using OpenCvSharp.Extensions;

namespace OpenCVProject
{
    public partial class Form1 : Form
    {
        double TrackbarCounter = 180;
        bool Thres = false;
        VideoCapture video;
        Mat frame = new Mat();
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                video = new VideoCapture(0);
                video.FrameWidth = 640;
                video.FrameHeight = 480;
                timer1.Start();
            }
            catch
            {
                
                timer1.Enabled = false;
            }

            timer1.Interval = 33;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            video.Read(frame);
            pictureBoxIpl1.ImageIpl = frame;

            if(Thres)
            {
                Threshold(frame);
            }
        }
        
        
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            frame.Dispose();
        }
        
        private void Threshold(Mat frame)
        {
            using (Mat frame1 = new Mat())
            {
                
                Cv2.CvtColor(frame, frame1, ColorConversionCodes.RGB2GRAY);
                Cv2.Threshold(frame1, frame1, TrackbarCounter, 255, ThresholdTypes.Binary);
                Cv2.PutText(frame1, "Threshold Binary", new OpenCvSharp.Point(30, 30), HersheyFonts.HersheyComplex, 1, new Scalar(255, 0, 0));
                pictureBoxIpl2.ImageIpl = frame1;
            }
        }

        private void Pattern_Click(object sender, EventArgs e)
        {
            using (Mat mat = new Mat("../Image/dog.jpg"))
            using (Mat temp = new Mat("../Image/dog_1.jpg"))
            using (Mat result = new Mat())
            {
                Cv2.MatchTemplate(mat, temp, result, TemplateMatchModes.CCoeffNormed);

                OpenCvSharp.Point minloc, maxloc;
                double minval, maxval;
                Cv2.MinMaxLoc(result, out minval, out maxval, out minloc, out maxloc);

                var threshold = 0.7;
                if (maxval >= threshold)
                {
                    Rect rect = new Rect(maxloc.X, maxloc.Y, temp.Width, temp.Height);
                    Cv2.Rectangle(mat, rect, new Scalar(0, 0, 255), 2);

                    Cv2.ImShow("jangjong", mat);
                }
                else
                {

                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Thres = true;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            TrackbarCounter = trackBar1.Value;
        }
    }
}
