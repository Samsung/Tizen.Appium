using NUnit.Framework;
using System.Drawing;

namespace Appium.UITests
{
    [TestFixture]
    public class BoxViewTest2 : TestTemplate
    {
        [Test]
        public void PositionTest1()
        {
            Point expect = new Point(360, 189);
            Point pt = Driver.GetLocation("BoxView1");
            Assert.AreEqual(expect, pt);
        }

        [Test]
        public void PositionTest2()
        {
            Point expect = new Point(360, 280);
            Point pt = Driver.GetLocation("BoxView2");
            Assert.AreEqual(expect, pt);
        }

        [Test]
        public void PositionTest3()
        {
            Point expect = new Point(360, 371);
            Point pt = Driver.GetLocation("BoxView3");
            Assert.AreEqual(expect, pt);
        }

        [Test]
        public void PositionTest4()
        {
            Point expect = new Point(39, 1046);
            Point pt = Driver.GetLocation("BoxView4");
            Assert.AreEqual(expect, pt);
        }

        [Test]
        public void PositionTest5()
        {
            Point expect = new Point(130, 1046);
            Point pt = Driver.GetLocation("BoxView5");
            Assert.AreEqual(expect, pt);
        }

        [Test]
        public void PositionTest6()
        {
            Point expect = new Point(221, 1046);
            Point pt = Driver.GetLocation("BoxView6");
            Assert.AreEqual(expect, pt);
        }
    }
}
