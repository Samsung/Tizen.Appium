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
    public class DensityIndependentTest2
    {
        string PlatformName;
        AppiumDriver Driver;

        public DensityIndependentTest2(string platform)
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
        public void FontSizeTest()
        {
            string ret = WebElementUtils.GetAttribute(Driver, "label1", "FontSize");
            Assert.AreEqual("23.2556957896752", ret);
        }

        [Test]
        public void FontSizeTest2()
        {
            string ret = WebElementUtils.GetAttribute(Driver, "label2", "FontSize");
            Assert.AreEqual("17.2556957896752", ret);
        }

        [Test]
        public void FontSizeTest3()
        {
            string ret = WebElementUtils.GetAttribute(Driver, "label3", "FontSize");
            Assert.AreEqual("14.2556957896752", ret);
        }

        [Test]
        public void FontSizeTest4()
        {
            string ret = WebElementUtils.GetAttribute(Driver, "label4", "FontSize");
            Assert.AreEqual("11.2556957896752", ret);
        }
    }
}
