using System;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Tizen;
using OpenQA.Selenium.Appium.Android;
using NUnit.Framework;
using System.Drawing;

namespace Xamarin.Issues.UITests
{
    [TestFixture(TestScriptUtils.Platform)]
    public class TimePickerTests_TimePicker_Time_UILK
    {
        string PlatformName;
        AppiumDriver Driver;

        public TimePickerTests_TimePicker_Time_UILK(string platform)
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
        public void TimeTest()
        {
            string expect = "18:00:00";
            string ret = WebElementUtils.GetAttribute(Driver, "_timePicker1", "Time");
            Assert.AreEqual(expect, ret);
        }
    }
}
