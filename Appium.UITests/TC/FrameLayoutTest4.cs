using System;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Tizen;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Remote;
using NUnit.Framework;
using OpenQA.Selenium.Appium.MultiTouch;
using OpenQA.Selenium.Interactions.Internal;
using System.Drawing;

namespace Appium.UITests
{
    [TestFixture(FormsTizenGalleryUtils.Platform)]
    public class FrameLayoutTest4
    {
        string PlatformName;
        AppiumDriver Driver;

        public FrameLayoutTest4(string platform)
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
            var paddingSliderId = "sliderPadding";
            var marginSliderId = "sliderMargin";

            WebElementUtils.SetAttribute(Driver, paddingSliderId, "Value", 100);
            WebElementUtils.SetAttribute(Driver, marginSliderId, "Value", 100);

            //screenshot
        }
    }
}
