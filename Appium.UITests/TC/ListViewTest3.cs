using System;
using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture(FormsTizenGalleryUtils.Platform)]
    public class ListViewTest3
    {
        string PlatformName;
        AppiumDriver Driver;

        public ListViewTest3(string platform)
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
            var itemString = "[Color: A=1, R=0, G=0, B=0, Hue=0, Saturation=0, Luminosity=0]";

            var itemId = WebElementUtils.GetAttribute(Driver, listId, itemString);
            Assert.False(String.IsNullOrEmpty(itemId), itemId + "should not be empty or null, but got " + itemId);

            var isVisible = WebElementUtils.GetAttribute(Driver, itemId, "IsVisible");
            Assert.True(Convert.ToBoolean(isVisible), itemId + ".IsVisible should be true, but got " + isVisible);

            // screenshot
        }
    }
}
