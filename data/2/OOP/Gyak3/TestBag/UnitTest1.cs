using Gyak3;

namespace TestBag
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]

        public void TestSetEmpty()
        {
            Gyak3.Bag bag = new();
            Assert.AreEqual("[]", bag.ToString());

            bag.Insert("barack");
            Assert.AreEqual("[(barack:1)]", bag.ToString());

            bag.SetEmpty();
            Assert.AreEqual("[]", bag.ToString());
        }

        [TestMethod]

        public void TestEmpty()
        {
            Gyak3.Bag bag = new();
            Assert.AreEqual(true, bag.Empty());

            bag.Insert("barack");
            Assert.AreEqual(false, bag.Empty());
        }

        [TestMethod]

        public void TestMax()
        {
            Gyak3.Bag bag = new();
            Assert.ThrowsException<Gyak3.Bag.EmptyBagException>(() => bag.Max());
            bag.Insert("alma");
            bag.Insert("barack");
            bag.Insert("barack");
            Assert.AreEqual("barack", bag.Max());
            bag.SetEmpty();
        }
        public void TestMethod1()
        {
        }
    }
}