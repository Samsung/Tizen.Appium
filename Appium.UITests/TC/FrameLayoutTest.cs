using NUnit.Framework;
using System.Drawing;

namespace Appium.UITests
{
    [TestFixture]
    public class FrameLayoutTest1 : TestTemplate
    {
        [Test]
        public void ButtonPositionTest()
        {
            Point buttonPt = Driver.GetLocation("button");
            Assert.AreEqual(361, buttonPt.X);
            Assert.AreEqual(716, buttonPt.Y);
        }

        [Test]
        public void LabelPositionTest()
        {
            Point buttonPt = Driver.GetLocation("bottomLabel");
            Assert.AreEqual(359, buttonPt.X);
            Assert.AreEqual(1223, buttonPt.Y);
        }

        [Test]
        public void BoxPositionTest()
        {
            Point topLeftBoxPt = Driver.GetLocation("topLeftBox");
            Assert.AreEqual(179, topLeftBoxPt.X);
            Assert.AreEqual(432, topLeftBoxPt.Y);

            Point topRightBoxPt = Driver.GetLocation("topRightBox");
            Assert.AreEqual(540, topRightBoxPt.X);
            Assert.AreEqual(432, topRightBoxPt.Y);
        }

        [Test]
        public void BoxSizeTest()
        {
            Size topLeftBoxPt = Driver.GetSize("topLeftBox");
            Assert.AreEqual(565, topLeftBoxPt.Height);
            Assert.AreEqual(359, topLeftBoxPt.Width);

            Size topRightBoxPt = Driver.GetSize("topRightBox");
            Assert.AreEqual(565, topRightBoxPt.Height);
            Assert.AreEqual(359, topRightBoxPt.Width);
        }
    }
}
