using System;
using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture(FormsTizenGalleryUtils.Platform)]
    public class TabbedPageTest2
    {
        string PlatformName;
        AppiumDriver Driver;

        public TabbedPageTest2(string platform)
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
            var changeBtnId = "chageTitle";

            WebElementUtils.Click(Driver, changeBtnId);
            //screenshot
        }
    }
}
