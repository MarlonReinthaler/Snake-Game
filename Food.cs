using System;

namespace SnakeGame
{
    public class Food
    {
        protected ConsoleColor Color { get; set; }
        protected char Letter { get; set; }

        public int FoodScore;
        public Position foodPos = new Position(0, 0);
        Random rnd = new Random();
        public void setFood()
        {
            foodPos.x = rnd.Next(1, Board.Width);
            foodPos.y = rnd.Next(1, Board.Height);
        }

        public Position posFood()
        {
            return foodPos;
        }

        public void drawFood()
        {
            Console.ForegroundColor = Color;
            Console.SetCursorPosition(foodPos.x, foodPos.y);
            Console.Write(Letter);
            Console.ForegroundColor = ConsoleColor.White;
        }


    }
}