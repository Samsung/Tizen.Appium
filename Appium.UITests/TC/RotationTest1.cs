using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture]
    public class RotationTest1 : TestTemplate
    {
        [Test]
        public void RotationTest()
        {
            var elementId = "btn";
            var before = Driver.GetAttribute<string>(elementId, "Rotation");
            Driver.Click(elementId);
            var after = Driver.GetAttribute<string>(elementId, "Rotation");

            Assert.AreNotEqual(before, after, before + " should be changed to " + after);
        }
    }
}
