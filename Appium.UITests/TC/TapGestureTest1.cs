using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture]
    public class TapGestureTest1 : TestTemplate
    {
        [Test]
        public void TapImage()
        {
            bool result = false;
            Driver.Click(200, 230);
            System.Threading.Thread.Sleep(3000);
            Driver.Click("image");
            string label = Driver.GetAttribute<string>("imageLabel", "Text");
            if (label.Equals("1 tap so far!"))
            {
                result = true;
            }

            System.Threading.Thread.Sleep(2000);

            Assert.AreEqual(result, true);
        }

        [Test]
        public void TapFrame()
        {
            bool result = false;
            Driver.Click(550, 230);
            System.Threading.Thread.Sleep(3000);
            Driver.Click("frame");
            string title = Driver.GetAttribute<string>("frameLabel", "Text");
            if (title.Equals("1 tap so far!"))
            {
                result = true;
            }

            System.Threading.Thread.Sleep(2000);

            Assert.AreEqual(result, true);
        }
    }
}
