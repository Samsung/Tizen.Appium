using System;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Tizen;
using OpenQA.Selenium.Appium.Android;
using NUnit.Framework;
using System.Drawing;

namespace Xamarin.Issues.UITests
{
    [TestFixture(TestScriptUtils.Platform)]
    public class SearchBarTests_HorizontalTextAlignment_SearchBar_UIBH
    {
        string PlatformName;
        AppiumDriver Driver;

        public SearchBarTests_HorizontalTextAlignment_SearchBar_UIBH(string platform)
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
        public void HorizontalTextAlignmentTest()
        {
            WebElementUtils.SetText(Driver, "srBar", "ABCDEFG");

            string ret = WebElementUtils.GetAttribute(Driver, "srBar", "HorizontalTextAlignment");
            Point pt = new Point(510, 425);
            RemoteTouchScreenUtils.Click(Driver, pt);
            string ret2 = WebElementUtils.GetAttribute(Driver, "srBar", "HorizontalTextAlignment");
            Assert.AreNotEqual(ret, ret2);
        }
    }
}
