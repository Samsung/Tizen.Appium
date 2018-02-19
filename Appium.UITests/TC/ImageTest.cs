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
    public class ImageTest
    {
        string PlatformName;
        AppiumDriver Driver;

        public ImageTest(string platform)
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
        public void ImageSourceTest()
        {
            WebElementUtils.Click(Driver, "btnImage1");
            string expect = "File: Icon.png";
            string ret = WebElementUtils.GetAttribute(Driver, "img", "Source");
            Assert.AreEqual(expect, ret);
        }

        [Test]
        public void ImageSourceTest2()
        {
            WebElementUtils.Click(Driver, "btnImage2");
            string expect = "File: b.jpg";
            string ret = WebElementUtils.GetAttribute(Driver, "img", "Source");
            Assert.AreEqual(expect, ret);
        }

        [Test]
        public void ImageSourceTest3()
        {
            WebElementUtils.Click(Driver, "btnImage3");
            string expect = "File: tizen.png";
            string ret = WebElementUtils.GetAttribute(Driver, "img", "Source");
            Assert.AreEqual(expect, ret);
        }
    }
}
