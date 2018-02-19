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
    public class CarouselPageTest1
    {
        string PlatformName;
        AppiumDriver Driver;

        public CarouselPageTest1(string platform)
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
        public void CurrentPageTest()
        {
            RemoteTouchScreenUtils touch = new RemoteTouchScreenUtils(Driver);
            touch.Flick(-10, 0);
            touch.Flick(-10, 0);
            touch.Flick(-10, 0);

            string ret = WebElementUtils.GetAttribute(Driver, "BlueLabel", "Text");
            Assert.AreEqual("Blue", ret);
        }
    }
}
