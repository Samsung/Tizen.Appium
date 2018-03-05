using System;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Tizen;
using OpenQA.Selenium.Appium.Android;
using NUnit.Framework;
using System.Drawing;

namespace Xamarin.Issues.UITests
{
    [TestFixture(TestScriptUtils.Platform)]
    public class StackLayoutTests_Scale_StackLayout_UILK
    {
        string PlatformName;
        AppiumDriver Driver;

        public StackLayoutTests_Scale_StackLayout_UILK(string platform)
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
        public void ScaleTest()
        {
            string ret = WebElementUtils.GetAttribute(Driver, "_simpleStackLayout", "Scale");

            var pt = new Point(366, 790);
            RemoteTouchScreenUtils.Click(Driver, pt);

            string ret2 = WebElementUtils.GetAttribute(Driver, "_simpleStackLayout", "Scale");
            Assert.AreNotEqual(ret, ret2);
        }
    }
}
