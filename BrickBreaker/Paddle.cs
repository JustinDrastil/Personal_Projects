using System;
using System.Drawing;
using System.Windows.Forms;

namespace BrickBreaker
{
    public class Paddle
    {
        public Point Position { get; private set; }
        public Size Size { get; private set; }
        public int Speed { get; private set; }

        private bool moveLeft;
        private bool moveRight;

        public Paddle(Point position, Size size)
        {
            Position = position;
            Size = size;
            Speed = 10;
        }

        public void Update()
        {
            if (moveLeft && Position.X > 0)
            {
                Position = new Point(Position.X - Speed, Position.Y);
            }

            if (moveRight && Position.X + Size.Width < 800)
            {
                Position = new Point(Position.X + Speed, Position.Y);
            }
        }

        public void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                moveLeft = true;
            }
            if (e.KeyCode == Keys.Right)
            {
                moveRight = true;
            }
        }

        public void OnKeyUp(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                moveLeft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                moveRight = false;
            }
        }

        public void Draw(Graphics g)
        {
            g.FillRectangle(Brushes.Blue, Position.X, Position.Y, Size.Width, Size.Height);
        }
    }
}
