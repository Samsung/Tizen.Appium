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
            var pregressbarId = "progressBar";
            var btnid = "playAnimation";
            var value = 1;

            WebElementUtils.Click(Driver, btnid);

            var result = WebElementUtils.GetAttribute<double>(Driver, pregressbarId, "Progress");
            Assert.True((value == result), "value should be " + result);
        }

        [Test]
        public void ChangeValueTest()
        {
            var pregressbarId = "progressBar";
            var sliderId = "slider";
            var value = 0.5;

            WebElementUtils.SetAttribute(Driver, sliderId, "Value", value);

            var result = WebElementUtils.GetAttribute<double>(Driver, pregressbarId, "Progress");

            Assert.True((value == result), "value should be " + result);
        }
    }
}
