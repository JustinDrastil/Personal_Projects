using System;
using SFML.Graphics;
using SFML.Window;
using SFML.System;

class Program
{
    static void Main(string[] args)
    {
        // Window setup
        VideoMode mode = new VideoMode(800, 600);
        RenderWindow window = new RenderWindow(mode, "Brick Breaker Game");
        window.SetFramerateLimit(60);

        // Game elements
        Paddle paddle = new Paddle();
        Ball ball = new Ball();
        Brick[,] bricks = new Brick[5, 10];

        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                bricks[i, j] = new Brick(j * 80, i * 30 + 50);
            }
        }

        // Event handling
        window.Closed += (sender, e) => window.Close();
        window.KeyPressed += (sender, e) =>
        {
            if (e.Code == Keyboard.Key.Escape)
                window.Close();
        };

        // Game loop
        while (window.IsOpen)
        {
            window.DispatchEvents();

            // Update game elements
            paddle.Update();
            ball.Update(paddle, bricks);

            // Clear screen
            window.Clear(Color.Black);

            // Draw game elements
            paddle.Draw(window);
            ball.Draw(window);
            foreach (var brick in bricks)
            {
                if (brick != null)
                    brick.Draw(window);
            }

            // Display
            window.Display();
        }
    }
}
