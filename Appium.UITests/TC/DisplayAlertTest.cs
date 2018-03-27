using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture]
    public class DisplayAlertTest : TestTemplate
    {
        [Test]
        public void DisplayAlertOKTest()
        {
            Driver.Click("button");
            Driver.Click(366, 1201);
        }

        [Test]
        public void DisplayAlertCancelTest()
        {
            Driver.Click("button2");
            Driver.Click(217, 1201);
        }
    }
}
