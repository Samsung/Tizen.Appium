using System;
using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture(FormsTizenGalleryUtils.Platform)]
    public class ListViewTest10
    {
        string PlatformName;
        AppiumDriver Driver;

        public ListViewTest10(string platform)
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
        public void HeightTest()
        {
            var item100Id = "Height 100";

            var height = WebElementUtils.GetAttribute<double>(Driver, item100Id, "Height");
            Assert.True(height == 100, item100Id + ".Height should be 100, but got " + height);

            var image = "ListViewTest10.png";
            //WebElementUtils.GetScreenshotAndSave(Driver, image);
            Assert.AreEqual(true, WebElementUtils.CompareToScreenshot(Driver, image));
        }
    }
}
