using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Tizen;
using Tizen.Appium.Forms;

#if WATCH
using CShellItemContext = Tizen.Wearable.CircularUI.Forms.Renderer.NavigationView.ItemContext;
#endif

namespace Tizen.Appium
{
    public class FormsAdapter : BaseAdapter
    {
        protected override IObjectList CreateObjectList()
        {
            return new FormsElementList();
        }

        protected override void AdaptApp()
        {

            Xamarin.Forms.Forms.ViewInitialized += (s, e) =>
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
                        ObjectList.RemoveById(e.View.GetId());
                    }
                };
                ObjectList.Add(e.View);

                if ((e.View is ListView) || (e.View is TableView))
                {
                    AddItemFromList(e.View);
                }
#if WATCH
                if (e.View is Shell shell)
                {
                    AddShellItems(shell);
                }
#endif
            };
        }

#if WATCH
        void AddShellItems(Shell shell)
        {
            var naviView = (Platform.GetOrCreateRenderer(shell) as Wearable.CircularUI.Forms.Renderer.ShellRenderer)?.NavigationView;
            if (naviView != null)
            {
                naviView.ItemRealized += (s, e) =>
                {
                    ObjectList.Add(e.Item.Data);
                };

                naviView.ItemUnrealized += (s, e) =>
                {
                    var id = (e.Item.Data as CShellItemContext)?.Source.GetId();
                    ObjectList.RemoveById(id);
                };
            }
        }
#endif
        void AddItemFromList(VisualElement list)
        {
            var nativeView = (ElmSharp.GenList)Platform.GetOrCreateRenderer(list).NativeView;

            nativeView.ItemRealized += (s, e) =>
            {
                var itemContext = e.Item.Data as Xamarin.Forms.Platform.Tizen.Native.ListView.ItemContext;

                if(itemContext != null)
                {
                    itemContext.Item = e.Item as ElmSharp.GenItem;
                    ObjectList.Add(itemContext);
                }
            };
        }
    }
}