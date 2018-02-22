using System;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Tizen;
using OpenQA.Selenium.Appium.Android;
using NUnit.Framework;
using System.Drawing;

namespace Xamarin.Issues.UITests
{
    [TestFixture(TestScriptUtils.Platform)]
    public class ContentPageTest_Content_UIBH
    {
        string PlatformName;
        AppiumDriver Driver;

        public ContentPageTest_Content_UIBH(string platform)
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
        public void ContentTest()
        {
            string ret = WebElementUtils.GetAttribute(Driver, "ContentPage", "Content");
            string expect = "Xamarin.Forms.StackLayout";
            Assert.AreEqual(expect, ret);
        }

        [Test]
        public void LabelTextTest()
        {
            string ret = WebElementUtils.GetAttribute(Driver, "Label", "Text");
            string expect = "Content has been set";
            Assert.AreEqual(expect, ret);
        }
    }
}
