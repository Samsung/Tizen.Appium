using System;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Tizen;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Remote;
using NUnit.Framework;
using OpenQA.Selenium.Appium.MultiTouch;
using OpenQA.Selenium.Interactions.Internal;

namespace Appium.UITests
{
    //[TestFixture("Android")]
    [TestFixture("Tizen")]
    public class DatePickerTest
    {
        string PlatformName;
        AppiumDriver Driver;
        RemoteTouchScreenUtils touchScreen;

        public DatePickerTest(string platform)
        {
            PlatformName = platform;
        }

        [TestFixtureSetUp]
        public void Setup()
        {
            Driver = new AppiumDriver(PlatformName);

            touchScreen = new RemoteTouchScreenUtils(Driver);
            touchScreen.Flick(0, -3);

            string testId = string.Empty;
            while (testId == string.Empty) {
                touchScreen.Flick(0, -3);
                testId = WebElementUtils.GetAttribute(Driver, "Content", this.GetType().Name);
            }
            WebElementUtils.Click(Driver, testId);
        }

        [TestFixtureTearDown]
        public void TearDown()
        {
            Driver.Quit();
        }

        [Test]
        public void DateTest()
        {
            string before = WebElementUtils.GetAttribute(Driver, "datePicker", "Date");

            // Click DatePicker
            touchScreen.Down(369, 267);
            touchScreen.Up(369, 267);

            // Change month
            touchScreen.Down(361, 811);
            touchScreen.Up(361, 811);

            // click "Set" button
            touchScreen.Down(549, 1224);
            touchScreen.Up(549, 1224);

            string after = WebElementUtils.GetAttribute(Driver, "datePicker", "Date");
            Assert.AreNotEqual(before, after);
        }

        [Test]
        public void SetDateTest()
        {
            string before = WebElementUtils.GetAttribute(Driver, "datePicker", "Date");

            // Click DatePicker
            touchScreen.Down(369, 267);
            touchScreen.Up(369, 267);

            // Change month
            touchScreen.Down(361, 811);
            touchScreen.Up(361, 811);

            // click "Set" button
            touchScreen.Down(549, 1224);
            touchScreen.Up(549, 1224);

            WebElementUtils.Click(Driver, "button");

            string after = WebElementUtils.GetAttribute(Driver, "datePicker", "Date");
            Assert.AreNotEqual(before, after);
        }
    }
}
