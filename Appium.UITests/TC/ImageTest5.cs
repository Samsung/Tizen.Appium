using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture]
    public class ImageTest5 : TestTemplate
    {
        [Test]
        public void WidthUpTest()
        {
            double ret = Driver.GetAttribute<double>("image", "Width");
            Driver.Click("widthUpBtn");
            double ret2 = Driver.GetAttribute<double>("image", "Width");
            Assert.AreNotEqual(ret, ret2);
        }

        [Test]
        public void WidthDownTest()
        {
            double ret = Driver.GetAttribute<double>("image", "Width");
            Driver.Click("widthDownBtn");
            double ret2 = Driver.GetAttribute<double>("image", "Width");
            Assert.AreNotEqual(ret, ret2);
            Driver.Click("widthUpBtn");
        }

        [Test]
        public void HeightUpTest()
        {
            double ret = Driver.GetAttribute<double>("image", "Height");
            Driver.Click("heightUpBtn");
            double ret2 = Driver.GetAttribute<double>("image", "Height");
            Assert.AreNotEqual(ret, ret2);
        }

        [Test]
        public void HeightDownTest()
        {
            double ret = Driver.GetAttribute<double>("image", "Height");
            Driver.Click("heightDownBtn");
            double ret2 = Driver.GetAttribute<double>("image", "Height");
            Assert.AreNotEqual(ret, ret2);
            Driver.Click("heightUpBtn");
        }
    }
}
