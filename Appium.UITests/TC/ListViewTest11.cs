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
            var itemId = "item list 1";

            var hasUnevenRows = WebElementUtils.GetAttribute<bool>(Driver, listId, "HasUnevenRows");
            if (!hasUnevenRows)
            {
                WebElementUtils.Click(Driver, checkId);
            }

            //set value 300
            //WebElementUtils.SetAttribute(Driver, sliderId, "Value", 300);

            var height = WebElementUtils.GetAttribute<double>(Driver, itemId, "Height");
            Assert.True((height != 300), "item's Height should not be 300");
        }

        [Test]
        public void HasUnevenRowsFalseTest()
        {
            var listId = "listView";
            var checkId = "check";
            var sliderId = "slider";
            var itemId = "item list 1";

            var hasUnevenRows = WebElementUtils.GetAttribute<bool>(Driver, listId, "HasUnevenRows");
            if (hasUnevenRows)
            {
                WebElementUtils.Click(Driver, checkId);
            }

            //set value 300
            //WebElementUtils.SetAttribute(Driver, sliderId, "Value", 300);

            var height = WebElementUtils.GetAttribute<double>(Driver, itemId, "Height");
            Assert.True((height == 300), "item's .Height should be 300");
        }
    }
}
