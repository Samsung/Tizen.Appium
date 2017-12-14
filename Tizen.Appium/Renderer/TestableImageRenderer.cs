using System;
using Xamarin.Forms.Platform.Tizen;
using Xamarin.Forms;

namespace Tizen.Appium.Renderer
{
    public class TestableImageRenderer : ImageRenderer
    {
        public TestableImageRenderer() : base()
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Image> e)
        {
            if (!String.IsNullOrEmpty(e.NewElement.AutomationId))
            {
                TestHelper.AddTestableElement(Element.AutomationId, Element);
            }

            base.OnElementChanged(e);
        }
    }
}
