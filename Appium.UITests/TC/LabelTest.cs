using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture]
    public class LabelTest : TestTemplate
    {
        [Test]
        public void ViewTest()
        {
            var elementId = "label_0";
            var x = Driver.GetAttribute<double>(elementId, "X");
            var y = Driver.GetAttribute<double>(elementId, "Y");
            var width = Driver.GetAttribute<double>(elementId, "Width");
            var height = Driver.GetAttribute<double>(elementId, "Height");
            var isVisible = Driver.GetAttribute<bool>(elementId, "IsVisible");

            Assert.True((x >= 0), "Failed x: " + x);
            Assert.True((y >= 0), "Failed y: " + y);
            Assert.True((width >= 0), "Failed width: " + width);
            Assert.True((height >= 0), "Failed height: " + height);
            Assert.True(isVisible, elementId + ".IsVisible should be true, but got " + isVisible);
        }
    }
}
