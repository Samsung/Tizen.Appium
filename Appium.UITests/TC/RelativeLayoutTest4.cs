using System;
using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture(FormsTizenGalleryUtils.Platform)]
    public class RelativeLayoutTest4
    {
        string PlatformName;
        AppiumDriver Driver;

        public RelativeLayoutTest4(string platform)
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

        //[Test]
        public void ViewTest()
        {
            //screenshot
            // using ActivityIndicator
        }
    }
}
