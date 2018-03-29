using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture]
    public class BoxViewTest3 : TestTemplate
    {
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

            Driver.SetAttribute(redSliderId, "Value", 150);
            Driver.SetAttribute(greenSliderId, "Value", 150);
            Driver.SetAttribute(blueSliderId, "Value", 150);
            Driver.SetAttribute(alphaSliderId, "Value", 150);

            var color = Driver.GetAttribute<string>(boxId, "Color");
            var precolor = Driver.GetAttribute<string>(preboxId, "Color");

            Assert.True((expectedBoxVal == color), "Normal box color should be " + expectedBoxVal);
            Assert.True((expectetPreBoxVal == precolor), "Pre-multiplied box color should be " + expectetPreBoxVal);

            var image = "BoxViewTest3.png";

            Driver.CheckScreenshot(image);
        }
    }
}
