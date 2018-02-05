using System;
using Xamarin.Forms.Platform.Tizen;
using Xamarin.Forms;
using Tizen.Appium.Renderer;

[assembly: ExportRenderer(typeof(Stepper), typeof(TestableStepperRenderer))]

namespace Tizen.Appium.Renderer
{
    public class TestableStepperRenderer : StepperRenderer
    {
        public TestableStepperRenderer() : base()
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Stepper> e)
        {
            if (!String.IsNullOrEmpty(e.NewElement.AutomationId))
            {
                ElementUtils.AddTestableElement(Element.AutomationId, Element);
            }

            base.OnElementChanged(e);
        }
    }
}
