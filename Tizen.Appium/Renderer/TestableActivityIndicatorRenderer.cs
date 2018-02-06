using System;
using Xamarin.Forms.Platform.Tizen;
using Xamarin.Forms;
using Tizen.Appium.Renderer;

[assembly: ExportRenderer(typeof(ActivityIndicator), typeof(TestableActivityIndicatorRenderer))]

namespace Tizen.Appium.Renderer
{
    public class TestableActivityIndicatorRenderer : ActivityIndicatorRenderer
    {
        public TestableActivityIndicatorRenderer() : base()
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<ActivityIndicator> e)
        {
            if (!String.IsNullOrEmpty(e.NewElement.AutomationId))
            {
                ElementUtils.AddTestableElement(Element.AutomationId, Element);
            }

            base.OnElementChanged(e);
        }
    }
}
