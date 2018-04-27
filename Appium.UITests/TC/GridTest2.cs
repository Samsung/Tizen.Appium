using NUnit.Framework;
using System.Drawing;

namespace Appium.UITests
{
    [TestFixture]
    public class GridTest2 : TestTemplate
    {
        [Test]
        public void TopLocationTest()
        {
            Point point = Driver.GetLocation("button1");
            Assert.AreEqual(360, point.X);
            Assert.AreEqual(199, point.Y);
        }

        [Test]
        public void BottomLocationTest()
        {
            Point point = Driver.GetLocation("button2");
            Assert.AreEqual(118, point.X);
            Assert.AreEqual(510, point.Y);

            point = Driver.GetLocation("button3");
            Assert.AreEqual(360, point.X);
            Assert.AreEqual(510, point.Y);

            point = Driver.GetLocation("button4");
            Assert.AreEqual(118, point.X);
            Assert.AreEqual(1025, point.Y);

            point = Driver.GetLocation("button5");
            Assert.AreEqual(360, point.X);
            Assert.AreEqual(1025, point.Y);

            point = Driver.GetLocation("button6");
            Assert.AreEqual(602, point.X);
            Assert.AreEqual(767, point.Y);
        }

        [Test]
        public void TopSizeTest()
        {
            Size area = Driver.GetSize("button1");
            Assert.AreEqual(99, area.Height);
            Assert.AreEqual(720, area.Width);
        }

        [Test]
        public void BottomSizeTest()
        {
            Size area = Driver.GetSize("button2");
            Assert.AreEqual(510, area.Height);
            Assert.AreEqual(236, area.Width);

            area = Driver.GetSize("button3");
            Assert.AreEqual(510, area.Height);
            Assert.AreEqual(236, area.Width);

            area = Driver.GetSize("button4");
            Assert.AreEqual(510, area.Height);
            Assert.AreEqual(236, area.Width);

            area = Driver.GetSize("button5");
            Assert.AreEqual(510, area.Height);
            Assert.AreEqual(236, area.Width);

            area = Driver.GetSize("button6");
            Assert.AreEqual(1025, area.Height);
            Assert.AreEqual(236, area.Width);
        }
    }
}
