using System;
using Xamarin.Forms.Platform.Tizen;
using Xamarin.Forms;
using Tizen.Appium.Renderer;

[assembly: ExportRenderer(typeof(SearchBar), typeof(TestableSearchBarRenderer))]

namespace Tizen.Appium.Renderer
{
    public class TestableSearchBarRenderer : SearchBarRenderer
    {
        public TestableSearchBarRenderer() : base()
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<SearchBar> e)
        {
            if (!String.IsNullOrEmpty(e.NewElement.AutomationId))
            {
                ElementUtils.AddTestableElement(Element.AutomationId, Element);
            }

            base.OnElementChanged(e);
        }
    }
}
