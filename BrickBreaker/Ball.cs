using System;
using System.Drawing;

namespace BrickBreaker
{
    public class Ball
    {
        public Point Position { get; private set; }
        public Size Size { get; private set; }
        public Point Velocity { get; private set; }

        public Ball(Point position, Size size)
        {
            Position = position;
            Size = size;
            Velocity = new Point(5, -5);
        }

        public void Update()
        {
            Position = new Point(Position.X + Velocity.X, Position.Y + Velocity.Y);

            // Handle wall collisions
            if (Position.X <= 0 || Position.X + Size.Width >= 800)
            {
                Velocity = new Point(-Velocity.X, Velocity.Y);
            }

            if (Position.Y <= 0 || Position.Y + Size.Height >= 600)
            {
                Velocity = new Point(Velocity.X, -Velocity.Y);
            }
        }

        public void Draw(Graphics g)
        {
            g.FillEllipse(Brushes.Red, Position.X, Position.Y, Size.Width, Size.Height);
        }
    }
}
