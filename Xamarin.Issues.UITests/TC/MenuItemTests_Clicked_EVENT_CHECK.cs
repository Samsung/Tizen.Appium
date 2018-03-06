using System;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Tizen;
using OpenQA.Selenium.Appium.Android;
using NUnit.Framework;
using System.Drawing;

namespace Xamarin.Issues.UITests
{
    [TestFixture(TestScriptUtils.Platform)]
    public class MenuItemTests_Clicked_EVENT_CHECK
    {
        string PlatformName;
        AppiumDriver Driver;

        public MenuItemTests_Clicked_EVENT_CHECK(string platform)
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
        public void ToolbarItemClickedTest()
        {
            WebElementUtils.Click(Driver, "pushBtn");

            Point pt = new Point(663, 99);
            var touch = new RemoteTouchScreenUtils(Driver);
            touch.Down(pt.X, pt.Y);
            touch.Up(pt.X, pt.Y);

            string ret = WebElementUtils.GetText(Driver, "label");

            string expect = "Back to test page";
            Assert.AreEqual(expect, ret);
        }
    }
}
