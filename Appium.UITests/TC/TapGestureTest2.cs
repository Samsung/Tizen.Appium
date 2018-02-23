using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture(FormsTizenGalleryUtils.Platform)]
    public class TapGestureTest2
    {
        string PlatformName;
        AppiumDriver Driver;

        public TapGestureTest2(string platform)
        {
            PlatformName = platform;
        }

        [TestFixtureSetUp]
        public void Setup()
        {
            Driver = new AppiumDriver(PlatformName);
            FormsTizenGalleryUtils.FindTC(Driver, this.GetType().Name);
        }

        [TestFixtureTearDown]
        public void TearDown()
        {
            Driver.Quit();
        }

        [Test]
        public void RotateImageByTap()
        {
            bool result = false;
            WebElementUtils.ClickWithoutSleep(Driver, "image");
            var rotation = WebElementUtils.GetAttribute(Driver, "image", "Rotation");
            if (rotation.Equals("45"))
            {
                result = true;
            }

            System.Threading.Thread.Sleep(2000);

            Assert.AreEqual(result, true);
        }

        [Test]
        public void ScaleImageByTap()
        {
            bool result = false;
            WebElementUtils.ClickWithoutSleep(Driver, "image");
            WebElementUtils.ClickWithoutSleep(Driver, "image");
            var scale = WebElementUtils.GetAttribute(Driver, "image", "Scale");
            if (scale.Equals("1.5"))
            {
                result = true;
            }

            System.Threading.Thread.Sleep(2000);

            Assert.AreEqual(result, true);
        }

        [Test]
        public void TurnedToOriginalStateByTap()
        {
            bool result = false;
            WebElementUtils.ClickWithoutSleep(Driver, "image");
            WebElementUtils.ClickWithoutSleep(Driver, "image");
            WebElementUtils.ClickWithoutSleep(Driver, "image");
            var rotation = WebElementUtils.GetAttribute(Driver, "image", "Rotation");
            var scale = WebElementUtils.GetAttribute(Driver, "image", "Scale");
            if (scale.Equals("1") && rotation.Equals("0"))
            {
                result = true;
            }

            System.Threading.Thread.Sleep(2000);

            Assert.AreEqual(result, true);
        }
    }
}
