using Microsoft.VisualBasic.ApplicationServices;
using System.Diagnostics;
using System.Media;
using System.Runtime.Intrinsics.Arm;
using WMPLib;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SpaceShooter
{
    public partial class Form1 : Form
    {
        WindowsMediaPlayer gameMedia;
        WindowsMediaPlayer shootgMedia;
        WindowsMediaPlayer explosion;

        PictureBox[] stars;
        int backgroundspeed;
        int playerSpeed;

        PictureBox[] munitions;
        int MunitionSpeed;

        PictureBox[] enemiesMunition;
        int enemiesMunitionSpeed;

        PictureBox[] enemies;
        int enemiespeed = 5;

        Random rnd;
        private PictureBox Player;

        int score;
        int level;
        int dificulty;
        bool pause;
        bool gameOver;

        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pause = false;
            gameOver = false;
            score = 0;
            level = 1;
            dificulty = 9;

            backgroundspeed = 4;
            playerSpeed = 20;
            MunitionSpeed = 20;
            munitions = new PictureBox[3];
            enemiesMunitionSpeed = 4;

            Image munition = Image.FromFile(@"C:\Users\HP\source\repos\SpaceShooter\SpaceShooter\bin\Debug\asserts\munition.png");

            Image enemi1 = Image.FromFile(@"C:\Users\HP\source\repos\SpaceShooter\SpaceShooter\bin\Debug\asserts\E1.png");
            Image enemi2 = Image.FromFile(@"C:\Users\HP\source\repos\SpaceShooter\SpaceShooter\bin\Debug\asserts\E2.png");
            Image enemi3 = Image.FromFile(@"C:\Users\HP\source\repos\SpaceShooter\SpaceShooter\bin\Debug\asserts\E3.png");
            Image boss1 = Image.FromFile(@"C:\Users\HP\source\repos\SpaceShooter\SpaceShooter\bin\Debug\asserts\Boss1.png");
            Image boss2 = Image.FromFile(@"C:\Users\HP\source\repos\SpaceShooter\SpaceShooter\bin\Debug\asserts\Boss2.png");

            enemies = new PictureBox[10];

            for (int i = 0; i < enemies.Length; i++)
            {
                enemies[i] = new PictureBox();
                enemies[i].Size = new Size(40, 40);
                enemies[i].SizeMode = PictureBoxSizeMode.Zoom;
                enemies[i].BorderStyle = BorderStyle.None;
                enemies[i].Visible = false;
                this.Controls.Add(enemies[i]);
                enemies[i].Location = new Point((i + 1) * 50, -50);
            }

            enemies[0].Image = boss1;
            enemies[1].Image = enemi2;
            enemies[2].Image = enemi3;
            enemies[3].Image = enemi1;
            enemies[4].Image = enemi2;
            enemies[5].Image = enemi3;
            enemies[6].Image = enemi1;
            enemies[7].Image = enemi2;
            enemies[8].Image = enemi3;
            enemies[9].Image = boss2;

            for (int i = 0; i < munitions.Length; i++)
            {
                munitions[i] = new PictureBox();
                munitions[i].Image = munition;
                munitions[i].Size = new Size(8, 8);
                munitions[i].SizeMode = PictureBoxSizeMode.Zoom;
                munitions[i].BorderStyle = BorderStyle.None;
                this.Controls.Add(munitions[i]);
            }

            gameMedia = new WindowsMediaPlayer();
            shootgMedia = new WindowsMediaPlayer();
            explosion = new WindowsMediaPlayer();

            gameMedia.URL = "C:\\Users\\HP\\source\\repos\\SpaceShooter\\SpaceShooter\\bin\\Debug\\songs\\GameSong.mp3";
            shootgMedia.URL = "C:\\Users\\HP\\source\\repos\\SpaceShooter\\SpaceShooter\\bin\\Debug\\songs\\shoot.mp3";
            explosion.URL = "C:\\Users\\HP\\source\\repos\\SpaceShooter\\SpaceShooter\\bin\\Debug\\songs\\boom.mp3";

            gameMedia.settings.setMode("loop", true);
            gameMedia.settings.volume = 5;
            shootgMedia.settings.volume = 1;
            explosion.settings.volume = 6;

            stars = new PictureBox[15];
            rnd = new Random();


            for (int i = 0; i < stars.Length; i++)
            {
                stars[i] = new PictureBox();
                stars[i].BorderStyle = BorderStyle.None;
                stars[i].Location = new Point(rnd.Next(20, 500), rnd.Next(-10, 400));
                if (i % 2 == 1)
                {
                    stars[i].Size = new Size(2, 2);
                    stars[i].BackColor = Color.Wheat;
                }
                else
                {
                    stars[i].Size = new Size(2, 2);
                    stars[i].BackColor = Color.Wheat;
                }
                this.Controls.Add(stars[i]);
            }

            enemiesMunition = new PictureBox[10];

            for (int i = 0; i < enemiesMunition.Length; i++)
            {
                enemiesMunition[i] = new PictureBox();
                enemiesMunition[i].Size = new Size(2, 25);
                enemiesMunition[i].Visible = false;
                enemiesMunition[i].BackColor = Color.Yellow;
                int x = rnd.Next(0, 10);
                enemiesMunition[i].Location = new Point(enemies[i].Location.X, enemies[x].Location.Y - 20);
                this.Controls.Add(enemiesMunition[i]);
            }

            gameMedia.controls.play();

            Player = pictureBox1;
            Player.Location = new Point(328, 388);

            MoveBgTimer.Start();
            MoveEnemiesTimer.Start();

        }

        private void MoveBgTimer_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < stars.Length / 2; i++)
            {
                stars[i].Top += backgroundspeed;

                if (stars[i].Top >= this.Height)
                {
                    stars[i].Top = -stars[i].Height;
                }
            }

            for (int i = stars.Length / 2; i < stars.Length; i++)
            {
                stars[i].Top += backgroundspeed - 2;

                if (stars[i].Top >= this.Height)
                {
                    stars[i].Top = -stars[i].Height;
                }
            }

        }

        private void LeftMoveTimer_Tick(object sender, EventArgs e)
        {
            if (Player.Left > 10)
            {
                Player.Left -= playerSpeed;
            }

        }

        private void RightMoveTimer_Tick(object sender, EventArgs e)
        {
            if (Player.Right < 580)
            {
                Player.Left += playerSpeed;
            }
        }

        private void DownMoveTimer_Tick(object sender, EventArgs e)
        {
            if (Player.Top < 400)
            {
                Player.Top += playerSpeed;
            }
        }

        private void UpMoveTimer_Tick(object sender, EventArgs e)
        {
            if (Player.Top > 10)
            {
                Player.Top -= playerSpeed;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (!pause)
            {
                if (e.KeyCode == Keys.Right)
                {
                    RightMoveTimer.Start();
                }
                if (e.KeyCode == Keys.Left)
                {
                    LeftMoveTimer.Start();
                }
                if (e.KeyCode == Keys.Down)
                {
                    DownMoveTimer.Start();
                }
                if (e.KeyCode == Keys.Up)
                {
                    UpMoveTimer.Start();
                }
            }

        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            LeftMoveTimer.Stop();
            RightMoveTimer.Stop();
            DownMoveTimer.Stop();
            UpMoveTimer.Stop();
            if (e.KeyCode == Keys.Space)
            {
                if (!gameOver)
                    if (pause)
                    {
                        StartTimer();
                        label1.Visible = false;
                        gameMedia.controls.play();
                        pause = false;
                    }
                    else
                    {
                        label1.Location = new Point(this.Width / 2 - 120, 150);
                        label1.Text = "PAUSED";
                        label1.Visible = true;
                        gameMedia.controls.pause();
                        StopTimers();
                        pause = true;
                    }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void MoveMunitiontimer_Tick(object sender, EventArgs e)
        {
            shootgMedia.controls.play();

            for (int i = 0; i < munitions.Length; i++)
            {
                if (munitions[i].Top > 0)
                {
                    munitions[i].Visible = true;
                    munitions[i].Top -= MunitionSpeed;

                    collision();
                    collisionWithEnemiesMunition();
                }
                else
                {
                    munitions[i].Visible = false;
                    munitions[i].Location = new Point(Player.Location.X + 20, Player.Location.Y - i * 30);
                }
            }
        }

        private void MoveEnemiesTimer_Tick(object sender, EventArgs e)
        {
            MoveEnemies(enemies, enemiespeed);
        }

        private void MoveEnemies(PictureBox[] array, int speed)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i].Visible = true;
                array[i].Top += speed;

                if (array[i].Top > this.Height)
                {
                    array[i].Location = new Point((i + 2) * 50, -200);
                }
            }
        }

        private void collision()
        {
            for (int i = 0; i < enemies.Length; i++)
            {
                if (munitions[0].Bounds.IntersectsWith(enemies[i].Bounds)
                    || munitions[1].Bounds.IntersectsWith(enemies[i].Bounds)
                    || munitions[2].Bounds.IntersectsWith(enemies[i].Bounds))
                {
                    explosion.controls.play();

                    score += 1;
                    btnScore.Text = (score < 10) ? "Score " + score.ToString() : score.ToString();
                    if (score % 30 == 0)
                    {
                        level += 1;
                        btnlevel.Text = (level < 10) ? "Level 0" + level.ToString() : level.ToString();
                        if (enemiespeed <= 10 && enemiesMunitionSpeed <= 10 && dificulty >= 0 )
                            {
                            dificulty--;
                            enemiespeed++;
                            enemiesMunitionSpeed++;
                            }
                        if (level <= 10  )
                        {
                            GameOver("Nice Game");
                        }
                    }

                    enemies[i].Location = new Point((i + 1) * 50, -100);
                }
                if (Player.Bounds.IntersectsWith(enemies[i].Bounds))
                {
                    explosion.settings.volume = 30;
                    explosion.controls.play();
                    Player.Visible = false;
                    GameOver("Game Over");
                }
            }
        }

        private void GameOver(string str)
        {

            button1.Visible = true;
            button2.Visible = true;

            gameMedia.controls.stop();
            StopTimers();
        }

        private void StopTimers()
        {
            MoveBgTimer.Stop();
            MoveEnemiesTimer.Stop();
            MoveMunitiontimer.Stop();
            EnemiesMunitionTimer.Stop();
        }
        private void StartTimer()
        {
            MoveBgTimer.Start();
            MoveEnemiesTimer.Start();
            MoveMunitiontimer.Start();
            EnemiesMunitionTimer.Start();
        }

        private void EnemiesMunitionTimer_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < (enemiesMunition.Length - dificulty); i++)
            {
                if (enemiesMunition[i].Top < this.Height)
                {
                    enemiesMunition[i].Visible = true;
                    enemiesMunition[i].Top += enemiesMunitionSpeed;
                }
                else
                {
                    enemiesMunition[i].Visible = false;
                    int x = rnd.Next(0, 10);
                    enemiesMunition[i].Location = new Point(enemies[x].Location.X + 20, enemies[i].Location.Y + 30);
                }
            }
        }
        private void collisionWithEnemiesMunition()
        {
            for (int i = 0; i < enemiesMunition.Length; i++)
            {
                if (enemiesMunition[i].Bounds.IntersectsWith(Player.Bounds))
                {
                    munitions[i].Visible = false;
                    explosion.settings.volume = 30;
                    explosion.controls.play();
                    Player.Visible = false;
                    GameOver("Game over");

                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            InitializeComponent();
            Form1_Load(e, e);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

      

        private void btnlevel_Click(object sender, EventArgs e)
        {

        }

        private void btnScore_Click(object sender, EventArgs e)
        {

        }
    }
}
