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

            var toggledBefore = Convert.ToBoolean(WebElementUtils.GetAttribute(Driver, switchId, "IsToggled"));

            WebElementUtils.Click(Driver, switchId);

            var toggledAfter = Convert.ToBoolean(WebElementUtils.GetAttribute(Driver, switchId, "IsToggled"));

            Assert.True((toggledBefore != toggledAfter), "IsToggled should be changed, but got before: " + toggledBefore + ", after: " + toggledAfter);
            //screenshot

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

            //screenshot
        }

        [Test]
        public void CenterTest()
        {
            var btnId = "center";

            WebElementUtils.Click(Driver, btnId);

            //screenshot
        }

        [Test]
        public void EndTest()
        {
            var btnId = "end";

            WebElementUtils.Click(Driver, btnId);

            //screenshot
        }

        [Test]
        public void StartAndExpandTest()
        {
            var btnId = "startAndExpand";

            WebElementUtils.Click(Driver, btnId);

            //screenshot
        }

        [Test]
        public void CenterAndExpandTest()
        {
            var btnId = "centerAndExpand";

            WebElementUtils.Click(Driver, btnId);

            //screenshot
        }

        [Test]
        public void EndAndExpandTest()
        {
            var btnId = "endAndExpand";

            WebElementUtils.Click(Driver, btnId);

            //screenshot
        }

        [Test]
        public void FillAndExpandTest()
        {
            var btnId = "fillAndExpand";

            WebElementUtils.Click(Driver, btnId);

            //screenshot
        }
    }
}
