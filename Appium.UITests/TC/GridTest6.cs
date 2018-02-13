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
    public class GridTest6
    {
        string PlatformName;
        AppiumDriver Driver;

        public GridTest6(string platform)
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
        public void AddRowTest()
        {
            Point point = WebElementUtils.GetLocation(Driver, "button8");
            Size area = WebElementUtils.GetSize(Driver, "button8");

            WebElementUtils.Click(Driver, "AddRow");

            Point point2 = WebElementUtils.GetLocation(Driver, "button8");
            Size area2 = WebElementUtils.GetSize(Driver, "button8");

            Assert.AreNotEqual(point, point2);
            Assert.AreNotEqual(area, area2);
        }

        [Test]
        public void AddColumnTest()
        {
            Point point = WebElementUtils.GetLocation(Driver, "button8");
            Size area = WebElementUtils.GetSize(Driver, "button8");

            WebElementUtils.Click(Driver, "Addcolumn");

            Point point2 = WebElementUtils.GetLocation(Driver, "button8");
            Size area2 = WebElementUtils.GetSize(Driver, "button8");

            Assert.AreNotEqual(point, point2);
            Assert.AreNotEqual(area, area2);
        }
    }
}
