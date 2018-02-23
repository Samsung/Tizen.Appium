using System;
using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture(FormsTizenGalleryUtils.Platform)]
    public class ListViewTest4
    {
        string PlatformName;
        AppiumDriver Driver;

        public ListViewTest4(string platform)
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
        public void SelectItemTest()
        {
            var listId = "list";
            var btnId = "setButton";
            var itemString = "item1-3";

            WebElementUtils.Click(Driver, btnId);

            var itemId = WebElementUtils.GetAttribute(Driver, listId, itemString);
            Assert.False(String.IsNullOrEmpty(itemId), itemId + "should not be empty or null, but got " + itemId);

            var isVisible = WebElementUtils.GetAttribute(Driver, itemId, "IsVisible");
            Assert.True(Convert.ToBoolean(isVisible), itemId + ".IsVisible should be true, but got " + isVisible);

            // screenshot
        }

        [Test]
        public void SelectGroupTest()
        {
            var btnId = "setButton2";

            WebElementUtils.Click(Driver, btnId);
            // screenshot
        }

        [Test]
        public void SelectGroupItemTest()
        {
            var listId = "list";
            var btnId = "setButton3";
            var itemString = "item2-1";

            WebElementUtils.Click(Driver, btnId);

            var itemId = WebElementUtils.GetAttribute(Driver, listId, itemString);
            Assert.False(String.IsNullOrEmpty(itemId), itemId + "should not be empty or null, but got " + itemId);

            var isVisible = WebElementUtils.GetAttribute(Driver, itemId, "IsVisible");
            Assert.True(Convert.ToBoolean(isVisible), itemId + ".IsVisible should be true, but got " + isVisible);

            // screenshot
        }
    }
}
