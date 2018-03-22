using System;
using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture(FormsTizenGalleryUtils.Platform)]
    public class TableViewTest5
    {
        string PlatformName;
        AppiumDriver Driver;

        public TableViewTest5(string platform)
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
            var enableBtnId = "enble";

            var image = "TabelViewTest5.png";

            WebElementUtils.Click(Driver, enableBtnId);
            //WebElementUtils.GetScreenshotAndSave(Driver, imageName);
            Assert.AreEqual(true, WebElementUtils.CompareToScreenshot(Driver, image));
        }
    }
}
