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
    public class BackgroundColorTest5
    {
        string PlatformName;
        AppiumDriver Driver;

        public BackgroundColorTest5(string platform)
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
            string result = WebElementUtils.GetAttribute(Driver, "ai", "BackgroundColor");
            WebElementUtils.Click(Driver, "button1");
            string result2 = WebElementUtils.GetAttribute(Driver, "ai", "BackgroundColor");
            Assert.AreNotEqual(result, result2);
        }

        [Test]
        public void LabelBackgroundTest()
        {
            string result = WebElementUtils.GetAttribute(Driver, "label", "BackgroundColor");
            WebElementUtils.Click(Driver, "button1");
            string result2 = WebElementUtils.GetAttribute(Driver, "label", "BackgroundColor");
            Assert.AreNotEqual(result, result2);
        }

        [Test]
        public void EntryBackgroundTest()
        {
            string result = WebElementUtils.GetAttribute(Driver, "entry", "BackgroundColor");
            WebElementUtils.Click(Driver, "button1");
            string result2 = WebElementUtils.GetAttribute(Driver, "entry", "BackgroundColor");
            Assert.AreNotEqual(result, result2);
        }

        [Test]
        public void SliderBackgroundTest()
        {
            string result = WebElementUtils.GetAttribute(Driver, "slider", "BackgroundColor");
            WebElementUtils.Click(Driver, "button1");
            string result2 = WebElementUtils.GetAttribute(Driver, "slider", "BackgroundColor");
            Assert.AreNotEqual(result, result2);
        }

        [Test]
        public void ProgressBarBackgroundTest()
        {
            string result = WebElementUtils.GetAttribute(Driver, "progress", "BackgroundColor");
            WebElementUtils.Click(Driver, "button1");
            string result2 = WebElementUtils.GetAttribute(Driver, "progress", "BackgroundColor");
            Assert.AreNotEqual(result, result2);
        }
    }
}
