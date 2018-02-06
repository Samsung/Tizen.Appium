using System;
using Xamarin.Forms.Platform.Tizen;
using Xamarin.Forms;
using Tizen.Appium.Renderer;

[assembly: ExportRenderer(typeof(Picker), typeof(TestablePickerRenderer))]

namespace Tizen.Appium.Renderer
{
    public class TestablePickerRenderer : PickerRenderer
    {
        public TestablePickerRenderer() : base()
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            if (!String.IsNullOrEmpty(e.NewElement.AutomationId))
            {
                ElementUtils.AddTestableElement(Element.AutomationId, Element);
            }

            base.OnElementChanged(e);
        }
    }
}
