
namespace OpenCVProject
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pictureBoxIpl1 = new OpenCvSharp.UserInterface.PictureBoxIpl();
            this.Pattern = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.파일ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.필터ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.머신러닝ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.이미지처리ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.알고리즘ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.응용ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.유틸리티ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBoxIpl2 = new OpenCvSharp.UserInterface.PictureBoxIpl();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIpl1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIpl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxIpl1
            // 
            this.pictureBoxIpl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxIpl1.Location = new System.Drawing.Point(12, 42);
            this.pictureBoxIpl1.Name = "pictureBoxIpl1";
            this.pictureBoxIpl1.Size = new System.Drawing.Size(640, 480);
            this.pictureBoxIpl1.TabIndex = 0;
            this.pictureBoxIpl1.TabStop = false;
            // 
            // Pattern
            // 
            this.Pattern.Location = new System.Drawing.Point(699, 42);
            this.Pattern.Name = "Pattern";
            this.Pattern.Size = new System.Drawing.Size(75, 23);
            this.Pattern.TabIndex = 1;
            this.Pattern.Text = "Pattern";
            this.Pattern.UseVisualStyleBackColor = true;
            this.Pattern.Click += new System.EventHandler(this.Pattern_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.파일ToolStripMenuItem,
            this.필터ToolStripMenuItem,
            this.머신러닝ToolStripMenuItem,
            this.이미지처리ToolStripMenuItem,
            this.알고리즘ToolStripMenuItem,
            this.응용ToolStripMenuItem,
            this.유틸리티ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(849, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 파일ToolStripMenuItem
            // 
            this.파일ToolStripMenuItem.Name = "파일ToolStripMenuItem";
            this.파일ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.파일ToolStripMenuItem.Text = "파일";
            // 
            // 필터ToolStripMenuItem
            // 
            this.필터ToolStripMenuItem.Name = "필터ToolStripMenuItem";
            this.필터ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.필터ToolStripMenuItem.Text = "필터";
            // 
            // 머신러닝ToolStripMenuItem
            // 
            this.머신러닝ToolStripMenuItem.Name = "머신러닝ToolStripMenuItem";
            this.머신러닝ToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.머신러닝ToolStripMenuItem.Text = "머신러닝";
            // 
            // 이미지처리ToolStripMenuItem
            // 
            this.이미지처리ToolStripMenuItem.Name = "이미지처리ToolStripMenuItem";
            this.이미지처리ToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.이미지처리ToolStripMenuItem.Text = "이미지처리";
            // 
            // 알고리즘ToolStripMenuItem
            // 
            this.알고리즘ToolStripMenuItem.Name = "알고리즘ToolStripMenuItem";
            this.알고리즘ToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.알고리즘ToolStripMenuItem.Text = "알고리즘";
            // 
            // 응용ToolStripMenuItem
            // 
            this.응용ToolStripMenuItem.Name = "응용ToolStripMenuItem";
            this.응용ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.응용ToolStripMenuItem.Text = "응용";
            // 
            // 유틸리티ToolStripMenuItem
            // 
            this.유틸리티ToolStripMenuItem.Name = "유틸리티ToolStripMenuItem";
            this.유틸리티ToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.유틸리티ToolStripMenuItem.Text = "유틸리티";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(699, 162);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "0,1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBoxIpl2
            // 
            this.pictureBoxIpl2.Location = new System.Drawing.Point(76, 42);
            this.pictureBoxIpl2.Name = "pictureBoxIpl2";
            this.pictureBoxIpl2.Size = new System.Drawing.Size(160, 160);
            this.pictureBoxIpl2.TabIndex = 5;
            this.pictureBoxIpl2.TabStop = false;
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(722, 306);
            this.trackBar1.Maximum = 200;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.trackBar1.Size = new System.Drawing.Size(45, 104);
            this.trackBar1.TabIndex = 5;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(849, 551);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.pictureBoxIpl2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Pattern);
            this.Controls.Add(this.pictureBoxIpl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIpl1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIpl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OpenCvSharp.UserInterface.PictureBoxIpl pictureBoxIpl1;
        private System.Windows.Forms.Button Pattern;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 파일ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 필터ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 머신러닝ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 이미지처리ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 알고리즘ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 응용ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 유틸리티ToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private OpenCvSharp.UserInterface.PictureBoxIpl pictureBoxIpl2;
        private System.Windows.Forms.TrackBar trackBar1;
    }
}

