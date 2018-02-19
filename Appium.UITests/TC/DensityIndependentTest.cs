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
    public class DensityIndependentTest
    {
        string PlatformName;
        AppiumDriver Driver;

        public DensityIndependentTest(string platform)
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
        public void BoxViewPositionTest()
        {
            Point expect = new Point(197, 411);
            Point ret = WebElementUtils.GetLocation(Driver, "box");
            Assert.AreEqual(expect, ret);
        }

        [Test]
        public void LabelPositionTest()
        {
            Point expect = new Point(197, 491);
            Point ret = WebElementUtils.GetLocation(Driver, "boxLabel");
            Assert.AreEqual(expect, ret);
        }

        [Test]
        public void BoxViewSizeTest()
        {
            string w = WebElementUtils.GetAttribute(Driver, "box", "Width");
            string h = WebElementUtils.GetAttribute(Driver, "box", "Height");
            Assert.AreEqual("200", w);
            Assert.AreEqual("200", h);
        }

        [Test]
        public void LabelSizeTest()
        {
            string w = WebElementUtils.GetAttribute(Driver, "boxLabel", "Width");
            string h = WebElementUtils.GetAttribute(Driver, "boxLabel", "Height");
            Assert.AreEqual("200", w);
            Assert.AreEqual("100", h);
        }
    }
}
