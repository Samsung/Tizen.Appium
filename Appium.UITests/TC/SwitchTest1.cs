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
            Driver.CheckScreenshot(image);

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
            Driver.CheckScreenshot(image);
        }

        [Test]
        public void CenterTest()
        {
            var btnId = "center";

            Driver.Click(btnId);

            var image = "SwitchTest1_center.png";
            Driver.CheckScreenshot(image);
        }

        [Test]
        public void EndTest()
        {
            var btnId = "end";

            Driver.Click(btnId);

            var image = "SwitchTest1_end.png";
            Driver.CheckScreenshot(image);
        }

        [Test]
        public void StartAndExpandTest()
        {
            var btnId = "startAndExpand";

            Driver.Click(btnId);

            var image = "SwitchTest1_startAndExpand.png";
            Driver.CheckScreenshot(image);
        }

        [Test]
        public void CenterAndExpandTest()
        {
            var btnId = "centerAndExpand";

            Driver.Click(btnId);

            var image = "SwitchTest1_centerAndExpand.png";
            Driver.CheckScreenshot(image);
        }

        [Test]
        public void EndAndExpandTest()
        {
            var btnId = "endAndExpand";

            Driver.Click(btnId);

            var image = "SwitchTest1_endAndExpand.png";
            Driver.CheckScreenshot(image);
        }

        [Test]
        public void FillAndExpandTest()
        {
            var btnId = "fillAndExpand";

            Driver.Click(btnId);

            var image = "SwitchTest1_fillAndExpand.png";
            Driver.CheckScreenshot(image);
        }
    }
}
