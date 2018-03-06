using System;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Tizen;
using OpenQA.Selenium.Appium.Android;
using NUnit.Framework;
using System.Drawing;

namespace Xamarin.Issues.UITests
{
    [TestFixture(TestScriptUtils.Platform)]
    public class SearchBarTests_SearchButtonPressed_CHECK
    {
        string PlatformName;
        AppiumDriver Driver;

        public SearchBarTests_SearchButtonPressed_CHECK(string platform)
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
        public void SearchButtonPressedTest()
        {
            WebElementUtils.SetText(Driver, "srBar", "ABCDEFG");
        }
    }
}
