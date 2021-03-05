using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenCvSharp;
using OpenCvSharp.Extensions;

namespace OpenCVProject
{
    public partial class Form2 : Form
    {
        enum DIR { LEFT,RIGHT,TOP,BOTTOM,NON};
        DIR dir = DIR.NON;
        private readonly VideoCapture capture;
        private readonly CascadeClassifier cascadeClassifier;
        private readonly VideoWriter writer;
        PictureBox Drag_Picturebox;
        System.Drawing.Point StartPoint,EndPoint;
        bool IsDrag = false;
        Panel panel = new Panel();
        Rectangle Left,Right,Top,Bottom;
        
        public Form2()
        {
            InitializeComponent();

            capture = new VideoCapture();
            writer = new VideoWriter();
            cascadeClassifier = new CascadeClassifier("haarcascade_frontalface_default.xml");

            Left = new Rectangle(0, pictureBox3.Height / 2, 10, 10);
            Right = new Rectangle(pictureBox3.Width - 10, pictureBox3.Height / 2, 10, 10);
            Top = new Rectangle(pictureBox3.Width / 2, 0, 10, 10);
            Bottom = new Rectangle(pictureBox3.Width / 2, pictureBox3.Height - 10, 10, 10);
            //pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(OnMouseDown);
            //pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(OnMouseMove);
            //pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(OnMouseUp);
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
            capture.Open(0, 0);
            if (!capture.IsOpened())
            {
                Close();
                return;
            }

            ClientSize = new System.Drawing.Size(capture.FrameWidth, capture.FrameHeight);

            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;

            
            Controls.Add(panel);
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            capture.Dispose();
            cascadeClassifier.Dispose();
            backgroundWorker1.CancelAsync();
            
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            var bgWorker = (BackgroundWorker)sender;
            while (!bgWorker.CancellationPending)
            {
                using(var frameMat = capture.RetrieveMat())
                {
                    var rects = cascadeClassifier.DetectMultiScale(frameMat, 1.1, 5, HaarDetectionType.ScaleImage, new OpenCvSharp.Size(30, 30));

                    if(rects.Length>0)
                    {
                        Cv2.Rectangle(frameMat, rects[0], Scalar.Red);

                    }

                    var frameBitmap = BitmapConverter.ToBitmap(frameMat);
                    bgWorker.ReportProgress(0, frameBitmap);
                }
                Thread.Sleep(100);
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if(!IsDrag)
            {
                var frameBitmap = (Bitmap)e.UserState;
                pictureBox1.Image?.Dispose();
                pictureBox1.Image = frameBitmap;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            backgroundWorker1.RunWorkerAsync();
            
        }

        private void save_button_Click(object sender, EventArgs e)
        {
            //save 버튼 누르면 backgroundworker1 작업중비시키고 마지막 장면을 picturebox3에 이미지 올림
            //picturbox3은 visible상태로 만들어줌

            backgroundWorker1.CancelAsync();
            pictureBox3.Visible = true;
            pictureBox3.Image = pictureBox1.Image;
        }
        void pictureBox3_Paint(object sender, PaintEventArgs e)
        {
            //이 함수가 picturebox3에 뭔가 변화가 생기면 호출되는 함수임 시각적으로
            // 위에서 visible상태로 만드니까 이 함수가 저절로 호출
            //Left, Right, Top, Bottom 변수는 위에서 생성하고 초기화함 38line
            //초기화한 rectangle을 밑에 함수를 이용해서 picturebox3에 그려줌
            e.Graphics.DrawRectangle(new Pen(Color.Gray, 3), Left);
            e.Graphics.DrawRectangle(new Pen(Color.Gray, 3), Right);
            e.Graphics.DrawRectangle(new Pen(Color.Gray, 3), Top);
            e.Graphics.DrawRectangle(new Pen(Color.Gray, 3), Bottom);

            Pen line = new Pen(Color.Gray, 2);
            line.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDotDot;
            e.Graphics.DrawLine(line,Left.Location, new System.Drawing.Point(Left.X, Top.Y));
            e.Graphics.DrawLine(line, new System.Drawing.Point(Left.X, Top.Y), Top.Location);
            e.Graphics.DrawLine(line, Top.Location, new System.Drawing.Point(Right.X+10, Top.Y));
            e.Graphics.DrawLine(line, new System.Drawing.Point(Right.X + 10, Top.Y), new System.Drawing.Point(Right.X+10,Right.Y));
            e.Graphics.DrawLine(line, new System.Drawing.Point(Right.X + 10, Right.Y), new System.Drawing.Point(Right.X + 10, Bottom.Y+10));
            e.Graphics.DrawLine(line, new System.Drawing.Point(Right.X + 10, Bottom.Y + 10), new System.Drawing.Point(Bottom.X, Bottom.Y + 10));
            e.Graphics.DrawLine(line, new System.Drawing.Point(Bottom.X, Bottom.Y + 10), new System.Drawing.Point(Left.X, Bottom.Y + 10));
            e.Graphics.DrawLine(line, new System.Drawing.Point(Left.X, Left.Y), new System.Drawing.Point(Left.X, Bottom.Y + 10));
        }

        private void pictureBox3_OnMouseDown(object sender, MouseEventArgs e)
        {
            //mouse 왼쪽 클릭하면 이 함수 호출
            //2번째 파라미터 MouseEventArges e 에 클릭이벤트에 대한 정보가 담겨있음
            //클릭한 좌표를 얻어와서 그 좌표가 위 rectangle 안에 있는지 확인
            textBox2.Text = "(" + e.X.ToString() + "," + e.Y.ToString() + ")";
    
            if(Left.Contains(e.X,e.Y))
            {
                //클릭한 좌표가 Left rectangle 안에 있으면 dir = DIR.LEFT로 변경
                //밑에 다 똑같은 코드
                dir = DIR.LEFT;
                
            }
            else if(Right.Contains(e.X,e.Y))
            {
                dir = DIR.RIGHT;
                
            }
            else if (Top.Contains(e.X, e.Y))
            {
                dir = DIR.TOP;
                
            }
            else if (Bottom.Contains(e.X, e.Y))
            {
                dir = DIR.BOTTOM;
                
            }
            else
            {
                dir = DIR.NON;
                
            }
        }
        private void pictureBox3_OnMouseMove(object sender, MouseEventArgs e)
        {
            textBox2.Text = "(" + e.X.ToString() + "," + e.Y.ToString() + ")";
            //mouse가 picturebox3 안에서 움직이면 위 함수 계속 호출
            //dir != DIR.NON 조건 건게 ractangle을 클릭 안하면 적용안되게끔 하려고
            if (dir != DIR.NON)
            {
                //내가 선택한 ractangle이 뭐냐에 따라서 각 ractangle 위치 변경
                switch (dir)
                {
                    case DIR.LEFT:
                        Left.X = e.X;
                        Top.X = Bottom.X = (int)((Right.X + Left.X) / 2);
                        break;
                    case DIR.RIGHT:
                        Right.X = e.X;
                        Top.X = Bottom.X = (int)((Right.X + Left.X) / 2);
                        break;
                    case DIR.TOP:
                        Top.Y = e.Y;
                        Left.Y = Right.Y = (int)((Bottom.Y + Top.Y) / 2);
                        break;
                    case DIR.BOTTOM:
                        Bottom.Y = e.Y;
                        Left.Y = Right.Y = (int)((Bottom.Y + Top.Y) / 2);
                        break;
                    default:break;
                }
                try
                {
                    //저기서 ractangle을 변경해도 화면은 변하지않음
                    //왜냐하면 ractangle 그려주는 함수는 pictureBox3_Paint 인데 이 함수는 시각적으로 변경이 있어야 호출됨
                    //그래서 refresh함수를 호출함으로써 저 함수까지 같이 호출해서 다시 그리게 만드는거
                    pictureBox3.Refresh();
                }
                catch
                {

                }
            }
        }
        private void pictureBox3_OnMouseUp(object sender, MouseEventArgs e)
        {
            //클릭 뗐을 때 NON으로 바꾸어서 move함수 안먹히게 초기화
            dir = DIR.NON;
            
        }
        private void load_button_Click(object sender, EventArgs e)
        {
            //load버튼 누르면 위 ractangle 좌표 알아서 잘 따서 clone만들고 그걸 png 저장
            Bitmap bitmap = new Bitmap(pictureBox1.Image);
            bitmap = bitmap.Clone(new Rectangle(Left.X, Top.Y, Right.X - Left.X+10, Bottom.Y - Top.Y+10), System.Drawing.Imaging.PixelFormat.DontCare);
            bitmap.Save("image" + DateTime.Now.ToString("hh-mm-ss") + ".png", System.Drawing.Imaging.ImageFormat.Png);
        }
        //private void OnMouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        //{
        //    StartPoint = e.Location;
        //    panel.BringToFront();
        //    panel.Location = StartPoint;
        //    panel.BackColor = Color.FromArgb(10,255,0,0) ;
        //    panel.Visible = true;
        //}
        //private void OnMouseMove(object sender, MouseEventArgs e)
        //{
        //    panel.Size = new System.Drawing.Size(e.X-StartPoint.X,e.Y-StartPoint.Y);

        //}


        //private void OnMouseUp(object sender, MouseEventArgs e)
        //{
        //    IsDrag = true;
        //    EndPoint = e.Location;
        //    Bitmap bitmap = new Bitmap(pictureBox1.Image);
        //    bitmap = bitmap.Clone(new Rectangle(StartPoint.X, StartPoint.Y, EndPoint.X - StartPoint.X, EndPoint.Y - StartPoint.Y), System.Drawing.Imaging.PixelFormat.DontCare);
        //    bitmap.Save("image" + DateTime.Now.ToString("hh-mm-ss") + ".png", System.Drawing.Imaging.ImageFormat.Png);

        //}
    }
    
}

