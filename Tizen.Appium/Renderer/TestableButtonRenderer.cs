using System;
using Xamarin.Forms.Platform.Tizen;
using Xamarin.Forms;

namespace Tizen.Appium.Renderer
{
    public class TestableButtonRenderer : ButtonRenderer
    {
        public TestableButtonRenderer() : base()
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            if (!String.IsNullOrEmpty(e.NewElement.AutomationId))
            {
                ElementUtils.AddTestableElement(Element.AutomationId, Element);
            }

            base.OnElementChanged(e);
        }
    }
}
