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
    public class GridTest3
    {
        string PlatformName;
        AppiumDriver Driver;

        public GridTest3(string platform)
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
        public void OperationLocationTest()
        {
            Point point = WebElementUtils.GetLocation(Driver, "*");
            Assert.AreEqual(633, point.X);
            Assert.AreEqual(769, point.Y);

            point = WebElementUtils.GetLocation(Driver, "-");
            Assert.AreEqual(633, point.X);
            Assert.AreEqual(916, point.Y);

            point = WebElementUtils.GetLocation(Driver, "+");
            Assert.AreEqual(633, point.X);
            Assert.AreEqual(1063, point.Y);

            point = WebElementUtils.GetLocation(Driver, "/");
            Assert.AreEqual(633, point.X);
            Assert.AreEqual(622, point.Y);
        }

        [Test]
        public void NumberButtonLocationTest()
        {
            Point point = WebElementUtils.GetLocation(Driver, "1");
            Assert.AreEqual(87, point.X);
            Assert.AreEqual(1063, point.Y);

            point = WebElementUtils.GetLocation(Driver, "2");
            Assert.AreEqual(269, point.X);
            Assert.AreEqual(1063, point.Y);

            point = WebElementUtils.GetLocation(Driver, "3");
            Assert.AreEqual(451, point.X);
            Assert.AreEqual(1063, point.Y);

            point = WebElementUtils.GetLocation(Driver, "4");
            Assert.AreEqual(87, point.X);
            Assert.AreEqual(916, point.Y);

            point = WebElementUtils.GetLocation(Driver, "5");
            Assert.AreEqual(269, point.X);
            Assert.AreEqual(916, point.Y);

            point = WebElementUtils.GetLocation(Driver, "6");
            Assert.AreEqual(451, point.X);
            Assert.AreEqual(916, point.Y);

            point = WebElementUtils.GetLocation(Driver, "7");
            Assert.AreEqual(87, point.X);
            Assert.AreEqual(769, point.Y);

            point = WebElementUtils.GetLocation(Driver, "8");
            Assert.AreEqual(269, point.X);
            Assert.AreEqual(769, point.Y);

            point = WebElementUtils.GetLocation(Driver, "9");
            Assert.AreEqual(451, point.X);
            Assert.AreEqual(769, point.Y);
        }

        [Test]
        public void OperationSizeTest()
        {
            Size area = WebElementUtils.GetSize(Driver, "*");
            Assert.AreEqual(70, area.Height);
            Assert.AreEqual(88, area.Width);

            area = WebElementUtils.GetSize(Driver, "-");
            Assert.AreEqual(70, area.Height);
            Assert.AreEqual(88, area.Width);

            area = WebElementUtils.GetSize(Driver, "+");
            Assert.AreEqual(70, area.Height);
            Assert.AreEqual(88, area.Width);

            area = WebElementUtils.GetSize(Driver, "/");
            Assert.AreEqual(70, area.Height);
            Assert.AreEqual(88, area.Width);
        }

        [Test]
        public void BottomSizeTest()
        {
            Size area = WebElementUtils.GetSize(Driver, "1");
            Assert.AreEqual(70, area.Height);
            Assert.AreEqual(88, area.Width);

            area = WebElementUtils.GetSize(Driver, "2");
            Assert.AreEqual(70, area.Height);
            Assert.AreEqual(88, area.Width);

            area = WebElementUtils.GetSize(Driver, "3");
            Assert.AreEqual(70, area.Height);
            Assert.AreEqual(88, area.Width);

            area = WebElementUtils.GetSize(Driver, "4");
            Assert.AreEqual(70, area.Height);
            Assert.AreEqual(88, area.Width);

            area = WebElementUtils.GetSize(Driver, "5");
            Assert.AreEqual(70, area.Height);
            Assert.AreEqual(88, area.Width);

            area = WebElementUtils.GetSize(Driver, "6");
            Assert.AreEqual(70, area.Height);
            Assert.AreEqual(88, area.Width);

            area = WebElementUtils.GetSize(Driver, "7");
            Assert.AreEqual(70, area.Height);
            Assert.AreEqual(88, area.Width);

            area = WebElementUtils.GetSize(Driver, "8");
            Assert.AreEqual(70, area.Height);
            Assert.AreEqual(88, area.Width);

            area = WebElementUtils.GetSize(Driver, "9");
            Assert.AreEqual(70, area.Height);
            Assert.AreEqual(88, area.Width);
        }
    }
}
