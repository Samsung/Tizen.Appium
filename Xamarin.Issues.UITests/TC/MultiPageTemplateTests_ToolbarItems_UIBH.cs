using System;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Tizen;
using OpenQA.Selenium.Appium.Android;
using NUnit.Framework;
using System.Drawing;

namespace Xamarin.Issues.UITests
{
    [TestFixture(TestScriptUtils.Platform)]
    public class MultiPageTemplateTests_ToolbarItems_UIBH
    {
        string PlatformName;
        AppiumDriver Driver;

        public MultiPageTemplateTests_ToolbarItems_UIBH(string platform)
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
        public void ToolbarItemTest()
        {
            WebElementUtils.Click(Driver, "pushBtn");
            WebElementUtils.Click(Driver, "btnAdd");

            Point pt = new Point(663, 99);
            var touch = new RemoteTouchScreenUtils(Driver);
            touch.Down(pt.X, pt.Y);
            touch.Up(pt.X, pt.Y);

            string ret = WebElementUtils.GetText(Driver, "btnAdd");

            string expect = "ToolbarItems are added";
            Assert.AreEqual(expect, ret);
        }
    }
}
