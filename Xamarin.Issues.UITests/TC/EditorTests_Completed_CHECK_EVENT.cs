using System;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Tizen;
using OpenQA.Selenium.Appium.Android;
using NUnit.Framework;
using System.Drawing;

namespace Xamarin.Issues.UITests
{
    [TestFixture(TestScriptUtils.Platform)]
    public class EditorTests_Completed_CHECK_EVENT
    {
        string PlatformName;
        AppiumDriver Driver;

        public EditorTests_Completed_CHECK_EVENT(string platform)
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
        public void CompletedTest()
        {
            WebElementUtils.SetText(Driver, "_editor", "ABCDE");
            WebElementUtils.Click(Driver, "_editor2");
            string expect = "Completed callback is called";
            string ret = WebElementUtils.GetAttribute(Driver, "_editor", "Text");
            Assert.AreEqual(expect, ret);
        }
    }
}
