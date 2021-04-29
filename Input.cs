using System;

namespace SnakeGame
{
    public class Input
    {
        public static void keyListener(Snake snakeOne)
        {
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.UpArrow:
                    if (snakeOne.headDirecton != Direction.Bottom)
                    {
                        snakeOne.headDirecton = Direction.Top;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (snakeOne.headDirecton != Direction.Top)
                    {
                        snakeOne.headDirecton = Direction.Bottom;
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    if (snakeOne.headDirecton != Direction.Right)
                    {
                        snakeOne.headDirecton = Direction.Left;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (snakeOne.headDirecton != Direction.Left)
                    {
                        snakeOne.headDirecton = Direction.Right;
                    }
                    break;
            }
        }

        public static void keyListener(Snake snakeOne, Snake snakeTwo)
        {
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.UpArrow:
                    if (snakeOne.headDirecton != Direction.Bottom)
                    {
                        snakeOne.headDirecton = Direction.Top;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (snakeOne.headDirecton != Direction.Top)
                    {
                        snakeOne.headDirecton = Direction.Bottom;
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    if (snakeOne.headDirecton != Direction.Right)
                    {
                        snakeOne.headDirecton = Direction.Left;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (snakeOne.headDirecton != Direction.Left)
                    {
                        snakeOne.headDirecton = Direction.Right;
                    }
                    break;
                case ConsoleKey.W:
                    if (snakeTwo.headDirecton != Direction.Bottom)
                    {
                        snakeTwo.headDirecton = Direction.Top;
                    }
                    break;
                case ConsoleKey.S:
                    if (snakeTwo.headDirecton != Direction.Top)
                    {
                        snakeTwo.headDirecton = Direction.Bottom;
                    }
                    break;
                case ConsoleKey.A:
                    if (snakeTwo.headDirecton != Direction.Right)
                    {
                        snakeTwo.headDirecton = Direction.Left;
                    }
                    break;
                case ConsoleKey.D:
                    if (snakeTwo.headDirecton != Direction.Left)
                    {
                        snakeTwo.headDirecton = Direction.Right;
                    }
                    break;
            }
        }
    }
}