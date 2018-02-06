using System;
using Xamarin.Forms.Platform.Tizen;
using Xamarin.Forms;
using Tizen.Appium.Renderer;

[assembly: ExportRenderer(typeof(ProgressBar), typeof(TestableProgressBarRenderer))]

namespace Tizen.Appium.Renderer
{
    public class TestableProgressBarRenderer : ProgressBarRenderer
    {
        public TestableProgressBarRenderer() : base()
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<ProgressBar> e)
        {
            if (!String.IsNullOrEmpty(e.NewElement.AutomationId))
            {
                ElementUtils.AddTestableElement(Element.AutomationId, Element);
            }

            base.OnElementChanged(e);
        }
    }
}
