using System;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Tizen;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Remote;
using NUnit.Framework;
using OpenQA.Selenium.Appium.MultiTouch;
using OpenQA.Selenium.Interactions.Internal;
using System.Drawing;

namespace Appium.UITests
{
    [TestFixture(FormsTizenGalleryUtils.Platform)]
    public class ImageTest5
    {
        string PlatformName;
        AppiumDriver Driver;

        public ImageTest5(string platform)
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
        public void WidthUpTest()
        {
            string ret = WebElementUtils.GetAttribute(Driver, "image", "Width");
            WebElementUtils.Click(Driver, "widthUpBtn");
            string ret2 = WebElementUtils.GetAttribute(Driver, "image", "Width");
            Assert.AreNotEqual(ret, ret2);
        }

        [Test]
        public void WidthDownTest()
        {
            string ret = WebElementUtils.GetAttribute(Driver, "image", "Width");
            WebElementUtils.Click(Driver, "widthDownBtn");
            string ret2 = WebElementUtils.GetAttribute(Driver, "image", "Width");
            Assert.AreNotEqual(ret, ret2);
            WebElementUtils.Click(Driver, "widthUpBtn");
        }

        [Test]
        public void HeightUpTest()
        {
            string ret = WebElementUtils.GetAttribute(Driver, "image", "Height");
            WebElementUtils.Click(Driver, "heightUpBtn");
            string ret2 = WebElementUtils.GetAttribute(Driver, "image", "Height");
            Assert.AreNotEqual(ret, ret2);
        }

        [Test]
        public void HeightDownTest()
        {
            string ret = WebElementUtils.GetAttribute(Driver, "image", "Height");
            WebElementUtils.Click(Driver, "heightDownBtn");
            string ret2 = WebElementUtils.GetAttribute(Driver, "image", "Height");
            Assert.AreNotEqual(ret, ret2);
            WebElementUtils.Click(Driver, "heightUpBtn");
        }
    }
}
