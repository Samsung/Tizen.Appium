using System;
using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture(FormsTizenGalleryUtils.Platform)]
    public class MasterDetailedTest2
    {
        string PlatformName;
        AppiumDriver Driver;

        public MasterDetailedTest2(string platform)
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
            var pageId = "MasterDetailPage";
            var itemId = "[Color: A=1, R=0, G=0, B=0, Hue=0, Saturation=0, Luminosity=0]";
            var detailPageId = "DetailPage";
            var touchScreen = new RemoteTouchScreenUtils(Driver);

            var isPresented = WebElementUtils.GetAttribute<bool>(Driver, pageId, "IsPresented");
            if (!isPresented)
            {
                touchScreen.Drag(0, 500, 300, 500);
            }

            WebElementUtils.Click(Driver, itemId);

            var color = WebElementUtils.GetAttribute<string>(Driver, detailPageId, "BackgroundColor");
            Assert.True((color == itemId), itemId + " is expected, but got " + color);
        }
    }
}
