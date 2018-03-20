using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture(FormsTizenGalleryUtils.Platform)]
    public class LabelTest4
    {
        string PlatformName;
        AppiumDriver Driver;

        public LabelTest4(string platform)
        {
            PlatformName = platform;
        }

        [TestFixtureSetUp]
        public void Setup()
        {
            Driver = new AppiumDriver(PlatformName);
            FormsTizenGalleryUtils.FindTC(Driver, this.GetType().Name);
        }

        [TestFixtureTearDown]
        public void TearDown()
        {
            Driver.Quit();
        }

        [Test]
        public void WordWrapTest()
        {
            WebElementUtils.Click(Driver, "wordWrapButton");
            var expected = "WordWrap";
            string result = WebElementUtils.GetText(Driver, "label2");
            Assert.AreEqual(result, expected, "Expected: " + expected + ",but got: " + result);
        }

        [Test]
        public void CharacterWrapTest()
        {
            WebElementUtils.Click(Driver, "characterWrapButton");
            var expected = "CharacterWrap";
            string result = WebElementUtils.GetText(Driver, "label2");
            Assert.AreEqual(result, expected, "Expected: " + expected + ",but got: " + result);
        }

        [Test]
        public void HeadTest()
        {
            WebElementUtils.Click(Driver, "headButton");
            var expected = "HeadTruncation";
            string result = WebElementUtils.GetText(Driver, "label2");
            Assert.AreEqual(result, expected, "Expected: " + expected + ",but got: " + result);
        }

        [Test]
        public void MiddleTest()
        {
            WebElementUtils.Click(Driver, "middleButton");
            var expected = "MiddleTruncation";
            string result = WebElementUtils.GetText(Driver, "label2");
            Assert.AreEqual(result, expected, "Expected: " + expected + ",but got: " + result);
        }

        [Test]
        public void TailTest()
        {
            WebElementUtils.Click(Driver, "tailButton");
            var expected = "TailTruncation";
            string result = WebElementUtils.GetText(Driver, "label2");
            Assert.AreEqual(result, expected, "Expected: " + expected + ",but got: " + result);
        }

        [Test]
        public void NowrapTest()
        {
            WebElementUtils.Click(Driver, "nowrapButton");
            var expected = "NoWrap";
            string result = WebElementUtils.GetText(Driver, "label2");
            Assert.AreEqual(result, expected, "Expected: " + expected + ",but got: " + result);
        }
    }
}
