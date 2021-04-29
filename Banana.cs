using System;

namespace SnakeGame
{
    public class Banana : Food
    {
        public void getBanana()
        {
            Color = ConsoleColor.Yellow;
            Letter = 'B';
            FoodScore = 8;
            setFood();
            drawFood();
        }
    }
}