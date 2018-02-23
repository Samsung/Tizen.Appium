using System;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Tizen;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Remote;
using NUnit.Framework;
using System.Drawing;

namespace Xamarin.Issues.UITests
{
    [TestFixture(TestScriptUtils.Platform)]
    public class ActivityIndicatorTest_ActivityIndicator_Opacity_UILK
    {
        string PlatformName;
        AppiumDriver Driver;

        public ActivityIndicatorTest_ActivityIndicator_Opacity_UILK(string platform)
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
        public void OpacityTest()
        {
            string ret = WebElementUtils.GetAttribute(Driver, "_mActivityIndicator", "Opacity");

            Point sliderPosition = new Point(111, 1005);
            var touch = new RemoteTouchScreenUtils(Driver);
            touch.Down(sliderPosition.X, sliderPosition.Y );
            touch.Up(sliderPosition.X, sliderPosition.Y);

            string ret2 = WebElementUtils.GetAttribute(Driver, "_mActivityIndicator", "Opacity");
            Assert.AreNotEqual(ret, ret2);
        }

    }
}
