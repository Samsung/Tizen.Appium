using Xamarin.Forms;
using Xamarin.Forms.Platform.Tizen;
using Xamarin.Forms.Internals;
using System;
using System.Linq;

namespace Tizen.Appium
{
    public sealed class FormsAdapter : IAppAdapter
    {
        FormsElementList _objectList = new FormsElementList();
        ToolbarTracker _toolbarTracker = new ToolbarTracker();

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

                    if(p is NavigationPage np)
                    {
                        _toolbarTracker.Target = np;
                    }
                }

                e.View.PropertyChanged += (ss, ee) =>
                {
                    if ((ee.PropertyName == "Renderer") && (Platform.GetRenderer((BindableObject)ss) == null))
                    {
                        _objectList.Remove(e.View);
                    }
                };
                _objectList.Add(e.View);

                if ((e.View is ListView) || (e.View is TableView))
                {
                    AddItemFromList(e.View);
                }
            };

            _toolbarTracker.CollectionChanged += OnToolbarCollectionChanged;


        }
        void OnToolbarCollectionChanged(object sender, EventArgs eventArgs)
        {
            _objectList.ResetToolbarItems();

            var right = _toolbarTracker.ToolbarItems.Where(
                i => i.Order == ToolbarItemOrder.Primary)
                .OrderBy(i => i.Priority).FirstOrDefault();

            var left = _toolbarTracker.ToolbarItems.Where(
                i => i.Order == ToolbarItemOrder.Secondary)
                .OrderBy(i => i.Priority).FirstOrDefault();


            if (right != null)
            {
                _objectList.AddToolbarItem(right, ToolbarItemPosition.Right);
            }

            if (left != null)
            {
                _objectList.AddToolbarItem(left, ToolbarItemPosition.Left);
            }
        }

        void AddItemFromList(VisualElement list)
        {
            var nativeView = (Xamarin.Forms.Platform.Tizen.Native.ListView)Platform.GetOrCreateRenderer(list).NativeView;

            nativeView.ItemRealized += (s, e) =>
            {
                var itemContext = (Xamarin.Forms.Platform.Tizen.Native.ListView.ItemContext)e.Item.Data;
                _objectList.Add(itemContext);

                itemContext.Cell.Disappearing += (sender, args) =>
                {
                    _objectList.Remove(itemContext);
                };

                itemContext.Item.Deleted += (sender, args) =>
                {
                    _objectList.Remove(itemContext);
                };
            };
        }
    }
}