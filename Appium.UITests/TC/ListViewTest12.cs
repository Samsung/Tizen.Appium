using System;
using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture(FormsTizenGalleryUtils.Platform)]
    public class ListViewTest12
    {
        string PlatformName;
        AppiumDriver Driver;

        public ListViewTest12(string platform)
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
        public void ViewTest()
        {
            var itemId = "99 List Item";

            var touchScreen = new RemoteTouchScreenUtils(Driver);

            var isEnabled = WebElementUtils.GetAttribute<bool>(Driver, itemId, "IsEnabled");

            while (!isEnabled)
            {
                touchScreen.Flick(0, -10);
                isEnabled = WebElementUtils.GetAttribute<bool>(Driver, itemId, "IsEnabled");
            }

            isEnabled = WebElementUtils.GetAttribute<bool>(Driver, itemId, "IsEnabled");
            Assert.True(isEnabled, itemId + ".isEnabled should be true, but got " + isEnabled);
        }
    }
}
