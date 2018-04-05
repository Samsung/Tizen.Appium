using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture]
    public class TapGestureTest3 : TestTemplate
    {
        [Test]
        public void TapImage()
        {
            bool result = false;
            Driver.Click("image");
            string label = Driver.GetAttribute<string>("label", "Text");
            if (label.Equals("1 tap so far!"))
            {
                result = true;
            }

            System.Threading.Thread.Sleep(2000);

            Assert.AreEqual(result, true);
        }

        //[Test]
        public void TapImageDouble()
        {
            bool result = false;
            Driver.Click("button");
            Driver.Click("image", 0);
            Driver.Click("image", 0);
            //WebElementUtils.ClickWithoutSleep(Driver, "image");
            //WebElementUtils.ClickWithoutSleep(Driver, "image");
            string label = Driver.GetAttribute<string>("label", "Text");
            if (label.Equals("2 taps so far!"))
            {
                result = true;
            }

            System.Threading.Thread.Sleep(2000);

            Assert.True(result);
        }
    }
}
