using NUnit.Framework;
using System.Drawing;

namespace Appium.UITests
{
    [TestFixture]
    public class GridTest4 : TestTemplate
    {
        [Test]
        public void LocationTest()
        {
            Point point = Driver.GetLocation("button1");
            Assert.AreEqual(360, point.X);
            Assert.AreEqual(199, point.Y);

            point = Driver.GetLocation("button2");
            Assert.AreEqual(296, point.X);
            Assert.AreEqual(510, point.Y);

            point = Driver.GetLocation("button3");
            Assert.AreEqual(647, point.X);
            Assert.AreEqual(510, point.Y);

            point = Driver.GetLocation("button4");
            Assert.AreEqual(296, point.X);
            Assert.AreEqual(1025, point.Y);

            point = Driver.GetLocation("button5");
            Assert.AreEqual(647, point.X);
            Assert.AreEqual(1025, point.Y);

            point = Driver.GetLocation("button6");
            Assert.AreEqual(711, point.X);
            Assert.AreEqual(767, point.Y);
        }

        [Test]
        public void SizeTest()
        {
            Size area = Driver.GetSize("button1");
            Assert.AreEqual(99, area.Height);
            Assert.AreEqual(720, area.Width);

            area = Driver.GetSize("button2");
            Assert.AreEqual(510, area.Height);
            Assert.AreEqual(592, area.Width);

            area = Driver.GetSize("button3");
            Assert.AreEqual(510, area.Height);
            Assert.AreEqual(99, area.Width);

            area = Driver.GetSize("button4");
            Assert.AreEqual(510, area.Height);
            Assert.AreEqual(592, area.Width);

            area = Driver.GetSize("button5");
            Assert.AreEqual(510, area.Height);
            Assert.AreEqual(99, area.Width);

            area = Driver.GetSize("button6");
            Assert.AreEqual(1025, area.Height);
            Assert.AreEqual(17, area.Width);
        }
    }
}
