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
    public class FocusSetTest
    {
        string PlatformName;
        AppiumDriver Driver;
        RemoteTouchScreenUtils touchScreen;

        public FocusSetTest(string platform)
        {
            PlatformName = platform;
        }

        [TestFixtureSetUp]
        public void Setup()
        {
            Driver = new AppiumDriver(PlatformName);
            touchScreen = new RemoteTouchScreenUtils(Driver);
            touchScreen.Flick(0, -12);

            string testId = WebElementUtils.GetAttribute(Driver, "Content", this.GetType().Name);
            WebElementUtils.Click(Driver, testId);
        }

        [TestFixtureTearDown]
        public void TearDown()
        {
            Driver.Quit();
        }

        [Test]
        public void FocusTest()
        {
            WebElementUtils.Click(Driver, "First -> Fourth");
            string result = WebElementUtils.GetText(Driver, "Fourth -> Second");
            Assert.AreEqual("Focused!!", result);

            WebElementUtils.Click(Driver, "Fourth -> Second");
            result = WebElementUtils.GetText(Driver, "Second -> Third");
            Assert.AreEqual("Focused!!", result);

            WebElementUtils.Click(Driver, "Second -> Third");
            result = WebElementUtils.GetText(Driver, "Third -> First");
            Assert.AreEqual("Focused!!", result);

            WebElementUtils.Click(Driver, "Third -> First");
            result = WebElementUtils.GetText(Driver, "First -> Fourth");
            Assert.AreEqual("Focused!!", result);

        }
    }
}
