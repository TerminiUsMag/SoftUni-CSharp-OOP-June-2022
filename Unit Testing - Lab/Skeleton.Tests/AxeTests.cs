using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        [Test]
        public void Test_Weapon_Should_Loose_Durability_After_Attack()
        {
            Axe axe = new Axe(10, 10);
            axe.Attack(new Dummy(100, 100));
            Assert.AreEqual(9, axe.DurabilityPoints);
        }
        [Test]
        public void Test_Should_Not_Be_Able_To_Attack_With_Zero_Durabilitty()
        {
            Axe axe = new Axe(10, 1);
            axe.Attack(new Dummy(100, 100));
            Assert.Throws<InvalidOperationException>(()=>{
                axe.Attack(new Dummy(100, 100));
            });
        }
    }
}