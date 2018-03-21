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
    [TestFixture(FormsTizenGalleryUtils.Platform)]
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
            var longEditorId = "longEditor";
            var editorId = "editor";
            string add = "abcdefg";

            string origin = WebElementUtils.GetText(Driver, longEditorId);

            WebElementUtils.SetText(Driver, longEditorId, add);

            WebElementUtils.Click(Driver, editorId);
            string result = WebElementUtils.GetText(Driver, longEditorId);
            Assert.AreEqual(origin + add, result);
        }

        [Test]
        public void CompletedTest()
        {
            var longEditorId = "longEditor";
            var editorId = "editor";
            string add = "ABC";

            WebElementUtils.SetText(Driver, longEditorId, add);
            WebElementUtils.Click(Driver, editorId);

            WebElementUtils.Click(Driver, editorId);
            string result = WebElementUtils.GetText(Driver, editorId);

            Assert.AreEqual("Editing completed", result);
        }
    }
}
