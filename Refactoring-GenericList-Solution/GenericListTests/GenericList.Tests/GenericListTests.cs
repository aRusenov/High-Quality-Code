using System;

using GenericList;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GenericListTests.GenericList.Tests
{
    [TestClass]
    public class GenericListTests
    {
        private GenericList<int> ints;

        [TestInitialize]
        public void InitializeList()
        {
            ints = new GenericList<int>();
        }

        // TODO: Implement additional tests

        [TestMethod]
        public void TestAddElementToList()
        {
            ints.Add(5);

            Assert.AreEqual(ints[0], 5);
        }
        
        [TestMethod]
        public void TestCountWhenAddingElementsOverCapacity()
        {
            for (int i = 0; i < 5; i++)
            {
                ints.Add(i);
            }

            Assert.AreEqual(ints.Count, 5);
        }

        [TestMethod]
        public void TestInsertAtPosition2()
        {
            for (int i = 0; i < 5; i++)
            {
                ints.Add(i);
            }

            ints.InsertAt(20, 2);

            Assert.AreEqual(ints[2], 20);
            Assert.AreEqual(ints[3], 2);
        }

        [TestMethod]
        public void TestRemoveExistingElement()
        {
            for (int i = 0; i <= 5; i++)
            {
                ints.Add(i);
            }

            Assert.AreEqual(ints[4], 4);
            ints.Remove(4);
            Assert.AreEqual(ints[4], 5);
        }

        [TestMethod]
        public void ClearShouldClearList()
        {
            for (int i = 0; i <= 5; i++)
            {
                ints.Add(i);
            }

            ints.Clear();
            Assert.AreEqual(ints.Count, 0);
        }

        [TestMethod]
        public void FindShouldGetIndexOfExistingElementWhenArrayIsOrdered()
        {
            for (int i = 0; i <= 5; i++)
            {
                ints.Add(i);
            }

            int index = ints.Find(3);
            Assert.AreEqual(index, 3);
        }

        [TestMethod]
        public void FindShouldGetIndexOfExistingElementWhenArrayIsUnordered()
        {
            ints.Add(3);
            ints.Add(1);
            ints.Add(7);
            ints.Add(24);

            int index = ints.Find(3);
            Assert.AreEqual(index, 0);
        }

        [TestMethod]
        public void FindShouldGetIndexOfMissingElementWhenArrayIsUnordered()
        {
            ints.Add(3);
            ints.Add(1);
            ints.Add(7);
            ints.Add(24);

            int index = ints.Find(5);
            Assert.AreEqual(index, -1);
        }

        [TestMethod]
        public void MaxShouldReturnMaximumValue()
        {
            ints.Add(3);
            ints.Add(1);
            ints.Add(24);
            ints.Add(7);

            int max = ints.Max();
            Assert.AreEqual(max, 24);
        }

        [TestMethod]
        public void MinShouldReturnMaximumValue()
        {
            ints.Add(3);
            ints.Add(1);
            ints.Add(24);
            ints.Add(7);

            int max = ints.Min();
            Assert.AreEqual(max, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void TestIndexingListCount()
        {
            for (int i = 0; i < 5; i++)
            {
                ints.Add(i);
            }

            int val = ints[5];
        }
    }
}
