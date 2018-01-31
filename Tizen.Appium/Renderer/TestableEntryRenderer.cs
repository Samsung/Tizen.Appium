using System;
using Xamarin.Forms.Platform.Tizen;
using Xamarin.Forms;

namespace Tizen.Appium.Renderer
{
    public class TestableEntryRenderer : EntryRenderer
    {
        public TestableEntryRenderer() : base()
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            if (!String.IsNullOrEmpty(e.NewElement.AutomationId))
            {
                ElementUtils.AddTestableElement(Element.AutomationId, Element);
            }

            base.OnElementChanged(e);
        }
    }
}
