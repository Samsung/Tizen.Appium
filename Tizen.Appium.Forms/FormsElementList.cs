using Xamarin.Forms;
using ItemContext = Xamarin.Forms.Platform.Tizen.Native.ListView.ItemContext;

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

            return null;
        }
    }
}
