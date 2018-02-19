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
    public class ImageTest2
    {
        string PlatformName;
        AppiumDriver Driver;

        public ImageTest2(string platform)
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
        public void AspectFitTest()
        {
            WebElementUtils.Click(Driver, "aspectFit");
            string expect = "AspectFit";
            string ret = WebElementUtils.GetAttribute(Driver, "image", "Aspect");
            Assert.AreEqual(expect, ret);
        }

        [Test]
        public void AspectFillTest()
        {
            WebElementUtils.Click(Driver, "aspectFill");
            string expect = "AspectFill";
            string ret = WebElementUtils.GetAttribute(Driver, "image", "Aspect");
            Assert.AreEqual(expect, ret);
        }

        [Test]
        public void FillTest()
        {
            WebElementUtils.Click(Driver, "fill");
            string expect = "Fill";
            string ret = WebElementUtils.GetAttribute(Driver, "image", "Aspect");
            Assert.AreEqual(expect, ret);
        }
    }
}
