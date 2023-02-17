using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ActividadColisiones
{
public class Ball
{
    public int X { get; set; }
    public int Y { get; set; }
    public int Radius { get; set; }
    public int Vx { get; set; }
    public int Vy { get; set; }
    public Color Color { get; set; }

        public Ball(int x, int y, int radius, int vx, int vy)
    {
        X = x;
        Y = y;
        Radius = radius;
        Vx = vx;
        Vy = vy;
            Color = GetRandomColor();
        }
        private static Random random = new Random();
        private static Color GetRandomColor()
        {
            return Color.FromArgb(random.Next(256), random.Next(256), random.Next(256));
        }

        public void Update(List<Ball> balls, int canvasWidth, int canvasHeight)
        {
            // Update the position of the ball
            X += Vx;
            Y += Vy;

            // Check if the ball has hit a wall and reverse its velocity if it has
            if (X - Radius < 0 || X + Radius > canvasWidth)
            {
                Vx = -Vx;
            }
            if (Y - Radius < 0 || Y + Radius > canvasHeight)
            {
                Vy = -Vy;
            }

            // Check for collisions with other balls
            foreach (var ball in balls)
            {
                if (ball != this)
                {
                    int dx = X - ball.X;
                    int dy = Y - ball.Y;
                    int distance = (int)Math.Sqrt(dx * dx + dy * dy);
                    int minDist = Radius + ball.Radius;

                    if (distance < minDist)
                    {
                        // The balls have collided, so reverse their velocities
                        int tx = Vx;
                        int ty = Vy;
                        Vx = ball.Vx;
                        Vy = ball.Vy;
                        ball.Vx = tx;
                        ball.Vy = ty;
                    }
                }
            }
        }

    }


}