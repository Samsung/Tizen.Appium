using System;
using Xamarin.Forms.Platform.Tizen;
using Xamarin.Forms;
using Tizen.Appium.Renderer;

[assembly: ExportRenderer(typeof(BoxView), typeof(TestableBoxViewRenderer))]

namespace Tizen.Appium.Renderer
{
    public class TestableBoxViewRenderer : BoxViewRenderer
    {
        public TestableBoxViewRenderer() : base()
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<BoxView> e)
        {
            if (!String.IsNullOrEmpty(e.NewElement.AutomationId))
            {
                ElementUtils.AddTestableElement(Element.AutomationId, Element);
            }

            base.OnElementChanged(e);
        }
    }
}
