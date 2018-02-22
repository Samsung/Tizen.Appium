using System;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Tizen;
using OpenQA.Selenium.Appium.Android;
using NUnit.Framework;
using System.Drawing;

namespace Xamarin.Issues.UITests
{
    [TestFixture(TestScriptUtils.Platform)]
    public class DatePickerTest_MaximumDate_UIBH
    {
        string PlatformName;
        AppiumDriver Driver;

        public DatePickerTest_MaximumDate_UIBH(string platform)
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

            string expect = "3/10/18 12:00:00 AM";
            string ret = WebElementUtils.GetAttribute(Driver, "DatePicker", "MaximumDate");
            Assert.AreEqual(expect, ret);
        }
    }
}
