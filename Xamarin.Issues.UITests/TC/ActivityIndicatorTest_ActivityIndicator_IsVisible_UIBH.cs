using System;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Tizen;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Remote;
using NUnit.Framework;
using OpenQA.Selenium.Appium.MultiTouch;
using OpenQA.Selenium.Interactions.Internal;

namespace Xamarin.Issues.UITests
{
    [TestFixture(TestScriptUtils.Platform)]
    public class ActivityIndicatorTest_ActivityIndicator_IsVisible_UIBH
    {
        string PlatformName;
        AppiumDriver Driver;

        public ActivityIndicatorTest_ActivityIndicator_IsVisible_UIBH(string platform)
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
        public void VisibleTest()
        {
            WebElementUtils.Click(Driver, "mBtnVisible");
            string IsVisibleRet = WebElementUtils.GetAttribute(Driver, "_mActivityIndicator", "IsVisible");
            string IsRunningRet = WebElementUtils.GetAttribute(Driver, "_mActivityIndicator", "IsRunning");
            Assert.AreEqual("True", IsVisibleRet);
            Assert.AreEqual("True", IsRunningRet);
        }

        [Test]
        public void HideTest()
        {
            WebElementUtils.Click(Driver, "mBtnHide");
            string IsVisibleRet = WebElementUtils.GetAttribute(Driver, "_mActivityIndicator", "IsVisible");
            Assert.AreEqual("False", IsVisibleRet);
        }
    }
}
