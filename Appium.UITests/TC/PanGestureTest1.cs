using System;
using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture(FormsTizenGalleryUtils.Platform)]
    public class PanGestureTest1
    {
        string PlatformName;
        AppiumDriver Driver;

        public PanGestureTest1(string platform)
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
            var containerId = "panContainer";
            var imageId = "image";

            var x = Convert.ToInt32(WebElementUtils.GetAttribute(Driver, containerId, "X"));
            var y = Convert.ToInt32(WebElementUtils.GetAttribute(Driver, containerId, "Y"));
            var width = Convert.ToDouble(WebElementUtils.GetAttribute(Driver, containerId, "Width"));
            var height = Convert.ToDouble(WebElementUtils.GetAttribute(Driver, containerId, "Height"));

            Console.WriteLine("x={0}, y={1}, width ={2}, height={3}", x, y, width, height);
            x = x + (int)(width / 2);
            y = y + (int)(height / 2);

            var beforeX = Convert.ToInt32(WebElementUtils.GetAttribute(Driver, imageId, "TranslationX"));
            var beforeY = Convert.ToInt32(WebElementUtils.GetAttribute(Driver, imageId, "TranslationY"));

            var touchScreen = new RemoteTouchScreenUtils(Driver);
            Console.WriteLine("x={0}, y={1},", x, y);
            touchScreen.Drag(x, y, x - 100, y - 100);

            var afterX = Convert.ToInt32(WebElementUtils.GetAttribute(Driver, imageId, "TranslationX"));
            var afterY = Convert.ToInt32(WebElementUtils.GetAttribute(Driver, imageId, "TranslationY"));

            Console.WriteLine("beforeX={0}, beforeY={1}, afterX={2}, afterY={3}", beforeX, beforeY, afterX, afterY);

            Assert.True(beforeX != afterX, beforeX + " should be changed to " + afterX);
            Assert.True(beforeY != afterY, beforeY + " should be changed to " + afterY);
        }
    }
}
