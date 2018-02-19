using System;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Tizen;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Remote;
using NUnit.Framework;
using OpenQA.Selenium.Appium.MultiTouch;
using OpenQA.Selenium.Interactions.Internal;

namespace Appium.UITests
{
    [TestFixture(FormsTizenGalleryUtils.Platform)]
    public class DisplayAlertTest
    {
        string PlatformName;
        AppiumDriver Driver;

        public DisplayAlertTest(string platform)
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
        public void DisplayAlertOKTest()
        {
            WebElementUtils.Click(Driver, "button");
            var touch = new RemoteTouchScreenUtils(Driver);
            touch.Down(366, 1201);
            touch.Up(366, 1201);
        }

        [Test]
        public void DisplayAlertCancelTest()
        {
            WebElementUtils.Click(Driver, "button2");
            var touch = new RemoteTouchScreenUtils(Driver);
            touch.Down(217, 1184);
            touch.Up(217, 1184);
        }
    }
}
