namespace Pong
{
	public class Scoreboard
	{
		public int LeftPoints = 0;
		public int RightPoints = 0;

		public string LeftName { get; }
		public string RightName { get; }

		public int X, Y;
		public int FieldLength;

		public Scoreboard(int fieldLength, int y, string leftname, string rightname)
		{
			FieldLength = fieldLength;
			X = fieldLength / 2 - 2;
			Y = y;
			LeftName = leftname;
			RightName = rightname;
		}

		public void Draw(int offsetX = 10)
		{
			//spiller point under spillet
			Console.SetCursorPosition(X + offsetX, Y);
			Console.Write($"{LeftPoints} | {RightPoints}");

			// Spillernavne
			Console.ForegroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(0 + offsetX, Y);
			Console.Write(LeftName);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(FieldLength - RightName.Length + offsetX, Y);
			Console.Write(RightName);

            Console.ResetColor();
        }
	}

}