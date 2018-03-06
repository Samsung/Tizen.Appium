using System;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Tizen;
using OpenQA.Selenium.Appium.Android;
using NUnit.Framework;
using System.Drawing;

namespace Xamarin.Issues.UITests
{
    [TestFixture(TestScriptUtils.Platform)]
    public class SliderTests_Slider_Value_UIBH
    {
        string PlatformName;
        AppiumDriver Driver;

        public SliderTests_Slider_Value_UIBH(string platform)
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
        public void ValueChangedTest()
        {
            var pt = new Point(537, 377);
            RemoteTouchScreenUtils.Click(Driver, pt);

            string expect = "Value Changed Event Called.";
            string ret = WebElementUtils.GetAttribute(Driver, "_label1", "Text");
            Assert.AreEqual(expect, ret);
        }
    }
}
