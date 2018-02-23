using System;
using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture(FormsTizenGalleryUtils.Platform)]
    public class NavigationTest1
    {
        string PlatformName;
        AppiumDriver Driver;

        public NavigationTest1(string platform)
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
        public void BarColorChangeTest()
        {
            var btnId = "barColorChanged";

            WebElementUtils.Click(Driver, btnId);
            //screenshot
        }

        [Test]
        public void BarVisibleTest()
        {
            var btnId = "BarVisible";

            WebElementUtils.Click(Driver, btnId);
            //screenshot
        }
    }
}
