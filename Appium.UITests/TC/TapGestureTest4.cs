using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture]
    public class TapGestureTest4 : TestTemplate
    {
        [Test]
        public void TapImage()
        {
            bool result = false;
            Driver.Click("image");
            string label = Driver.GetAttribute<string>("result", "Text");
            if (label.Equals("An image is tapped."))
            {
                result = true;
            }

            System.Threading.Thread.Sleep(2000);

            Assert.AreEqual(result, true);
        }

        [Test]
        public void TapBoxView()
        {
            bool result = false;
            Driver.Click("boxView");
            string label = Driver.GetAttribute<string>("result", "Text");
            if (label.Equals("A boxView is tapped."))
            {
                result = true;
            }

            System.Threading.Thread.Sleep(2000);

            Assert.AreEqual(result, true);
        }

        [Test]
        public void TapButton()
        {
            bool result = false;
            Driver.Click("button");
            string label = Driver.GetAttribute<string>("result", "Text");
            if (label.Equals("A button is tapped."))
            {
                result = true;
            }

            System.Threading.Thread.Sleep(2000);

            Assert.AreEqual(result, true);
        }

        [Test]
        public void TapLabel()
        {
            bool result = false;
            Driver.Click("label");
            string label = Driver.GetAttribute<string>("result", "Text");
            if (label.Equals("A label is tapped."))
            {
                result = true;
            }

            System.Threading.Thread.Sleep(2000);

            Assert.AreEqual(result, true);
        }
    }
}
