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
        RemoteTouchScreenUtils touchScreen;

        public EntryTest4(string platform)
        {
            PlatformName = platform;
        }

        [TestFixtureSetUp]
        public void Setup()
        {
            Driver = new AppiumDriver(PlatformName);
            touchScreen = new RemoteTouchScreenUtils(Driver);
            touchScreen.Flick(0, -11);

            string testId = WebElementUtils.GetAttribute(Driver, "Content", this.GetType().Name);
            WebElementUtils.Click(Driver, testId);
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
            touchScreen.Down(545, 229);
            touchScreen.Up(545, 229);

            Point entryPt = WebElementUtils.GetLocation(Driver, "test1");
            //Assert.AreEqual(221, entryPt.X);
            //Assert.AreEqual(419, entryPt.Y);

            Point labelPt = WebElementUtils.GetLocation(Driver, "test2");
            //Assert.AreEqual(355, labelPt.X);
            //Assert.AreEqual(419, labelPt.Y);

            Point buttonPt = WebElementUtils.GetLocation(Driver, "label");
            //Assert.AreEqual(561, buttonPt.X);
            //Assert.AreEqual(419, buttonPt.Y);
        }
    }
}
