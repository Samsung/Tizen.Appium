using System;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Tizen;
using OpenQA.Selenium.Appium.Android;
using NUnit.Framework;
using System.Drawing;

namespace Xamarin.Issues.UITests
{
    [TestFixture(TestScriptUtils.Platform)]
    public class SearchBarTests_PlaceHolder_SearchBar_UIBH
    {
        string PlatformName;
        AppiumDriver Driver;

        public SearchBarTests_PlaceHolder_SearchBar_UIBH(string platform)
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
        public void PlaceHolderTest()
        {
            WebElementUtils.SetText(Driver, "srBar", "ABCDEFG");
            string expect = "Placeholder Text";
            string ret = WebElementUtils.GetAttribute(Driver, "srBar", "Placeholder");
            Assert.AreEqual(expect, ret);
        }
    }
}
