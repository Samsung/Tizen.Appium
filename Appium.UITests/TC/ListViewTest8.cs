using System;
using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture(FormsTizenGalleryUtils.Platform)]
    public class ListViewTest8
    {
        string PlatformName;
        AppiumDriver Driver;

        public ListViewTest8(string platform)
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
        public void AddRemoveTest()
        {
            var btnId = "button";
            var listId = "list";
            var itemString = "item 0";

            WebElementUtils.Click(Driver, btnId);

            var itemId = WebElementUtils.GetAttribute(Driver, listId, itemString);
            Assert.False(String.IsNullOrEmpty(itemId), itemId + "should not be empty or null, but got " + itemId);

            var isVisible = WebElementUtils.GetAttribute(Driver, itemId, "IsVisible");
            Assert.True(Convert.ToBoolean(isVisible), itemString + ".IsVisible should be true, but got " + isVisible);

            WebElementUtils.Click(Driver, btnId);

            isVisible = WebElementUtils.GetAttribute(Driver, itemId, "IsVisible");
            Assert.False(Convert.ToBoolean(isVisible), itemString + ".IsVisible should be false, but got " + isVisible);
        }
    }
}
