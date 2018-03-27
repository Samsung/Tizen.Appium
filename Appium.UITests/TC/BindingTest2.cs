using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture]
    public class BindingTest2 : TestTemplate
    {
        [Test]
        public void BindingTest()
        {
            var box1Id = "box1";
            var box2Id = "box2";
            var sliderId = "slider";
            var value = 150;

            Driver.SetAttribute(sliderId, "Value", value);

            var width1 = Driver.GetAttribute<double>(box1Id, "Width");
            var width2 = Driver.GetAttribute<double>(box2Id, "Width");

            Assert.True((width1 == value), "Height should be same with " + value);
            Assert.True((width2 == value), "Width should be same with " + value);
        }
    }
}
