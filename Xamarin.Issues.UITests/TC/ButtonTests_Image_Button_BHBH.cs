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
    public class ButtonTests_Image_Button_BHBH
    {
        string PlatformName;
        AppiumDriver Driver;

        public ButtonTests_Image_Button_BHBH(string platform)
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
        public void ButtonImageTest()
        {
            Point smallPt = new Point(652, 528);
            var touch = new RemoteTouchScreenUtils(Driver);
            touch.Down(smallPt.X, smallPt.Y);
            touch.Up(smallPt.X, smallPt.Y);
            string ret = WebElementUtils.GetAttribute(Driver, "_button", "Image");
            string expect = "File: TED/thumbnail/a.jpg";
            Assert.AreEqual(expect, ret);
        }

        [Test]
        public void ButtonImageTest2()
        {
            Point smallPt = new Point(514, 739);
            var touch = new RemoteTouchScreenUtils(Driver);
            touch.Down(smallPt.X, smallPt.Y);
            touch.Up(smallPt.X, smallPt.Y);
            string ret = WebElementUtils.GetAttribute(Driver, "_button", "Image");
            string expect = "File: TED/thumbnail/b.jpg";
            Assert.AreEqual(expect, ret);
        }

        [Test]
        public void ButtonImageTest3()
        {
            Point smallPt = new Point(510, 978);
            var touch = new RemoteTouchScreenUtils(Driver);
            touch.Down(smallPt.X, smallPt.Y);
            touch.Up(smallPt.X, smallPt.Y);
            string ret = WebElementUtils.GetAttribute(Driver, "_button", "Image");
            string expect = "File: TED/thumbnail/c.jpg";
            Assert.AreEqual(expect, ret);
        }
    }
}
