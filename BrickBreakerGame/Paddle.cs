using SFML.Graphics;
using SFML.System;
using SFML.Window;

class Paddle
{
    public RectangleShape Shape { get; private set; }

    public Paddle()
    {
        Shape = new RectangleShape(new Vector2f(100, 20))
        {
            FillColor = Color.White,
            Position = new Vector2f(350, 550)
        };
    }

    public void Update()
    {
        if (Keyboard.IsKeyPressed(Keyboard.Key.Left) && Shape.Position.X > 0)
        {
            Shape.Position = new Vector2f(Shape.Position.X - 10, Shape.Position.Y);
        }
        if (Keyboard.IsKeyPressed(Keyboard.Key.Right) && Shape.Position.X + Shape.Size.X < 800)
        {
            Shape.Position = new Vector2f(Shape.Position.X + 10, Shape.Position.Y);
        }
    }

    public void Draw(RenderWindow window)
    {
        window.Draw(Shape);
    }
}
