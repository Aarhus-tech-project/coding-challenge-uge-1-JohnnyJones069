using System;
using System.Linq;
using System.Threading;

namespace Pong
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int winnerScore = 5; // Scoren for at vinde

            Screens.ShowStartScreen();

            // Setup objecter
            GameField field = new GameField(50, 15, '#');
            Racket leftRacket = new Racket(0, field.Height / 4, '|');
            Racket rightRacket = new Racket(field.Width - 1, field.Height / 4, '|');

            // Start på midten af banen
            leftRacket.Height = field.Height / 2 - leftRacket.Length / 2;
            rightRacket.Height = field.Height / 2 - rightRacket.Length / 2;

            Ball ball = new Ball(field.Width / 2, field.Height / 2, 'O');
            Scoreboard sb = new Scoreboard(field.Width, field.Height + 1);

            // Spil loop
            while (true)
            {
                Console.Clear();

                // Tegn ramme
                field.DrawBorders();

                // Tegn opjekter
                leftRacket.Draw();
                rightRacket.Draw();
                sb.Draw();
                ball.Draw();

                Thread.Sleep(100);

                // Ryd bold og flyt den
                ball.Clear();
                ball.Move();

                // Bold kollision med top/bund
                if (ball.Y <= 1 || ball.Y >= field.Height - 1)
                    ball.GoingDown = !ball.GoingDown;

                // Venstre side
                if (ball.X <= leftRacket.X + 1)
                {
                    if (ball.Y >= leftRacket.Height + 1 && ball.Y <= leftRacket.Height + leftRacket.Length)
                        ball.GoingRight = true;
                    else
                    {
                        sb.RightPoints++;
                        ball.Reset(field.Width / 2, field.Height / 2);
                    }
                }

                // Højre side
                if (ball.X >= rightRacket.X - 1)
                {
                    if (ball.Y >= rightRacket.Height + 1 && ball.Y <= rightRacket.Height + rightRacket.Length)
                        ball.GoingRight = false;
                    else
                    {
                        sb.LeftPoints++;
                        ball.Reset(field.Width / 2, field.Height / 2);
                    }
                }

                //Ketcher kontrols
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(true).Key;

                    // Tøm Key-buffer med det samme
                    while (Console.KeyAvailable) Console.ReadKey(true);

                    if (key == ConsoleKey.W) leftRacket.MoveUp();
                    if (key == ConsoleKey.S) leftRacket.MoveDown(field.Height);
                    if (key == ConsoleKey.UpArrow) rightRacket.MoveUp();
                    if (key == ConsoleKey.DownArrow) rightRacket.MoveDown(field.Height);
                }

                // Tjek for vinder
                if (sb.LeftPoints >= winnerScore || sb.RightPoints >= winnerScore)
                    break;
            }

            // GAME-OVER skærm
            Screens.ShowGameOverScreen(sb.LeftPoints, sb.RightPoints);
        }


    }
}