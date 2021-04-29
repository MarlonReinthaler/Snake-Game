using System;

namespace SnakeGame
{
    public class Cherry : Food
    {
        public void getCherrry()
        {
            Color = ConsoleColor.Red;
            Letter = 'C';
            FoodScore = 9;
            setFood();
            drawFood();
        }
    }
}