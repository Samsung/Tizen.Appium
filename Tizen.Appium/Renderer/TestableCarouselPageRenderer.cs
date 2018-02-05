using System;
using Xamarin.Forms.Platform.Tizen;
using Xamarin.Forms;
using Tizen.Appium.Renderer;

[assembly: ExportRenderer(typeof(NavigationPage), typeof(TestableNavigationPageRenderer))]

namespace Tizen.Appium.Renderer
{
    public class TestableNavigationPageRenderer : NavigationPageRenderer
    {
        public TestableNavigationPageRenderer() : base()
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<NavigationPage> e)
        {
            if (!String.IsNullOrEmpty(e.NewElement.AutomationId))
            {
                ElementUtils.AddTestableElement(Element.AutomationId, Element);
            }

            base.OnElementChanged(e);
        }
    }
}
