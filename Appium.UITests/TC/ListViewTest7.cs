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
            var itemId = "Item added 2";

            WebElementUtils.Click(Driver, insertBtnId);

            var isEnabled = WebElementUtils.GetAttribute<bool>(Driver, itemId, "IsEnabled");
            Assert.True(isEnabled, itemId + ".IsVisible should be true, but got " + isEnabled);

            WebElementUtils.Click(Driver, itemId);
            WebElementUtils.Click(Driver, removeBtnId);

            isEnabled = WebElementUtils.GetAttribute<bool>(Driver, itemId, "IsEnabled");
            Assert.False(isEnabled, itemId + ".IsVisible should be false, but got " + isEnabled);
        }

        [Test]
        public void AddRemoveAllTest()
        {
            var insertBtnId = "insertButton";
            var removeAllBtnId = "removeAllButton";
            var itemId = "Item added 1";

            WebElementUtils.Click(Driver, insertBtnId);

            var isEnabled = WebElementUtils.GetAttribute<bool>(Driver, itemId, "IsEnabled");
            Assert.True(isEnabled, itemId + ".IsVisible should be true, but got " + isEnabled);

            WebElementUtils.Click(Driver, removeAllBtnId);

            isEnabled = WebElementUtils.GetAttribute<bool>(Driver, itemId, "IsEnabled");
            Assert.False(isEnabled, itemId + ".IsVisible should be false, but got " + isEnabled);
        }
    }
}
