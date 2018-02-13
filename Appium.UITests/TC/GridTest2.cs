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
    public class GridTest2
    {
        string PlatformName;
        AppiumDriver Driver;

        public GridTest2(string platform)
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
            Assert.AreEqual(199, point.Y);
        }

        [Test]
        public void BottomLocationTest()
        {
            Point point = WebElementUtils.GetLocation(Driver, "button2");
            Assert.AreEqual(118, point.X);
            Assert.AreEqual(510, point.Y);

            point = WebElementUtils.GetLocation(Driver, "button3");
            Assert.AreEqual(360, point.X);
            Assert.AreEqual(510, point.Y);

            point = WebElementUtils.GetLocation(Driver, "button4");
            Assert.AreEqual(118, point.X);
            Assert.AreEqual(1025, point.Y);

            point = WebElementUtils.GetLocation(Driver, "button5");
            Assert.AreEqual(360, point.X);
            Assert.AreEqual(1025, point.Y);

            point = WebElementUtils.GetLocation(Driver, "button6");
            Assert.AreEqual(602, point.X);
            Assert.AreEqual(767, point.Y);
        }

        [Test]
        public void TopSizeTest()
        {
            Size area = WebElementUtils.GetSize(Driver, "button1");
            Assert.AreEqual(50, area.Height);
            Assert.AreEqual(364, area.Width);
        }

        [Test]
        public void BottomSizeTest()
        {
            Size area = WebElementUtils.GetSize(Driver, "button2");
            Assert.AreEqual(258, area.Height);
            Assert.AreEqual(119, area.Width);

            area = WebElementUtils.GetSize(Driver, "button3");
            Assert.AreEqual(258, area.Height);
            Assert.AreEqual(119, area.Width);

            area = WebElementUtils.GetSize(Driver, "button4");
            Assert.AreEqual(258, area.Height);
            Assert.AreEqual(119, area.Width);

            area = WebElementUtils.GetSize(Driver, "button5");
            Assert.AreEqual(258, area.Height);
            Assert.AreEqual(119, area.Width);

            area = WebElementUtils.GetSize(Driver, "button6");
            Assert.AreEqual(519, area.Height);
            Assert.AreEqual(119, area.Width);
        }
    }
}
