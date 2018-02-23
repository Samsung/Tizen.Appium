using System;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Tizen;
using OpenQA.Selenium.Appium.Android;
using NUnit.Framework;
using System.Drawing;

namespace Xamarin.Issues.UITests
{
    [TestFixture(TestScriptUtils.Platform)]
    public class DatePickerTest_TextColor_UILK
    {
        string PlatformName;
        AppiumDriver Driver;

        public DatePickerTest_TextColor_UILK(string platform)
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
        public void DatePickerTest()
        {
            Point datePickerPt = new Point(401, 721);
            Point setPt = new Point(568, 1218);

            var touch = new RemoteTouchScreenUtils(Driver);
            touch.Down(datePickerPt.X, datePickerPt.Y);
            touch.Up(datePickerPt.X, datePickerPt.Y);

            touch.Down(setPt.X, setPt.Y);
            touch.Up(setPt.X, setPt.Y);

            string expect = "[Color: A=1, R=1, G=0, B=0, Hue=1, Saturation=1, Luminosity=0.5]";
            string ret = WebElementUtils.GetAttribute(Driver, "DatePicker", "TextColor");
            Assert.AreEqual(expect, ret);
        }
    }
}
