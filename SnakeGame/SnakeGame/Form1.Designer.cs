
namespace SnakeGame
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
            this.startButton = new System.Windows.Forms.Button();
            this.snapButton = new System.Windows.Forms.Button();
            this.picCanvas = new System.Windows.Forms.PictureBox();
            this.txtScore = new System.Windows.Forms.Label();
            this.txtHighScore = new System.Windows.Forms.Label();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.finishButton = new System.Windows.Forms.Button();
            this.txtGameOver = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).BeginInit();
            this.SuspendLayout();
            this.KeyPreview = true;
            // 
            // startButton
            // 
            this.startButton.BackColor = System.Drawing.Color.Aquamarine;
            this.startButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.startButton.Font = new System.Drawing.Font("굴림", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.startButton.Location = new System.Drawing.Point(632, 12);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(123, 52);
            this.startButton.TabIndex = 0;
            this.startButton.Text = "시작";
            this.startButton.UseVisualStyleBackColor = false;
            this.startButton.Click += new System.EventHandler(this.StartGame_Click);
            // 
            // snapButton
            // 
            this.snapButton.BackColor = System.Drawing.Color.PaleTurquoise;
            this.snapButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.snapButton.Font = new System.Drawing.Font("굴림", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.snapButton.Location = new System.Drawing.Point(632, 519);
            this.snapButton.Name = "snapButton";
            this.snapButton.Size = new System.Drawing.Size(123, 43);
            this.snapButton.TabIndex = 1;
            this.snapButton.Text = "캡처하기";
            this.snapButton.UseVisualStyleBackColor = false;
            this.snapButton.Click += new System.EventHandler(this.TakeSnapshot);
            // 
            // picCanvas
            // 
            this.picCanvas.BackColor = System.Drawing.Color.Silver;
            this.picCanvas.Location = new System.Drawing.Point(15, 12);
            this.picCanvas.Name = "picCanvas";
            this.picCanvas.Size = new System.Drawing.Size(600, 600);
            this.picCanvas.TabIndex = 2;
            this.picCanvas.TabStop = false;
            this.picCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.UpdatePictureBoxGraphics);
            // 
            // txtScore
            // 
            this.txtScore.Font = new System.Drawing.Font("굴림", 11F, System.Drawing.FontStyle.Bold);
            this.txtScore.Location = new System.Drawing.Point(629, 150);
            this.txtScore.Name = "txtScore";
            this.txtScore.Size = new System.Drawing.Size(100, 23);
            this.txtScore.TabIndex = 3;
            this.txtScore.Text = "  Score : 0";
            this.txtScore.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtHighScore
            // 
            this.txtHighScore.Font = new System.Drawing.Font("굴림", 11F, System.Drawing.FontStyle.Bold);
            this.txtHighScore.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtHighScore.Location = new System.Drawing.Point(629, 184);
            this.txtHighScore.Name = "txtHighScore";
            this.txtHighScore.Size = new System.Drawing.Size(151, 23);
            this.txtHighScore.TabIndex = 4;
            this.txtHighScore.Text = "Highest : 0";
            this.txtHighScore.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gameTimer
            // 
            this.gameTimer.Interval = 200;
            this.gameTimer.Tick += new System.EventHandler(this.gameTimer_Tick);
            // 
            // finishButton
            // 
            this.finishButton.BackColor = System.Drawing.Color.MediumVioletRed;
            this.finishButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.finishButton.Font = new System.Drawing.Font("굴림", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.finishButton.Location = new System.Drawing.Point(632, 79);
            this.finishButton.Name = "finishButton";
            this.finishButton.Size = new System.Drawing.Size(123, 52);
            this.finishButton.TabIndex = 5;
            this.finishButton.Text = "종료";
            this.finishButton.UseVisualStyleBackColor = false;
            this.finishButton.Click += new System.EventHandler(this.finishButton_Click);
            // 
            // txtGameOver
            // 
            this.txtGameOver.Font = new System.Drawing.Font("휴먼옛체", 50F, System.Drawing.FontStyle.Bold);
            this.txtGameOver.ForeColor = System.Drawing.Color.Red;
            this.txtGameOver.Location = new System.Drawing.Point(112, 223);
            this.txtGameOver.Name = "txtGameOver";
            this.txtGameOver.Size = new System.Drawing.Size(425, 126);
            this.txtGameOver.TabIndex = 6;
            this.txtGameOver.Text = "GAME OVER";
            this.txtGameOver.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.txtGameOver.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(806, 642);
            this.Controls.Add(this.txtGameOver);
            this.Controls.Add(this.finishButton);
            this.Controls.Add(this.txtHighScore);
            this.Controls.Add(this.txtScore);
            this.Controls.Add(this.picCanvas);
            this.Controls.Add(this.snapButton);
            this.Controls.Add(this.startButton);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "Snake Game";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyIsDown);
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button snapButton;
        private System.Windows.Forms.PictureBox picCanvas;
        private System.Windows.Forms.Label txtScore;
        private System.Windows.Forms.Label txtHighScore;
        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.Button finishButton;
        private System.Windows.Forms.Label txtGameOver;
    }
}

