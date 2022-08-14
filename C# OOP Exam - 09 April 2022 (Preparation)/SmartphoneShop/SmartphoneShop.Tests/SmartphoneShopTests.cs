using NUnit.Framework;
using System;

namespace SmartphoneShop.Tests
{
    [TestFixture]
    public class SmartphoneShopTests
    {
        [Test]
        public void TestShopCapacityPropertyThrowsExceptionIfBelowZero()
        {
            Shop shop;
            Assert.Throws<ArgumentException>(() =>
            shop = new Shop(-1), "Invalid capacity.");
        }
        [Test]
        public void TestShopCapacityPropertySetsTheFieldProperly()
        {
            var shop = new Shop(100);
            Assert.AreEqual(100, shop.Capacity);
        }
        [Test]
        public void TestShopCountPropertyIfCountsProperly()
        {
            var shop = new Shop(10);
            shop.Add(new Smartphone("Samsung", 100));
            Assert.AreEqual(1, shop.Count);
            shop.Add(new Smartphone("Apple", 90));
            Assert.AreEqual(2, shop.Count);
        }
        [Test]
        public void TestIfShopAddWillThrowExceptionIfThePhoneModelAlreadyExists()
        {
            var shop = new Shop(2);
            shop.Add(new Smartphone("Samsung", 100));
            Assert.Throws<InvalidOperationException>(() => shop.Add(new Smartphone("Samsung", 100)),
                $"The phone model Samsung already exist."
                );
        }
        [Test]
        public void TestIfShopWillThrowAnExceptionWhenAddingAboveCapacity()
        {
            var shop = new Shop(1);
            shop.Add(new Smartphone("Samsung", 100));
            Assert.Throws<InvalidOperationException>(() => shop.Add(new Smartphone("Apple", 90)), "The shop is full.");
        }
        [Test]
        public void TestShopRemove()
        {
            var shop = new Shop(10);
            shop.Add(new Smartphone("Samsung", 100));
            shop.Add(new Smartphone("Apple", 90));
            shop.Remove("Samsung");
            Assert.AreEqual(1, shop.Count);
            Assert.Throws<InvalidOperationException>(() => shop.Remove("Samsung"), "The phone model Samsung doesn't exist.");
        }
        [Test]
        public void TestShopRemoveShouldThrowExceptionIfThePhoneModelDoesNotExist()
        {
            var shop = new Shop(10);
            Assert.Throws<InvalidOperationException>(() => shop.Remove("Samsung"), "The phone model Samsung doesn't exist.");
        }
        [Test]
        public void TestShopTestPhoneFunction()
        {
            var shop = new Shop(2);
            Assert.Throws<InvalidOperationException>(() => shop.TestPhone("Samsung", 2), "The phone model Samsung doesn't exist.");
        }
        [Test]
        public void TestShopChargePhone()
        {
            var shop = new Shop(2);
            Assert.Throws<InvalidOperationException>(() => shop.ChargePhone("Samsung"), "The phone model Samsung doesn't exist.");
        }
    }
}