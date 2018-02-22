using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture(FormsTizenGalleryUtils.Platform)]
    public class TapGestureTest4
    {
        string PlatformName;
        AppiumDriver Driver;

        public TapGestureTest4(string platform)
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
            string label = WebElementUtils.GetAttribute(Driver, "result", "Text");
            if (label.Equals("An image is tapped."))
            {
                result = true;
            }

            System.Threading.Thread.Sleep(2000);

            Assert.AreEqual(result, true);
        }

        [Test]
        public void TapBoxView()
        {
            bool result = false;
            WebElementUtils.Click(Driver, "boxView");
            string label = WebElementUtils.GetAttribute(Driver, "result", "Text");
            if (label.Equals("A boxView is tapped."))
            {
                result = true;
            }

            System.Threading.Thread.Sleep(2000);

            Assert.AreEqual(result, true);
        }

        [Test]
        public void TapButton()
        {
            bool result = false;
            WebElementUtils.Click(Driver, "button");
            string label = WebElementUtils.GetAttribute(Driver, "result", "Text");
            if (label.Equals("A button is tapped."))
            {
                result = true;
            }

            System.Threading.Thread.Sleep(2000);

            Assert.AreEqual(result, true);
        }

        [Test]
        public void TapLabel()
        {
            bool result = false;
            WebElementUtils.Click(Driver, "label");
            string label = WebElementUtils.GetAttribute(Driver, "result", "Text");
            if (label.Equals("A label is tapped."))
            {
                result = true;
            }

            System.Threading.Thread.Sleep(2000);

            Assert.AreEqual(result, true);
        }
    }
}
