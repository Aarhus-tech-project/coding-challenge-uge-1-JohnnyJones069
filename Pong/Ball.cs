namespace Pong
{
    public class Ball
    {
        public int X, Y;
        public bool GoingDown = true;
        public bool GoingRight = true;
        public char Tile;

        public Ball(int x, int y, char tile)
        {
            X = x;
            Y = y;
            Tile = tile;
        }

        public void Draw()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(Tile);
        }

        public void Clear()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(" ");
        }

        public void Move()
        {
            Y += GoingDown ? 1 : -1;
            X += GoingRight ? 1 : -1;
        }

        public void Reset(int middleX, int middleY)
        {
            X = middleX;
            Y = middleY;
            GoingRight = !GoingRight;
            GoingDown = !GoingDown;
        }
    }
}