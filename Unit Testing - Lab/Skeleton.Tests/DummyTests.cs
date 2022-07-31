using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        private Axe axe;
        private Dummy dummy;
        [SetUp]
        public void Setup()
        {
            axe = new Axe(100, 100);
            dummy = new Dummy(101, 100);
        }
        [Test]
        public void Test_Dummy_Losses_Health_If_Attacked()
        {
            
            axe.Attack(dummy);
            Assert.AreEqual(1, dummy.Health);
        }
        [Test]
        public void Test_When_Dead_Dummy_Is_Attacked_Throws_Error()
        {
            axe.Attack(dummy);
            axe.Attack(dummy);
            Assert.Throws<InvalidOperationException>(() => { axe.Attack(dummy); });
        }
        [Test]
        public void Test_When_Dead_Dummy_Can_Give_XP()
        {
            axe.Attack(dummy);
            axe.Attack(dummy);
            Assert.AreEqual(100, dummy.GiveExperience());
        }
        [Test]
        public void Test_When_Alive_Dummy_Cannot_Give_XP()
        {
            Assert.Throws<InvalidOperationException>(() => { dummy.GiveExperience(); });
        }
    }
}