using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Platform.Tizen;

namespace Tizen.Appium
{
    public class FormsAdapter : AppAdapter
    {
        ToolbarTracker _toolbarTracker;

        public FormsAdapter(Application app = null) : base()
        {
            Forms.ViewInitialized += (s, e) =>
            {
                if (e.View is Page)
                {
                    ((Page)e.View).Appearing += (ss, ee) =>
                    {
                        e.View.SetIsShownProperty(true);
                    };

                    ((Page)e.View).Disappearing += (ss, ee) =>
                    {
                        e.View.SetIsShownProperty(false);
                    };
                }

                e.View.PropertyChanged += (ss, ee) =>
                {
                    if ((ee.PropertyName == "Renderer") && (Platform.GetRenderer((BindableObject)ss) == null))
                    {
                        ObjectList.Remove(e.View);
                    }
                };
                ObjectList.Add(e.View);

                if ((e.View is ListView) || (e.View is TableView))
                {
                    AddItemFromList(e.View);
                }
            };

            if (app != null)
            {
                _toolbarTracker = new ToolbarTracker();
                _toolbarTracker.Target = app.MainPage;
                _toolbarTracker.CollectionChanged += (s, e) =>
                {
                    ((FormsElementList)ObjectList).ResetToolbarItems();

                    foreach (var item in _toolbarTracker.ToolbarItems)
                    {
                        ObjectList.Add(item);
                    }
                };
            }
        }

        protected override IObjectList InitObjectList()
        {
            return new FormsElementList();
        }

        void AddItemFromList(VisualElement list)
        {
            var nativeView = (Xamarin.Forms.Platform.Tizen.Native.ListView)Platform.GetOrCreateRenderer(list).NativeView;

            nativeView.ItemRealized += (s, e) =>
            {
                var itemContext = (Xamarin.Forms.Platform.Tizen.Native.ListView.ItemContext)e.Item.Data;
                ObjectList.Add(itemContext);

                itemContext.Cell.Disappearing += (sender, args) =>
                {
                    ObjectList.Remove(itemContext);
                };

                itemContext.Item.Deleted += (sender, args) =>
                {
                    ObjectList.Remove(itemContext);
                };
            };
        }

    }
}