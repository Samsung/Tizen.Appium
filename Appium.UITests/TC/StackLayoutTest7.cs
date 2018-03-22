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

            var image = "StackLayoutTest7_hRadioFill.png";
            //WebElementUtils.GetScreenshotAndSave(Driver, image);
            Assert.AreEqual(true, WebElementUtils.CompareToScreenshot(Driver, image));
        }

        [Test]
        public void HRadioStartTest()
        {
            var btnId = "hRadioStart";

            WebElementUtils.Click(Driver, btnId);

            var image = "StackLayoutTest7_hRadioStart.png";
            //WebElementUtils.GetScreenshotAndSave(Driver, image);
            Assert.AreEqual(true, WebElementUtils.CompareToScreenshot(Driver, image));
        }

        [Test]
        public void HRadioCenterTest()
        {
            var btnId = "hRadioCenter";

            WebElementUtils.Click(Driver, btnId);

            var image = "StackLayoutTest7_hRadioCenter.png";
            //WebElementUtils.GetScreenshotAndSave(Driver, image);
            Assert.AreEqual(true, WebElementUtils.CompareToScreenshot(Driver, image));
        }

        [Test]
        public void HRadioEndTest()
        {
            var btnId = "hRadioEnd";

            WebElementUtils.Click(Driver, btnId);

            var image = "StackLayoutTest7_hRadioEnd.png";
            //WebElementUtils.GetScreenshotAndSave(Driver, image);
            Assert.AreEqual(true, WebElementUtils.CompareToScreenshot(Driver, image));
        }

        [Test]
        public void VRadioFillTest()
        {
            var btnId = "vRadioFill";

            WebElementUtils.Click(Driver, btnId);

            var image = "StackLayoutTest7_vRadioFill.png";
            //WebElementUtils.GetScreenshotAndSave(Driver, image);
            Assert.AreEqual(true, WebElementUtils.CompareToScreenshot(Driver, image));
        }

        [Test]
        public void VRadioEndTest()
        {
            var btnId = "vRadioEnd";

            WebElementUtils.Click(Driver, btnId);

            var image = "StackLayoutTest7_vRadioEnd.png";
            //WebElementUtils.GetScreenshotAndSave(Driver, image);
            Assert.AreEqual(true, WebElementUtils.CompareToScreenshot(Driver, image));
        }

        [Test]
        public void VRadioStartTest()
        {
            var btnId = "vRadioStart";

            WebElementUtils.Click(Driver, btnId);

            var image = "StackLayoutTest7_vRadioStart.png";
            //WebElementUtils.GetScreenshotAndSave(Driver, image);
            Assert.AreEqual(true, WebElementUtils.CompareToScreenshot(Driver, image));
        }

        [Test]
        public void VRadioCenterTest()
        {
            var btnId = "vRadioCenter";

            WebElementUtils.Click(Driver, btnId);

            var image = "StackLayoutTest7_vRadioCenter.png";
            //WebElementUtils.GetScreenshotAndSave(Driver, image);
            Assert.AreEqual(true, WebElementUtils.CompareToScreenshot(Driver, image));
        }
    }
}
