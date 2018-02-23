using System;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Tizen;
using OpenQA.Selenium.Appium.Android;
using NUnit.Framework;
using System.Drawing;

namespace Xamarin.Issues.UITests
{
    [TestFixture(TestScriptUtils.Platform)]
    public class EntryCellTests_Keyboard_UILK
    {
        string PlatformName;
        AppiumDriver Driver;

        public EntryCellTests_Keyboard_UILK(string platform)
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
        public void EntryCellEnableTest()
        {
            WebElementUtils.Click(Driver, "btnKeyBorChat");
        }

        [Test]
        public void EntryCellDisenableTest()
        {
            WebElementUtils.Click(Driver, "btnNumeric");
        }
    }
}
