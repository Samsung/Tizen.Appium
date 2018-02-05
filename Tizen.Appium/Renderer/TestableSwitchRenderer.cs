using System;
using Xamarin.Forms.Platform.Tizen;
using Xamarin.Forms;
using Tizen.Appium.Renderer;

[assembly: ExportRenderer(typeof(Switch), typeof(TestableSwitchRenderer))]

namespace Tizen.Appium.Renderer
{
    public class TestableSwitchRenderer : SwitchRenderer
    {
        public TestableSwitchRenderer() : base()
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Switch> e)
        {
            if (!String.IsNullOrEmpty(e.NewElement.AutomationId))
            {
                ElementUtils.AddTestableElement(Element.AutomationId, Element);
            }

            base.OnElementChanged(e);
        }
    }
}
