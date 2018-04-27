using NUnit.Framework;
using System.Drawing;

namespace Appium.UITests
{
    [TestFixture]
    public class EntryTest4 : TestTemplate
    {
        [Test]
        public void FirstPageTest()
        {
            Point entryPt = Driver.GetLocation("entry");
            Assert.AreEqual(360, entryPt.X);
            Assert.AreEqual(354, entryPt.Y);

            Point labelPt = Driver.GetLocation("label");
            Assert.AreEqual(360, labelPt.X);
            Assert.AreEqual(462, labelPt.Y);

            Point buttonPt = Driver.GetLocation("button");
            Assert.AreEqual(70, buttonPt.X);
            Assert.AreEqual(659, buttonPt.Y);
        }

        [Test]
        public void SecondPageTest()
        {
            Driver.Click(545, 229);

            Point entryPt = Driver.GetLocation("test1");
            Assert.AreEqual(99, entryPt.X);
            Assert.AreEqual(333, entryPt.Y);

            Point labelPt = Driver.GetLocation("test2");
            Assert.AreEqual(310, labelPt.X);
            Assert.AreEqual(333, labelPt.Y);

            Point buttonPt = Driver.GetLocation("label");
            Assert.AreEqual(565, buttonPt.X);
            Assert.AreEqual(333, buttonPt.Y);
        }
    }
}
