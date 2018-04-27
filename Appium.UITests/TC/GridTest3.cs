using NUnit.Framework;
using System.Drawing;

namespace Appium.UITests
{
    [TestFixture]
    public class GridTest3 : TestTemplate
    {
        [Test]
        public void OperationLocationTest()
        {
            Point point = Driver.GetLocation("*");
            Assert.AreEqual(633, point.X);
            Assert.AreEqual(769, point.Y);

            point = Driver.GetLocation("-");
            Assert.AreEqual(633, point.X);
            Assert.AreEqual(916, point.Y);

            point = Driver.GetLocation("+");
            Assert.AreEqual(633, point.X);
            Assert.AreEqual(1063, point.Y);

            point = Driver.GetLocation("/");
            Assert.AreEqual(633, point.X);
            Assert.AreEqual(622, point.Y);
        }

        [Test]
        public void NumberButtonLocationTest()
        {
            Point point = Driver.GetLocation("1");
            Assert.AreEqual(87, point.X);
            Assert.AreEqual(1063, point.Y);

            point = Driver.GetLocation("2");
            Assert.AreEqual(269, point.X);
            Assert.AreEqual(1063, point.Y);

            point = Driver.GetLocation("3");
            Assert.AreEqual(451, point.X);
            Assert.AreEqual(1063, point.Y);

            point = Driver.GetLocation("4");
            Assert.AreEqual(87, point.X);
            Assert.AreEqual(916, point.Y);

            point = Driver.GetLocation("5");
            Assert.AreEqual(269, point.X);
            Assert.AreEqual(916, point.Y);

            point = Driver.GetLocation("6");
            Assert.AreEqual(451, point.X);
            Assert.AreEqual(916, point.Y);

            point = Driver.GetLocation("7");
            Assert.AreEqual(87, point.X);
            Assert.AreEqual(769, point.Y);

            point = Driver.GetLocation("8");
            Assert.AreEqual(269, point.X);
            Assert.AreEqual(769, point.Y);

            point = Driver.GetLocation("9");
            Assert.AreEqual(451, point.X);
            Assert.AreEqual(769, point.Y);
        }

        [Test]
        public void OperationSizeTest()
        {
            Size area = Driver.GetSize("*");
            Assert.AreEqual(139, area.Height);
            Assert.AreEqual(174, area.Width);

            area = Driver.GetSize("-");
            Assert.AreEqual(139, area.Height);
            Assert.AreEqual(174, area.Width);

            area = Driver.GetSize("+");
            Assert.AreEqual(139, area.Height);
            Assert.AreEqual(174, area.Width);

            area = Driver.GetSize("/");
            Assert.AreEqual(139, area.Height);
            Assert.AreEqual(174, area.Width);
        }

        [Test]
        public void BottomSizeTest()
        {
            Size area = Driver.GetSize("1");
            Assert.AreEqual(139, area.Height);
            Assert.AreEqual(174, area.Width);

            area = Driver.GetSize("2");
            Assert.AreEqual(139, area.Height);
            Assert.AreEqual(174, area.Width);

            area = Driver.GetSize("3");
            Assert.AreEqual(139, area.Height);
            Assert.AreEqual(174, area.Width);

            area = Driver.GetSize("4");
            Assert.AreEqual(139, area.Height);
            Assert.AreEqual(174, area.Width);

            area = Driver.GetSize("5");
            Assert.AreEqual(139, area.Height);
            Assert.AreEqual(174, area.Width);

            area = Driver.GetSize("6");
            Assert.AreEqual(139, area.Height);
            Assert.AreEqual(174, area.Width);

            area = Driver.GetSize("7");
            Assert.AreEqual(139, area.Height);
            Assert.AreEqual(174, area.Width);

            area = Driver.GetSize("8");
            Assert.AreEqual(139, area.Height);
            Assert.AreEqual(174, area.Width);

            area = Driver.GetSize("9");
            Assert.AreEqual(139, area.Height);
            Assert.AreEqual(174, area.Width);
        }
    }
}
