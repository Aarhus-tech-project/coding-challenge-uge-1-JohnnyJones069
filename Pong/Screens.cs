namespace Pong
{
	public static class Screens
	{
		public static void ShowStartScreen()
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

		public static void  ShowGameOverScreen(int left, int right)
		{
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
			string winnerText = right == 10 ? "Player 2 Wins!" : "Player 1 Wins!";
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
	}
}