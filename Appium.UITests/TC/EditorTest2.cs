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
    [TestFixture("Tizen")]
    public class EditorTest2
    {
        string PlatformName;
        AppiumDriver Driver;

        public EditorTest2(string platform)
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
        public void SetTextTest()
        {
            string origin = WebElementUtils.GetText(Driver, "longEditor");
            string add = "abcdefg";
            WebElementUtils.SetText(Driver, "longEditor", add);

            WebElementUtils.Click(Driver, "editor");
            string result = WebElementUtils.GetText(Driver, "longEditor");
            Assert.AreEqual(origin+add, result);
        }

        [Test]
        public void CompletedTest()
        {
            WebElementUtils.SetText(Driver, "longEditor", "ABC");
            WebElementUtils.Click(Driver, "editor");
            string result = WebElementUtils.GetText(Driver, "editor");
            Assert.AreEqual("Editing completed", result);
        }
    }
}
