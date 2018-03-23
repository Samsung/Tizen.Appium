using System;
using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture(FormsTizenGalleryUtils.Platform)]
    public class SearchBarTest1
    {
        string PlatformName;
        AppiumDriver Driver;

        public SearchBarTest1(string platform)
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
        public void ScrollWithoutAnimationTest()
        {
            var searchBarBtnId = "searchBar";

            WebElementUtils.SetText(Driver, searchBarBtnId, "test");
            System.Threading.Thread.Sleep(2000);

            var image = "SearchBarTest1.png";
            //WebElementUtils.GetScreenshotAndSave(Driver, image);
            Assert.AreEqual(true, WebElementUtils.CompareToScreenshot(Driver, image));
        }
    }
}
