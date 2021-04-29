using System;
using System.Threading;

namespace SnakeGame
{
    public class Player
    {
        public decimal Speed = 180m;
        public int ScoreOne = 0;
        public static int ScoreToWin = 100;
        public bool gameOver;
        public bool gameWin;

        public Board board;
        public Cherry cherry;
        public Banana banana;
        public Snake snakeOne;

        protected void setDesc(int amountPlayer)
        {
            Console.SetCursorPosition(0, (Board.Height + 6));
            if (amountPlayer == 1)
            {

                Console.WriteLine($"{ScoreToWin} Points to win!\nPlayer 1 (blue snake): Arrow Keys");
            }
            else if (amountPlayer == 2)
            {

                Console.WriteLine($"{ScoreToWin} Points to win!\nPlayer 1 (blue snake): Arrow Keys\nPlayer 2 (magenta snake): W A S D");
            }
        }
        protected void setScore(int amountScore, int posScore, string playerScore = "Score Snake")
        {
            Console.SetCursorPosition(Board.Width / 2 - 4 + posScore, Board.Height + 2);
            Console.Write($"{playerScore}: {amountScore}");
        }

        protected void setWin(string playerMessage, int posWin = 5)
        {
            Console.SetCursorPosition(Board.Width / 2 - posWin, Board.Height + 5);
            Console.Write($"{playerMessage}");
        }

        protected void restartGame()
        {
            Console.Clear();
            Console.WriteLine("Neustart (j/n)");

            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.J:
                    break;
                case ConsoleKey.N:
                    Game.gameMode();
                    break;
            }
        }
    }
}