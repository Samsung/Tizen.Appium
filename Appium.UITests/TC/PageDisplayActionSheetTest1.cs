using System;
using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture(FormsTizenGalleryUtils.Platform)]
    public class PageDisplayActionSheetTest1
    {
        string PlatformName;
        AppiumDriver Driver;

        public PageDisplayActionSheetTest1(string platform)
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
        public void ViewTest()
        {
            var btnId = "button";

            WebElementUtils.Click(Driver, btnId);

            var image = "PageDisplayActionSheetTest1_button.png";
            //WebElementUtils.GetScreenshotAndSave(Driver, image);
            Assert.AreEqual(true, WebElementUtils.CompareToScreenshot(Driver, image));

            Driver.Driver.Navigate().Back();
            System.Threading.Thread.Sleep(1000);
        }

        [Test]
        public void ViewTest2()
        {
            var btnId = "button1";

            WebElementUtils.Click(Driver, btnId);

            var image = "PageDisplayActionSheetTest1_button1.png";
            //WebElementUtils.GetScreenshotAndSave(Driver, image);
            Assert.AreEqual(true, WebElementUtils.CompareToScreenshot(Driver, image));

            Driver.Driver.Navigate().Back();
            System.Threading.Thread.Sleep(1000);
        }

        [Test]
        public void ViewTest3()
        {
            var btnId = "button2";

            WebElementUtils.Click(Driver, btnId);

            var image = "PageDisplayActionSheetTest1_button3.png";
            //WebElementUtils.GetScreenshotAndSave(Driver, image);
            Assert.AreEqual(true, WebElementUtils.CompareToScreenshot(Driver, image));

            Driver.Driver.Navigate().Back();
            System.Threading.Thread.Sleep(1000);
        }
    }
}
