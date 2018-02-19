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
    public class BackgroundImageTest
    {
        string PlatformName;
        AppiumDriver Driver;

        public BackgroundImageTest(string platform)
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
        public void ActivityIndicatorBackgroundTest()
        {
            string result = WebElementUtils.GetAttribute(Driver, "ContentPage", "BackgroundImage");
            WebElementUtils.Click(Driver, "button1");
            string result2 = WebElementUtils.GetAttribute(Driver, "ContentPage", "BackgroundImage");
            Assert.AreNotEqual(result, result2);
        }
    }
}
