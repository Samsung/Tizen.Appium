using System;
using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture(FormsTizenGalleryUtils.Platform)]
    public class ListViewTest7
    {
        string PlatformName;
        AppiumDriver Driver;

        public ListViewTest7(string platform)
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
            var insertBtnId = "insertButton";
            var removeBtnId = "removeButton";
            var listId = "list";
            var itemString = "Item added 1";

            WebElementUtils.Click(Driver, insertBtnId);

            var itemId = WebElementUtils.GetAttribute(Driver, listId, itemString);
            Assert.False(String.IsNullOrEmpty(itemId), itemId + "should not be empty or null, but got " + itemId);

            var isVisible = WebElementUtils.GetAttribute(Driver, itemId, "IsVisible");
            Assert.True(Convert.ToBoolean(isVisible), itemString + ".IsVisible should be true, but got " + isVisible);

            WebElementUtils.Click(Driver, itemId);
            WebElementUtils.Click(Driver, removeBtnId);

            isVisible = WebElementUtils.GetAttribute(Driver, itemId, "IsVisible");
            Assert.False(Convert.ToBoolean(isVisible), itemString + ".IsVisible should be false, but got " + isVisible);
        }

        [Test]
        public void AddRemoveAllTest()
        {
            var insertBtnId = "insertButton";
            var removeAllBtnId = "removeAllButton";
            var listId = "list";
            var itemString = "Item added 1";

            WebElementUtils.Click(Driver, insertBtnId);

            var itemId = WebElementUtils.GetAttribute(Driver, listId, itemString);
            Assert.False(String.IsNullOrEmpty(itemId), itemId + "should not be empty or null, but got " + itemId);

            var isVisible = WebElementUtils.GetAttribute(Driver, itemId, "IsVisible");
            Assert.True(Convert.ToBoolean(isVisible), itemString + ".IsVisible should be true, but got " + isVisible);

            WebElementUtils.Click(Driver, removeAllBtnId);

            isVisible = WebElementUtils.GetAttribute(Driver, itemId, "IsVisible");
            Assert.False(Convert.ToBoolean(isVisible), itemString + ".IsVisible should be false, but got " + isVisible);
        }
    }
}
