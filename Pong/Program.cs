using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

namespace Pong
{

    public class Program
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                StartGame();

                bool restart = Screens.ShowLeaderBoardScreen();

                if (!restart) break;  // spiller vil stoppe -> afslut
            }
        }

        public static void StartGame()
        {
            int winnerScore = 5;

            var (p1, p2) = Screens.ShowStartScreen();

            // Setup objecter
            GameField field = new GameField(50, 15, '#', 10);
            Racket leftRacket = new Racket(field.OffsetX + 1, field.Height / 4, '|', ConsoleColor.Blue);
            Racket rightRacket = new Racket(field.OffsetX + field.Width - 2, field.Height / 4, '|', ConsoleColor.Red);

            leftRacket.Height = field.Height / 2 - leftRacket.Length / 2;
            rightRacket.Height = field.Height / 2 - rightRacket.Length / 2;

            Ball ball = new Ball(field.OffsetX + field.Width / 2, field.Height / 2, 'O');
            Scoreboard sb = new Scoreboard(field.Width, field.Height + 1, p1, p2);

            // -------------------------------------
            // SPILLOOP
            // -------------------------------------
            while (true)
            {
                Console.Clear();

                field.DrawBorders();
                leftRacket.Draw();
                rightRacket.Draw();
                sb.Draw();
                ball.Draw();

                Thread.Sleep(100);

                ball.Clear();
                ball.Move();

                if (ball.Y <= 1 || ball.Y >= field.Height - 1)
                    ball.GoingDown = !ball.GoingDown;

                if (ball.X == leftRacket.X)
                {
                    if (ball.Y >= leftRacket.Height && ball.Y <= leftRacket.Height + leftRacket.Length - 1)
                        ball.GoingRight = true;
                    else
                    {
                        sb.RightPoints++;
                        ball.Reset(field.Width / 2, field.Height / 2);
                    }
                }

                if (ball.X == rightRacket.X)
                {
                    if (ball.Y >= rightRacket.Height && ball.Y <= rightRacket.Height + rightRacket.Length - 1)
                        ball.GoingRight = false;
                    else
                    {
                        sb.LeftPoints++;
                        ball.Reset(field.Width / 2, field.Height / 2);
                    }
                }

                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(true).Key;

                    while (Console.KeyAvailable) Console.ReadKey(true);

                    if (key == ConsoleKey.W) leftRacket.MoveUp();
                    if (key == ConsoleKey.S) leftRacket.MoveDown(field.Height);
                    if (key == ConsoleKey.UpArrow) rightRacket.MoveUp();
                    if (key == ConsoleKey.DownArrow) rightRacket.MoveDown(field.Height);
                }

                if (sb.LeftPoints >= winnerScore || sb.RightPoints >= winnerScore)
                    break;
            }

            // GAME OVER
            Screens.ShowGameOverScreen(sb.LeftPoints, sb.RightPoints, p1, p2);
        }
    }

}