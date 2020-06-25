using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Tizen;
using Tizen.Appium.Forms;

namespace Tizen.Appium
{
    public class FormsAdapter : BaseAdapter
    {
        public static IDictionary<string, TypeConverter> TypeConverters
        {
            get;
            private set;
        }

        protected override IObjectList CreateObjectList()
        {
            return new FormsElementList();
        }

        protected override void AdaptApp()
        {
            var asm = typeof(Xamarin.Forms.View).Assembly;
            var typeinfo = typeof(Xamarin.Forms.TypeConverter).GetTypeInfo();
            TypeConverters = (from klass in asm.DefinedTypes
                                where typeinfo.IsAssignableFrom(klass) && !klass.IsInterface && !klass.IsAbstract
                                select new KeyValuePair<string, TypeConverter>(klass.Name, Activator.CreateInstance(klass) as TypeConverter))
                                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

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
            };
        }

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