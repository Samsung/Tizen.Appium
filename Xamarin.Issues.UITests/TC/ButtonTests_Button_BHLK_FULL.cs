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
    public class ButtonTests_Button_BHLK_FULL
    {
        string PlatformName;
        AppiumDriver Driver;

        public ButtonTests_Button_BHLK_FULL(string platform)
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
        public void ClickTest()
        {
            WebElementUtils.Click(Driver, "mButton1");
            string ret = WebElementUtils.GetAttribute(Driver, "mButton1", "Text");
            Assert.AreEqual("Clicked", ret);
        }

        [Test]
        public void IsEnabledTest()
        {
            string ret = WebElementUtils.GetAttribute(Driver, "mButton22", "IsEnabled");
            Assert.AreEqual("False", ret);
        }

        [Test]
        public void ButtonImageTest()
        {
            string expect = "File: icon/settings_restart.png";
            string ret = WebElementUtils.GetAttribute(Driver, "mButton31", "Image");
            Assert.AreEqual(expect, ret);
        }

        [Test]
        public void ButtonPaddingTest()
        {
            Point pt = WebElementUtils.GetLocation(Driver, "mButton41");
            Point pt2 = WebElementUtils.GetLocation(Driver, "mButton42");
            Assert.Greater(pt2.Y, pt.Y);
        }
    }
}
