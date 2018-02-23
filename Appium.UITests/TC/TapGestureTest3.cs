using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture(FormsTizenGalleryUtils.Platform)]
    public class TapGestureTest3
    {
        string PlatformName;
        AppiumDriver Driver;

        public TapGestureTest3(string platform)
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
        public void TapImage()
        {
            bool result = false;
            WebElementUtils.Click(Driver, "image");
            string label = WebElementUtils.GetAttribute(Driver, "label", "Text");
            if (label.Equals("1 tap so far!"))
            {
                result = true;
            }

            System.Threading.Thread.Sleep(2000);

            Assert.AreEqual(result, true);
        }

        [Test]
        public void TapImageDouble()
        {
            bool result = false;
            WebElementUtils.Click(Driver, "button");
            WebElementUtils.ClickWithoutSleep(Driver, "image");
            WebElementUtils.ClickWithoutSleep(Driver, "image");
            string label = WebElementUtils.GetAttribute(Driver, "label", "Text");
            if (label.Equals("2 taps so far!"))
            {
                result = true;
            }

            System.Threading.Thread.Sleep(2000);

            Assert.AreEqual(result, true);
        }
    }
}
