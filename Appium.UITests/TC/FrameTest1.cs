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
    public class FrameTest1
    {
        string PlatformName;
        AppiumDriver Driver;

        public FrameTest1(string platform)
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
        public void HasShowdowTest()
        {
            WebElementUtils.Click(Driver, "btnHasShadow");
            string result = WebElementUtils.GetAttribute(Driver, "_frame", "HasShadow");
            Assert.AreEqual("True", result);
        }

        [Test]
        public void HasNoShowdowTest()
        {
            WebElementUtils.Click(Driver, "btnHasNoShadow");
            string result = WebElementUtils.GetAttribute(Driver, "_frame", "HasShadow");
            Assert.AreEqual("False", result);
        }
    }
}
