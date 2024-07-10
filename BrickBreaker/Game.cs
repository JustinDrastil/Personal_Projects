using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace BrickBreaker
{
    public class Game : Form
    {
        private Timer gameTimer;
        private Ball ball;
        private Paddle paddle;
        private List<Brick> bricks;
        private GameManager gameManager;

        public Game()
        {
            InitializeGame();
        }

        private void InitializeGame()
        {
            this.Width = 800;
            this.Height = 600;
            this.Text = "Brick Breaker";
            this.DoubleBuffered = true;

            ball = new Ball(new Point(400, 300), new Size(10, 10));
            paddle = new Paddle(new Point(350, 550), new Size(100, 20));
            bricks = new List<Brick>();
            gameManager = new GameManager();

            // Example: Add some bricks
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    bricks.Add(new Brick(new Point(50 + i * 150, 50 + j * 50), new Size(100, 30)));
                }
            }

            gameTimer = new Timer();
            gameTimer.Interval = 16; // ~60 FPS
            gameTimer.Tick += GameLoop;
            gameTimer.Start();
        }

        private void GameLoop(object sender, EventArgs e)
        {
            UpdateGame();
            this.Invalidate();
        }

        private void UpdateGame()
        {
            ball.Update();
            paddle.Update();
            gameManager.CheckCollisions(ball, paddle, bricks);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            ball.Draw(g);
            paddle.Draw(g);
            foreach (var brick in bricks)
            {
                brick.Draw(g);
            }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            paddle.OnKeyDown(e);
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            paddle.OnKeyUp(e);
        }
    }
}
