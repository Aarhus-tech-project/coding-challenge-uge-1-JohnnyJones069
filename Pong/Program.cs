using System;
using System.Linq;
using System.Threading;

namespace Pong
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Field
            const int fieldLength = 50, fieldWidth = 15;
            const char fieldTile = '#';
            string line = string.Concat(Enumerable.Repeat(fieldTile, fieldLength));

            //Rackets 
            const int racketLength = fieldWidth / 4;
            const char racketTile = '|';

            int leftRacketHeight = 0;
            int rightRacketHeight = 0;

            //Ball
            int ballX = fieldLength / 2;
            int ballY = fieldWidth / 2;
            const char ballTile = 'O';

            bool isBallGoingDown = true;
            bool isBallGoingRight = true;

            //Points
            int leftPlayerPoints = 0;
            int rightPlayerPoints = 0;

            //Scoreboard
            int scoreboardX = fieldLength / 2 - 2;
            int scoreboardY = fieldWidth + 1;

            //Spillernavne
            string leftPlayerName = "P1";
            string rightPlayerName = "P2";

            int leftNameX = 0;
            int rightNameX = fieldLength - rightPlayerName.Length;

            while (true)
            {
                //Print the borders
                Console.SetCursorPosition(0, 0);
                Console.WriteLine(line);

                Console.SetCursorPosition(0, fieldWidth);
                Console.WriteLine(line);

                //Print the rackets
                for (int i = 0; i < racketLength; i++)
                {
                    Console.SetCursorPosition(0, i + 1 + leftRacketHeight);
                    Console.Write(racketTile);
                    Console.SetCursorPosition(fieldLength - 1, i + 1 + rightRacketHeight);
                    Console.Write(racketTile);
                }

                Console.SetCursorPosition(0, scoreboardY);
                Console.Write(leftPlayerName);
                Console.SetCursorPosition(fieldLength - 2, scoreboardY);
                Console.Write(rightPlayerName);

                //Do until a key is pressed
                while (!Console.KeyAvailable)
                {
                    Console.SetCursorPosition(ballX, ballY);
                    Console.Write(ballTile);
                    Thread.Sleep(100); //Adds a timer so that the players have time to react

                    Console.SetCursorPosition(ballX, ballY);
                    Console.Write(" "); //Clears the previous position of the ball

                    //Update position of the ball
                    if (isBallGoingDown)
                    {
                        ballY++;
                    }
                    else
                    {
                        ballY--;
                    }

                    if (isBallGoingRight)
                    {
                        ballX++;
                    }
                    else
                    {
                        ballX--;
                    }

                    if (ballY == 1 || ballY == fieldWidth - 1)
                    {
                        isBallGoingDown = !isBallGoingDown; //Change direction
                    }

                    if (ballX == 1)
                    {
                        if (ballY >= leftRacketHeight + 1 && ballY <= leftRacketHeight + racketLength) //Left racket hits the ball and it bounces
                        {
                            isBallGoingRight = !isBallGoingRight;
                        }
                        else //Ball goes out of the field; Right player scores
                        {
                            rightPlayerPoints++;
                            ballY = fieldWidth / 2;
                            ballX = fieldLength / 2;
                            Console.SetCursorPosition(scoreboardX, scoreboardY);
                            Console.WriteLine($"{leftPlayerPoints} | {rightPlayerPoints}");

                            // Venstre spiller navn
                            Console.SetCursorPosition(leftNameX, scoreboardY);
                            Console.Write(leftPlayerName);

                            // Højre spiller navn
                            Console.SetCursorPosition(rightNameX, scoreboardY);
                            Console.Write(rightPlayerName);

                            if (rightPlayerPoints == 5)
                            {
                                goto outer;
                            }
                        }
                    }

                    if (ballX == fieldLength - 2)
                    {
                        if (ballY >= rightRacketHeight + 1 && ballY <= rightRacketHeight + racketLength) //Right racket hits the ball and it bounces
                        {
                            isBallGoingRight = !isBallGoingRight;
                        }
                        else //Ball goes out of the field; Left player scores
                        {
                            leftPlayerPoints++;
                            ballY = fieldWidth / 2;
                            ballX = fieldLength / 2;
                            Console.SetCursorPosition(scoreboardX, scoreboardY);
                            Console.WriteLine($"{leftPlayerPoints} | {rightPlayerPoints}");

                            // Venstre spiller navn
                            Console.SetCursorPosition(leftNameX, scoreboardY);
                            Console.Write(leftPlayerName);

                            // Højre spiller navn
                            Console.SetCursorPosition(rightNameX, scoreboardY);
                            Console.Write(rightPlayerName);

                            if (leftPlayerPoints == 5)
                            {
                                goto outer;
                            }
                        }
                    }
                }

                //Check which key has been pressed
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.UpArrow:
                        if (rightRacketHeight > 0)
                        {
                            rightRacketHeight--;
                        }
                        break;

                    case ConsoleKey.DownArrow:
                        if (rightRacketHeight < fieldWidth - racketLength - 1)
                        {
                            rightRacketHeight++;
                        }
                        break;

                    case ConsoleKey.W:
                        if (leftRacketHeight > 0)
                        {
                            leftRacketHeight--;
                        }
                        break;

                    case ConsoleKey.S:
                        if (leftRacketHeight < fieldWidth - racketLength - 1)
                        {
                            leftRacketHeight++;
                        }
                        break;
                }

                //Clear the rackets’ previous positions
                for (int i = 1; i < fieldWidth; i++)
                {
                    Console.SetCursorPosition(0, i);
                    Console.Write(" ");
                    Console.SetCursorPosition(fieldLength - 1, i);
                    Console.Write(" ");
                }
            }
        outer:;
            Console.Clear();
            Console.CursorVisible = true;

            // Ramme
            int screenWidth = 50;
            int screenHeight = 15;
            string horizontalBorder = new string('#', screenWidth);

            Console.ForegroundColor = ConsoleColor.White;

            // Top og bund
            Console.SetCursorPosition(0, 0);
            Console.WriteLine(horizontalBorder);

            Console.SetCursorPosition(0, screenHeight);
            Console.WriteLine(horizontalBorder);

            // GAME OVER – stor og farvet
            string gameOverText = " GAME OVER ";
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition((screenWidth - gameOverText.Length) / 2, screenHeight / 2 - 2);
            Console.WriteLine(gameOverText);

            // Vindertekst
            Console.ForegroundColor = ConsoleColor.Yellow;
            string winnerText = rightPlayerPoints == 10 ? "Player 2 Wins!" : "Player 1 Wins!";
            Console.SetCursorPosition((screenWidth - winnerText.Length) / 2, screenHeight / 2);
            Console.WriteLine(winnerText);

            // Undertekst
            Console.ForegroundColor = ConsoleColor.Gray;
            string exitText = "Tryk Enter for at afslutte";
            Console.SetCursorPosition((screenWidth - exitText.Length) / 2, screenHeight / 2 + 3);
            Console.WriteLine(exitText);

            // Nulstil farver
            Console.ResetColor();

            // Vent på Enter
            while (Console.ReadKey(true).Key != ConsoleKey.Enter) { }


        }
    }
}