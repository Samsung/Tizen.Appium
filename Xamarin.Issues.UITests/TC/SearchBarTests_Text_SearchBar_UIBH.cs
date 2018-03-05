using System;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Tizen;
using OpenQA.Selenium.Appium.Android;
using NUnit.Framework;
using System.Drawing;

namespace Xamarin.Issues.UITests
{
    [TestFixture(TestScriptUtils.Platform)]
    public class SearchBarTests_Text_SearchBar_UIBH
    {
        string PlatformName;
        AppiumDriver Driver;

        public SearchBarTests_Text_SearchBar_UIBH(string platform)
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
        public void SearchBarTextTest()
        {
            string expect = "ABCDEFG";
            WebElementUtils.SetText(Driver, "srBar", expect);
            string ret = WebElementUtils.GetAttribute(Driver, "srBar", "Text");
            Assert.AreEqual(expect, ret);
        }
    }
}
