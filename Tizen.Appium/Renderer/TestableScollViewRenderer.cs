using System;
using Xamarin.Forms.Platform.Tizen;
using Xamarin.Forms;
using Tizen.Appium.Renderer;

[assembly: ExportRenderer(typeof(ScrollView), typeof(TestableScrollViewRenderer))]

namespace Tizen.Appium.Renderer
{
    public class TestableScrollViewRenderer : ScrollViewRenderer
    {
        public TestableScrollViewRenderer() : base()
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<ScrollView> e)
        {
            if (!String.IsNullOrEmpty(e.NewElement.AutomationId))
            {
                ElementUtils.AddTestableElement(Element.AutomationId, Element);
            }

            base.OnElementChanged(e);
        }
    }
}
