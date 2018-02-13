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
    public class GridTest
    {
        string PlatformName;
        AppiumDriver Driver;

        public GridTest(string platform)
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
        public void TopLocationTest()
        {
            Point point = WebElementUtils.GetLocation(Driver, "button1");
            Assert.AreEqual(360, point.X);
            Assert.AreEqual(290, point.Y);
        }

        [Test]
        public void MiddleLocationTest()
        {
            Point point = WebElementUtils.GetLocation(Driver, "button2");
            Assert.AreEqual(118, point.X);
            Assert.AreEqual(573, point.Y);

            point = WebElementUtils.GetLocation(Driver, "button3");
            Assert.AreEqual(359, point.X);
            Assert.AreEqual(573, point.Y);

            point = WebElementUtils.GetLocation(Driver, "button4");
            Assert.AreEqual(118, point.X);
            Assert.AreEqual(857, point.Y);

            point = WebElementUtils.GetLocation(Driver, "button5");
            Assert.AreEqual(359, point.X);
            Assert.AreEqual(857, point.Y);

            point = WebElementUtils.GetLocation(Driver, "button6");
            Assert.AreEqual(601, point.X);
            Assert.AreEqual(714, point.Y);
        }

        [Test]
        public void BottomLocationTest()
        {
            Point point = WebElementUtils.GetLocation(Driver, "button7");
            Assert.AreEqual(239, point.X);
            Assert.AreEqual(1140, point.Y);

            point = WebElementUtils.GetLocation(Driver, "button8");
            Assert.AreEqual(601, point.X);
            Assert.AreEqual(1140, point.Y);
        }

        [Test]
        public void TopSizeTest()
        {
            Size area = WebElementUtils.GetSize(Driver, "button1");
            Assert.AreEqual(141, area.Height);
            Assert.AreEqual(364, area.Width);
        }

        [Test]
        public void MiddleSizeTest()
        {
            Size area = WebElementUtils.GetSize(Driver, "button2");
            Assert.AreEqual(141, area.Height);
            Assert.AreEqual(120, area.Width);

            area = WebElementUtils.GetSize(Driver, "button3");
            Assert.AreEqual(141, area.Height);
            Assert.AreEqual(120, area.Width);

            area = WebElementUtils.GetSize(Driver, "button4");
            Assert.AreEqual(141, area.Height);
            Assert.AreEqual(120, area.Width);

            area = WebElementUtils.GetSize(Driver, "button5");
            Assert.AreEqual(141, area.Height);
            Assert.AreEqual(120, area.Width);

            area = WebElementUtils.GetSize(Driver, "button6");
            Assert.AreEqual(285, area.Height);
            Assert.AreEqual(120, area.Width);
        }

        [Test]
        public void BottomSizeTest()
        {
            Size area = WebElementUtils.GetSize(Driver, "button7");
            Assert.AreEqual(141, area.Height);
            Assert.AreEqual(242, area.Width);

            area = WebElementUtils.GetSize(Driver, "button8");
            Assert.AreEqual(141, area.Height);
            Assert.AreEqual(120, area.Width);
        }
    }
}
