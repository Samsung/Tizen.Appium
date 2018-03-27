using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture]
    public class PageDisplayAlertTest1 : TestTemplate
    {
        //[Test]
        public void CancleTest()
        {
            var btnId = "cancelOnlyButton";

            Driver.Click(btnId);

            //screenshot
            //not working displayalert

            Driver.GoBack();
            System.Threading.Thread.Sleep(1000);
        }

        //[Test]
        public void CancleAcceptTest()
        {
            var btnId = "cancelAceeptButton";

            Driver.Click(btnId);

            //screenshot
            //not working displayalert
            Driver.GoBack();
            System.Threading.Thread.Sleep(1000);
        }
    }
}
