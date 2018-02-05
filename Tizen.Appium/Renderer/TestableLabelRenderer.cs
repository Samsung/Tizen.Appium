using System;
using Xamarin.Forms.Platform.Tizen;
using Xamarin.Forms;
using Tizen.Appium.Renderer;

[assembly: ExportRenderer(typeof(Label), typeof(TestableLabelRenderer))]

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
