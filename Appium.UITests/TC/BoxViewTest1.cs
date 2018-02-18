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
    public class BoxViewTest1
    {
        string PlatformName;
        AppiumDriver Driver;

        public BoxViewTest1(string platform)
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
        public void PositionTest1()
        {
            Point expect = new Point(360, 288);
            Point pt = WebElementUtils.GetLocation(Driver, "BoxView1");
            Assert.AreEqual(expect, pt);
        }

        [Test]
        public void PositionTest2()
        {
            Point expect = new Point(360, 387);
            Point pt = WebElementUtils.GetLocation(Driver, "BoxView2");
            Assert.AreEqual(expect, pt);
        }

        [Test]
        public void PositionTest3()
        {
            Point expect = new Point(360, 485);
            Point pt = WebElementUtils.GetLocation(Driver, "BoxView3");
            Assert.AreEqual(expect, pt);
        }
    }
}
