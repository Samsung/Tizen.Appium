using System;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Tizen;
using OpenQA.Selenium.Appium.Android;
using NUnit.Framework;
using System.Drawing;

namespace Xamarin.Issues.UITests
{
    [TestFixture(TestScriptUtils.Platform)]
    public class SliderTests_Slider_Width_CHANGE_SIZE
    {
        string PlatformName;
        AppiumDriver Driver;

        public SliderTests_Slider_Width_CHANGE_SIZE(string platform)
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
        public void WidthRequestTest()
        {
            string ret = WebElementUtils.GetAttribute(Driver, "_slider3", "WidthRequest");

            var pt = new Point(448, 1206);
            RemoteTouchScreenUtils.Click(Driver, pt);

            string ret2 = WebElementUtils.GetAttribute(Driver, "_slider3", "WidthRequest");
            Assert.AreNotEqual(ret, ret2);
        }
    }
}
