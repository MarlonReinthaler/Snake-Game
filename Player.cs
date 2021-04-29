using System;
using System.Threading;

namespace SnakeGame
{
    public class Player
    {
        public decimal Speed = 120m;
        public int ScoreOne = 0;
        public int ScoreToWin = 20;
        public bool gameOver;
        public bool gameWin;

        public Board board;
        public Cherry cherry;
        public Banana banana;
        public Snake snakeOne;

        protected void setScore(int amountScore, int posScore, string playerScore = "Score Snake")
        {
            Console.SetCursorPosition(Board.Width / 2 - 4 + posScore, Board.Height + 2);
            Console.Write($"{playerScore}: {amountScore}");
        }

        protected void setWin(string playerMessage, int posWin = 10)
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