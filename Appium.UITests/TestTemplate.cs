using NUnit.Framework;

namespace Appium.UITests
{
    public class TestTemplate
    {
        public UITestDriver Driver;

        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            Driver = UITestDriver.Instance;
            Driver.FindTC(this.GetType().Name);
        }

        [TestFixtureTearDown]
        public void TestFixtureTearDown()
        {
            Driver.GoHomePage();
        }

        [TearDown]
        public void TearDown()
        {
            System.Threading.Thread.Sleep(1000);
        }
    }
}
