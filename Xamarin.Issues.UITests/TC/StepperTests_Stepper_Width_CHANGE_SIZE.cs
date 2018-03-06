using System;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Tizen;
using OpenQA.Selenium.Appium.Android;
using NUnit.Framework;
using System.Drawing;

namespace Xamarin.Issues.UITests
{
    [TestFixture(TestScriptUtils.Platform)]
    public class StepperTests_Stepper_Width_CHANGE_SIZE
    {
        string PlatformName;
        AppiumDriver Driver;

        public StepperTests_Stepper_Width_CHANGE_SIZE(string platform)
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
            string ret = WebElementUtils.GetAttribute(Driver, "_stepper3", "Width");

            var pt = new Point(501, 1207);
            RemoteTouchScreenUtils.Click(Driver, pt);

            string ret2 = WebElementUtils.GetAttribute(Driver, "_stepper3", "Width");
            Assert.AreNotEqual(ret, ret2);
        }
    }
}
