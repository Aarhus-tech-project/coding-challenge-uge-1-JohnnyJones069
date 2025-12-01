namespace Pong
{
    public class Racket
    {
        public int Height { get; set; }
        public int Length { get; }
        public int X { get; }
        public char Tile { get; }

        public Racket(int x, int length, char tile)
        {
            X = x;
            Tile = tile;
            Length = length;
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
            for (int i = 0; i < Length; i++)
            {
                Console.SetCursorPosition(X, Height + i);
                Console.WriteLine(Tile);
            }
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