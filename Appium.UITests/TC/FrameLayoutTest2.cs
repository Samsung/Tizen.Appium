using NUnit.Framework;
using System.Drawing;

namespace Appium.UITests
{
    [TestFixture]
    public class FrameLayoutTest2 : TestTemplate
    {
        [Test]
        public void TopBoxPositionTest()
        {
            Point topLeftBox = Driver.GetLocation("topLeftBox");
            Assert.AreEqual(69, topLeftBox.X);
            Assert.AreEqual(219, topLeftBox.Y);

            Point topCenterBox = Driver.GetLocation("topCenterBox");
            Assert.AreEqual(359, topCenterBox.X);
            Assert.AreEqual(219, topCenterBox.Y);

            Point topRightBox = Driver.GetLocation("topRightBox");
            Assert.AreEqual(651, topRightBox.X);
            Assert.AreEqual(219, topRightBox.Y);
        }

        [Test]
        public void BottomBoxPositionTest()
        {
            Point bottomLeftBox = Driver.GetLocation("bottomLeftBox");
            Assert.AreEqual(69, bottomLeftBox.X);
            Assert.AreEqual(1210, bottomLeftBox.Y);

            Point bottomCenterBox = Driver.GetLocation("bottomCenterBox");
            Assert.AreEqual(359, bottomCenterBox.X);
            Assert.AreEqual(1210, bottomCenterBox.Y);

            Point bottomRightBox = Driver.GetLocation("bottomRightBox");
            Assert.AreEqual(651, bottomRightBox.X);
            Assert.AreEqual(1210, bottomRightBox.Y);
        }

        [Test]
        public void BoxSizeTest()
        {
            Size leftBGBox = Driver.GetSize("leftBGBox");
            Assert.AreEqual(442, leftBGBox.Height);
            Assert.AreEqual(86, leftBGBox.Width);

            Size rightBGBox = Driver.GetSize("rightBGBox");
            Assert.AreEqual(442, rightBGBox.Height);
            Assert.AreEqual(86, rightBGBox.Width);
        }
    }
}
