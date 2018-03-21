using System;
using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture(FormsTizenGalleryUtils.Platform)]
    public class SliderTest1
    {
        string PlatformName;
        AppiumDriver Driver;

        public SliderTest1(string platform)
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
        public void IncreaseTest()
        {
            var btnId = "button1";
            var sliderId = "slider";

            var before = WebElementUtils.GetAttribute<double>(Driver, sliderId, "Value");

            WebElementUtils.Click(Driver, btnId);

            var after = WebElementUtils.GetAttribute<double>(Driver, sliderId, "Value");

            Assert.True(((before + 3) == after), "Value should be " + (before + 3));
        }

        [Test]
        public void DecreaseTest()
        {
            var inBtnId = "button1";
            var deBtnId = "button2";
            var sliderId = "slider";

            var before = WebElementUtils.GetAttribute<double>(Driver, sliderId, "Value");

            WebElementUtils.Click(Driver, inBtnId);
            WebElementUtils.Click(Driver, inBtnId);

            WebElementUtils.Click(Driver, deBtnId);

            var after = WebElementUtils.GetAttribute<double>(Driver, sliderId, "Value");

            Assert.True(((before + 3) == after), "Value should be " + (before + 3));
        }
    }
}
