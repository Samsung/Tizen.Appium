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
    public class ButtonTests_FontSize_Button_BHBH
    {
        string PlatformName;
        AppiumDriver Driver;

        public ButtonTests_FontSize_Button_BHBH(string platform)
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
        public void FontSizeTest()
        {
            Point smallPt = new Point(652, 528);
            var touch = new RemoteTouchScreenUtils(Driver);
            touch.Down(smallPt.X, smallPt.Y);
            touch.Up(smallPt.X, smallPt.Y);
            string ret = WebElementUtils.GetAttribute(Driver, "_button", "FontSize");
            string expect = "15.2";
            Assert.AreEqual(expect, ret);
        }

        [Test]
        public void FontSizeTest2()
        {
            Point smallPt = new Point(514, 739);
            var touch = new RemoteTouchScreenUtils(Driver);
            touch.Down(smallPt.X, smallPt.Y);
            touch.Up(smallPt.X, smallPt.Y);
            string ret = WebElementUtils.GetAttribute(Driver, "_button", "FontSize");
            string expect = "25.3";
            Assert.AreEqual(expect, ret);
        }

        [Test]
        public void FontSizeTest3()
        {
            Point smallPt = new Point(510, 978);
            var touch = new RemoteTouchScreenUtils(Driver);
            touch.Down(smallPt.X, smallPt.Y);
            touch.Up(smallPt.X, smallPt.Y);
            string ret = WebElementUtils.GetAttribute(Driver, "_button", "FontSize");
            string expect = "45.5";
            Assert.AreEqual(expect, ret);
        }
    }
}
