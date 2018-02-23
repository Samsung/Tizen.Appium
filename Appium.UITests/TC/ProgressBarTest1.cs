using System;
using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture(FormsTizenGalleryUtils.Platform)]
    public class ProgressBarTest1
    {
        string PlatformName;
        AppiumDriver Driver;

        public ProgressBarTest1(string platform)
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
            var pickerid = "playAnimation";

            WebElementUtils.Click(Driver, pickerid);

            //screenshot
        }

        [Test]
        public void ChangeValueTest()
        {
            var sliderId = "slider";

            //setvalue

            //screenshot
        }
    }
}
