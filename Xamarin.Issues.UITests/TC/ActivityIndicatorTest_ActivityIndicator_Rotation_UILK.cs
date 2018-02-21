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
    public class ButtonTests_BackgroundColor_COLOR_CHANGE
    {
        string PlatformName;
        AppiumDriver Driver;

        public ButtonTests_BackgroundColor_COLOR_CHANGE(string platform)
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
        public void RedBackgroudColorTest()
        {
            string ret = WebElementUtils.GetAttribute(Driver, "_button", "BackgroundColor");
            WebElementUtils.Click(Driver, "RED");
            string ret2 = WebElementUtils.GetAttribute(Driver, "_button", "BackgroundColor");
            Assert.AreNotEqual(ret, ret2);
        }

        [Test]
        public void GreenBackgroudColorTest()
        {
            string ret = WebElementUtils.GetAttribute(Driver, "_button", "BackgroundColor");
            WebElementUtils.Click(Driver, "GREEN");
            string ret2 = WebElementUtils.GetAttribute(Driver, "_button", "BackgroundColor");
            Assert.AreNotEqual(ret, ret2);
        }

        [Test]
        public void GrayBackgroudColorTest()
        {
            string ret = WebElementUtils.GetAttribute(Driver, "_button", "BackgroundColor");
            WebElementUtils.Click(Driver, "GRAY");
            string ret2 = WebElementUtils.GetAttribute(Driver, "_button", "BackgroundColor");
            Assert.AreNotEqual(ret, ret2);
        }
    }
}
