using Xamarin.Forms;
using Xamarin.Forms.Platform.Tizen;
using Xamarin.Forms.Internals;

namespace Tizen.Appium
{
    public class TizenAppiumElement
    {
        ToolbarTracker _toolbarTracker;

        public TizenAppiumElement(Application app = null)
        {
            Forms.ViewInitialized += (s, e) =>
            {
                e.View.PropertyChanged += (ss, ee) =>
                {
                    if ((ee.PropertyName == "Renderer") && (Platform.GetRenderer((BindableObject)ss) == null))
                    {
                        ElementUtils.RemoveElement(e.View);
                    }
                    else if ((ee.PropertyName == VisualElement.IsVisibleProperty.PropertyName))
                    {
                         if(e.View.IsVisible)
                             ElementUtils.AddElement(e.View);
                         else 
                             ElementUtils.RemoveElement(e.View);
                    }
                };
                
                if(e.View.IsVisible)
                {
                    ElementUtils.AddElement(e.View);
                    if ((e.View is ListView) || (e.View is TableView))
                    {
                        AddItemFromList(e.View);
                    }                
                }
            };

            if (app != null)
            {
                _toolbarTracker = new ToolbarTracker();
                _toolbarTracker.Target = app.MainPage;
                _toolbarTracker.CollectionChanged += (s, e) =>
                {
                    ElementUtils.ResetToolbarItems();

                    foreach (var item in _toolbarTracker.ToolbarItems)
                    {
                        ElementUtils.AddElement(item);
                    }
                };
            }
        }

        void AddItemFromList(VisualElement list)
        {
            var nativeView = (Xamarin.Forms.Platform.Tizen.Native.ListView)Platform.GetOrCreateRenderer(list).NativeView;

            nativeView.ItemRealized += (s, e) =>
            {
                var itemContext = (Xamarin.Forms.Platform.Tizen.Native.ListView.ItemContext)e.Item.Data;
                ElementUtils.AddItemContext(itemContext);

                itemContext.Cell.Disappearing += (sender, args) =>
                {
                    ElementUtils.RemoveItemContext(itemContext);
                };

                itemContext.Item.Deleted += (sender, args) =>
                {
                    ElementUtils.RemoveItemContext(itemContext);
                };
            };
        }
    }
}
