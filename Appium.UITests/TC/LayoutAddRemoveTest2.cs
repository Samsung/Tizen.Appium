using System;
using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture(FormsTizenGalleryUtils.Platform)]
    public class LayoutAddRemoveTest2
    {
        string PlatformName;
        AppiumDriver Driver;

        public LayoutAddRemoveTest2(string platform)
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
        public void AddTest()
        {
            var btnId = "addbtn";

            WebElementUtils.Click(Driver, btnId);

            //screenshot
        }

        [Test]
        public void AddTaskTest()
        {
            var btnId = "addtaskbtn";

            WebElementUtils.Click(Driver, btnId);

            //screenshot
        }

        [Test]
        public void RemoveTest()
        {
            var addBtnId = "addbtn";
            var removeBtnId = "removebtn";

            WebElementUtils.Click(Driver, addBtnId);
            WebElementUtils.Click(Driver, removeBtnId);

            //screenshot
        }
    }
}
