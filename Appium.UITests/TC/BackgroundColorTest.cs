using System;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Tizen;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Remote;
using NUnit.Framework;
using System.Drawing;

namespace Appium.UITests
{
    [TestFixture(FormsTizenGalleryUtils.Platform)]
    public class BackgroundColorTest
    {
        string PlatformName;
        AppiumDriver Driver;

        public BackgroundColorTest(string platform)
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
        public void ButtonBackgroundTest()
        {
            string expect = "[Color: A=1, R=0, G=0, B=0, Hue=0, Saturation=0, Luminosity=0]";
            string result = WebElementUtils.GetAttribute(Driver, "button1", "BackgroundColor");
            Assert.AreEqual(expect, result);
        }

        [Test]
        public void ActivityIndicatorBackgroundTest()
        {
            string expect = "[Color: A=1, R=0, G=0, B=1, Hue=0.666666686534882, Saturation=1, Luminosity=0.5]";
            string result = WebElementUtils.GetAttribute(Driver, "ai", "BackgroundColor");
            Assert.AreEqual(expect, result);
        }

        [Test]
        public void ButtonBackgroundTest2()
        {
            string expect = "[Color: A=1, R=1, G=0, B=0, Hue=1, Saturation=1, Luminosity=0.5]";
            string result = WebElementUtils.GetAttribute(Driver, "Button2", "BackgroundColor");
            Assert.AreEqual(expect, result);
        }

        [Test]
        public void ButtonBackgroundTest3()
        {
            string expect = "[Color: A=1, R=0, G=0, B=1, Hue=0.666666686534882, Saturation=1, Luminosity=0.5]";
            string result = WebElementUtils.GetAttribute(Driver, "Button3", "BackgroundColor");
            Assert.AreEqual(expect, result);
        }

        [Test]
        public void ButtonBackgroundTest4()
        {
            string expect = "[Color: A=0.5, R=0, G=0, B=1, Hue=0.666666686534882, Saturation=1, Luminosity=0.5]";
            string result = WebElementUtils.GetAttribute(Driver, "Button4", "BackgroundColor");
            Assert.AreEqual(expect, result);
        }

        [Test]
        public void LabelBackgroundTest()
        {
            string expect = "[Color: A=1, R=0.752941191196442, G=0.752941191196442, B=0.752941191196442, Hue=0, Saturation=0, Luminosity=0.752941191196442]";
            string result = WebElementUtils.GetAttribute(Driver, "Label1", "BackgroundColor");
            Assert.AreEqual(expect, result);
        }

        [Test]
        public void LabelBackgroundTest2()
        {
            string expect = "[Color: A=1, R=1, G=0.752941191196442, B=0.796078443527222, Hue=0.970899522304535, Saturation=1, Luminosity=0.876470565795898]";
            string result = WebElementUtils.GetAttribute(Driver, "Label2", "BackgroundColor");
            Assert.AreEqual(expect, result);
        }

        [Test]
        public void EntryBackgroundTest()
        {
            string expect = "[Color: A=1, R=0, G=1, B=0, Hue=0.333333343267441, Saturation=1, Luminosity=0.5]";
            string result = WebElementUtils.GetAttribute(Driver, "Entry1", "BackgroundColor");
            Assert.AreEqual(expect, result);
        }

        [Test]
        public void EntryBackgroundTest2()
        {
            string expect = "[Color: A=1, R=0.501960813999176, G=0, B=0, Hue=1, Saturation=1, Luminosity=0.250980406999588]";
            string result = WebElementUtils.GetAttribute(Driver, "Entry2", "BackgroundColor");
            Assert.AreEqual(expect, result);
        }

        [Test]
        public void ProgressBarBackgroundTest1()
        {
            string expect = "[Color: A=1, R=1, G=0.752941191196442, B=0.796078443527222, Hue=0.970899522304535, Saturation=1, Luminosity=0.876470565795898]";
            string result = WebElementUtils.GetAttribute(Driver, "ProgressBar1", "BackgroundColor");
            Assert.AreEqual(expect, result);
        }

        [Test]
        public void SliderBackgroundTest1()
        {
            string expect = "[Color: A=1, R=0.501960813999176, G=0, B=0.501960813999176, Hue=0.833333313465118, Saturation=1, Luminosity=0.250980406999588]";
            string result = WebElementUtils.GetAttribute(Driver, "Slider1", "BackgroundColor");
            Assert.AreEqual(expect, result);
        }
    }
}
