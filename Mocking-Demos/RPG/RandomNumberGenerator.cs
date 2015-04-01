namespace RPG
{
    using System;

    public class RandomNumberGenerator : IRandomNumberGenerator
    {
        private readonly Random randomGenerator;

        public RandomNumberGenerator()
        {
            this.randomGenerator = new Random();
        }

        public int GetRandomNumber(int minRange, int maxRange)
        {
            return this.randomGenerator.Next(minRange, maxRange);
        }
    }
}
