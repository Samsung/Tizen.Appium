using System;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Tizen;
using OpenQA.Selenium.Appium.Android;
using NUnit.Framework;
using System.Drawing;

namespace Xamarin.Issues.UITests
{
    [TestFixture(TestScriptUtils.Platform)]
    public class SliderTests_Slider_Opacity_LOOK
    {
        string PlatformName;
        AppiumDriver Driver;

        public SliderTests_Slider_Opacity_LOOK(string platform)
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
            string ret = WebElementUtils.GetAttribute(Driver, "_slider3", "Opacity");

            var pt = new Point(373, 1162);
            RemoteTouchScreenUtils.Click(Driver, pt);

            string ret2 = WebElementUtils.GetAttribute(Driver, "_slider3", "Opacity");
            Assert.AreNotEqual(ret, ret2);
        }
    }
}
