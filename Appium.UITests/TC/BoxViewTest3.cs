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
    public class BoxViewTest3
    {
        string PlatformName;
        AppiumDriver Driver;

        public BoxViewTest3(string platform)
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
        public void ViewTest()
        {
            var redSliderId = "red";
            var greenSliderId = "green";
            var blueSliderId = "blue";
            var alphaSliderId = "alpha";
            var boxId = "colorBox";
            var preboxId = "preColorBox";

            var expectedBoxVal = "[Color: A=0.588235318660736, R=0.588235318660736, G=0.588235318660736, B=0.588235318660736, Hue=0, Saturation=0, Luminosity=0.588235318660736]";
            var expectetPreBoxVal = "[Color: A=0.588235318660736, R=0.345098048448563, G=0.345098048448563, B=0.345098048448563, Hue=0, Saturation=0, Luminosity=0.345098048448563]";

            WebElementUtils.SetAttribute(Driver, redSliderId, "Value", 150);
            WebElementUtils.SetAttribute(Driver, greenSliderId, "Value", 150);
            WebElementUtils.SetAttribute(Driver, blueSliderId, "Value", 150);
            WebElementUtils.SetAttribute(Driver, alphaSliderId, "Value", 150);

            var color = WebElementUtils.GetAttribute<string>(Driver, boxId, "Color");
            var precolor = WebElementUtils.GetAttribute<string>(Driver, preboxId, "Color");

            Assert.True((expectedBoxVal == color), "Normal box color should be " + expectedBoxVal);
            Assert.True((expectetPreBoxVal == precolor), "Pre-multiplied box color should be " + expectetPreBoxVal);

            //screenshot
        }
    }
}
