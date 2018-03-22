using System;
using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture(FormsTizenGalleryUtils.Platform)]
    public class TableViewTest6
    {
        string PlatformName;
        AppiumDriver Driver;
        //TizenDriver Driver;

        public TableViewTest6(string platform)
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
            var redBtnId = "red";
            var redImage = "TableViewTest6_red.png";

            WebElementUtils.Click(Driver, redBtnId);
            //WebElementUtils.GetScreenshotAndSave(Driver, redImage);

            Assert.AreEqual(true, WebElementUtils.CompareToScreenshot(Driver, redImage));
        }

        [Test]
        public void ViewTest2()
        {
            var greenBtnId = "green";
            var greenImage = "TableViewTest6_green.png";

            WebElementUtils.Click(Driver, greenBtnId);
            //WebElementUtils.GetScreenshotAndSave(Driver, greenImage);

            Assert.AreEqual(true, WebElementUtils.CompareToScreenshot(Driver, greenImage));
        }

        [Test]
        public void ViewTest3()
        {
            var grayBtnId = "gray";
            var grayImage = "TableViewTest6_gray.png";

            WebElementUtils.Click(Driver, grayBtnId);
            //WebElementUtils.GetScreenshotAndSave(Driver, grayImage);

            Assert.AreEqual(true, WebElementUtils.CompareToScreenshot(Driver, grayImage));
        }
    }
}
