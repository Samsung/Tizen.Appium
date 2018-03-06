using System;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Tizen;
using OpenQA.Selenium.Appium.Android;
using NUnit.Framework;
using System.Drawing;

namespace Xamarin.Issues.UITests
{
    [TestFixture(TestScriptUtils.Platform)]
    public class TimePickerTests_Height_TimePicker_CHANGE_SIZE
    {
        string PlatformName;
        AppiumDriver Driver;

        public TimePickerTests_Height_TimePicker_CHANGE_SIZE(string platform)
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
        public void BackgroundColorTest()
        {
            string ret = WebElementUtils.GetAttribute(Driver, "_timePicker4", "Height");

            var pt = new Point(521, 796);
            RemoteTouchScreenUtils.Click(Driver, pt);

            string ret2 = WebElementUtils.GetAttribute(Driver, "_timePicker4", "Height");
            Assert.AreNotEqual(ret, ret2);
        }
    }
}
