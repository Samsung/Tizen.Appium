using System;
using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture(FormsTizenGalleryUtils.Platform)]
    public class StackLayoutTest7
    {
        string PlatformName;
        AppiumDriver Driver;

        public StackLayoutTest7(string platform)
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
        public void HRadioFillTest()
        {
            var btnId = "hRadioFill";

            WebElementUtils.Click(Driver, btnId);

            //screenshot
        }

        [Test]
        public void HRadioStartTest()
        {
            var btnId = "hRadioStart";

            WebElementUtils.Click(Driver, btnId);

            //screenshot
        }

        [Test]
        public void HRadioCenterTest()
        {
            var btnId = "hRadioCenter";

            WebElementUtils.Click(Driver, btnId);

            //screenshot
        }

        [Test]
        public void HRadioEndTest()
        {
            var btnId = "hRadioEnd";

            WebElementUtils.Click(Driver, btnId);

            //screenshot
        }

        [Test]
        public void VRadioFillTest()
        {
            var btnId = "vRadioFill";

            WebElementUtils.Click(Driver, btnId);

            //screenshot
        }

        [Test]
        public void VRadioEndTest()
        {
            var btnId = "vRadioEnd";

            WebElementUtils.Click(Driver, btnId);

            //screenshot
        }

        [Test]
        public void VRadioStartTest()
        {
            var btnId = "vRadioStart";

            WebElementUtils.Click(Driver, btnId);

            //screenshot
        }

        [Test]
        public void VRadioCenterTest()
        {
            var btnId = "vRadioCenter";

            WebElementUtils.Click(Driver, btnId);

            //screenshot
        }
    }
}
