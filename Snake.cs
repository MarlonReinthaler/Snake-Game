using System;
using System.Collections.Generic;

namespace SnakeGame
{
    public enum Direction { Top, Bottom, Left, Right, W, A, S, D };
    public class Snake
    {
        public Direction headDirecton = Direction.Top;
        public List<Position> SnakeBody { get; set; }
        public int xSnake { get; set; }
        public int ySnake { get; set; }

        public Snake(int posHead)
        {
            xSnake = Board.Width / 2 - 8 + posHead;
            ySnake = Board.Height / 2 + 5;

            SnakeBody = new List<Position>();
            SnakeBody.Add(new Position(xSnake, ySnake));
            SnakeBody.Add(new Position(xSnake, ySnake - 1));
        }

        public void moveSnakeHead()
        {
            Console.SetCursorPosition(SnakeBody[^1].x, SnakeBody[^1].y);
            drawSnake();
        }

        public void drawSnake()
        {
            foreach (Position pos in SnakeBody)
            {
                Console.SetCursorPosition(SnakeBody[0].x, SnakeBody[0].y);
                Console.Write(' ');

                Console.SetCursorPosition(pos.x, pos.y);
                Console.Write('S');
            }
        }

        public void updateSnake()
        {
            switch (headDirecton)
            {
                case Direction.Top:
                    ySnake--;
                    break;
                case Direction.Bottom:
                    ySnake++;
                    break;
                case Direction.Left:
                    xSnake--;
                    break;
                case Direction.Right:
                    xSnake++;
                    break;
                case Direction.W:
                    ySnake--;
                    break;
                case Direction.S:
                    ySnake++;
                    break;
                case Direction.A:
                    xSnake--;
                    break;
                case Direction.D:
                    xSnake++;
                    break;
            }

            SnakeBody.Add(new Position(xSnake, ySnake));
            SnakeBody.RemoveAt(0);
        }

        public void growSnake(ref decimal speedSnake, ref int scoreFood, ref int scoreSnake, Position food, Food f)
        {
            var head = SnakeBody[^1];

            if (head.x == food.x && head.y == food.y)
            {
                speedSnake *= 0.9m;
                scoreSnake += scoreFood;
                SnakeBody.Add(new Position(xSnake, ySnake));
                f.setFood();
            }
        }

        public void hitEachOther(Snake snakeOne, Snake snakeTwo, ref bool gameOver)
        {
            // for (int i = 0; i < snakeOne.SnakeBody.Count; i++)
            // {
            //     var sb = SnakeBody[^1];

            //     if (sb.x == snakeOne.SnakeBody[i].x && sb.y == snakeOne.SnakeBody[i].y || sb.x == snakeOne.SnakeBody[i].x && sb.y == snakeOne.SnakeBody[i].y) //Gameover Tail Snake 1
            //     {
            //         gameOver = true;
            //         // Console.Write("verloren");
            //     }
            // }
            // for (int i = 0; i < snakeTwo.SnakeBody.Count; i++)
            // {
            //     var sb = SnakeBody[^1];

            //     if (sb.x == snakeTwo.SnakeBody[i].x && sb.y == snakeTwo.SnakeBody[i].y || sb.x == snakeTwo.SnakeBody[i].x && sb.y == snakeTwo.SnakeBody[i].y) //Gameover Tail Snake 2
            //     {
            //         gameOver = true;
            //         // Console.Write("verloren");
            //     }
            // }
        }

        public void hitItself(ref bool gameOver)
        {
            var head = SnakeBody[^1];

            for (int i = 0; i < SnakeBody.Count - 2; i++)
            {
                Position sb = SnakeBody[i];

                if (head.x == sb.x && head.y == sb.y)
                {
                    gameOver = true;
                }
            }

        }

        public void hitBoard(ref bool gameOver)
        {
            Position head = SnakeBody[^1];

            if (head.x >= Board.Width || head.x <= 0 || head.y >= Board.Height || head.y <= 0)
            {
                gameOver = true;
            }
        }
    }
}