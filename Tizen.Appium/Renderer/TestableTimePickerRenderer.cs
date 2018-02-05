using System;
using Xamarin.Forms.Platform.Tizen;
using Xamarin.Forms;
using Tizen.Appium.Renderer;

[assembly: ExportRenderer(typeof(TimePicker), typeof(TestableTimePickerRenderer))]

namespace Tizen.Appium.Renderer
{
    public class TestableTimePickerRenderer : TimePickerRenderer
    {
        public TestableTimePickerRenderer() : base()
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<TimePicker> e)
        {
            if (!String.IsNullOrEmpty(e.NewElement.AutomationId))
            {
                ElementUtils.AddTestableElement(Element.AutomationId, Element);
            }

            base.OnElementChanged(e);
        }
    }
}
