using NUnit.Framework;
using System.Drawing;

namespace Appium.UITests
{
    [TestFixture]
    public class GridTest : TestTemplate
    {
        [Test]
        public void TopLocationTest()
        {
            Point point = Driver.GetLocation("button1");
            Assert.AreEqual(360, point.X);
            Assert.AreEqual(290, point.Y);
        }

        [Test]
        public void MiddleLocationTest()
        {
            Point point = Driver.GetLocation("button2");
            Assert.AreEqual(118, point.X);
            Assert.AreEqual(573, point.Y);

            point = Driver.GetLocation("button3");
            Assert.AreEqual(359, point.X);
            Assert.AreEqual(573, point.Y);

            point = Driver.GetLocation("button4");
            Assert.AreEqual(118, point.X);
            Assert.AreEqual(857, point.Y);

            point = Driver.GetLocation("button5");
            Assert.AreEqual(359, point.X);
            Assert.AreEqual(857, point.Y);

            point = Driver.GetLocation("button6");
            Assert.AreEqual(601, point.X);
            Assert.AreEqual(714, point.Y);
        }

        [Test]
        public void BottomLocationTest()
        {
            Point point = Driver.GetLocation("button7");
            Assert.AreEqual(239, point.X);
            Assert.AreEqual(1140, point.Y);

            point = Driver.GetLocation("button8");
            Assert.AreEqual(601, point.X);
            Assert.AreEqual(1140, point.Y);
        }

        [Test]
        public void TopSizeTest()
        {
            Size area = Driver.GetSize("button1");
            Assert.AreEqual(280, area.Height);
            Assert.AreEqual(720, area.Width);
        }

        [Test]
        public void MiddleSizeTest()
        {
            Size area = Driver.GetSize("button2");
            Assert.AreEqual(280, area.Height);
            Assert.AreEqual(237, area.Width);

            area = Driver.GetSize("button3");
            Assert.AreEqual(280, area.Height);
            Assert.AreEqual(237, area.Width);

            area = Driver.GetSize("button4");
            Assert.AreEqual(280, area.Height);
            Assert.AreEqual(237, area.Width);

            area = Driver.GetSize("button5");
            Assert.AreEqual(280, area.Height);
            Assert.AreEqual(237, area.Width);

            area = Driver.GetSize("button6");
            Assert.AreEqual(563, area.Height);
            Assert.AreEqual(237, area.Width);
        }

        [Test]
        public void BottomSizeTest()
        {
            Size area = Driver.GetSize("button7");
            Assert.AreEqual(280, area.Height);
            Assert.AreEqual(479, area.Width);

            area = Driver.GetSize("button8");
            Assert.AreEqual(280, area.Height);
            Assert.AreEqual(237, area.Width);
        }
    }
}
