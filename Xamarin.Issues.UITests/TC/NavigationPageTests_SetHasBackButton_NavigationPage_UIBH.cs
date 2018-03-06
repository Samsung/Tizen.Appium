using System;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Tizen;
using OpenQA.Selenium.Appium.Android;
using NUnit.Framework;
using System.Drawing;

namespace Xamarin.Issues.UITests
{
    [TestFixture(TestScriptUtils.Platform)]
    public class NavigationPageTests_SetHasBackButton_NavigationPage_UIBH
    {
        string PlatformName;
        AppiumDriver Driver;

        public NavigationPageTests_SetHasBackButton_NavigationPage_UIBH(string platform)
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
        public void HasBackButtonTest()
        {
            // BackButton clicked
            WebElementUtils.Click(Driver, "pushBtn");

            Point pt = new Point(55, 114);
            var touch = new RemoteTouchScreenUtils(Driver);
            touch.Down(pt.X, pt.Y);
            touch.Up(pt.X, pt.Y);

            WebElementUtils.Click(Driver, "pushBtn");

            // BackButton Hide
            Point pt2 = new Point(524, 739);
            touch.Down(pt2.X, pt2.Y);
            touch.Up(pt2.X, pt2.Y);

            string ret = WebElementUtils.GetText(Driver, "HideLabel");

            string expect = "BackButton HIDE";
            Assert.AreEqual(expect, ret);
        }
    }
}
