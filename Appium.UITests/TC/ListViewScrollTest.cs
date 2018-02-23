using System;
using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture(FormsTizenGalleryUtils.Platform)]
    public class ListViewScrollTest
    {
        string PlatformName;
        AppiumDriver Driver;

        public ListViewScrollTest(string platform)
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
        public void Move1Test()
        {
            var btnId = "move1";
            var listId = "list";
            var itemString = "item 1";
            WebElementUtils.Click(Driver, btnId);

            var itemId = WebElementUtils.GetAttribute(Driver, listId, itemString);
            Assert.False(String.IsNullOrEmpty(itemId), itemId + "should not be empty or null, but got " + itemId);

            var isVisible = WebElementUtils.GetAttribute(Driver, itemId, "IsVisible");
            Assert.True(Convert.ToBoolean(isVisible), itemId + ".IsVisible should be true, but got " + isVisible);
        }

        [Test]
        public void Move2Test()
        {
            var btnId = "move2";
            var listId = "list";
            var itemString = "item 200";
            WebElementUtils.Click(Driver, btnId);

            var itemId = WebElementUtils.GetAttribute(Driver, listId, itemString);
            Assert.False(String.IsNullOrEmpty(itemId), itemId + "should not be empty or null, but got " + itemId);

            var isVisible = WebElementUtils.GetAttribute(Driver, itemId, "IsVisible");
            Assert.True(Convert.ToBoolean(isVisible), itemId + ".IsVisible should be true, but got " + isVisible);
        }

        [Test]
        public void Move3Test()
        {
            var btnId = "move3";
            var listId = "list";
            var itemString = "item 999";
            WebElementUtils.Click(Driver, btnId);

            var itemId = WebElementUtils.GetAttribute(Driver, listId, itemString);
            Assert.False(String.IsNullOrEmpty(itemId), itemId + "should not be empty or null, but got " + itemId);

            var isVisible = WebElementUtils.GetAttribute(Driver, itemId, "IsVisible");
            Assert.True(Convert.ToBoolean(isVisible), itemId + ".IsVisible should be true, but got " + isVisible);
        }
    }
}
