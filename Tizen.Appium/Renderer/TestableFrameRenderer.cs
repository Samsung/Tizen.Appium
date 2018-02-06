using System;
using Xamarin.Forms.Platform.Tizen;
using Xamarin.Forms;
using Tizen.Appium.Renderer;

[assembly: ExportRenderer(typeof(Frame), typeof(TestableFrameRenderer))]

namespace Tizen.Appium.Renderer
{
    public class TestableFrameRenderer : FrameRenderer
    {
        public TestableFrameRenderer() : base()
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Frame> e)
        {
            if (!String.IsNullOrEmpty(e.NewElement.AutomationId))
            {
                ElementUtils.AddTestableElement(Element.AutomationId, Element);
            }

            base.OnElementChanged(e);
        }
    }
}
