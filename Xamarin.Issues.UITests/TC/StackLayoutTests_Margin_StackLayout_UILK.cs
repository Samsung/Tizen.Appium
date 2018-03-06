using System;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Tizen;
using OpenQA.Selenium.Appium.Android;
using NUnit.Framework;
using System.Drawing;

namespace Xamarin.Issues.UITests
{
    [TestFixture(TestScriptUtils.Platform)]
    public class StackLayoutTests_Margin_StackLayout_UILK
    {
        string PlatformName;
        AppiumDriver Driver;

        public StackLayoutTests_Margin_StackLayout_UILK(string platform)
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
        public void MarginTest()
        {
            Point ret = WebElementUtils.GetLocation(Driver, "_simpleStackLayout");

            var pt = new Point(384, 1003);
            RemoteTouchScreenUtils.Click(Driver, pt);

            Point ret2 = WebElementUtils.GetLocation(Driver, "_simpleStackLayout");
            Assert.AreNotEqual(ret, ret2);
        }
    }
}
