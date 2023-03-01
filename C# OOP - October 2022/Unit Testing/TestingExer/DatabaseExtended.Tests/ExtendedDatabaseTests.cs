using System;
using System.Reflection;
using NUnit.Framework;

using ExtendedDatabase;

namespace DatabaseExtended.Tests
{
    [TestFixture]
    public class ExtendedDatabaseTests
    {
        private const int MAX_ARRAY_SIZE = 16;
        private readonly Person GENERIC_PERSON = new Person(1111111, "genericName");

        private Person[] validInput = new Person[16];
        private Database validDatabase;

        [SetUp]
        public void Setup()
        {
            for (int i = 0; i < validInput.Length; i++)
            {
                Person person = new Person(i, "validUsername" + i);
                validInput[i] = person;
            }

            validDatabase = new Database(validInput);
        }

        [Test]
        public void DatabaseShouldBeAbleToStoreOnlyPerson()
        {
            ParameterInfo constructorParams = typeof(Database)
                .GetConstructors()[0]
                .GetParameters()[0];

            Assert.IsTrue(constructorParams.ParameterType == typeof(Person[]),
                "Database constructor should receive a Person array.");
        }

        [Test]
        public void ArrayInputShouldBe16ElementsOrLess()
        {
            Assert.IsTrue(validDatabase.Count <= MAX_ARRAY_SIZE,
                "Size of input data should be between 0 and 16 elements.");
        }

        [Test]
        public void ArrayInputShouldNotBeOver16Elements()
        {
            var tooManyPeople = new Person[17];
            Array.Copy(validInput, tooManyPeople, validInput.Length);
            tooManyPeople[16] = GENERIC_PERSON;

            Assert.Throws<ArgumentException>(() => new Database(tooManyPeople));
        }

        [Test]
        public void AddOperationShouldAddElementAtTheNextFreeCell()
        {
            validDatabase.Remove();
            Assert.DoesNotThrow(() => validDatabase.Add(GENERIC_PERSON),
                "Add operation should be able to add element at the next free cell in the array.");
        }

        [Test]
        public void AddOperationShouldThrowWhenArrayHasMoreThan16Elements()
        {
            Assert.Throws<InvalidOperationException>(() => validDatabase.Add(GENERIC_PERSON),
                "Array cannot have more than 16 elements.");
        }

        [Test]
        public void AddOperationShouldThrowWhenUsernameAlreadyExists()
        {
            var existingUsername = new Person(2222, validInput[0].UserName);
            Assert.Throws<InvalidOperationException>(() => validDatabase.Add(existingUsername),
                "All usernames must be unique.");
        }

        [Test]
        public void AddOperationShouldThrowWhenIdAlreadyExists()
        {
            var existingId = new Person(validInput[0].Id, "ID already exists");
            Assert.Throws<InvalidOperationException>(() => validDatabase.Add(existingId),
                "All IDs must be unique.");
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
            Assert.Throws<InvalidOperationException>(() => new Database().Remove(),
                "Remove operation should not be able to be executed when there are 0 elements in the array.");
        }

        [Test]
        public void FindByUsernameShouldThrowWhenCriteriaIsNullOrEmpty()
        {
            Assert.Throws<ArgumentNullException>(() => validDatabase.FindByUsername(null),
                "Username should not be null or empty.");
            Assert.Throws<ArgumentNullException>(() => validDatabase.FindByUsername(string.Empty),
                "Username should not be null or empty.");
        }

        [Test]
        public void FindByUsernameShouldThrowWhenUsernameDoesNotExist()
        {
            Assert.Throws<InvalidOperationException>(() => validDatabase.FindByUsername(GENERIC_PERSON.UserName),
                "Username should already exist in the database.");
        }

        [Test]
        public void FindByUsernameShouldReturnCorrectPersonMatch()
        {
            var soughtPerson = validInput[0];
            Assert.AreEqual(soughtPerson, validDatabase.FindByUsername(validInput[0].UserName),
                "The returned Person object should match the entered criteria.");
        }

        [Test]
        public void FindByIdShouldThrowWhenCriteriaIsNegative()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => validDatabase.FindById(-1),
                "ID should not be negative.");
        }

        [Test]
        public void FindByIdShouldThrowWhenIdDoesNotExist()
        {
            Assert.Throws<InvalidOperationException>(() => validDatabase.FindById(GENERIC_PERSON.Id),
                "ID should already exist in the database.");
        }

        [Test]
        public void FindByIdShouldReturnCorrectPersonMatch()
        {
            var soughtPerson = validInput[0];
            Assert.AreEqual(soughtPerson, validDatabase.FindById(validInput[0].Id),
                "The returned Person object should match the entered criteria.");
        }
    }
}