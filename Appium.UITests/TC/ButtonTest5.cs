using System;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Tizen;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Remote;
using NUnit.Framework;
using OpenQA.Selenium.Appium.MultiTouch;
using OpenQA.Selenium.Interactions.Internal;

namespace Appium.UITests
{
    //[TestFixture("Android")]
    [TestFixture("Tizen")]
    public class ButtonTest5
    {
        string PlatformName;
        AppiumDriver Driver;

        public ButtonTest5(string platform)
        {
            PlatformName = platform;
        }

        [TestFixtureSetUp]
        public void Setup()
        {
            Driver = new AppiumDriver(PlatformName);

            var touchScreen = new RemoteTouchScreenUtils(Driver);
            touchScreen.Flick(0, -8);

            string testId = WebElementUtils.GetAttribute(Driver, "Content", this.GetType().Name);
            WebElementUtils.Click(Driver, testId);
        }

        [TestFixtureTearDown]
        public void TearDown()
        {
            Driver.Quit();
        }

        [Test]
        public void ClickTest()
        {
            string before = WebElementUtils.GetAttribute(Driver, "btnOpacitySlider", "Value");
            Assert.AreEqual("1", before);
            WebElementUtils.Click(Driver, "button");
            string after = WebElementUtils.GetAttribute(Driver, "btnOpacitySlider", "Value");
            Assert.AreEqual("0.5", after);
        }
    }
}
