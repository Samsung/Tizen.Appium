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
            if (obj is ItemContext)
            {
                el = ((ItemContext)obj).Cell;
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
                if (_element.Target is Element)
                {
                    return ((Element)_element.Target).GetIsShownProperty() && ((VisualElement)_element.Target).IsVisible;
                }
                else if (_element.Target is ItemContext)
                {
                    return ((ItemContext)_element.Target).Cell.GetIsShownProperty();
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
                    if (_element.Target is Element)
                    {
                        return IsShown ? (Element)_element.Target : null;
                    }
                    else if (_element.Target is ItemContext)
                    {
                        return IsShown ? ((ItemContext)_element.Target).Cell : null;
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
                    if (_element.Target is Element)
                    {
                        return IsShown ? Platform.GetRenderer((Element)_element.Target).NativeView : null;
                    }
                    else if (_element.Target is ItemContext)
                    {
                        return IsShown ? ((ItemContext)_element.Target).Item.TrackObject : null;
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
