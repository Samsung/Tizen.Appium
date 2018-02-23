using System;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Tizen;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Remote;
using NUnit.Framework;
using System.Drawing;

namespace Xamarin.Issues.UITests
{
    [TestFixture(TestScriptUtils.Platform)]
    public class ButtonTests_Font_Button_BHBH
    {
        string PlatformName;
        AppiumDriver Driver;

        public ButtonTests_Font_Button_BHBH(string platform)
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
        public void FontSmallTest()
        {
            Point smallPt = new Point(652, 528);
            var touch = new RemoteTouchScreenUtils(Driver);
            touch.Down(smallPt.X, smallPt.Y);
            touch.Up(smallPt.X, smallPt.Y);
            string ret = WebElementUtils.GetAttribute(Driver, "_button", "Font");
            string expect = "FontFamily: , FontSize: 0, NamedSize: Small, FontAttributes: None";
            Assert.AreEqual(expect, ret);
        }

        [Test]
        public void FontMediumTest()
        {
            Point smallPt = new Point(514, 739);
            var touch = new RemoteTouchScreenUtils(Driver);
            touch.Down(smallPt.X, smallPt.Y);
            touch.Up(smallPt.X, smallPt.Y);
            string ret = WebElementUtils.GetAttribute(Driver, "_button", "Font");
            string expect = "FontFamily: , FontSize: 0, NamedSize: Medium, FontAttributes: None";
            Assert.AreEqual(expect, ret);
        }

        [Test]
        public void FontLargeTest()
        {
            Point smallPt = new Point(510, 978);
            var touch = new RemoteTouchScreenUtils(Driver);
            touch.Down(smallPt.X, smallPt.Y);
            touch.Up(smallPt.X, smallPt.Y);
            string ret = WebElementUtils.GetAttribute(Driver, "_button", "Font");
            string expect = "FontFamily: , FontSize: 0, NamedSize: Large, FontAttributes: None";
            Assert.AreEqual(expect, ret);
        }
    }
}
