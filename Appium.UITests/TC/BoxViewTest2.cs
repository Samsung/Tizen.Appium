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
    public class BoxViewTest2
    {
        string PlatformName;
        AppiumDriver Driver;

        public BoxViewTest2(string platform)
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
            Point expect = new Point(360, 189);
            Point pt = WebElementUtils.GetLocation(Driver, "BoxView1");
            Assert.AreEqual(expect, pt);
        }

        [Test]
        public void PositionTest2()
        {
            Point expect = new Point(360, 280);
            Point pt = WebElementUtils.GetLocation(Driver, "BoxView2");
            Assert.AreEqual(expect, pt);
        }

        [Test]
        public void PositionTest3()
        {
            Point expect = new Point(360, 371);
            Point pt = WebElementUtils.GetLocation(Driver, "BoxView3");
            Assert.AreEqual(expect, pt);
        }

        [Test]
        public void PositionTest4()
        {
            Point expect = new Point(39, 1046);
            Point pt = WebElementUtils.GetLocation(Driver, "BoxView4");
            Assert.AreEqual(expect, pt);
        }

        [Test]
        public void PositionTest5()
        {
            Point expect = new Point(130, 1046);
            Point pt = WebElementUtils.GetLocation(Driver, "BoxView5");
            Assert.AreEqual(expect, pt);
        }

        [Test]
        public void PositionTest6()
        {
            Point expect = new Point(221, 1046);
            Point pt = WebElementUtils.GetLocation(Driver, "BoxView6");
            Assert.AreEqual(expect, pt);
        }
    }
}
