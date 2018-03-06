using System;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Tizen;
using OpenQA.Selenium.Appium.Android;
using NUnit.Framework;
using System.Drawing;

namespace Xamarin.Issues.UITests
{
    [TestFixture(TestScriptUtils.Platform)]
    public class TimePickerTests_TimePicker_TextColor_UILK
    {
        string PlatformName;
        AppiumDriver Driver;

        public TimePickerTests_TimePicker_TextColor_UILK(string platform)
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
        public void TextColorTest()
        {
            string expect = "[Color: A=1, R=1, G=0, B=0, Hue=1, Saturation=1, Luminosity=0.5]";
            string ret = WebElementUtils.GetAttribute(Driver, "_timePicker1", "TextColor");
            Assert.AreEqual(expect, ret);
        }
    }
}
