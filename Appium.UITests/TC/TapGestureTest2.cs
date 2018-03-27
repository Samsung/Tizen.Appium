using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture]
    public class TapGestureTest2 : TestTemplate
    {
        [Test]
        public void RotateImageByTap()
        {
            Driver.Click("image");

            var rotation = Driver.GetAttribute<double>("image", "Rotation");
            Assert.AreEqual(rotation, 45);
        }

        [Test]
        public void ScaleImageByTap()
        {
            Driver.Click("image", 0);
            Driver.Click("image");

            System.Threading.Thread.Sleep(2000);
            var scale = Driver.GetAttribute<double>("image", "Scale");
            Assert.AreEqual(scale, 1.5);
        }

        [Test]
        public void TurnedToOriginalStateByTap()
        {
            Driver.Click("image", 0);
            Driver.Click("image", 0);
            Driver.Click("image");

            var rotation = Driver.GetAttribute<double>("image", "Rotation");
            var scale = Driver.GetAttribute<double>("image", "Scale");

            Assert.AreEqual(rotation, 0);
            Assert.AreEqual(scale, 1);
        }
    }
}
