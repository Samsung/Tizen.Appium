using System;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Tizen;
using OpenQA.Selenium.Appium.Android;
using NUnit.Framework;
using System.Drawing;

namespace Xamarin.Issues.UITests
{
    [TestFixture(TestScriptUtils.Platform)]
    public class ButtonTests_TextColor_Button_BHBH
    {
        string PlatformName;
        AppiumDriver Driver;

        public ButtonTests_TextColor_Button_BHBH(string platform)
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
        public void TextColorRedTest()
        {
            Point smallPt = new Point(652, 528);
            var touch = new RemoteTouchScreenUtils(Driver);
            touch.Down(smallPt.X, smallPt.Y);
            touch.Up(smallPt.X, smallPt.Y);
            string ret = WebElementUtils.GetAttribute(Driver, "_button", "TextColor");
            string expect = "[Color: A=1, R=1, G=0, B=0, Hue=1, Saturation=1, Luminosity=0.5]";
            Assert.AreEqual(expect, ret);
        }

        [Test]
        public void TextColorGreenTest()
        {
            Point smallPt = new Point(514, 739);
            var touch = new RemoteTouchScreenUtils(Driver);
            touch.Down(smallPt.X, smallPt.Y);
            touch.Up(smallPt.X, smallPt.Y);
            string ret = WebElementUtils.GetAttribute(Driver, "_button", "TextColor");
            string expect = "[Color: A=1, R=0, G=0.501960813999176, B=0, Hue=0.333333343267441, Saturation=1, Luminosity=0.250980406999588]";
            Assert.AreEqual(expect, ret);
        }

        [Test]
        public void TextColorYellowTest()
        {
            Point smallPt = new Point(510, 978);
            var touch = new RemoteTouchScreenUtils(Driver);
            touch.Down(smallPt.X, smallPt.Y);
            touch.Up(smallPt.X, smallPt.Y);
            string ret = WebElementUtils.GetAttribute(Driver, "_button", "TextColor");
            string expect = "[Color: A=1, R=1, G=1, B=0, Hue=0.16666667163372, Saturation=1, Luminosity=0.5]";
            Assert.AreEqual(expect, ret);
        }

    }
}
