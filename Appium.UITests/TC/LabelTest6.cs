using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture(FormsTizenGalleryUtils.Platform)]
    public class LabelTest6
    {
        string PlatformName;
        AppiumDriver Driver;

        public LabelTest6(string platform)
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
        public void BoldTest()
        {
            WebElementUtils.Click(Driver, "boldBtn");
        }

        [Test]
        public void ItalicTest()
        {
            WebElementUtils.Click(Driver, "italic");
        }

        [Test]
        public void LargerFontTest()
        {
            WebElementUtils.Click(Driver, "largerFont");
        }

        [Test]
        public void SmallerFontTest()
        {
            WebElementUtils.Click(Driver, "smallerFont");
        }

        [Test]
        public void WordWrapTest()
        {
            WebElementUtils.Click(Driver, "wordWrap");
        }

        [Test]
        public void CharWrapTest()
        {
            WebElementUtils.Click(Driver, "charWrap");
        }

        [Test]
        public void HeadWrapTest()
        {
            WebElementUtils.Click(Driver, "headWrap");
        }

        [Test]
        public void MiddleWrapTest()
        {
            WebElementUtils.Click(Driver, "middleWrap");
        }

        [Test]
        public void NoWrapTest()
        {
            WebElementUtils.Click(Driver, "noWrap");
        }
    }
}
