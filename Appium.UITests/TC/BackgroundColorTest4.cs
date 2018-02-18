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
    public class BackgroundColorTest4
    {
        string PlatformName;
        AppiumDriver Driver;

        public BackgroundColorTest4(string platform)
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
        public void LabelBackgroundTest()
        {
            WebElementUtils.Click(Driver, "btnDefaultLabel");
            string result = WebElementUtils.GetAttribute(Driver, "label", "BackgroundColor");
            WebElementUtils.Click(Driver, "btnRedLabel");
            string result2 = WebElementUtils.GetAttribute(Driver, "label", "BackgroundColor");
            Assert.AreNotEqual(result, result2);
        }

        [Test]
        public void ButtonBackgroundTest()
        {
            WebElementUtils.Click(Driver, "btnDefaultButton");
            string result = WebElementUtils.GetAttribute(Driver, "button", "BackgroundColor");
            WebElementUtils.Click(Driver, "btnBlueButton");
            string result2 = WebElementUtils.GetAttribute(Driver, "button", "BackgroundColor");
            Assert.AreNotEqual(result, result2);
        }
    }
}
