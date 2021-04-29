using System;
using System.Threading;

namespace SnakeGame
{
    public class SinglePlayer : Player
    {
        private void winGame()
        {
            if (ScoreOne >= ScoreToWin)
            {
                setWin("Gewonnen", 1);
                gameWin = true;
            }
            else if (gameOver == true)
            {
                setWin("Verloren", 1);
            }
        }
        public void singlePlayerGame()
        {
            while (true)
            {
                board = new Board();
                cherry = new Cherry();
                banana = new Banana();
                snakeOne = new Snake(8);

                Speed = 120m;
                ScoreOne = 0;
                gameOver = false;
                gameWin = false;

                Console.CursorVisible = false;
                Console.Clear();

                board.drawBoard(); // Board
                cherry.getCherrry(); // Cherry
                banana.getBanana(); // Banana


                Thread thr2 = new Thread(restartGame);
                Thread thread = new Thread(() =>
                            {
                                while (!gameOver)
                                {
                                    Input.keyListener(snakeOne);
                                }
                            });
                thread.Start();

                while (gameOver == false && gameWin == false)
                {
                    snakeOne.hitBoard(ref gameOver);
                    snakeOne.hitItself(ref gameOver);
                    snakeOne.growSnake(ref Speed, ref cherry.FoodScore, ref ScoreOne, cherry.posFood(), cherry);
                    snakeOne.growSnake(ref Speed, ref banana.FoodScore, ref ScoreOne, banana.posFood(), banana);

                    setScore(ScoreOne, 0);
                    winGame();

                    snakeOne.moveSnakeHead();
                    snakeOne.updateSnake();

                    cherry.drawFood();
                    banana.drawFood();
                    Thread.Sleep(Convert.ToInt32(Speed));
                }
                Thread.Sleep(2000);
                restartGame();
            }
        }
    }
}