namespace Pong
{
	public class Scoreboard
	{
		public int LeftPoints = 0;
		public int RightPoints = 0;

		public string LeftName = "P1";
		public string RightName = "P2";

		public int X, Y;
		public int FieldLength;

		public Scoreboard(int fieldLength, int y)
		{
			FieldLength = fieldLength;
			X = fieldLength / 2 - 2;
			Y = y;
		}

		public void Draw()
		{
			//spiller point under spillet
			Console.SetCursorPosition(X, Y);
			Console.Write($"{LeftPoints} | {RightPoints}");

			// Spillernavne
			Console.SetCursorPosition(0, Y);
			Console.Write(LeftName);

			Console.SetCursorPosition(FieldLength - RightName.Length, Y);
			Console.Write(RightName);
		}
	}
}