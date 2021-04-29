using System;
using System.Threading;

namespace SnakeGame
{
    public class Multiplayer : Player
    {
        int ScoreTwo = 0;
        Snake snakeTwo;

        private void winGame()
        {
            if (ScoreOne >= ScoreToWin)
            {
                setWin("SnakeOne has won");
                gameWin = true;
            }
            else if (ScoreTwo >= ScoreToWin)
            {
                setWin("SnakeTwo has won");
                gameWin = true;
            }
            else if (gameOver == true && ScoreOne >= ScoreTwo)
            {
                setWin("SnakeOne has won");
                gameWin = true;
            }
            else if (gameOver == true && ScoreOne <= ScoreTwo)
            {
                setWin("SnakeTwo has won");
                gameWin = true;
            }
            else if (gameOver == true)
            {
                setWin("Nobody won");
            }

        }
        public void multPlayerGame()
        {
            while (true)
            {
                board = new Board();
                cherry = new Cherry();
                banana = new Banana();
                snakeOne = new Snake(0);
                snakeTwo = new Snake(16);

                Speed = 120m;
                ScoreOne = 0;
                ScoreTwo = 0;
                gameOver = false;
                gameWin = false;

                Console.CursorVisible = false;
                Console.Clear();

                board.drawBoard(); // Board
                cherry.getCherrry(); // Cherry
                banana.getBanana(); // Banana

                Thread thread = new Thread(() =>
                            {
                                while (!gameOver)
                                {
                                    Input.keyListener(snakeOne, snakeTwo);
                                }
                            });
                thread.Start();

                while (gameOver == false && gameWin == false)
                {
                    snakeOne.hitBoard(ref gameOver);
                    snakeOne.hitItself(ref gameOver);
                    snakeOne.growSnake(ref Speed, ref cherry.FoodScore, ref ScoreOne, cherry.posFood(), cherry);
                    snakeOne.growSnake(ref Speed, ref banana.FoodScore, ref ScoreOne, banana.posFood(), banana);
                    snakeOne.hitEachOther(snakeOne, snakeTwo, ref gameOver);

                    snakeTwo.hitBoard(ref gameOver);
                    snakeTwo.hitItself(ref gameOver);
                    snakeTwo.growSnake(ref Speed, ref cherry.FoodScore, ref ScoreTwo, cherry.posFood(), cherry);
                    snakeTwo.growSnake(ref Speed, ref banana.FoodScore, ref ScoreTwo, banana.posFood(), banana);
                    snakeTwo.hitEachOther(snakeOne, snakeTwo, ref gameOver);

                    setScore(ScoreOne, -17, "Score SnakeOne");
                    setScore(ScoreTwo, 10, "Score SnakeTwo");
                    winGame();

                    snakeOne.moveSnakeHead();
                    snakeOne.updateSnake();

                    snakeTwo.moveSnakeHead();
                    snakeTwo.updateSnake();

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