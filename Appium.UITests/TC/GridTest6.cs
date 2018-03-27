using NUnit.Framework;
using System.Drawing;

namespace Appium.UITests
{
    [TestFixture]
    public class GridTest6 : TestTemplate
    {
        [Test]
        public void AddRowTest()
        {
            Point point = Driver.GetLocation("button8");
            Size area = Driver.GetSize("button8");

            Driver.Click("AddRow");

            Point point2 = Driver.GetLocation("button8");
            Size area2 = Driver.GetSize("button8");

            Assert.AreNotEqual(point, point2);
            Assert.AreNotEqual(area, area2);
        }

        [Test]
        public void AddColumnTest()
        {
            Point point = Driver.GetLocation("button8");
            Size area = Driver.GetSize("button8");

            Driver.Click("Addcolumn");

            Point point2 = Driver.GetLocation("button8");
            Size area2 = Driver.GetSize("button8");

            Assert.AreNotEqual(point, point2);
            Assert.AreNotEqual(area, area2);
        }
    }
}
