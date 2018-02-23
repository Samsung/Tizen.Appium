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
            var listId = "listView";
            var itemString = "[Color: A=1, R=0, G=0, B=0, Hue=0, Saturation=0, Luminosity=0]";
            var detailPageId = "DetailPage";
            var touchScreen = new RemoteTouchScreenUtils(Driver);

            var isPresented = WebElementUtils.GetAttribute(Driver, pageId, "IsPresented");
            if (!Convert.ToBoolean(isPresented))
            {
                touchScreen.Drag(0, 500, 300, 500);
            }

            var itemId = WebElementUtils.GetAttribute(Driver, listId, itemString);
            Assert.False(String.IsNullOrEmpty(itemId), itemId + "should not be empty or null, but got " + itemId);
            WebElementUtils.Click(Driver, itemId);

            var color = WebElementUtils.GetAttribute(Driver, detailPageId, "BackgroundColor");
            Assert.True((color.ToString() == itemString), itemString + " is expected, but got " + color.ToString());

            //screenshot
        }
    }
}
