using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture]
    public class ListViewTest10 : TestTemplate
    {
        [Test]
        public void HeightTest()
        {
            var item100Id = "Height 100";

            var height = Driver.GetAttribute<double>(item100Id, "Height");
            Assert.True(height == 100, item100Id + ".Height should be 100, but got " + height);

            var image = "ListViewTest10.png";
            //WebElementUtils.GetScreenshotAndSave(Driver, image);
            Assert.AreEqual(true, Driver.CompareToScreenshot(image));
        }
    }
}
