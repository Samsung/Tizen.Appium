using System;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Tizen;
using OpenQA.Selenium.Appium.Android;
using NUnit.Framework;
using System.Drawing;

namespace Xamarin.Issues.UITests
{
    [TestFixture(TestScriptUtils.Platform)]
    public class SearchBarTests_CancelButtonColor_SearchBar_UIBH
    {
        string PlatformName;
        AppiumDriver Driver;

        public SearchBarTests_CancelButtonColor_SearchBar_UIBH(string platform)
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
        public void CancelButtonColorTest()
        {
            WebElementUtils.SetText(Driver, "srBar", "ABCDEFG");

            string ret = WebElementUtils.GetAttribute(Driver, "srBar", "CancelButtonColor");
            Point pt = new Point(510, 425);
            RemoteTouchScreenUtils.Click(Driver, pt);
            string ret2 = WebElementUtils.GetAttribute(Driver, "srBar", "CancelButtonColor");
            Assert.AreNotEqual(ret, ret2);
        }
    }
}
