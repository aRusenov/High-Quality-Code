namespace RPG
{
    using System;
    using System.Collections.Generic;
    
    using RPG.Contracts;
    using RPG.Items;

    public class RpgMain
    {
        static void Main()
        {
            var possibleItems = new List<IItem>()
            {
                new Item("Giant Sword", 20, 5),
                new Item("Cardboard Shield", 5, 35)
            };

            var randomNumberGenerator = new RandomNumberGenerator();

            var enemy = new Enemy(possibleItems, randomNumberGenerator);

            // 50-50 result
            var itemDropped = enemy.DropItem();
            Console.WriteLine(itemDropped);
        }
    }
}
