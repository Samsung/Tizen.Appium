using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture]
    public class SearchBarTest1 : TestTemplate
    {
        [Test]
        public void ScrollWithoutAnimationTest()
        {
            var searchBarBtnId = "searchBar";

            Driver.SetText(searchBarBtnId, "test");
            System.Threading.Thread.Sleep(2000);

            var image = "SearchBarTest1.png";
            //WebElementUtils.GetScreenshotAndSave(Driver, image);
            Assert.AreEqual(true, Driver.CompareToScreenshot(image));
        }
    }
}
