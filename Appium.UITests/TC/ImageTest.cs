using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture]
    public class ImageTest : TestTemplate
    {
        [Test]
        public void ImageSourceTest()
        {
            var alphaSliderId = "sldAlpha";
            var redSliderId = "sldRed";
            var greenSliderId = "sldGreen";
            var blueSliderId = "sldBlue";

            Driver.SetAttribute(alphaSliderId, "Value", 100);
            Driver.SetAttribute(redSliderId, "Value", 100);
            Driver.SetAttribute(greenSliderId, "Value", 100);
            Driver.SetAttribute(blueSliderId, "Value", 100);

            Driver.Click("btnImage1");
            string expect = "File: Icon.png";
            string ret = Driver.GetAttribute<string>("img", "Source");
            Assert.AreEqual(expect, ret);

            var image = "ImageTest.png";
            //WebElementUtils.GetScreenshotAndSave(Driver, image);
            Assert.AreEqual(true, Driver.CompareToScreenshot(image));
        }

        [Test]
        public void ImageSourceTest2()
        {
            var alphaSliderId = "sldAlpha";
            var redSliderId = "sldRed";
            var greenSliderId = "sldGreen";
            var blueSliderId = "sldBlue";

            Driver.SetAttribute(alphaSliderId, "Value", 100);
            Driver.SetAttribute(redSliderId, "Value", 100);
            Driver.SetAttribute(greenSliderId, "Value", 100);
            Driver.SetAttribute(blueSliderId, "Value", 100);

            Driver.Click("btnImage2");
            string expect = "File: b.jpg";
            string ret = Driver.GetAttribute<string>("img", "Source");
            Assert.AreEqual(expect, ret);

            var image = "ImageTest_2.png";
            //WebElementUtils.GetScreenshotAndSave(Driver, image);
            Assert.AreEqual(true, Driver.CompareToScreenshot(image));
        }

        [Test]
        public void ImageSourceTest3()
        {
            var alphaSliderId = "sldAlpha";
            var redSliderId = "sldRed";
            var greenSliderId = "sldGreen";
            var blueSliderId = "sldBlue";

            Driver.SetAttribute(alphaSliderId, "Value", 100);
            Driver.SetAttribute(redSliderId, "Value", 100);
            Driver.SetAttribute(greenSliderId, "Value", 100);
            Driver.SetAttribute(blueSliderId, "Value", 100);

            Driver.Click("btnImage3");
            string expect = "File: tizen.png";
            string ret = Driver.GetAttribute<string>("img", "Source");
            Assert.AreEqual(expect, ret);

            var image = "ImageTest_3.png";
            //WebElementUtils.GetScreenshotAndSave(Driver, image);
            Assert.AreEqual(true, Driver.CompareToScreenshot(image));
        }
    }
}
