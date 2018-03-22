using System;
using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture(FormsTizenGalleryUtils.Platform)]
    public class SwitchTest1
    {
        string PlatformName;
        AppiumDriver Driver;

        public SwitchTest1(string platform)
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
        public void ToggleTest()
        {
            var switchId = "switch";

            var toggledBefore = WebElementUtils.GetAttribute<bool>(Driver, switchId, "IsToggled");

            WebElementUtils.Click(Driver, switchId);

            var toggledAfter = WebElementUtils.GetAttribute<bool>(Driver, switchId, "IsToggled");

            Assert.True((toggledBefore != toggledAfter), "IsToggled should be changed, but got before: " + toggledBefore + ", after: " + toggledAfter);

            var image = "SwitchTest1_switch.png";
            //WebElementUtils.GetScreenshotAndSave(Driver, image);
            Assert.AreEqual(true, WebElementUtils.CompareToScreenshot(Driver, image));

            //reset
            if (toggledBefore != toggledAfter)
            {
                WebElementUtils.Click(Driver, switchId);
            }
        }

        [Test]
        public void StartTest()
        {
            var btnId = "start";

            WebElementUtils.Click(Driver, btnId);

            var image = "SwitchTest1_start.png";
            //WebElementUtils.GetScreenshotAndSave(Driver, image);
            Assert.AreEqual(true, WebElementUtils.CompareToScreenshot(Driver, image));
        }

        [Test]
        public void CenterTest()
        {
            var btnId = "center";

            WebElementUtils.Click(Driver, btnId);

            var image = "SwitchTest1_center.png";
            //WebElementUtils.GetScreenshotAndSave(Driver, image);
            Assert.AreEqual(true, WebElementUtils.CompareToScreenshot(Driver, image));
        }

        [Test]
        public void EndTest()
        {
            var btnId = "end";

            WebElementUtils.Click(Driver, btnId);

            var image = "SwitchTest1_end.png";
            //WebElementUtils.GetScreenshotAndSave(Driver, image);
            Assert.AreEqual(true, WebElementUtils.CompareToScreenshot(Driver, image));
        }

        [Test]
        public void StartAndExpandTest()
        {
            var btnId = "startAndExpand";

            WebElementUtils.Click(Driver, btnId);

            var image = "SwitchTest1_startAndExpand.png";
            //WebElementUtils.GetScreenshotAndSave(Driver, image);
            Assert.AreEqual(true, WebElementUtils.CompareToScreenshot(Driver, image));
        }

        [Test]
        public void CenterAndExpandTest()
        {
            var btnId = "centerAndExpand";

            WebElementUtils.Click(Driver, btnId);

            var image = "SwitchTest1_centerAndExpand.png";
            //WebElementUtils.GetScreenshotAndSave(Driver, image);
            Assert.AreEqual(true, WebElementUtils.CompareToScreenshot(Driver, image));
        }

        [Test]
        public void EndAndExpandTest()
        {
            var btnId = "endAndExpand";

            WebElementUtils.Click(Driver, btnId);

            var image = "SwitchTest1_endAndExpand.png";
            //WebElementUtils.GetScreenshotAndSave(Driver, image);
            Assert.AreEqual(true, WebElementUtils.CompareToScreenshot(Driver, image));
        }

        [Test]
        public void FillAndExpandTest()
        {
            var btnId = "fillAndExpand";

            WebElementUtils.Click(Driver, btnId);

            var image = "SwitchTest1_fillAndExpand.png";
            //WebElementUtils.GetScreenshotAndSave(Driver, image);
            Assert.AreEqual(true, WebElementUtils.CompareToScreenshot(Driver, image));
        }
    }
}
