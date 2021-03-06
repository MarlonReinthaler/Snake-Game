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
        private ConsoleColor color;

        public Snake(ConsoleColor color, int posHead)
        {
            this.color = color;

            xSnake = Board.Width / 2 - 8 + posHead;
            ySnake = Board.Height / 2 + 5;

            SnakeBody = new List<Position>();
            SnakeBody.Add(new Position(xSnake, ySnake));
            SnakeBody.Add(new Position(xSnake, ySnake));
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

                Console.ForegroundColor = color;
                Console.SetCursorPosition(pos.x, pos.y);
                Console.Write('S');
                Console.ForegroundColor = ConsoleColor.Black;
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
                speedSnake *= 0.95m;
                scoreSnake += scoreFood;
                SnakeBody.Add(new Position(xSnake, ySnake));
                f.setFood();
            }
        }

        public void hitEachOther(Snake snakeOne, Snake snakeTwo, ref bool gameOver)
        {
            for (int i = 0; i < snakeOne.SnakeBody.Count; i++)
            {
                var head = snakeTwo.SnakeBody[^1];

                if (head.x == snakeOne.SnakeBody[i].x && head.y == snakeOne.SnakeBody[i].y || head.x == snakeOne.SnakeBody[i].x && head.y == snakeOne.SnakeBody[i].y)
                {
                    gameOver = true;
                }
            }
            for (int i = 0; i < snakeTwo.SnakeBody.Count; i++)
            {
                var head = snakeOne.SnakeBody[^1];

                if (head.x == snakeTwo.SnakeBody[i].x && head.y == snakeTwo.SnakeBody[i].y || head.x == snakeTwo.SnakeBody[i].x && head.y == snakeTwo.SnakeBody[i].y)
                {
                    gameOver = true;
                }
            }
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
            var head = SnakeBody[^1];

            if (head.x >= Board.Width || head.x <= 0 || head.y >= Board.Height || head.y <= 0)
            {
                gameOver = true;
            }
        }
    }
}