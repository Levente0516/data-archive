using System.Data;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]

        public void TestSetEmpty()
        {
            Map.Map map = new();
            Assert.AreEqual(map.ToString(), "[]");

            map.Insert(new Map.Item(1, "barack"));
            Assert.AreEqual(map.ToString(), "[(1:barack)]");

            map.SetEmpty();
            Assert.AreEqual(map.ToString(), "[]");
        }

        [TestMethod]

        public void TestSelect()
        {
            Map.Map map = new();

            map.Insert(new Map.Item(1, "barack"));
            map.Insert(new Map.Item(2, "eper"));
            map.Insert(new Map.Item(0, "alma"));
            Assert.AreEqual(map.Select(2), "eper");
            Assert.ThrowsException<Map.Map.NonExistingKeyException>(() => map.Select(5));
        }
        public void TestMethod1()
        {
        }
    }
}