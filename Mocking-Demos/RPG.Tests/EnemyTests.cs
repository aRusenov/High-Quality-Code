namespace RPG.Tests
{
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using RPG;
    using RPG.Contracts;
    using RPG.Items;

    using RPG.Tests.Mocks;

    [TestClass]
    public class EnemyTests
    {
        private IRandomNumberGenerator randomGenerator;

        [TestInitialize]
        public void InitMock()
        {
            var randomMock = new RandomNumberGeneratorMock();

            this.randomGenerator = randomMock.RandomNumberGenerator;
        }

        [TestMethod]
        public void EnemyShouldAlwaysDropFirstItem()
        {
            var possibleItems = new List<IItem>()
            {
                new Item("Giant Sword", 20, 5),
                new Item("Cardboard Shield", 5, 35)
            };

            var enemy = new Enemy(possibleItems, this.randomGenerator);
            var droppedItem = enemy.DropItem();
            Assert.AreEqual(droppedItem.ToString(), possibleItems[0].ToString());
        }
    }
}
