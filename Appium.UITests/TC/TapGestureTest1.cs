using OpenQA.Selenium.Remote;
using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture(FormsTizenGalleryUtils.Platform)]
    public class TapGestureTest1
    {
        string PlatformName;
        AppiumDriver Driver;

        public TapGestureTest1(string platform)
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
            var touch = new RemoteTouchScreen(Driver.Driver);
            touch.Down(200, 230);
            touch.Up(200, 230);
            System.Threading.Thread.Sleep(3000);
            WebElementUtils.Click(Driver, "image");
            string label = WebElementUtils.GetAttribute(Driver, "imageLabel", "Text");
            if (label.Equals("1 tap so far!"))
            {
                result = true;
            }

            System.Threading.Thread.Sleep(2000);

            Assert.AreEqual(result, true);
        }

        [Test]
        public void TapFrame()
        {
            bool result = false;
            var touch = new RemoteTouchScreen(Driver.Driver);
            touch.Down(550, 230);
            touch.Up(550, 230);
            System.Threading.Thread.Sleep(3000);

            WebElementUtils.Click(Driver, "frame");
            string title = WebElementUtils.GetAttribute(Driver, "frameLabel", "Text");
            if (title.Equals("1 tap so far!"))
            {
                result = true;
            }

            System.Threading.Thread.Sleep(2000);

            Assert.AreEqual(result, true);
        }
    }
}
