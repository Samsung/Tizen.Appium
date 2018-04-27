using NUnit.Framework;
using System.Drawing;

namespace Appium.UITests
{
    [TestFixture]
    public class GridTest5 : TestTemplate
    {
        //[Test]
        public void LableLocationTest()
        {
            Point point = Driver.GetLocation("label1");
            Assert.AreEqual(358, point.X);
            Assert.AreEqual(216, point.Y);

            point = Driver.GetLocation("label2");
            Assert.AreEqual(108, point.X);
            Assert.AreEqual(273, point.Y);

            point = Driver.GetLocation("label3");
            Assert.AreEqual(349, point.X);
            Assert.AreEqual(683, point.Y);

            point = Driver.GetLocation("label4");
            Assert.AreEqual(602, point.X);
            Assert.AreEqual(657, point.Y);

            point = Driver.GetLocation("label5");
            Assert.AreEqual(255, point.X);
            Assert.AreEqual(1172, point.Y);

            point = Driver.GetLocation("label6");
            Assert.AreEqual(602, point.X);
            Assert.AreEqual(1172, point.Y);
        }

        [Test]
        public void BoxLocationTest()
        {
            Point point = Driver.GetLocation("BoxView1");
            Assert.AreEqual(349, point.X);
            Assert.AreEqual(259, point.Y);

            point = Driver.GetLocation("BoxView2");
            Assert.AreEqual(108, point.X);
            Assert.AreEqual(676, point.Y);
        }

        //[Test]
        public void LabelSizeTest()
        {
            Size area = Driver.GetSize("label1");
            Assert.AreEqual(26, area.Height);
            Assert.AreEqual(36, area.Width);

            area = Driver.GetSize("label2");
            Assert.AreEqual(19, area.Height);
            Assert.AreEqual(89, area.Width);

            area = Driver.GetSize("label3");
            Assert.AreEqual(383, area.Height);
            Assert.AreEqual(143, area.Width);

            area = Driver.GetSize("label4");
            Assert.AreEqual(408, area.Height);
            Assert.AreEqual(100, area.Width);

            area = Driver.GetSize("label5");
            Assert.AreEqual(100, area.Height);
            Assert.AreEqual(238, area.Width);

            area = Driver.GetSize("label6");
            Assert.AreEqual(100, area.Height);
            Assert.AreEqual(100, area.Width);
        }

        [Test]
        public void BoxSizeTest()
        {
            Size area = Driver.GetSize("BoxView1");
            Assert.AreEqual(38, area.Height);
            Assert.AreEqual(283, area.Width);

            area = Driver.GetSize("BoxView2");
            Assert.AreEqual(772, area.Height);
            Assert.AreEqual(176, area.Width);
        }
    }
}
