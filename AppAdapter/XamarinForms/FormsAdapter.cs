using Xamarin.Forms;
using Xamarin.Forms.Platform.Tizen;
#if WATCH
using Tizen.Wearable.CircularUI.Forms.Renderer;
using ElmSharp;
#endif

namespace Tizen.Appium
{
    public sealed class FormsAdapter : IAppAdapter
    {
        FormsElementList _objectList = new FormsElementList();

        public IObjectList ObjectList => _objectList;

        public FormsAdapter()
        {
            Forms.ViewInitialized += (s, e) =>
            {
                if (e.View is Page p)
                {
                    p.Appearing += (ss, ee) =>
                    {
                        p.SetIsShownProperty(true);
                    };

                    p.Disappearing += (ss, ee) =>
                    {
                        p.SetIsShownProperty(false);
                    };
                }

                e.View.PropertyChanged += (ss, ee) =>
                {
                    if ((ee.PropertyName == "Renderer") && (Platform.GetRenderer((BindableObject)ss) == null))
                    {
                        _objectList.Remove(e.View);
                    }
                };
                _objectList.Add(e.View);

#if WATCH
                if (e.View is Wearable.CircularUI.Forms.CircleListView)
                {
                    AddItemFromCircleList(e.View);
                }
                else if((e.View is ListView) || (e.View is TableView))
#else
                if ((e.View is ListView) || (e.View is TableView))
#endif
                {
                    AddItemFromList(e.View);
                }
            };
        }

        void AddItemFromList(VisualElement list)
        {
            var nativeView = (Xamarin.Forms.Platform.Tizen.Native.ListView)Platform.GetOrCreateRenderer(list).NativeView;

            nativeView.ItemRealized += (s, e) =>
            {
                var itemContext = e.Item.Data as Xamarin.Forms.Platform.Tizen.Native.ListView.ItemContext;

                if (itemContext != null)
                {
                    _objectList.Add(itemContext);

                    itemContext.Cell.Disappearing += (sender, args) =>
                    {
                        _objectList.Remove(itemContext);
                    };

                    itemContext.Item.Deleted += (sender, args) =>
                    {
                        _objectList.Remove(itemContext);
                    };
                }
            };
        }

#if WATCH
        void AddItemFromCircleList(VisualElement list)
        {
            var nativeView = (Wearable.CircularUI.Forms.Renderer.CircleListView)Platform.GetOrCreateRenderer(list).NativeView;

            nativeView.ItemRealized += (s, e) =>
            {
                if(e.Item.Data is ListViewItemContext)
                {
                    var itemContext = e.Item.Data as ListViewItemContext;
                    if (itemContext != null)
                    {
                        itemContext.Item = e.Item as GenItem;

                        _objectList.Add(itemContext);

                        itemContext.Cell.Disappearing += (sender, args) =>
                        {
                            _objectList.Remove(itemContext);
                        };

                        itemContext.Item.Deleted += (sender, args) =>
                        {
                            _objectList.Remove(itemContext);
                        };
                    }
                }
            };
        }
#endif
    }
}