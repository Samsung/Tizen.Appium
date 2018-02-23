using System;
using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture(FormsTizenGalleryUtils.Platform)]
    public class ListViewTest12
    {
        string PlatformName;
        AppiumDriver Driver;

        public ListViewTest12(string platform)
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
            var listId = "listView";
            var itemString = "99 List Item";

            var touchScreen = new RemoteTouchScreenUtils(Driver);
            var itemId = WebElementUtils.GetAttribute(Driver, listId, itemString);
            while (itemId == string.Empty)
            {
                touchScreen.Flick(0, -10);
                itemId = WebElementUtils.GetAttribute(Driver, listId, itemString);
            }
            Assert.False(String.IsNullOrEmpty(itemId), itemId + "should not be empty or null, but got " + itemId);

            var isVisible = WebElementUtils.GetAttribute(Driver, itemId, "IsVisible");
            Assert.True(Convert.ToBoolean(isVisible), itemId + ".IsVisible should be true, but got " + isVisible);
        }
    }
}
