using System;
using System.Collections.Generic;

namespace BrickBreaker
{
    public class GameManager
    {
        public void CheckCollisions(Ball ball, Paddle paddle, List<Brick> bricks)
        {
            // Check collision with paddle
            if (ball.Position.Y + ball.Size.Height >= paddle.Position.Y &&
                ball.Position.X + ball.Size.Width >= paddle.Position.X &&
                ball.Position.X <= paddle.Position.X + paddle.Size.Width)
            {
                ball.Velocity = new Point(ball.Velocity.X, -ball.Velocity.Y);
            }

            // Check collision with bricks
            foreach (var brick in bricks)
            {
                if (!brick.IsHit &&
                    ball.Position.Y <= brick.Position.Y + brick.Size.Height &&
                    ball.Position.Y + ball.Size.Height >= brick.Position.Y &&
                    ball.Position.X + ball.Size.Width >= brick.Position.X &&
                    ball.Position.X <= brick.Position.X + brick.Size.Width)
                {
                    brick.Hit();
                    ball.Velocity = new Point(ball.Velocity.X, -ball.Velocity.Y);
                    break;
                }
            }
        }
    }
}
