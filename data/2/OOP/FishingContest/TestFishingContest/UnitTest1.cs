using FishingContest;
using System.Threading;
using System.Globalization;

namespace TestFishingContest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestSearch0()
        {
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            Fisher fisher = Program.Search("input0.txt");
            Assert.AreEqual(fisher, null);
        }

        [TestMethod]
        public void TestSearch1()
        {
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            Fisher fisher = Program.Search("input1.txt");
            Assert.AreEqual(fisher, null);
        }

        [TestMethod]
        public void TestSearch2()
        {
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            Fisher fisher = Program.Search("input2.txt");
            Assert.AreEqual(fisher.name, "Józsi");
        }
    }
}