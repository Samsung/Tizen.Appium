using System;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Tizen;
using OpenQA.Selenium.Appium.Android;
using NUnit.Framework;
using System.Drawing;

namespace Xamarin.Issues.UITests
{
    [TestFixture(TestScriptUtils.Platform)]
    public class ScrollViewTests_LayoutChildren_INVOKED_CHECK
    {
        string PlatformName;
        AppiumDriver Driver;

        public ScrollViewTests_LayoutChildren_INVOKED_CHECK(string platform)
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
        public void LayoutChildrenTest()
        {
            System.Threading.Thread.Sleep(4000);
            string ret = WebElementUtils.GetText(Driver, "newLabel");
            string expect = "New Label";
            Assert.AreEqual(expect, ret);
        }
    }
}
