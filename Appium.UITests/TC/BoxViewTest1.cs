using NUnit.Framework;
using System.Drawing;

namespace Appium.UITests
{
    [TestFixture]
    public class BoxViewTest1 : TestTemplate
    {
        [Test]
        public void PositionTest1()
        {
            Point expect = new Point(360, 288);
            Point pt = Driver.GetLocation("BoxView1");
            Assert.AreEqual(expect, pt);
        }

        [Test]
        public void PositionTest2()
        {
            Point expect = new Point(360, 387);
            Point pt = Driver.GetLocation("BoxView2");
            Assert.AreEqual(expect, pt);
        }

        [Test]
        public void PositionTest3()
        {
            Point expect = new Point(360, 485);
            Point pt = Driver.GetLocation("BoxView3");
            Assert.AreEqual(expect, pt);
        }
    }
}
