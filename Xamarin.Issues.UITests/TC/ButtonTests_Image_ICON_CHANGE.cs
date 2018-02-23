using System;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Tizen;
using OpenQA.Selenium.Appium.Android;
using NUnit.Framework;
using System.Drawing;

namespace Xamarin.Issues.UITests
{
    [TestFixture(TestScriptUtils.Platform)]
    public class ButtonTests_Image_ICON_CHANGE
    {
        string PlatformName;
        AppiumDriver Driver;

        public ButtonTests_Image_ICON_CHANGE(string platform)
        {
            PlatformName = platform;
        }

        [TestFixtureSetUp]
        public void Setup()
        {
            Driver = new AppiumDriver(PlatformName);
            TestScriptUtils.FindTC(Driver, this.GetType().Name);
        }

        [TestFixtureTearDown]
        public void TearDown()
        {
            Driver.Quit();
        }

        [Test]
        public void ButtonIconTest()
        {
            Point smallPt = new Point(163, 968);
            var touch = new RemoteTouchScreenUtils(Driver);
            touch.Down(smallPt.X, smallPt.Y);
            touch.Up(smallPt.X, smallPt.Y);
            string ret = WebElementUtils.GetAttribute(Driver, "_button", "Image");
            string expect = "File: icon/settings_sound.png";
            Assert.AreEqual(expect, ret);
        }

        [Test]
        public void ButtonIconTest2()
        {
            Point smallPt = new Point(325, 978);
            var touch = new RemoteTouchScreenUtils(Driver);
            touch.Down(smallPt.X, smallPt.Y);
            touch.Up(smallPt.X, smallPt.Y);
            string ret = WebElementUtils.GetAttribute(Driver, "_button", "Image");
            string expect = "File: icon/settings_storage.png";
            Assert.AreEqual(expect, ret);
        }

        [Test]
        public void ButtonIconTest3()
        {
            Point smallPt = new Point(576, 998778);
            var touch = new RemoteTouchScreenUtils(Driver);
            touch.Down(smallPt.X, smallPt.Y);
            touch.Up(smallPt.X, smallPt.Y);
            string ret = WebElementUtils.GetAttribute(Driver, "_button", "Image");
            string expect = "File: icon/settings_storage.png";
            Assert.AreEqual(expect, ret);
        }
    }
}
