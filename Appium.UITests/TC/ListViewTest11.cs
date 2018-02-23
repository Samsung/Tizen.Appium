using System;
using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture(FormsTizenGalleryUtils.Platform)]
    public class ListViewTest11
    {
        string PlatformName;
        AppiumDriver Driver;

        public ListViewTest11(string platform)
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
        public void HasUnevenRowsTrueTest()
        {
            var listId = "listView";
            var checkId = "check";
            var sliderId = "slider";
            var itemString = "item list 1";

            var hasUnevenRows = WebElementUtils.GetAttribute(Driver, listId, "HasUnevenRows");
            if (!Convert.ToBoolean(hasUnevenRows))
            {
                WebElementUtils.Click(Driver, checkId);
            }

            //set value 300
            //WebElementUtils.SetAttribute(Driver, sliderId, "Value", 300);

            var itemId = WebElementUtils.GetAttribute(Driver, listId, itemString);
            var height = WebElementUtils.GetAttribute(Driver, itemId, "Height");
            Assert.False((Convert.ToDouble(height) == 300), itemString + ".Height should not be 300");
        }

        [Test]
        public void HasUnevenRowsFalseTest()
        {
            var listId = "listView";
            var checkId = "check";
            var sliderId = "slider";
            var itemString = "item list 1";

            var hasUnevenRows = WebElementUtils.GetAttribute(Driver, listId, "HasUnevenRows");
            if (!Convert.ToBoolean(hasUnevenRows))
            {
                WebElementUtils.Click(Driver, checkId);
            }

            //set value 300
            //WebElementUtils.SetAttribute(Driver, sliderId, "Value", 300);

            var itemId = WebElementUtils.GetAttribute(Driver, listId, itemString);
            var height = WebElementUtils.GetAttribute(Driver, itemId, "Height");
            Assert.True((Convert.ToDouble(height) == 300), itemString + ".Height should be 300");
        }
    }
}
