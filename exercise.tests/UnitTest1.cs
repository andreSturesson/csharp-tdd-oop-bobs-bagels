namespace exercise.test;

using exercise.main;
public class Tests
{

    private Basket _basket;


    [SetUp]
    public void Setup()
    {
        _basket = new Basket(10);
    }

        [TestCase ("Sweet Bagel", true)]
        [TestCase ("Super Bagel", true)]
        [TestCase ("", false)]
        [TestCase ("Small Bagel", true)]
        public void TestAddBagel(string Type, bool expected) {

            Assert.That(_bagel.AddBagel(Type), Is.EqualTo(expected));
        }
}