using NUnit.Framework;

namespace Appium.UITests
{
    [TestFixture]
    public class AnimationTest3 : TestTemplate
    {
        [Test]
        public void AnimationTest()
        {
            Driver.Click("btnStartAnim");
        }
    }
}
