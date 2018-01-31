using System;
using Xamarin.Forms.Platform.Tizen;
using Xamarin.Forms;

namespace Tizen.Appium.Renderer
{
    public class TestableSliderRenderer : SliderRenderer
    {
        public TestableSliderRenderer() : base()
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Slider> e)
        {
            if (!String.IsNullOrEmpty(e.NewElement.AutomationId))
            {
                ElementUtils.AddTestableElement(Element.AutomationId, Element);
            }

            base.OnElementChanged(e);
        }
    }
}
