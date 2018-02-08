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
    public class EntryTest4
    {
        string PlatformName;
        AppiumDriver Driver;

        public EntryTest4(string platform)
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
        public void FirstPageTest()
        {
            Point entryPt = WebElementUtils.GetLocation(Driver, "entry");
            Assert.AreEqual(360, entryPt.X);
            Assert.AreEqual(313, entryPt.Y);

            Point labelPt = WebElementUtils.GetLocation(Driver, "label");
            Assert.AreEqual(360, labelPt.X);
            Assert.AreEqual(417, labelPt.Y);

            Point buttonPt = WebElementUtils.GetLocation(Driver, "button");
            Assert.AreEqual(70, buttonPt.X);
            Assert.AreEqual(650, buttonPt.Y);
        }

        [Test]
        public void SecondPageTest()
        {
            var touchScreen = new RemoteTouchScreenUtils(Driver);
            touchScreen.Down(545, 229);
            touchScreen.Up(545, 229);

            Point entryPt = WebElementUtils.GetLocation(Driver, "test1");
            Assert.AreEqual(99, entryPt.X);
            Assert.AreEqual(419, entryPt.Y);

            Point labelPt = WebElementUtils.GetLocation(Driver, "test2");
            Assert.AreEqual(310, labelPt.X);
            Assert.AreEqual(419, labelPt.Y);

            Point buttonPt = WebElementUtils.GetLocation(Driver, "label");
            Assert.AreEqual(560, buttonPt.X);
            Assert.AreEqual(419, buttonPt.Y);
        }
    }
}
