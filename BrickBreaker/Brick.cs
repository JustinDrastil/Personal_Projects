using System;
using System.Drawing;

namespace BrickBreaker
{
    public class Brick
    {
        public Point Position { get; private set; }
        public Size Size { get; private set; }
        public bool IsHit { get; private set; }

        public Brick(Point position, Size size)
        {
            Position = position;
            Size = size;
            IsHit = false;
        }

        public void Hit()
        {
            IsHit = true;
        }

        public void Draw(Graphics g)
        {
            if (!IsHit)
            {
                g.FillRectangle(Brushes.Green, Position.X, Position.Y, Size.Width, Size.Height);
                g.DrawRectangle(Pens.Black, Position.X, Position.Y, Size.Width, Size.Height);
            }
        }
    }
}
