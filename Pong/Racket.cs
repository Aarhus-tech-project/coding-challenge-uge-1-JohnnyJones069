namespace Pong
{
    public class Racket
    {
        public int Height { get; set; }
        public int Length { get; }
        public int X { get; }
        public char Tile { get; }
        public ConsoleColor Color { get; }


        public Racket(int x, int length, char tile, ConsoleColor color)
        {
            X = x;
            Tile = tile;
            Length = length;
            Color = color;
        }

        public void MoveUp()
        {
            if (Height > 1) Height--;   
        }

        public void MoveDown(int fieldHeight)
        {
            if (Height < fieldHeight - Length)
                Height++;
        }

        public void Draw()
        {
            Console.ForegroundColor = Color;
            for (int i = 0; i < Length; i++)
            {
                Console.SetCursorPosition(X, Height + i);
                Console.WriteLine(Tile);
            }
            Console.ResetColor();
        }

        public void Clear(int fieldHeight)
        {
            for (int i = 1; i < fieldHeight; i++)
            {
                Console.SetCursorPosition(X, i);
                Console.WriteLine(" ");
            }
        }
    }
}