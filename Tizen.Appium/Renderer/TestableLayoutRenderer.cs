using System;
using Xamarin.Forms.Platform.Tizen;
using Xamarin.Forms;
using Tizen.Appium.Renderer;

[assembly: ExportRenderer(typeof(Layout), typeof(TestableLayoutRenderer))]

namespace Tizen.Appium.Renderer
{
    public class TestableLayoutRenderer : LayoutRenderer
    {
        public TestableLayoutRenderer() : base()
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Layout> e)
        {
            if (!String.IsNullOrEmpty(e.NewElement.AutomationId))
            {
                ElementUtils.AddTestableElement(Element.AutomationId, Element);
            }

            base.OnElementChanged(e);
        }
    }
}
