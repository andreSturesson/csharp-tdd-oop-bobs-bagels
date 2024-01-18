namespace exercise.test;

using exercise.main;
using NUnit.Framework;

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
            Assert.That(Stock.GetItem(Sku), Is.Not.Null);
        }

        [TestCase ("BGLO", "FILE", "Added: Bagel")]
        [TestCase ("BGLS", "FILX", "Added: Bagel")]
        public void TestAddBagelAndFilling(string Sku,string fillingSku, string expected) {
            Bagel bagel = (Bagel)Stock.GetItem(Sku);
            bagel.AddFilling((Filling)Stock.GetItem(fillingSku));
            Assert.AreEqual(expected, _basket.AddItem(bagel));
        }

        public void TestChangeCapacity() {
            Assert.That(_basket.ChangeCapacity(15), Is.EqualTo(15));
        }

        [Test]
        public void TestRemoveBagel() {
            _basket.AddItem(Stock.GetItem("BGLO"));
            BasicItem item2 = Stock.GetItem("BGLO");
            _basket.AddItem(item2);
            Assert.That(_basket.Remove(item2.Id.ToString()), Is.EqualTo(true));
        }

        [Test]
        public void TestGetCost() {
             Bagel bagel = (Bagel)Stock.GetItem("BGLO");
             bagel.AddFilling((Filling)Stock.GetItem("FILX"));
            _basket.AddItem(bagel);
            _basket.AddItem(Stock.GetItem("BGLO"));
            _basket.AddItem(Stock.GetItem("COFB"));
            _basket.AddItem(Stock.GetItem("COFB"));
            _basket.AddItem(Stock.GetItem("COFB"));
            Receipt r = new Receipt(_basket);
            double d = r.GetTotalCost();
            Assert.That(d, Is.EqualTo(3.61).Within(0.05));
        }

        [Test]
        public void TestTestDiscount() {
            _basket.AddItem(Stock.GetItem("BGLS"));
            _basket.AddItem(Stock.GetItem("BGLS"));
            _basket.AddItem(Stock.GetItem("BGLS"));
            _basket.AddItem(Stock.GetItem("BGLS"));
            _basket.AddItem(Stock.GetItem("BGLS"));
            _basket.AddItem(Stock.GetItem("BGLS"));
            Receipt r = new Receipt(_basket);
            double d = r.GetTotalCost();
            Assert.That(d, Is.EqualTo(2.49).Within(0.05));
        }
        [Test]
        public void TestCoffeeAndBagelDiscount() {
             _basket.AddItem(Stock.GetItem("BGLS"));
            _basket.AddItem(Stock.GetItem("COFB"));
            Receipt r = new Receipt(_basket);
            double d = r.GetTotalCost();
            Assert.That(d, Is.EqualTo(1.25).Within(0.05));
        }
}