using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture]
    public class StackLayoutTest7 : TestTemplate
    {
        [Test]
        public void HRadioFillTest()
        {
            var btnId = "hRadioFill";

            Driver.Click(btnId);

            var image = "StackLayoutTest7_hRadioFill.png";
            //WebElementUtils.GetScreenshotAndSave(Driver, image);
            Assert.AreEqual(true, Driver.CompareToScreenshot(image));
        }

        [Test]
        public void HRadioStartTest()
        {
            var btnId = "hRadioStart";

            Driver.Click(btnId);

            var image = "StackLayoutTest7_hRadioStart.png";
            //WebElementUtils.GetScreenshotAndSave(Driver, image);
            Assert.AreEqual(true, Driver.CompareToScreenshot(image));
        }

        [Test]
        public void HRadioCenterTest()
        {
            var btnId = "hRadioCenter";

            Driver.Click(btnId);

            var image = "StackLayoutTest7_hRadioCenter.png";
            //WebElementUtils.GetScreenshotAndSave(Driver, image);
            Assert.AreEqual(true, Driver.CompareToScreenshot(image));
        }

        [Test]
        public void HRadioEndTest()
        {
            var btnId = "hRadioEnd";

            Driver.Click(btnId);

            var image = "StackLayoutTest7_hRadioEnd.png";
            //WebElementUtils.GetScreenshotAndSave(Driver, image);
            Assert.AreEqual(true, Driver.CompareToScreenshot(image));
        }

        [Test]
        public void VRadioFillTest()
        {
            var btnId = "vRadioFill";

            Driver.Click(btnId);

            var image = "StackLayoutTest7_vRadioFill.png";
            //WebElementUtils.GetScreenshotAndSave(Driver, image);
            Assert.AreEqual(true, Driver.CompareToScreenshot(image));
        }

        [Test]
        public void VRadioEndTest()
        {
            var btnId = "vRadioEnd";

            Driver.Click(btnId);

            var image = "StackLayoutTest7_vRadioEnd.png";
            //WebElementUtils.GetScreenshotAndSave(Driver, image);
            Assert.AreEqual(true, Driver.CompareToScreenshot(image));
        }

        [Test]
        public void VRadioStartTest()
        {
            var btnId = "vRadioStart";

            Driver.Click(btnId);

            var image = "StackLayoutTest7_vRadioStart.png";
            //WebElementUtils.GetScreenshotAndSave(Driver, image);
            Assert.AreEqual(true, Driver.CompareToScreenshot(image));
        }

        [Test]
        public void VRadioCenterTest()
        {
            var btnId = "vRadioCenter";

            Driver.Click(btnId);

            var image = "StackLayoutTest7_vRadioCenter.png";
            //WebElementUtils.GetScreenshotAndSave(Driver, image);
            Assert.AreEqual(true, Driver.CompareToScreenshot(image));
        }
    }
}
