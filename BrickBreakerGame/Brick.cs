using SFML.Graphics;
using SFML.System;

class Brick
{
    public RectangleShape Shape { get; private set; }

    public Brick(float x, float y)
    {
        Shape = new RectangleShape(new Vector2f(80, 30))
        {
            FillColor = Color.Green,
            Position = new Vector2f(x, y)
        };
    }

    public void Draw(RenderWindow window)
    {
        window.Draw(Shape);
    }
}
