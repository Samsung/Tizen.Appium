using NUnit.Framework;
using System;

namespace Appium.UITests
{
    [TestFixture]
    public class PanGestureTest1 : TestTemplate
    {
        [Test]
        public void ViewTest()
        {
            var containerId = "panContainer";
            var imageId = "image";

            int x = Driver.GetAttribute<int>(containerId, "X");
            int y = Driver.GetAttribute<int>(containerId, "Y");
            double width = Driver.GetAttribute<double>(containerId, "Width");
            double height = Driver.GetAttribute<double>(containerId, "Height");

            Console.WriteLine("x={0}, y={1}, width ={2}, height={3}", x, y, width, height);
            x = x + (int)(width / 2);
            y = y + (int)(height / 2);

            int beforeX = Driver.GetAttribute<int>(imageId, "TranslationX");
            int beforeY = Driver.GetAttribute<int>(imageId, "TranslationY");

            Console.WriteLine("x={0}, y={1},", x, y);
            Driver.Drag(x, y, x - 100, y - 100);

            int afterX = Driver.GetAttribute<int>(imageId, "TranslationX");
            int afterY = Driver.GetAttribute<int>(imageId, "TranslationY");

            Console.WriteLine("beforeX={0}, beforeY={1}, afterX={2}, afterY={3}", beforeX, beforeY, afterX, afterY);

            Assert.True(beforeX != afterX, beforeX + " should be changed to " + afterX);
            Assert.True(beforeY != afterY, beforeY + " should be changed to " + afterY);
        }
    }
}
