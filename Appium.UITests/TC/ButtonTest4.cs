using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture]
    public class ButtonTest4 : TestTemplate
    {
        [Test]
        public void ClickTest()
        {
            Driver.Click("button1");
            Driver.Click("button2");

            Driver.Flick(0, -3);

            Driver.Click("button3");
            Driver.Click("button4");

            Driver.Flick(0, -7);
        }
    }
}
