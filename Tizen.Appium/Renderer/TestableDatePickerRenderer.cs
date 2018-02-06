using System;
using Xamarin.Forms.Platform.Tizen;
using Xamarin.Forms;
using Tizen.Appium.Renderer;

[assembly: ExportRenderer(typeof(DatePicker), typeof(TestableDatePickerRenderer))]

namespace Tizen.Appium.Renderer
{
    public class TestableDatePickerRenderer : DatePickerRenderer
    {
        public TestableDatePickerRenderer() : base()
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<DatePicker> e)
        {
            if (!String.IsNullOrEmpty(e.NewElement.AutomationId))
            {
                ElementUtils.AddTestableElement(Element.AutomationId, Element);
            }

            base.OnElementChanged(e);
        }
    }
}
