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
    public class GridTest4
    {
        string PlatformName;
        AppiumDriver Driver;

        public GridTest4(string platform)
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
        public void LocationTest()
        {
            Point point = WebElementUtils.GetLocation(Driver, "button1");
            Assert.AreEqual(360, point.X);
            Assert.AreEqual(199, point.Y);

            point = WebElementUtils.GetLocation(Driver, "button2");
            Assert.AreEqual(296, point.X);
            Assert.AreEqual(510, point.Y);

            point = WebElementUtils.GetLocation(Driver, "button3");
            Assert.AreEqual(647, point.X);
            Assert.AreEqual(510, point.Y);

            point = WebElementUtils.GetLocation(Driver, "button4");
            Assert.AreEqual(296, point.X);
            Assert.AreEqual(1025, point.Y);

            point = WebElementUtils.GetLocation(Driver, "button5");
            Assert.AreEqual(647, point.X);
            Assert.AreEqual(1025, point.Y);

            point = WebElementUtils.GetLocation(Driver, "button6");
            Assert.AreEqual(711, point.X);
            Assert.AreEqual(767, point.Y);
        }

        [Test]
        public void SizeTest()
        {
            Size area = WebElementUtils.GetSize(Driver, "button1");
            Assert.AreEqual(50, area.Height);
            Assert.AreEqual(364, area.Width);

            area = WebElementUtils.GetSize(Driver, "button2");
            Assert.AreEqual(258, area.Height);
            Assert.AreEqual(300, area.Width);

            area = WebElementUtils.GetSize(Driver, "button3");
            Assert.AreEqual(258, area.Height);
            Assert.AreEqual(50, area.Width);

            area = WebElementUtils.GetSize(Driver, "button4");
            Assert.AreEqual(258, area.Height);
            Assert.AreEqual(300, area.Width);

            area = WebElementUtils.GetSize(Driver, "button5");
            Assert.AreEqual(258, area.Height);
            Assert.AreEqual(50, area.Width);

            area = WebElementUtils.GetSize(Driver, "button6");
            Assert.AreEqual(519, area.Height);
            Assert.AreEqual(8, area.Width);
        }
    }
}
