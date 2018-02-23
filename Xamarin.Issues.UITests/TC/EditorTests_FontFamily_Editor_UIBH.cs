using System;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Tizen;
using OpenQA.Selenium.Appium.Android;
using NUnit.Framework;
using System.Drawing;

namespace Xamarin.Issues.UITests
{
    [TestFixture(TestScriptUtils.Platform)]
    public class EditorTests_FontFamily_Editor_UIBH
    {
        string PlatformName;
        AppiumDriver Driver;

        public EditorTests_FontFamily_Editor_UIBH(string platform)
        {
            PlatformName = platform;
        }

        [TestFixtureSetUp]
        public void Setup()
        {
            Driver = new AppiumDriver(PlatformName);
            TestScriptUtils.FindTC(Driver, this.GetType().Name);
        }

        [TestFixtureTearDown]
        public void TearDown()
        {
            Driver.Quit();
        }

        [Test]
        public void FontFamilyTest()
        {
            Point smallPt = new Point(400, 752);
            var touch = new RemoteTouchScreenUtils(Driver);
            touch.Down(smallPt.X, smallPt.Y);
            touch.Up(smallPt.X, smallPt.Y);
            string expect = "Times New Roman:style=Regular";
            string ret = WebElementUtils.GetAttribute(Driver, "_editor", "FontFamily");
            Assert.AreEqual(expect, ret);
        }

        [Test]
        public void FontFamilyTest2()
        {
            Point smallPt = new Point(359, 965);
            var touch = new RemoteTouchScreenUtils(Driver);
            touch.Down(smallPt.X, smallPt.Y);
            touch.Up(smallPt.X, smallPt.Y);
            string expect = "Sans:style=Regular";
            string ret = WebElementUtils.GetAttribute(Driver, "_editor", "FontFamily");
            Assert.AreEqual(expect, ret);
        }

        [Test]
        public void FontFamilyTest3()
        {
            Point smallPt = new Point(359, 1132);
            var touch = new RemoteTouchScreenUtils(Driver);
            touch.Down(smallPt.X, smallPt.Y);
            touch.Up(smallPt.X, smallPt.Y);
            string expect = "Sans:style=Bold";
            string ret = WebElementUtils.GetAttribute(Driver, "_editor", "FontFamily");
            Assert.AreEqual(expect, ret);
        }
    }
}
