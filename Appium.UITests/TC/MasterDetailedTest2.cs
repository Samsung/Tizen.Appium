using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture]
    public class MasterDetailedTest2 : TestTemplate
    {
        [Test]
        public void ViewTest()
        {
            var pageId = "MasterDetailPage";
            var itemId = "[Color: A=1, R=0, G=0, B=0, Hue=0, Saturation=0, Luminosity=0]";
            var detailPageId = "DetailPage";

            var isPresented = Driver.GetAttribute<bool>(pageId, "IsPresented");
            if (!isPresented)
            {
                Driver.Drag(0, 500, 300, 500);
            }

            Driver.Click(itemId);

            var color = Driver.GetAttribute<string>(detailPageId, "BackgroundColor");
            Assert.True((color == itemId), itemId + " is expected, but got " + color);
        }
    }
}
