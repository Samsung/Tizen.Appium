using System;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Tizen;
using OpenQA.Selenium.Appium.Android;
using NUnit.Framework;
using System.Drawing;

namespace Xamarin.Issues.UITests
{
    [TestFixture(TestScriptUtils.Platform)]
    public class PickerTests_TextColor_Picker_UILK
    {
        string PlatformName;
        AppiumDriver Driver;

        public PickerTests_TextColor_Picker_UILK(string platform)
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
        public void PickerTest()
        {
            // Picker clicked
            Point pt = new Point(505, 189);
            var touch = new RemoteTouchScreenUtils(Driver);
            touch.Down(pt.X, pt.Y);
            touch.Up(pt.X, pt.Y);

            // Aqua clicked
            Point pt2 = new Point(420, 793);
            touch.Down(pt.X, pt.Y);
            touch.Up(pt.X, pt.Y);

            string ret = WebElementUtils.GetAttribute(Driver, "_picker", "SelectedItem");
            string expect = "Aqua";
            Assert.AreEqual(expect, ret);
        }
    }
}
