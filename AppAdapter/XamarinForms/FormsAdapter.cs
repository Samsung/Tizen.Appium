using Xamarin.Forms;
using Xamarin.Forms.Platform.Tizen;

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
                        e.View.SetIsShownProperty(true);
                    };

                    p.Disappearing += (ss, ee) =>
                    {
                        e.View.SetIsShownProperty(false);
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

                if ((e.View is ListView) || (e.View is TableView))
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