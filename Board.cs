using System;

namespace SnakeGame
{
    public class Board
    {
        public static int Width { get; } = 60;
        public static int Height { get; } = 30;
        public void drawBoard()
        {
            // top  
            for (int i = 0; i < Width; i++)
            {
                getCursor(i, 0);
            }

            // bottom
            for (int i = 0; i < (Width + 1); i++)
            {
                getCursor(i, Height);
            }

            // left and right
            for (int i = 0; i < Height; i++)
            {
                getCursor(0, i);
                getCursor(Width, i);
            }

            Console.SetCursorPosition(0, (Height + 6));
            Console.WriteLine("100 Points to win!\nPlayer 1 (pink snake): W A S D\nPlayer 2 (green snake): Arrow Keys\n\n");
        }

        private void getCursor(int x, int y, char c = '#')
        {
            Console.SetCursorPosition(x, y);
            Console.Write(c);
        }
    }
}