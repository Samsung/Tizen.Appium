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
    public class FrameLayoutTest2
    {
        string PlatformName;
        AppiumDriver Driver;

        public FrameLayoutTest2(string platform)
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
        public void TopBoxPositionTest()
        {
            Point topLeftBox = WebElementUtils.GetLocation(Driver, "topLeftBox");
            Assert.AreEqual(69, topLeftBox.X);
            Assert.AreEqual(219, topLeftBox.Y);

            Point topCenterBox = WebElementUtils.GetLocation(Driver, "topCenterBox");
            Assert.AreEqual(359, topCenterBox.X);
            Assert.AreEqual(219, topCenterBox.Y);

            Point topRightBox = WebElementUtils.GetLocation(Driver, "topRightBox");
            Assert.AreEqual(651, topRightBox.X);
            Assert.AreEqual(219, topRightBox.Y);
        }

        [Test]
        public void BottomBoxPositionTest()
        {
            Point bottomLeftBox = WebElementUtils.GetLocation(Driver, "bottomLeftBox");
            Assert.AreEqual(69, bottomLeftBox.X);
            Assert.AreEqual(1210, bottomLeftBox.Y);

            Point bottomCenterBox = WebElementUtils.GetLocation(Driver, "bottomCenterBox");
            Assert.AreEqual(359, bottomCenterBox.X);
            Assert.AreEqual(1210, bottomCenterBox.Y);

            Point bottomRightBox = WebElementUtils.GetLocation(Driver, "bottomRightBox");
            Assert.AreEqual(651, bottomRightBox.X);
            Assert.AreEqual(1210, bottomRightBox.Y);
        }

        [Test]
        public void BoxSizeTest()
        {
            Size leftBGBox = WebElementUtils.GetSize(Driver, "leftBGBox");
            Assert.AreEqual(442, leftBGBox.Height);
            Assert.AreEqual(86, leftBGBox.Width);

            Size rightBGBox = WebElementUtils.GetSize(Driver, "rightBGBox");
            Assert.AreEqual(442, rightBGBox.Height);
            Assert.AreEqual(86, rightBGBox.Width);
        }
    }
}
