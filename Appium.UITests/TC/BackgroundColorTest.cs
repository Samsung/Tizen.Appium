using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture]
    public class BackgroundColorTest : TestTemplate
    {
        [Test]
        public void ButtonBackgroundTest()
        {
            var expect = "[Color: A=1, R=0, G=0, B=0, Hue=0, Saturation=0, Luminosity=0]";
            var result = Driver.GetAttribute<string>("button1", "BackgroundColor");
            Assert.AreEqual(expect, result);
        }

        [Test]
        public void ActivityIndicatorBackgroundTest()
        {
            var expect = "[Color: A=1, R=0, G=0, B=1, Hue=0.666666686534882, Saturation=1, Luminosity=0.5]";
            var result = Driver.GetAttribute<string>("ai", "BackgroundColor");
            Assert.AreEqual(expect, result);
        }

        [Test]
        public void ButtonBackgroundTest2()
        {
            var expect = "[Color: A=1, R=1, G=0, B=0, Hue=1, Saturation=1, Luminosity=0.5]";
            var result = Driver.GetAttribute<string>("Button2", "BackgroundColor");
            Assert.AreEqual(expect, result);
        }

        [Test]
        public void ButtonBackgroundTest3()
        {
            var expect = "[Color: A=1, R=0, G=0, B=1, Hue=0.666666686534882, Saturation=1, Luminosity=0.5]";
            var result = Driver.GetAttribute<string>("Button3", "BackgroundColor");
            Assert.AreEqual(expect, result);
        }

        [Test]
        public void ButtonBackgroundTest4()
        {
            var expect = "[Color: A=0.5, R=0, G=0, B=1, Hue=0.666666686534882, Saturation=1, Luminosity=0.5]";
            var result = Driver.GetAttribute<string>("Button4", "BackgroundColor");
            Assert.AreEqual(expect, result);
        }

        [Test]
        public void LabelBackgroundTest()
        {
            var expect = "[Color: A=1, R=0.752941191196442, G=0.752941191196442, B=0.752941191196442, Hue=0, Saturation=0, Luminosity=0.752941191196442]";
            var result = Driver.GetAttribute<string>("Label1", "BackgroundColor");
            Assert.AreEqual(expect, result);
        }

        [Test]
        public void LabelBackgroundTest2()
        {
            var expect = "[Color: A=1, R=1, G=0.752941191196442, B=0.796078443527222, Hue=0.970899522304535, Saturation=1, Luminosity=0.876470565795898]";
            var result = Driver.GetAttribute<string>("Label2", "BackgroundColor");
            Assert.AreEqual(expect, result);
        }

        [Test]
        public void EntryBackgroundTest()
        {
            var expect = "[Color: A=1, R=0, G=1, B=0, Hue=0.333333343267441, Saturation=1, Luminosity=0.5]";
            var result = Driver.GetAttribute<string>("Entry1", "BackgroundColor");
            Assert.AreEqual(expect, result);
        }

        [Test]
        public void EntryBackgroundTest2()
        {
            var expect = "[Color: A=1, R=0.501960813999176, G=0, B=0, Hue=1, Saturation=1, Luminosity=0.250980406999588]";
            var result = Driver.GetAttribute<string>("Entry2", "BackgroundColor");
            Assert.AreEqual(expect, result);
        }

        [Test]
        public void ProgressBarBackgroundTest1()
        {
            var expect = "[Color: A=1, R=1, G=0.752941191196442, B=0.796078443527222, Hue=0.970899522304535, Saturation=1, Luminosity=0.876470565795898]";
            var result = Driver.GetAttribute<string>("ProgressBar1", "BackgroundColor");
            Assert.AreEqual(expect, result);
        }

        [Test]
        public void SliderBackgroundTest1()
        {
            var expect = "[Color: A=1, R=0.501960813999176, G=0, B=0.501960813999176, Hue=0.833333313465118, Saturation=1, Luminosity=0.250980406999588]";
            var result = Driver.GetAttribute<string>("Slider1", "BackgroundColor");
            Assert.AreEqual(expect, result);
        }
    }
}
