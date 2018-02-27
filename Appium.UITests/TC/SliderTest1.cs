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

            WebElementUtils.Click(Driver, btnId);

            //screenshot
        }

        [Test]
        public void DecreaseTest()
        {
            var inBtnId = "button1";
            var deBtnId = "button2";

            WebElementUtils.Click(Driver, inBtnId);
            WebElementUtils.Click(Driver, inBtnId);

            WebElementUtils.Click(Driver, deBtnId);

            //screenshot
        }
    }
}
