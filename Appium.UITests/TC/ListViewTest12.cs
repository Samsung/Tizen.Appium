using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture]
    public class ListViewTest12 : TestTemplate
    {
        [Test]
        public void ViewTest()
        {
            var itemId = "99 List Item";

            var isEnabled = Driver.GetAttribute<bool>(itemId, "IsEnabled");

            while (!isEnabled)
            {
                Driver.Flick(0, -10);
                isEnabled = Driver.GetAttribute<bool>(itemId, "IsEnabled");
            }

            isEnabled = Driver.GetAttribute<bool>(itemId, "IsEnabled");
            Assert.True(isEnabled, itemId + ".isEnabled should be true, but got " + isEnabled);
        }
    }
}
