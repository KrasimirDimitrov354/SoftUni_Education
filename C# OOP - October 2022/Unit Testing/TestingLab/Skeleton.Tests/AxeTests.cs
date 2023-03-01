using System;
using NUnit.Framework;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        private Axe axe;
        private Dummy dummy;

        [SetUp]
        public void Setup()
        {
            axe = new Axe(10, 10);
            dummy = new Dummy(10, 10);
        }

        [Test]
        public void WeaponShouldLoseDurabilityAfterEachAttack()
        {
            int originalAxeDurability = axe.DurabilityPoints;
            axe.Attack(dummy);

            Assert.That(axe.DurabilityPoints == originalAxeDurability - 1,
                "Axe Durability should go down by 1 after attack.");
        }

        [Test]
        public void AttackingWithBrokenWeaponShouldThrow()
        {
            Axe brokenAxe = new Axe(10, 0);
            Assert.Catch<InvalidOperationException>(() => brokenAxe.Attack(dummy),
                "Axe should throw the appropriate exception when attacking with 0 or less Durability.");
        }
    }
}