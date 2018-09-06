using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Tizen;
using ItemContext = Xamarin.Forms.Platform.Tizen.Native.ListView.ItemContext;
using EvasObject = ElmSharp.EvasObject;

namespace Tizen.Appium
{
    public class FormsElementWrapper
    {
        WeakReference _element;
        string _id;
        string _parentId;

        public EventHandler Deleted;

        public string Id
        {
            get
            {
                return _id;
            }
        }

        public FormsElementWrapper(object obj)
        {
            Element el;
            if (obj is ItemContext ic)
            {
                el = ic.Cell;
            }
            else
            {
                el = (Element)obj;
            }
            _element = new WeakReference(obj);
            _id = el.GetId();
            _parentId = el.Parent != null ? el.Parent.GetId() : string.Empty;
        }

        public bool IsShown
        {
            get
            {
                if (_element.Target is VisualElement ve)
                {
                    return ve.GetIsShownProperty() && ve.IsVisible;
                }
                else if (_element.Target is ItemContext ic)
                {
                    return ic.Cell.GetIsShownProperty();
                }
                return false;
            }
        }

        public string Name
        {
            get
            {
                if(_element.IsAlive)
                {
                    var property = _element.Target.GetType().GetProperty("Text");
                    if (property != null)
                    {
                        return (string)(property.GetValue(_element.Target));
                    }
                }
                return string.Empty;
            }
        }

        public Element Element
        {
            get
            {
                if (_element.IsAlive)
                {
                    if (_element.Target is Element e)
                    {
                        return IsShown ? e : null;
                    }
                    else if (_element.Target is ItemContext ic)
                    {
                        return IsShown ? ic.Cell : null;
                    }
                }
                else
                {
                    Deleted?.Invoke(this, EventArgs.Empty);
                }
                return null;
            }
        }

        public EvasObject NativeView
        {
            get
            {
                if (_element.IsAlive)
                {
                    if (_element.Target is Element e)
                    {
                        return IsShown ? Platform.GetRenderer(e).NativeView : null;
                    }
                    else if (_element.Target is ItemContext ic)
                    {
                        return IsShown ? ic.Item.TrackObject : null;
                    }
                }
                else
                {
                    Deleted?.Invoke(this, EventArgs.Empty);
                }
                return null;
            }
        }
    }
}
