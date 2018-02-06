using System;
using Xamarin.Forms.Platform.Tizen;
using Xamarin.Forms;
using Tizen.Appium.Renderer;

[assembly: ExportRenderer(typeof(MasterDetailPage), typeof(TestableMasterDetailPageRenderer))]

namespace Tizen.Appium.Renderer
{
    public class TestableMasterDetailPageRenderer : MasterDetailPageRenderer
    {
        public TestableMasterDetailPageRenderer() : base()
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<MasterDetailPage> e)
        {
            if (!String.IsNullOrEmpty(e.NewElement.AutomationId))
            {
                ElementUtils.AddTestableElement(Element.AutomationId, Element);
            }

            base.OnElementChanged(e);
        }
    }
}
