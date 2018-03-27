using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture]
    public class SimpleTest : TestTemplate
    {
        [Test]
        public void ViewTest()
        {
            var btnId = "button";
            var labelId = "label";
            var expected = "click count: 1";

            Driver.Click(btnId);

            var text = Driver.GetAttribute<string>(labelId, "Text");

            Assert.True((text == expected), "expected: " + expected + ", but got " + text);
        }
    }
}
