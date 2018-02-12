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
    public class GridTest5
    {
        string PlatformName;
        AppiumDriver Driver;

        public GridTest5(string platform)
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
        public void LableLocationTest()
        {
            Point point = WebElementUtils.GetLocation(Driver, "label1");
            Assert.AreEqual(358, point.X);
            Assert.AreEqual(216, point.Y);

            point = WebElementUtils.GetLocation(Driver, "label2");
            Assert.AreEqual(108, point.X);
            Assert.AreEqual(273, point.Y);

            point = WebElementUtils.GetLocation(Driver, "label3");
            Assert.AreEqual(349, point.X);
            Assert.AreEqual(683, point.Y);

            point = WebElementUtils.GetLocation(Driver, "label4");
            Assert.AreEqual(602, point.X);
            Assert.AreEqual(657, point.Y);

            point = WebElementUtils.GetLocation(Driver, "label5");
            Assert.AreEqual(255, point.X);
            Assert.AreEqual(1172, point.Y);

            point = WebElementUtils.GetLocation(Driver, "label6");
            Assert.AreEqual(602, point.X);
            Assert.AreEqual(1172, point.Y);
        }

        [Test]
        public void BoxLocationTest()
        {
            Point point = WebElementUtils.GetLocation(Driver, "BoxView1");
            Assert.AreEqual(349, point.X);
            Assert.AreEqual(273, point.Y);

            point = WebElementUtils.GetLocation(Driver, "BoxView2");
            Assert.AreEqual(108, point.X);
            Assert.AreEqual(683, point.Y);
        }

        [Test]
        public void LabelSizeTest()
        {
            Size area = WebElementUtils.GetSize(Driver, "label1");
            Assert.AreEqual(26, area.Height);
            Assert.AreEqual(36, area.Width);

            area = WebElementUtils.GetSize(Driver, "label2");
            Assert.AreEqual(19, area.Height);
            Assert.AreEqual(89, area.Width);

            area = WebElementUtils.GetSize(Driver, "label3");
            Assert.AreEqual(383, area.Height);
            Assert.AreEqual(143, area.Width);

            area = WebElementUtils.GetSize(Driver, "label4");
            Assert.AreEqual(408, area.Height);
            Assert.AreEqual(100, area.Width);

            area = WebElementUtils.GetSize(Driver, "label5");
            Assert.AreEqual(100, area.Height);
            Assert.AreEqual(238, area.Width);

            area = WebElementUtils.GetSize(Driver, "label6");
            Assert.AreEqual(100, area.Height);
            Assert.AreEqual(100, area.Width);
        }

        [Test]
        public void BoxSizeTest()
        {
            Size area = WebElementUtils.GetSize(Driver, "BoxView1");
            Assert.AreEqual(19, area.Height);
            Assert.AreEqual(143, area.Width);

            area = WebElementUtils.GetSize(Driver, "BoxView2");
            Assert.AreEqual(383, area.Height);
            Assert.AreEqual(89, area.Width);
        }
    }
}
