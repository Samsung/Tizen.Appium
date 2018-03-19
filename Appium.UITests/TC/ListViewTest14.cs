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
            var enableBtnId = "disableButton";
            var itemId = "1 item";

            WebElementUtils.Click(Driver, itemId);
            WebElementUtils.Click(Driver, enableBtnId);

            var isEnabled = WebElementUtils.GetAttribute<bool>(Driver, itemId, "IsEnabled");
            Assert.False(isEnabled, itemId + ".IsVisible should be true, but got " + isEnabled);
        }

        [Test]
        public void EnableTest()
        {
            var enableBtnId = "enableButton";
            var itemId = "0 item";

            WebElementUtils.Click(Driver, itemId);
            WebElementUtils.Click(Driver, enableBtnId);

            var isEnabled = WebElementUtils.GetAttribute<bool>(Driver, itemId, "IsEnabled");
            Assert.True(isEnabled, itemId + ".IsVisible should be true, but got " + isEnabled);
        }
    }
}
