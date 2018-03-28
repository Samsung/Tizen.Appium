using NUnit.Framework;
using System;

namespace Appium.UITests
{
    [TestFixture]
    public class MasterDetailedTest1 : TestTemplate
    {
        [Test]
        public void ViewTest()
        {
            var pageId = "MasterDetailPage";

            var isPresented = Driver.GetAttribute<bool>(pageId, "IsPresented");

            if (!isPresented)
            {
                Driver.Drag(0, 500, 300, 500);
            }

            isPresented = Driver.GetAttribute<bool>(pageId, "IsPresented");
            Assert.True(Convert.ToBoolean(isPresented), "IsPresented should be true, but got " + isPresented);

            var image = "MasterDetailedTest1.png";
            Driver.CheckScreenshot(image);
        }
    }
}
