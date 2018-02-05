using System;
using Xamarin.Forms.Platform.Tizen;
using Xamarin.Forms;
using Tizen.Appium.Renderer;

[assembly: ExportRenderer(typeof(Editor), typeof(TestableEditorRenderer))]

namespace Tizen.Appium.Renderer
{
    public class TestableEditorRenderer : EditorRenderer
    {
        public TestableEditorRenderer() : base()
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
        {
            if (!String.IsNullOrEmpty(e.NewElement.AutomationId))
            {
                ElementUtils.AddTestableElement(Element.AutomationId, Element);
            }

            base.OnElementChanged(e);
        }
    }
}
