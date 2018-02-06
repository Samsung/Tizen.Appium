using System;
using Xamarin.Forms.Platform.Tizen;
using Xamarin.Forms;
using Tizen.Appium.Renderer;

[assembly: ExportRenderer(typeof(CarouselPage), typeof(TestableCarouselPageRenderer))]

namespace Tizen.Appium.Renderer
{
    public class TestableCarouselPageRenderer : CarouselPageRenderer
    {
        public TestableCarouselPageRenderer() : base()
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<CarouselPage> e)
        {
            if (!String.IsNullOrEmpty(e.NewElement.AutomationId))
            {
                ElementUtils.AddTestableElement(Element.AutomationId, Element);
            }

            base.OnElementChanged(e);
        }
    }
}
