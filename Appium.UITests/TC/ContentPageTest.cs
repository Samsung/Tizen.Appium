using System;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Tizen;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Remote;
using NUnit.Framework;
using OpenQA.Selenium.Appium.MultiTouch;
using OpenQA.Selenium.Interactions.Internal;

namespace Appium.UITests
{
    [TestFixture(FormsTizenGalleryUtils.Platform)]
    public class ContentPageTest
    {
        string PlatformName;
        AppiumDriver Driver;

        public ContentPageTest(string platform)
        {
            PlatformName = platform;
        }

        [TestFixtureSetUp]
        public void Setup()
        {
            Driver = new AppiumDriver(PlatformName);
            FormsTizenGalleryUtils.FindTC(Driver, this.GetType().Name);
        }

        [TestFixtureTearDown]
        public void TearDown()
        {
            Driver.Quit();
        }

        [Test]
        public void ContentTest()
        {
            WebElementUtils.Click(Driver, "one");
            WebElementUtils.Click(Driver, "two");
            string ret = WebElementUtils.GetAttribute(Driver, "one", "Text");
            Assert.AreEqual("ONE", ret);
        }
    }
}
