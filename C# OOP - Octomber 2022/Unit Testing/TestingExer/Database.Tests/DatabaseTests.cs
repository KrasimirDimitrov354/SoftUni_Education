using System;
using System.Reflection;
using NUnit.Framework;

namespace Database.Tests
{
    //Database
    //You are provided with a simple class Database which stores integers. The constructor receives an array of numbers which is added into a private field.
    //The database has the functionality to add, remove and fetch all stored items.
    //
    //Your task is to test the class for the following scenarios:
    //  •	Storing array's capacity must be exactly 16 integers.
    //      o If the size of the array is not 16 integers long, InvalidOperationException is thrown
    //  •	The "Add()" operation should add an element at the next free cell.
    //      o If there are 16 elements in the Database and you try to add a 17th, InvalidOperationException is thrown.
    //  •	The "Remove()" operation should support only removing an element at the last index.
    //      o If you try to remove an element from an empty Database, InvalidOperationException is thrown.
    //  •	The constructor should take integers only, and store them in an array.
    //  •	The "Fetch()" method should return the elements as an array.

    [TestFixture]
    public class DatabaseTests
    {
        private readonly int[] VALID_DATA = new int[16];
        private readonly int[] INVALID_DATA = new int[17];

        private const int ELEMENT_TO_ADD = 1;
        private const int ARRAY_SIZE = 16;

        private Database validDatabase;

        [SetUp]
        public void Setup()
        {
            validDatabase = new Database(VALID_DATA);
        }

        [Test]
        public void DatabaseShouldBeAbleToStoreOnlyIntegers()
        {
            ParameterInfo constructorParams = typeof(Database)
                .GetConstructors()[0]
                .GetParameters()[0];

            Assert.IsTrue(constructorParams.ParameterType == typeof(int[]));
        }

        [Test]
        public void ArraySizeShouldBe16Elements()
        {
            Assert.IsTrue(validDatabase.Count == ARRAY_SIZE,
                "Size of input data should be exactly 16 elements.");
        }

        [Test]
        public void ArraySizeShouldNotBeAnythingElseBut16Elements()
        {
            Assert.Throws<InvalidOperationException>(() => new Database(INVALID_DATA),
                "Size of input data should be exactly 16 elements.");
        }

        [Test]
        public void AddOperationShouldAddElementAtTheNextFreeCell()
        {
            validDatabase.Remove();
            Assert.DoesNotThrow(() => validDatabase.Add(ELEMENT_TO_ADD),
                "Add operation should be able to add element at the next free cell in the array.");
        }

        [Test]
        public void AddOperationShouldThrowWhenArrayHas16Elements()
        {
            Assert.Throws<InvalidOperationException>(() => validDatabase.Add(ELEMENT_TO_ADD),
                "Array should not be able to have more than 16 elements.");
        }

        [Test]
        public void RemoveOperationShouldRemoveElementAtTheLastIndex()
        {
            Assert.DoesNotThrow(() => validDatabase.Remove(),
                "Remove operation should be able to remove element at the last index of the array.");
        }

        [Test]
        public void RemoveOperationShouldThrowWhenArrayHas0Elements()
        {
            Assert.Throws<InvalidOperationException>(() => new Database(new int[0]).Remove(),
                "Remove operation should not be able to be executed when there are 0 elements in the array.");
        }

        [Test]
        public void FetchOperationShouldReturnAnArray()
        {
            Assert.That(validDatabase.Fetch().GetType().IsArray);
        }
    }
}
