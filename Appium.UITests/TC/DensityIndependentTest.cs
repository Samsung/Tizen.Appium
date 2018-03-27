using NUnit.Framework;
using System.Drawing;

namespace Appium.UITests
{
    [TestFixture]
    public class DensityIndependentTest : TestTemplate
    {
        [Test]
        public void BoxViewPositionTest()
        {
            Point expect = new Point(197, 411);
            Point ret = Driver.GetLocation("box");
            Assert.AreEqual(expect, ret);
        }

        [Test]
        public void LabelPositionTest()
        {
            Point expect = new Point(197, 491);
            Point ret = Driver.GetLocation("boxLabel");
            Assert.AreEqual(expect, ret);
        }

        [Test]
        public void BoxViewSizeTest()
        {
            double w = Driver.GetAttribute<double>("box", "Width");
            double h = Driver.GetAttribute<double>("box", "Height");
            Assert.AreEqual(200, w);
            Assert.AreEqual(200, h);
        }

        [Test]
        public void LabelSizeTest()
        {
            double w = Driver.GetAttribute<double>("boxLabel", "Width");
            double h = Driver.GetAttribute<double>("boxLabel", "Height");
            Assert.AreEqual(200, w);
            Assert.AreEqual(100, h);
        }
    }
}
