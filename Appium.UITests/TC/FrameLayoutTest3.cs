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
    [TestFixture("Tizen")]
    public class FrameLayoutTest3
    {
        string PlatformName;
        AppiumDriver Driver;

        public FrameLayoutTest3(string platform)
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
        public void ActivateButtonTest()
        {
            Point before = WebElementUtils.GetLocation(Driver, "button1");
            var touch = new RemoteTouchScreenUtils(Driver);
            touch.Down(408, 250);
            touch.Up(408, 250);
            Point after = WebElementUtils.GetLocation(Driver, "button1");
            Assert.AreNotEqual(before, after);

            touch.Down(156, 250);
            touch.Up(156, 250);
            Point after2 = WebElementUtils.GetLocation(Driver, "button1");
            Assert.AreNotEqual(after, after2);
        }

        [Test]
        public void InactivateButtonTest()
        {
            WebElementUtils.Click(Driver, "button2");

            Point before = WebElementUtils.GetLocation(Driver, "button2");
            var touch = new RemoteTouchScreenUtils(Driver);
            touch.Down(408, 250);
            touch.Up(408, 250);
            Point after = WebElementUtils.GetLocation(Driver, "button2");
            Assert.AreNotEqual(before, after);

            touch.Down(156, 250);
            touch.Up(156, 250);
            Point after2 = WebElementUtils.GetLocation(Driver, "button2");
            Assert.AreNotEqual(after, after2);
        }
    }
}
