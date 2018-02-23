using System;
using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture(FormsTizenGalleryUtils.Platform)]
    public class PageDisplayAlertTest1
    {
        string PlatformName;
        AppiumDriver Driver;

        public PageDisplayAlertTest1(string platform)
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
        public void CancleTest()
        {
            var btnId = "cancelOnlyButton";

            WebElementUtils.Click(Driver, btnId);

            //screenshot

            Driver.Driver.Navigate().Back();
            System.Threading.Thread.Sleep(1000);
        }

        [Test]
        public void CancleAcceptTest()
        {
            var btnId = "cancelAceeptButton";

            WebElementUtils.Click(Driver, btnId);

            //screenshot
            Driver.Driver.Navigate().Back();
            System.Threading.Thread.Sleep(1000);
        }
    }
}
