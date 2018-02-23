using System;
using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture(FormsTizenGalleryUtils.Platform)]
    public class ListViewTest14
    {
        string PlatformName;
        AppiumDriver Driver;

        public ListViewTest14(string platform)
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
        public void DisableTest()
        {
            var listId = "list";
            var enableBtnId = "disableButton";
            var itemString = "1 Item";

            var itemId = WebElementUtils.GetAttribute(Driver, listId, itemString);
            Assert.False(String.IsNullOrEmpty(itemId), itemId + "should not be empty or null, but got " + itemId);

            WebElementUtils.Click(Driver, itemId);
            WebElementUtils.Click(Driver, enableBtnId);

            //screenshot for checking disabled cell
        }

        [Test]
        public void EnableTest()
        {
            var listId = "list";
            var enableBtnId = "enableButton";
            var itemString = "0 Item";

            var itemId = WebElementUtils.GetAttribute(Driver, listId, itemString);
            Assert.False(String.IsNullOrEmpty(itemId), itemId + "should not be empty or null, but got " + itemId);

            WebElementUtils.Click(Driver, itemId);
            WebElementUtils.Click(Driver, enableBtnId);

            //screenshot for checking enabled cell
        }
    }
}
