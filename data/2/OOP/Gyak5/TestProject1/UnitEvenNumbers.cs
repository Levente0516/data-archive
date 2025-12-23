using Gy05;
namespace TestProject1
{
    [TestClass]
    public class UnitEvenNumbers
    {
        [TestMethod]
        public void TestMethod0()
        {
            Program.Counting("test0.txt", out int countbegin, out int countend);
            Assert.AreEqual(countbegin, 0);
            Assert.AreEqual(countend, 0);
        }

        [TestMethod]
        public void TestMethod00()
        {
            Program.Counting("test00.txt", out int countbegin, out int countend);
            Assert.AreEqual(countbegin, 0);
            Assert.AreEqual(countend, 0);
        }
        [TestMethod]
        public void TestMethod01()
        {
            Program.Counting("test01.txt", out int countbegin, out int countend);
            Assert.AreEqual(countbegin, 0);
            Assert.AreEqual(countend, 1);
        }
        [TestMethod]
        public void TestMethod10()
        {
            Program.Counting("test10.txt", out int countbegin, out int countend);
            Assert.AreEqual(countbegin, 1);
            Assert.AreEqual(countend, 0);
        }
        [TestMethod]
        public void TestMethod11()
        {
            Program.Counting("test11.txt", out int countbegin, out int countend);
            Assert.AreEqual(countbegin, 1);
            Assert.AreEqual(countend, 1);
        }
        
        [TestMethod]
        public void TestMethod22()
        {
            Program.Counting("test22.txt", out int countbegin, out int countend);
            Assert.AreEqual(countbegin, 2);
            Assert.AreEqual(countend, 2);
        }
    }
}