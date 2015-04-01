namespace RPG
{
    using System.Collections.Generic;

    using RPG.Contracts;

    public class Enemy
    {
        private readonly IList<IItem> possibleItemDrops;

        public Enemy(IList<IItem> items, IRandomNumberGenerator randomNumberGenerator)
        {
            this.RandomGenerator = randomNumberGenerator;
            this.possibleItemDrops = items;
        }

        public IRandomNumberGenerator RandomGenerator { get; set; }

        public IItem DropItem()
        {
            int index = this.RandomGenerator.GetRandomNumber(0, this.possibleItemDrops.Count);

            return this.possibleItemDrops[index];
        }
    }
}
