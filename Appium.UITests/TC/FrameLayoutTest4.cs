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
        public void PaddingTest()
        {
            Point boxOrigin = WebElementUtils.GetLocation(Driver, "box");
            Point box2Origin = WebElementUtils.GetLocation(Driver, "box2");

            var touch = new RemoteTouchScreenUtils(Driver);
            touch.Down(78, 237);
            touch.Up(78, 237);
            touch.Down(245, 237);
            touch.Up(245, 237);
            touch.Down(504, 237);
            touch.Up(504, 237);

            Point boxAfter = WebElementUtils.GetLocation(Driver, "box");
            Point box2After = WebElementUtils.GetLocation(Driver, "box2");

            Assert.AreNotEqual(boxOrigin, boxAfter);
            Assert.AreNotEqual(box2Origin, box2After);
        }

        [Test]
        public void MarginTest()
        {
            Size boxOrigin = WebElementUtils.GetSize(Driver, "box");
            Size box2Origin = WebElementUtils.GetSize(Driver, "box2");

            var touch = new RemoteTouchScreenUtils(Driver);
            touch.Down(51, 344);
            touch.Up(51, 344);
            touch.Down(88, 344);
            touch.Up(88, 344);
            touch.Down(142, 344);
            touch.Up(142, 344);

            Size boxAfter = WebElementUtils.GetSize(Driver, "box");
            Size box2After = WebElementUtils.GetSize(Driver, "box2");

            Assert.AreNotEqual(boxOrigin, boxAfter);
            Assert.AreNotEqual(box2Origin, box2After);
        }
    }
}
