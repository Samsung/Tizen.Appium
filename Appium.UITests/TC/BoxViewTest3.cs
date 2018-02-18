using System;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Tizen;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Remote;
using NUnit.Framework;
using System.Drawing;

namespace Appium.UITests
{
    [TestFixture(FormsTizenGalleryUtils.Platform)]
    public class BoxViewTest3
    {
        string PlatformName;
        AppiumDriver Driver;

        public BoxViewTest3(string platform)
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
        public void ColorTest1()
        {
            string ret = WebElementUtils.GetAttribute(Driver, "colorBox", "Color");
            var touch = new RemoteTouchScreenUtils(Driver);
            touch.Down(647, 512);
            touch.Up(647, 512);
            string ret2 = WebElementUtils.GetAttribute(Driver, "colorBox", "Color");
        }

        [Test]
        public void ColorTest2()
        {
            string ret = WebElementUtils.GetAttribute(Driver, "preColorBox", "Color");
            var touch = new RemoteTouchScreenUtils(Driver);
            touch.Down(662, 748);
            touch.Up(662, 748);
            string ret2 = WebElementUtils.GetAttribute(Driver, "preColorBox", "Color");
        }

        [Test]
        public void ColorTest3()
        {
            string ret = WebElementUtils.GetAttribute(Driver, "colorBox", "Color");
            var touch = new RemoteTouchScreenUtils(Driver);
            touch.Down(119, 628);
            touch.Up(119, 628);
            string ret2 = WebElementUtils.GetAttribute(Driver, "colorBox", "Color");
        }

        [Test]
        public void ColorTest4()
        {
            string ret = WebElementUtils.GetAttribute(Driver, "preColorBox", "Color");
            var touch = new RemoteTouchScreenUtils(Driver);
            touch.Down(101, 847);
            touch.Up(101, 847);
            string ret2 = WebElementUtils.GetAttribute(Driver, "preColorBox", "Color");
        }
    }
}
