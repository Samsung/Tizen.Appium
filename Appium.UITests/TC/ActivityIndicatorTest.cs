using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture]
    public class ActivityIndicatorTest : TestTemplate
    {
        [Test]
        public void ColorTest()
        {
            var btnId = "button";
            var elementId = "ai";

            var color = Driver.GetAttribute<string>(elementId, "Color");

            Driver.Click(btnId);

            var color2 = Driver.GetAttribute<string>(elementId, "Color");

            Assert.AreNotEqual(color, color2);
        }
    }
}
