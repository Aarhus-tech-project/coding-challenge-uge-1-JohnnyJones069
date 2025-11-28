using System;
using System.Linq;
using System.Threading;

namespace Pong
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ShowStartScreen();

            //Bane
            const int fieldLength = 50, fieldWidth = 15;
            const char fieldTile = '#';
            string line = string.Concat(Enumerable.Repeat(fieldTile, fieldLength));

            //Ketcher
            const int racketLength = fieldWidth / 4;
            const char racketTile = '|';

            int leftRacketHeight = 0;
            int rightRacketHeight = 0;

            //Bold
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
                Console.Clear();
                Console.CursorVisible = false;

                //Print spillets bane-grænser
                Console.SetCursorPosition(0, 0);
                Console.WriteLine(line);

                Console.SetCursorPosition(0, fieldWidth);
                Console.WriteLine(line);

                //Gør indtil en tast er trykket
                while (!Console.KeyAvailable)
                {

                    //Print Ketchers
                    for (int i = 0; i < racketLength; i++)
                    {
                        Console.SetCursorPosition(0, 1 + leftRacketHeight + i);
                        Console.Write(racketTile);
                        Console.SetCursorPosition(fieldLength - 1, 1 + rightRacketHeight + i);
                        Console.Write(racketTile);
                    }

                    // Visable Scoreboard
                    Console.SetCursorPosition(scoreboardX, scoreboardY);
                    Console.WriteLine($"{leftPlayerPoints} | {rightPlayerPoints}");

                    // Spillernavne
                    Console.SetCursorPosition(0, scoreboardY);
                    Console.Write(leftPlayerName);
                    Console.SetCursorPosition(fieldLength - 2, scoreboardY);
                    Console.Write(rightPlayerName);


                    // Tegn bold
                    Console.SetCursorPosition(ballX, ballY);
                    Console.Write(ballTile);
                    Thread.Sleep(100); //Tilføj en timer, så spillerne kan reagere.


                    // Clear bolden for tidligere position
                    Console.SetCursorPosition(ballX, ballY);
                    Console.Write(" ");

                    //Opdater position af bolden
                    ballY += isBallGoingDown ? 1 : -1;
                    ballX += isBallGoingRight ? 1 : -1;

                    // Hoppe Top/Bund
                    if (ballY == 1 || ballY == fieldWidth - 1)
                    {
                        isBallGoingDown = !isBallGoingDown; 
                    }

                    // Venstre væg
                    if (ballX == 1)
                    {
                        if (ballY >= leftRacketHeight + 1 && ballY <= leftRacketHeight + racketLength) //Venstre Ketcher rammer bolden, og den ryger bagud
                        {
                            isBallGoingRight = true;
                        }
                        else //Bolden ryger af banen, og højre spiller score
                        {
                            rightPlayerPoints++;
                            ballY = fieldWidth / 2;
                            ballX = fieldLength / 2;

                            if (rightPlayerPoints == 5)
                            {
                                goto outer;
                            }
                        }
                    }

                    // Højre væg
                    if (ballX == fieldLength - 2)
                    {
                        if (ballY >= rightRacketHeight + 1 && ballY <= rightRacketHeight + racketLength) //Højre Ketcher rammer bolden, og den ryger bagud
                        {
                            isBallGoingRight = false;
                        }
                        else //Bolden ryger af banen, Venstre spiller score.
                        {
                            leftPlayerPoints++;
                            ballY = fieldWidth / 2;
                            ballX = fieldLength / 2;

                            if (leftPlayerPoints == 5)
                            {
                                goto outer;
                            }
                        }
                    }
                }

                //Ketcher kontrols
                ConsoleKey key = Console.ReadKey(true).Key;
                
                if (key == ConsoleKey.W && leftRacketHeight > 0)
                    leftRacketHeight--;
                else if (key == ConsoleKey.S && leftRacketHeight < fieldWidth - racketLength - 1)
                    leftRacketHeight++;

                if (key == ConsoleKey.UpArrow && rightRacketHeight > 0)
                    rightRacketHeight--;
                else if (key == ConsoleKey.DownArrow && rightRacketHeight < fieldWidth - racketLength - 1)
                    rightRacketHeight++;
            }
        outer:;
            Console.Clear();
            Console.CursorVisible = true;

            // Ramme
            int screenWidth = 50;
            int screenHeight = 15;
            string horizontalBorder = new string('#', screenWidth);

            // Top og bund
            Console.ForegroundColor = ConsoleColor.White;
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

            // Vent på tryk af Enter
            while (Console.ReadKey(true).Key != ConsoleKey.Enter) { }


        }

        static void ShowStartScreen()
        {
            Console.Clear();
            Console.CursorVisible = false;

            int screenWidth = 50;
            int screenHeight = 15;
            string border = new string('#', screenWidth);

            // Top border
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(0, 0);
            Console.WriteLine(border);

            // Bottom border
            Console.SetCursorPosition(0, screenHeight);
            Console.WriteLine(border);

            // Titel
            string title = " PONG ";
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition((screenWidth - title.Length) / 2, screenHeight / 2 - 3);
            Console.WriteLine(title);

            // Undertekst
            Console.ForegroundColor = ConsoleColor.Cyan;
            string subtitle = "P1: W/S   |   P2: ↑/↓";
            Console.SetCursorPosition((screenWidth - subtitle.Length) / 2, screenHeight / 2 - 1);
            Console.WriteLine(subtitle);

            // Start prompt
            Console.ForegroundColor = ConsoleColor.Gray;
            string prompt = "Tryk ENTER for at starte";
            Console.SetCursorPosition((screenWidth - prompt.Length) / 2, screenHeight / 2 + 2);
            Console.WriteLine(prompt);

            Console.ResetColor();

            // Vent på Enter
            while (Console.ReadKey(true).Key != ConsoleKey.Enter) { }
        }

    }
}