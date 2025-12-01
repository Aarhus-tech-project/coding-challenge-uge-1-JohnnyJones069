namespace Pong
{
    public class GameField
    {
        public int Width;
        public int Height;
        public char Tile;

        public GameField(int width, int height, char tile)
        {
            Width = width;
            Height = height;
            Tile = tile;
        }

        public void DrawBorders()
            {
            string line = new string(Tile, Width);

            Console.SetCursorPosition(0, 0);
            Console.WriteLine(line);

            Console.SetCursorPosition(0, Height);
            Console.WriteLine(line);
        }
    }
}