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
    public class ContentPageTest2
    {
        string PlatformName;
        AppiumDriver Driver;

        public ContentPageTest2(string platform)
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
            string ret = WebElementUtils.GetAttribute(Driver, "header", "Text");
            Assert.AreEqual("Template header", ret);
            ret = WebElementUtils.GetAttribute(Driver, "ContentViewContent", "Text");
            Assert.AreEqual("This is a content", ret);
            ret = WebElementUtils.GetAttribute(Driver, "footer", "Text");
            Assert.AreEqual("Template fotter", ret);
        }
    }
}
