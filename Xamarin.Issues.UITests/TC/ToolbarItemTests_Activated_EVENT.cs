using System;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Tizen;
using OpenQA.Selenium.Appium.Android;
using NUnit.Framework;
using System.Drawing;

namespace Xamarin.Issues.UITests
{
    [TestFixture(TestScriptUtils.Platform)]
    public class ToolbarItemTests_Activated_EVENT
    {
        string PlatformName;
        AppiumDriver Driver;

        public ToolbarItemTests_Activated_EVENT(string platform)
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
        public void ActivatedTest()
        {
            var pt = new Point(656, 111);
            RemoteTouchScreenUtils.Click(Driver, pt);

            string expect = "OnActivated is called";
            string ret = WebElementUtils.GetAttribute(Driver, "ToolbarItemTests_Activated_EVENT", "Title");
            Assert.AreEqual(expect, ret);
        }
    }
}
