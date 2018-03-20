using System;
using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture(FormsTizenGalleryUtils.Platform)]
    public class ScrollViewTest7
    {
        string PlatformName;
        AppiumDriver Driver;

        public ScrollViewTest7(string platform)
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
        public void RandomScrollTest()
        {
            var randomScrollBtnId = "button";
            var scrollViewId = "scrollView";

            var yBefore = WebElementUtils.GetAttribute<double>(Driver, scrollViewId, "ScrollY");

            WebElementUtils.Click(Driver, randomScrollBtnId);

            var yAfter = WebElementUtils.GetAttribute<double>(Driver, scrollViewId, "ScrollY");

            Assert.True((yBefore < yAfter), "Y value should be incresed, but got before: " + yBefore + ", after: " + yAfter);
            //screenshot
        }
    }
}
