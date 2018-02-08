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
    [TestFixture("Tizen")]
    public class FrameLayoutTest1
    {
        string PlatformName;
        AppiumDriver Driver;

        public FrameLayoutTest1(string platform)
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
        public void ButtonPositionTest()
        {
            Point buttonPt = WebElementUtils.GetLocation(Driver, "button");
            Assert.AreEqual(361, buttonPt.X);
            Assert.AreEqual(716, buttonPt.Y);
        }

        [Test]
        public void LabelPositionTest()
        {
            Point buttonPt = WebElementUtils.GetLocation(Driver, "bottomLabel");
            Assert.AreEqual(359, buttonPt.X);
            Assert.AreEqual(1223, buttonPt.Y);
        }

        [Test]
        public void BoxPositionTest()
        {
            Point topLeftBoxPt = WebElementUtils.GetLocation(Driver, "topLeftBox");
            Assert.AreEqual(179, topLeftBoxPt.X);
            Assert.AreEqual(432, topLeftBoxPt.Y);

            Point topRightBoxPt = WebElementUtils.GetLocation(Driver, "topRightBox");
            Assert.AreEqual(540, topRightBoxPt.X);
            Assert.AreEqual(432, topRightBoxPt.Y);
        }

        [Test]
        public void BoxSizeTest()
        {
            Size topLeftBoxPt = WebElementUtils.GetSize(Driver, "topLeftBox");
            Assert.AreEqual(286, topLeftBoxPt.Height);
            Assert.AreEqual(182, topLeftBoxPt.Width);

            Size topRightBoxPt = WebElementUtils.GetSize(Driver, "topRightBox");
            Assert.AreEqual(286, topRightBoxPt.Height);
            Assert.AreEqual(182, topRightBoxPt.Width);
        }
    }
}
