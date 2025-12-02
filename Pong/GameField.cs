namespace Pong
{
    public class GameField
    {
        public int Width;
        public int Height;
        public int OffsetX {  get; private set; }
        public char Tile;

        public GameField(int width, int height, char tile, int offsetX = 10)
        {
            Width = width;
            Height = height;
            Tile = tile;
            OffsetX = offsetX;
        }

        public void DrawBorders()
            {
            string line = new string(Tile, Width);

            // Top Border
            Console.SetCursorPosition(OffsetX, 0);
            Console.WriteLine(new string(Tile, Width));

            // Bottom Border
            Console.SetCursorPosition(OffsetX, Height);
            Console.WriteLine(new string(Tile, Width));

            // Side Borders
            for (int i = 0; i < Height; i++) 
            {
                Console.SetCursorPosition(OffsetX, i);
                Console.Write(Tile);

                Console.SetCursorPosition(OffsetX + Width - 1, i);
                Console.Write(Tile);

            }
        }
    }
}