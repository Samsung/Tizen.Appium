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
            var disableBtnId = "disableButton";
            var itemId = "1 item";

            var isEnabled = WebElementUtils.GetAttribute<bool>(Driver, itemId, "On");
            Assert.True(isEnabled, itemId + ".IsVisible should be true, but got " + isEnabled);

            WebElementUtils.Click(Driver, itemId);
            WebElementUtils.Click(Driver, disableBtnId);

            isEnabled = WebElementUtils.GetAttribute<bool>(Driver, itemId, "On");
            Assert.False(isEnabled, itemId + ".IsVisible should be false, but got " + isEnabled);
        }

        [Test]
        public void EnableTest()
        {
            var enableBtnId = "enableButton";
            var itemId = "0 item";

            var isEnabled = WebElementUtils.GetAttribute<bool>(Driver, itemId, "On");
            Assert.True(isEnabled, itemId + ".IsVisible should be true, but got " + isEnabled);

            WebElementUtils.Click(Driver, itemId);
            WebElementUtils.Click(Driver, enableBtnId);

            isEnabled = WebElementUtils.GetAttribute<bool>(Driver, itemId, "On");
            Assert.True(isEnabled, itemId + ".IsVisible should be true, but got " + isEnabled);
        }
    }
}
