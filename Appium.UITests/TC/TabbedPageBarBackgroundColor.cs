using System;
using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture(FormsTizenGalleryUtils.Platform)]
    public class TabbedPageBarBackgroundColor
    {
        string PlatformName;
        AppiumDriver Driver;

        public TabbedPageBarBackgroundColor(string platform)
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
        public void ChangeTitleTest()
        {
            var btnId = "changeTitle";

            WebElementUtils.Click(Driver, btnId);

            //screenshot
        }

        [Test]
        public void ChangeBackgroundTest()
        {
            var btnId = "changeBackground";

            WebElementUtils.Click(Driver, btnId);

            //screenshot
        }
    }
}
