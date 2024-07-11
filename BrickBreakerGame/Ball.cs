using SFML.Graphics;
using SFML.System;

class Ball
{
    public CircleShape Shape { get; private set; }
    private Vector2f velocity;

    public Ball()
    {
        Shape = new CircleShape(10)
        {
            FillColor = Color.White,
            Position = new Vector2f(395, 540)
        };
        velocity = new Vector2f(5, -5);
    }

    public void Update(Paddle paddle, Brick[,] bricks)
    {
        Shape.Position += velocity;

        if (Shape.Position.X < 0 || Shape.Position.X + Shape.Radius * 2 > 800)
        {
            velocity.X = -velocity.X;
        }
        if (Shape.Position.Y < 0)
        {
            velocity.Y = -velocity.Y;
        }
        if (Shape.GetGlobalBounds().Intersects(paddle.Shape.GetGlobalBounds()))
        {
            velocity.Y = -velocity.Y;
        }

        for (int i = 0; i < bricks.GetLength(0); i++)
        {
            for (int j = 0; j < bricks.GetLength(1); j++)
            {
                if (bricks[i, j] != null && Shape.GetGlobalBounds().Intersects(bricks[i, j].Shape.GetGlobalBounds()))
                {
                    bricks[i, j] = null;
                    velocity.Y = -velocity.Y;
                }
            }
        }

        if (Shape.Position.Y > 600)
        {
            // Ball fell out of the screen
            // Reset ball position
            Shape.Position = new Vector2f(395, 540);
            velocity = new Vector2f(5, -5);
        }
    }

    public void Draw(RenderWindow window)
    {
        window.Draw(Shape);
    }
}
