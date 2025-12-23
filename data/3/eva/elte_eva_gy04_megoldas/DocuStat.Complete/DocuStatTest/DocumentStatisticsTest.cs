using ELTE.DocuStat.Model;
using ELTE.DocuStat.Persistence;
using Moq;

namespace DocuStatTest
{
    [TestClass]
    public sealed class DocumentStatisticsTest
    {

        private Mock<IFileManager> _mock = null!;
        private DocumentStatistics _docStats = null!;

        [TestInitialize]
        public void InitDocuStatTest()
        {
            _mock = new Mock<IFileManager>();
            _docStats = new DocumentStatistics(_mock.Object);
        }


        [TestMethod]
        public void TestFileContent()
        {
            _mock.Setup(m => m.Load()).Returns("test");
            _docStats.Load();

            Assert.AreEqual("test", _docStats.FileContent);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]

        public void TestFileErrorWhenLoading()
        {
            _mock.Setup(m => m.Load()).Returns(() => throw new Exception());
            _docStats.Load();
        }

        [TestMethod]

        public void TestFileContentReadyEventRaised()
        {
            bool hasFieldContentReadyRaised = false;
            _mock.Setup(m => m.Load()).Returns("test");
            _docStats.FileContentReady += (sender, args) => hasFieldContentReadyRaised = true;
            _docStats.Load();

            Assert.IsTrue(hasFieldContentReadyRaised);
        }

        [TestMethod]

        public void TestCharacterCount()
        {
            var text1 = "Alma fa";
            _mock.Setup(m => m.Load()).Returns(text1);
            _docStats.Load();

            Assert.AreEqual(7, _docStats.CharacterCount);

            var text2 = "";
            _mock.Setup(m => m.Load()).Returns(text2);
            _docStats.Load();

            Assert.AreEqual(0, _docStats.CharacterCount);
        }

        [TestMethod]

        public void TestNonWhiteSpaceCharacterCount()
        {
            var text1 = "Alma";
            _mock.Setup(m => m.Load()).Returns(text1);
            _docStats.Load();

            Assert.AreEqual(4, _docStats.NonWhiteSpaceCharacterCount);

            var text2 = "";
            _mock.Setup(m => m.Load()).Returns(text2);
            _docStats.Load();

            Assert.AreEqual(0, _docStats.NonWhiteSpaceCharacterCount);
        }

        [TestMethod]

        public void TestSentenceCount()
        {
            var text1 = "Alma! fa. almafa?";
            _mock.Setup(m => m.Load()).Returns(text1);
            _docStats.Load();

            Assert.AreEqual(3, _docStats.SentenceCount);

            var text2 = "";
            _mock.Setup(m => m.Load()).Returns(text2);
            _docStats.Load();

            Assert.AreEqual(0, _docStats.SentenceCount);
        }

        [TestMethod]

        public void TestProperNounCount()
        {
            var text1 = "The Great Gatsby";
            _mock.Setup(m => m.Load()).Returns(text1);
            _docStats.Load();

            Assert.AreEqual(2, _docStats.ProperNounCount);

            var text2 = "The Great Gatsby. The Great Gatsby.";
            _mock.Setup(m => m.Load()).Returns(text2);
            _docStats.Load();

            Assert.AreEqual(4, _docStats.ProperNounCount);
        }

        [TestMethod]

        public void TestColemanLieuIndex()
        {
            var text2 = "Az almafa. Valamint a kecske."; // non white: 25, sentence: 2
            _mock.Setup(m => m.Load()).Returns(text2);
            _docStats.Load();

            double ratio = (double)_docStats.DistinctWordCount.Sum(w => w.Value) / 100;

            var value = 0.0588 * ((double)(_docStats.NonWhiteSpaceCharacterCount / ratio) - 0.296) * ((double)(_docStats.SentenceCount / ratio) - 15.8);
            Assert.AreEqual(value, _docStats.ColemanLieuIndex);

            /*var text1 = "The Great Gatsby";
            _mock.Setup(m => m.Load()).Returns(text1);
            _docStats.Load();

            Assert.AreEqual(2, _docStats.ColemanLieuIndex);
            */
        }
    }
}
