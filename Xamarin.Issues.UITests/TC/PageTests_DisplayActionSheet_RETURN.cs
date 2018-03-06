using System;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Tizen;
using OpenQA.Selenium.Appium.Android;
using NUnit.Framework;
using System.Drawing;

namespace Xamarin.Issues.UITests
{
    [TestFixture(TestScriptUtils.Platform)]
    public class PageTests_DisplayActionSheet_RETURN
    {
        string PlatformName;
        AppiumDriver Driver;

        public PageTests_DisplayActionSheet_RETURN(string platform)
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
        public void DisplayActionSheetTest()
        {
            // BackButton clicked
            WebElementUtils.Click(Driver, "pushBtn");

            Point pt = new Point(420, 1012);
            var touch = new RemoteTouchScreenUtils(Driver);
            touch.Down(pt.X, pt.Y);
            touch.Up(pt.X, pt.Y);

            string ret = WebElementUtils.GetText(Driver, "pushBtn");

            string expect = "Btn1";
            Assert.AreEqual(expect, ret);
        }
    }
}
