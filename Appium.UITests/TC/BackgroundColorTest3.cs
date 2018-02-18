using System;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Tizen;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Remote;
using NUnit.Framework;
using System.Drawing;

namespace Appium.UITests
{
    [TestFixture(FormsTizenGalleryUtils.Platform)]
    public class BackgroundColorTest3
    {
        string PlatformName;
        AppiumDriver Driver;

        public BackgroundColorTest3(string platform)
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
        public void ContentPageBackgroundTest()
        {
            string result = WebElementUtils.GetAttribute(Driver, "ContentPage", "BackgroundColor");
            WebElementUtils.Click(Driver, "button1");
            string result2 = WebElementUtils.GetAttribute(Driver, "ContentPage", "BackgroundColor");
            Assert.AreNotEqual(result, result2);
        }
    }
}
