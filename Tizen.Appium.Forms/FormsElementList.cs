using Xamarin.Forms;
using ItemContext = Xamarin.Forms.Platform.Tizen.Native.ListView.ItemContext;

#if WATCH
using ShellItemContext = Tizen.Wearable.CircularUI.Forms.Renderer.NavigationView.ItemContext;
#endif

namespace Tizen.Appium.Forms
{
    public class FormsElementList : BaseObjectList
    {
        protected override IObjectWrapper CreateWrapper(object obj)
        {
            if (obj is VisualElement ve)
            {
                return new VisualElementWrapper(ve);
            }
            else if (obj is ItemContext ic)
            {
                return new CellWrapper(ic);
            }
#if WATCH
            else if (obj is ShellItemContext sic)
            {
                return new ShellItemWrapper(sic);
            }
#endif
            return null;
        }
    }
}
