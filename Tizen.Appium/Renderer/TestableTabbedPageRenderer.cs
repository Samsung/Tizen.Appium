using System;
using Xamarin.Forms.Platform.Tizen;
using Xamarin.Forms;
using Tizen.Appium.Renderer;

[assembly: ExportRenderer(typeof(TabbedPage), typeof(TestableTabbedPageRenderer))]

namespace Tizen.Appium.Renderer
{
    public class TestableTabbedPageRenderer : TabbedPageRenderer
    {
        public TestableTabbedPageRenderer() : base()
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<TabbedPage> e)
        {
            if (!String.IsNullOrEmpty(e.NewElement.AutomationId))
            {
                ElementUtils.AddTestableElement(Element.AutomationId, Element);
            }

            base.OnElementChanged(e);
        }
    }
}
