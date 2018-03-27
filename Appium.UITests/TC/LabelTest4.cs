using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture]
    public class LabelTest4 : TestTemplate
    {
        [Test]
        public void WordWrapTest()
        {
            Driver.Click("wordWrapButton");
            var expected = "WordWrap";
            string result = Driver.GetText("label2");
            Assert.AreEqual(result, expected, "Expected: " + expected + ",but got: " + result);
        }

        [Test]
        public void CharacterWrapTest()
        {
            Driver.Click("characterWrapButton");
            var expected = "CharacterWrap";
            string result = Driver.GetText("label2");
            Assert.AreEqual(result, expected, "Expected: " + expected + ",but got: " + result);
        }

        [Test]
        public void HeadTest()
        {
            Driver.Click("headButton");
            var expected = "HeadTruncation";
            string result = Driver.GetText("label2");
            Assert.AreEqual(result, expected, "Expected: " + expected + ",but got: " + result);
        }

        [Test]
        public void MiddleTest()
        {
            Driver.Click("middleButton");
            var expected = "MiddleTruncation";
            string result = Driver.GetText("label2");
            Assert.AreEqual(result, expected, "Expected: " + expected + ",but got: " + result);
        }

        [Test]
        public void TailTest()
        {
            Driver.Click("tailButton");
            var expected = "TailTruncation";
            string result = Driver.GetText("label2");
            Assert.AreEqual(result, expected, "Expected: " + expected + ",but got: " + result);
        }

        [Test]
        public void NowrapTest()
        {
            Driver.Click("nowrapButton");
            var expected = "NoWrap";
            string result = Driver.GetText("label2");
            Assert.AreEqual(result, expected, "Expected: " + expected + ",but got: " + result);
        }
    }
}
