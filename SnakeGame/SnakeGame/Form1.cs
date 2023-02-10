using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;    //JPG 압축

namespace SnakeGame
{
    public partial class Form1 : Form
    {
        private List<Circle> Snake = new List<Circle>();
        private Circle food = new Circle();

        int maxWidth, maxHeight;

        int score = 0; 
        int highScore = 0;

        Random rand = new Random();

        public Form1()
        {
            InitializeComponent();
            new Settings();            
        }
        
        /// <summary>
        /// 키보드 입력에 관한 정의
        /// 엔터 : 게임 시작
        /// 방향키 : 뱀 이동방향 조작
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KeyIsDown(object sender, KeyEventArgs e)
        
        
        {
            //엔터키로 게임 시작
            if (e.KeyCode == Keys.Enter)
            {
                this.startButton.PerformClick();
            }

            //방향키
            if (e.KeyCode == Keys.Left && Settings.direction != Directions.Right)
            {
                Settings.direction = Directions.Left;
            }
            else if (e.KeyCode == Keys.Right && Settings.direction != Directions.Left)
            {
                Settings.direction = Directions.Right;
            }
            else if (e.KeyCode == Keys.Up && Settings.direction != Directions.Down)
            {
                Settings.direction = Directions.Up;
            }
            else if (e.KeyCode == Keys.Down && Settings.direction != Directions.Up)
            {
                Settings.direction = Directions.Down;
            }
        }

        /// <summary>
        /// 스크린샷 촬영, 저장
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TakeSnapshot(object sender, EventArgs e)
        {
            Label caption = new Label();
            caption.Text = "Score: " + score + " // Highscore: " + highScore ;
            caption.Font = new Font("Ariel", 12, FontStyle.Bold);
            caption.ForeColor = Color.Purple;
            caption.AutoSize = false;
            caption.Width = picCanvas.Width;
            caption.Height = 30;
            caption.TextAlign = ContentAlignment.MiddleCenter;
            picCanvas.Controls.Add(caption);
            
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.FileName = "Snake Game SnapShot";
            dialog.DefaultExt = "jpg";
            dialog.Filter = "JPG Image File | *.jpg";
            dialog.ValidateNames = true;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                int width = Convert.ToInt32(picCanvas.Width);
                int height = Convert.ToInt32(picCanvas.Height);
                Bitmap bmp = new Bitmap(width, height);
                picCanvas.DrawToBitmap(bmp, new Rectangle(0, 0, width, height));
                bmp.Save(dialog.FileName, ImageFormat.Jpeg);
                picCanvas.Controls.Remove(caption);
            }
        }

        /// <summary>
        /// interval(~200ms) 간격으로 게임 진행
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gameTimer_Tick(object sender, EventArgs e)
        {
            //뱀 업데이트
            for (int i = Snake.Count - 1; i >= 0; i--)
            {
                //head
                if (i == 0)
                {
                    switch (Settings.direction)
                    {
                        case Directions.Left:
                            Snake[i].X--; break;
                        case Directions.Right:
                            Snake[i].X++; break;
                        case Directions.Up:
                            Snake[i].Y++; break;
                        case Directions.Down:
                            Snake[i].Y--; break;
                    }

                    if (Snake[i].X == food.X && Snake[i].Y == food.Y)
                    { 
                        EatFood();
                    }

                    //head가 picCanvas 테두리에 닿는 경우 game over
                    if (Snake[i].X < 0 || Snake[i].X > maxWidth || Snake[i].Y < 0 || Snake[i].Y > maxHeight)
                    {
                        GameOver();
                    }       

                    //head가 body 부분에 닿는 경우 game over
                    for (int j = 1; j < Snake.Count; j++) 
                    {
                        if (Snake[i].X == Snake[j].X && Snake[i].Y == Snake[j].Y)  
                        { 
                            GameOver(); 
                        }
                    }
                }
                //bo
                else
                {
                    Snake[i].X = Snake[i - 1].X;
                    Snake[i].Y = Snake[i - 1].Y;
                }
            }
            picCanvas.Invalidate();
        }

        private void UpdatePictureBoxGraphics(object sender, PaintEventArgs e)
        {
            Graphics canvas = e.Graphics;
            Brush snakeColor;
             
            //뱀 그리기
            for (int i = 0; i < Snake.Count; i++)
            {
                if (i == 0)
                { snakeColor = Brushes.Black; }
                else
                { snakeColor = Brushes.DarkGreen; }

                canvas.FillEllipse(snakeColor, new Rectangle
                    (
                    Snake[i].X * Settings.Width,
                    Snake[i].Y * Settings.Height,
                    Settings.Width, Settings.Height
                    ));
            }

            canvas.FillEllipse(Brushes.DarkRed, new Rectangle
            (
            food.X * Settings.Width,
            food.Y * Settings.Height,
            Settings.Width, Settings.Height
            ));

            //격자 그리기
            int Xn = picCanvas.Width;
            int Yn = picCanvas.Height;
            Pen pen = new Pen(Color.FromArgb(150, 255, 255, 255));

            for (int x = 0; x < Xn - 1; x += 20)
            {
                e.Graphics.DrawLine(pen, x, 0, x, Yn);
            }
            for (int y = 0; y < Yn - 1; y += 20)
            {
                e.Graphics.DrawLine(pen, 0, y, Xn, y);
            }
        }

        /// <summary>
        /// 강제종료
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void finishButton_Click(object sender, EventArgs e)
        {
            GameOver();
        }

        private void StartGame_Click(object sender, EventArgs e)
        {
            RestartGame();
        }

        /// <summary>
        /// 처음 snake : 3(head(1) + body(2)) 
        /// food : 랜덤한 위치에 생성
        /// </summary>
        private void RestartGame()
        {
            txtGameOver.Visible = false;

            maxWidth = picCanvas.Width / Settings.Width - 1;
            maxHeight = picCanvas.Height / Settings.Height - 1;

            picCanvas.Controls.Clear();
            Snake.Clear();

            startButton.Enabled = false;
            snapButton.Enabled = false;
            finishButton.Enabled = true;

            score = 0;
            txtScore.Text = "Score: " + score;

            Circle head = new Circle { X = 15, Y = 15};
            Snake.Add(head); 

            for (int i = 0; i < 2; i++)
            {
                Circle body = new Circle();
                Snake.Add(body);
            }

            food = new Circle { X = rand.Next(2, maxWidth), Y = rand.Next(2, maxHeight) };

            gameTimer.Start();
        }

        /// <summary>
        /// 뱀의 머리가 음식에 닿으면 점수 +1, 몸의 길이 +1, interval -5
        /// 새로운 음식을 랜덤한 장소에 생성
        /// </summary>
        private void EatFood()
            {
                score += 1;
                gameTimer.Interval -= 5;
                txtScore.Text = "Score: " + score;

                Circle body = new Circle
                {
                    X = Snake[Snake.Count - 1].X,
                    Y = Snake[Snake.Count - 1].Y
                };

                Snake.Add(body);

                food = new Circle { X = rand.Next(2, maxWidth), Y = rand.Next(2, maxHeight) };
            }

        private void GameOver()
            {
            gameTimer.Stop();
            startButton.Enabled = true;
            snapButton.Enabled = true;
            finishButton.Enabled = false;

            if (score > highScore || highScore == 0)
            {
                highScore = score;

                txtHighScore.Text = "Highest : " + highScore;
                txtHighScore.ForeColor = Color.Maroon;
                txtHighScore.TextAlign = ContentAlignment.MiddleLeft;
                txtGameOver.Visible = true;
            }
        }
    }
}