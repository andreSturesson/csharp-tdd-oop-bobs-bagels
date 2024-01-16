namespace exercise.test;

using System.Security.Cryptography;
using exercise.main;
using NUnit.Framework.Internal;

public class Tests
{

    private Basket _basket;


    [SetUp]
    public void Setup()
    {
        _basket = new Basket(10);
    }

        [TestCase ("BGLO", true)]
        [TestCase ("COFB", true)]
        [TestCase ("BGLS", false)]
        [TestCase ("COFL", true)]
        public void TestAddBagel(string Sku, bool expected) {

            Assert.That(_basket.AddItem(Sku), Is.Not.Null);
        }

        [TestCase ("BGLO", "FILE", true)]
        [TestCase ("BGLS", "FILX", false)]
        public void TestAddBagelAndFilling(string Sku,string fillingSku, bool expected) {

            Assert.That(_basket.AddItem(Sku, fillingSku), Is.Not.Null);
        }

        public void TestChangeCapacity() {
            Assert.That(_basket.ChangeCapacity(15), Is.EqualTo(15));
        }

        public void TestChangeCapacityWhenManyItemsAreAdded() {
            _basket.AddItem("BGLO", "FILX");
            _basket.AddItem("BGLO", "FILX");
            _basket.AddItem("BGLO", "FILX");
            _basket.AddItem("BGLO", "FILX");
            _basket.AddItem("BGLO", "FILX");
            _basket.AddItem("BGLO", "FILX");
            _basket.AddItem("BGLO", "FILX");
            _basket.AddItem("BGLO", "FILX");
            Assert.That(_basket.ChangeCapacity(6), Is.EqualTo(10));
        }

        [Test]
        public void TestRemoveBagel() {
            _basket.AddItem("BGLO", "FILX");
            _basket.AddItem("BGLO", "FILS");
            List<Item> item = _basket.AddItem("BGLO", "FILX");
            Assert.That(_basket.RemoveBagel(item[0]), Is.EqualTo(true));
        }

        [Test]
        public void TestGetCost() {
            _basket.AddItem("BGLO", "FILX");
            _basket.AddItem("BGLS");
            _basket.AddItem("COFL");
            _basket.AddItem("COFW");
            Assert.That(_basket.GetTotalCost(), Is.EqualTo(3.58));
        }

        [Test]
        public void TestGetDiscounted() {
            _basket.AddItem("BGLO");
            _basket.AddItem("BGLO");
            _basket.AddItem("BGLO");
            _basket.AddItem("BGLO");
            _basket.AddItem("BGLO");
            _basket.AddItem("BGLO");
            Assert.That(_basket.GetTotalCost(), Is.EqualTo(2.49).Within(.0005));
        }
}