using System;
using Xamarin.Forms.Platform.Tizen;
using Xamarin.Forms;
using Tizen.Appium.Renderer;

[assembly: ExportRenderer(typeof(Page), typeof(TestablePageRenderer))]

namespace Tizen.Appium.Renderer
{
    public class TestablePageRenderer : PageRenderer
    {
        public TestablePageRenderer() : base()
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
        {
            if (!String.IsNullOrEmpty(e.NewElement.AutomationId))
            {
                ElementUtils.AddTestableElement(Element.AutomationId, Element);
            }

            base.OnElementChanged(e);
        }
    }
}
