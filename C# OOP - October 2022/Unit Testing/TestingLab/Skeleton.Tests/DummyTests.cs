using System;
using NUnit.Framework;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        private Dummy dummy;
        private Dummy deadDummy;

        [SetUp]
        public void Setup()
        {
            dummy = new Dummy(10, 10);
            deadDummy = new Dummy(0, 10);
        }

        [Test]
        public void DummyShouldLoseHealthWhenAttacked()
        {
            int originalDummyHealth = dummy.Health;
            int attackPoints = 1;
            dummy.TakeAttack(attackPoints);

            Assert.IsTrue(dummy.Health == originalDummyHealth - attackPoints,
                "Dummy should lose Health when attacked.");
        }

        [Test]
        public void DummyShouldThrowWhenAttackedAtZeroHealth()
        {
            Assert.Catch<InvalidOperationException>(() => deadDummy.TakeAttack(1),
                "Dummy shouldn't be able to be attacked at 0 Health.");
        }

        [Test]
        public void DummyShouldGiveExperienceWhenAtZeroHealth()
        {
            Assert.AreEqual(10, deadDummy.GiveExperience(),
                "Dummy should give Experience at 0 Health.");
        }

        [Test]
        public void DummyShouldNotGiveExperienceWhenNotAtZeroHealth()
        {
            Assert.Catch<InvalidOperationException>(() => dummy.GiveExperience(),
                "Dummy shouldn't give Experience when it has more than 0 Health.");
        }
    }
}