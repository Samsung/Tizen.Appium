using System;
using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture(FormsTizenGalleryUtils.Platform)]
    public class ListViewTest9
    {
        string PlatformName;
        AppiumDriver Driver;

        public ListViewTest9(string platform)
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
            var itemId = "list item #1";

            WebElementUtils.Click(Driver, checkId);

            var hasUnevenRows = WebElementUtils.GetAttribute<bool>(Driver, listId, "HasUnevenRows");
            if (!hasUnevenRows)
            {
                WebElementUtils.Click(Driver, checkId);
            }

            WebElementUtils.SetAttribute(Driver, sliderId, "Value", 300);

            var height = WebElementUtils.GetAttribute<double>(Driver, itemId, "Height");
            Assert.True((height == 300), "Height value should not be 300");
        }

        [Test]
        public void HasUnevenRowsFalseTest()
        {
            var listId = "listView";
            var checkId = "check";
            var sliderId = "slider";
            var itemId = "list item #1";

            WebElementUtils.Click(Driver, checkId);

            var hasUnevenRows = WebElementUtils.GetAttribute<bool>(Driver, listId, "HasUnevenRows");
            if (hasUnevenRows)
            {
                WebElementUtils.Click(Driver, checkId);
            }

            WebElementUtils.SetAttribute(Driver, sliderId, "Value", 300);

            var height = WebElementUtils.GetAttribute<double>(Driver, itemId, "Height");
            Assert.True((height != 300), "Height value should be 300");
        }
    }
}
