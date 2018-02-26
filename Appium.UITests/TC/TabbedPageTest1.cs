using System;
using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture(FormsTizenGalleryUtils.Platform)]
    public class TabbedPageTest1
    {
        string PlatformName;
        AppiumDriver Driver;

        public TabbedPageTest1(string platform)
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
        public void ShowHideTest()
        {
            var hideBtnId = "hide";
            var showBtnId = "show";

            WebElementUtils.Click(Driver, showBtnId);

            WebElementUtils.Click(Driver, hideBtnId);
            //screenshot

            WebElementUtils.Click(Driver, showBtnId);
            //screenshot
        }
    }
}
