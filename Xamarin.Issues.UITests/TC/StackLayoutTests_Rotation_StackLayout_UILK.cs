using System;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Tizen;
using OpenQA.Selenium.Appium.Android;
using NUnit.Framework;
using System.Drawing;

namespace Xamarin.Issues.UITests
{
    [TestFixture(TestScriptUtils.Platform)]
    public class StackLayoutTests_Rotation_StackLayout_UILK
    {
        string PlatformName;
        AppiumDriver Driver;

        public StackLayoutTests_Rotation_StackLayout_UILK(string platform)
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
        public void RotationTest()
        {
            string ret = WebElementUtils.GetAttribute(Driver, "_simpleStackLayout", "Rotation");

            var pt = new Point(384, 1003);
            RemoteTouchScreenUtils.Click(Driver, pt);

            string ret2 = WebElementUtils.GetAttribute(Driver, "_simpleStackLayout", "Rotation");
            Assert.AreNotEqual(ret, ret2);
        }
    }
}
