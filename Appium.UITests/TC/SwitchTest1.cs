using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture]
    public class SwitchTest1 : TestTemplate
    {
        [Test]
        public void ToggleTest()
        {
            var switchId = "switch";

            var toggledBefore = Driver.GetAttribute<bool>(switchId, "IsToggled");

            Driver.Click(switchId);

            var toggledAfter = Driver.GetAttribute<bool>(switchId, "IsToggled");

            Assert.True((toggledBefore != toggledAfter), "IsToggled should be changed, but got before: " + toggledBefore + ", after: " + toggledAfter);

            var image = "SwitchTest1_switch.png";
            //WebElementUtils.GetScreenshotAndSave(Driver, image);
            Assert.AreEqual(true, Driver.CompareToScreenshot(image));

            //reset
            if (toggledBefore != toggledAfter)
            {
                Driver.Click(switchId);
            }
        }

        [Test]
        public void StartTest()
        {
            var btnId = "start";

            Driver.Click(btnId);

            var image = "SwitchTest1_start.png";
            //WebElementUtils.GetScreenshotAndSave(Driver, image);
            Assert.AreEqual(true, Driver.CompareToScreenshot(image));
        }

        [Test]
        public void CenterTest()
        {
            var btnId = "center";

            Driver.Click(btnId);

            var image = "SwitchTest1_center.png";
            //WebElementUtils.GetScreenshotAndSave(Driver, image);
            Assert.AreEqual(true, Driver.CompareToScreenshot(image));
        }

        [Test]
        public void EndTest()
        {
            var btnId = "end";

            Driver.Click(btnId);

            var image = "SwitchTest1_end.png";
            //WebElementUtils.GetScreenshotAndSave(Driver, image);
            Assert.AreEqual(true, Driver.CompareToScreenshot(image));
        }

        [Test]
        public void StartAndExpandTest()
        {
            var btnId = "startAndExpand";

            Driver.Click(btnId);

            var image = "SwitchTest1_startAndExpand.png";
            //WebElementUtils.GetScreenshotAndSave(Driver, image);
            Assert.AreEqual(true, Driver.CompareToScreenshot(image));
        }

        [Test]
        public void CenterAndExpandTest()
        {
            var btnId = "centerAndExpand";

            Driver.Click(btnId);

            var image = "SwitchTest1_centerAndExpand.png";
            //WebElementUtils.GetScreenshotAndSave(Driver, image);
            Assert.AreEqual(true, Driver.CompareToScreenshot(image));
        }

        [Test]
        public void EndAndExpandTest()
        {
            var btnId = "endAndExpand";

            Driver.Click(btnId);

            var image = "SwitchTest1_endAndExpand.png";
            //WebElementUtils.GetScreenshotAndSave(Driver, image);
            Assert.AreEqual(true, Driver.CompareToScreenshot(image));
        }

        [Test]
        public void FillAndExpandTest()
        {
            var btnId = "fillAndExpand";

            Driver.Click(btnId);

            var image = "SwitchTest1_fillAndExpand.png";
            //WebElementUtils.GetScreenshotAndSave(Driver, image);
            Assert.AreEqual(true, Driver.CompareToScreenshot(image));
        }
    }
}
