using System;
using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture(FormsTizenGalleryUtils.Platform)]
    public class ListViewTest13
    {
        string PlatformName;
        AppiumDriver Driver;

        public ListViewTest13(string platform)
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
            var itemString = "1 item";

            var itemId = WebElementUtils.GetAttribute(Driver, listId, itemString);
            Assert.False(String.IsNullOrEmpty(itemId), itemString + "should not be empty or null, but got " + itemId);

            WebElementUtils.Click(Driver, itemId);
            WebElementUtils.Click(Driver, enableBtnId);

            //evas object does not provide IsEnabled, it is a ItemObject's property

            //var enabled = WebElementUtils.GetAttribute(Driver, itemId, "IsEnabled");
            //Assert.False(Convert.ToBoolean(enabled), itemString + "should be false, but got " + enabled);

            //screenshot for checking disabled cell
        }

        [Test]
        public void EnableTest()
        {
            var listId = "list";
            var enableBtnId = "enableButton";
            var itemString = "0 item";

            var itemId = WebElementUtils.GetAttribute(Driver, listId, itemString);
            Assert.False(String.IsNullOrEmpty(itemId), itemId + "should not be empty or null, but got " + itemId);

            WebElementUtils.Click(Driver, itemId);
            WebElementUtils.Click(Driver, enableBtnId);

            //evas object does not provide IsEnabled, it is a ItemObject's property

            //var enabled = WebElementUtils.GetAttribute(Driver, itemId, "IsEnabled");
            //Assert.True(Convert.ToBoolean(enabled), itemString + "should be true, but got " + enabled);

            //screenshot for checking enabled cell
        }
    }
}
