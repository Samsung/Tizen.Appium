using System;
using Xamarin.Forms.Platform.Tizen;
using Xamarin.Forms;

namespace Tizen.Appium.Renderer
{
    public class TestableLabelRenderer : LabelRenderer
    {
        public TestableLabelRenderer() : base()
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            if (!String.IsNullOrEmpty(e.NewElement.AutomationId))
            {
                ElementUtils.AddTestableElement(Element.AutomationId, Element);
            }

            base.OnElementChanged(e);
        }
    }
}
