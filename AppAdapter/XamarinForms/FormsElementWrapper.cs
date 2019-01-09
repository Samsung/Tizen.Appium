using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Tizen;
using ItemContext = Xamarin.Forms.Platform.Tizen.Native.ListView.ItemContext;
using EvasObject = ElmSharp.EvasObject;
using ItemObject = ElmSharp.ItemObject;
#if WATCH
using Tizen.Wearable.CircularUI.Forms.Renderer;
#endif

namespace Tizen.Appium
{
    public enum ToolbarItemPosition
    {
        None,
        Left,
        Right
    };

    public class FormsElementWrapper : IObject
    {
        WeakReference _element;
        string _id;

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
            _element = new WeakReference(obj);

            if (obj is Element e)
            {
                _id = e.GetId();
            }
            else if (obj is ItemContext ic)
            {
                _id = ic.Cell.GetId();
            }
#if WATCH
            else if (obj is ListViewItemContext lic)
            {
                _id = lic.Cell.GetId();
            }
#endif
            else
            {
                _id = obj.GetHashCode().ToString();
            }

            if (NativeView != null)
            {
                NativeView.Deleted += (sender, arg) =>
                {
                    Deleted?.Invoke(this, EventArgs.Empty);
                };
            }
        }

        public object Element
        {
            get
            {
                if (_element.IsAlive)
                {
                    if (_element.Target is VisualElement ve)
                    {
                        return (ve.GetIsShownProperty() && ve.IsVisible) ? ve : null;
                    }
                    else if (_element.Target is ItemContext ic)
                    {
                        return ic.Cell.GetIsShownProperty() ? ic.Cell : null;
                    }
#if WATCH
                    else if (_element.Target is ListViewItemContext lic)
                    {
                        return lic.Cell.GetIsShownProperty() ? lic.Cell : null;
                    }
#endif
                    else if (_element.Target is Element e)
                    {
                        return e;
                    }
                    else
                    {
                        return _element.Target;
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
                    if (_element.Target is VisualElement ve)
                    {
                        return (ve.GetIsShownProperty() && ve.IsVisible) ? Platform.GetRenderer(ve).NativeView : null;
                    }
                    else if (_element.Target is ItemContext ic)
                    {
                        return ic.Cell.GetIsShownProperty() ? ic.Item.TrackObject : null;
                    }
#if WATCH
                    else if (_element.Target is ListViewItemContext lic)
                    {
                        return lic.Cell.GetIsShownProperty() ? lic.Item.TrackObject : null;
                    }
#endif
                    else if (_element.Target is ItemObject io)
                    {
                        return io.TrackObject;
                    }
                    else if (_element.Target is EvasObject eo)
                    {
                        return eo;
                    }
                }
                else
                {
                    Deleted?.Invoke(this, EventArgs.Empty);
                }
                return null;
            }
        }

        public bool Focused
        {
            get
            {
                if (Element is VisualElement ve)
                {
                    return ve.IsFocused;
                }
                return false;
            }
        }

        public Geometry Geometry
        {
            get
            {
                return RunOnMainThread<Geometry>(() =>
                {
                    if (NativeView != null)
                    {
                        return new Geometry(NativeView.Geometry.X, NativeView.Geometry.Y, NativeView.Geometry.Width, NativeView.Geometry.Height);
                    }
                    else
                    {
                        return new Geometry();
                    }
                });
            }
        }

        public string Text
        {
            get
            {
                return RunOnMainThread<string>(() =>
                {
                    string[] TextProperties = { "Text", "FormattedText" };

                    foreach (var prop in TextProperties)
                    {
                        var text = Element?.GetType().GetProperty(prop)?.GetValue(Element);
                        if (text != null)
                            return text.ToString();
                    }

                    return string.Empty;
                });
            }
        }

        public object GetPropertyValue(string propertyName)
        {
            return RunOnMainThread<object>(() =>
            {
                var value = Element?.GetType().GetProperty(propertyName)?.GetValue(Element);
                return value;
            });
        }

        public bool SetPropertyValue(string propertyName, object value)
        {
            return RunOnMainThread<bool>(() =>
            {
                var property = Element?.GetType().GetProperty(propertyName);
                if (property == null)
                {
                    Log.Debug(Id + " element does not have " + propertyName + " property.");
                    return false;
                }

                try
                {
                    var valueType = property.GetValue(Element).GetType();
                    var convertedValue = Convert.ChangeType(value, valueType);
                    property.SetValue(Element, convertedValue);
                }
                catch (Exception e)
                {
                    Log.Debug(e.ToString());
                    return false;
                }

                return true;
            });
        }

        public bool HasTextPropertyByName(string name)
        {
            return RunOnMainThread<bool>(() =>
            {
                string[] TextProperties = { "Text", "Name", "FormattedText", "Title", "Placeholder", "Detail" };

                foreach (var prop in TextProperties)
                {
                    var text = Element?.GetType().GetProperty(prop)?.GetValue(Element)?.ToString();
                    if (!string.IsNullOrEmpty(text))
                    {
                        if (text.Equals(name))
                        {
                            return true;
                        }
                    }
                }
                return false;
            });
        }

        public bool HasProperty(string propertyName)
        {
            var property = Element?.GetType().GetProperty(propertyName);
            if (property == null)
                return false;

            return true;
        }

        T RunOnMainThread<T>(Func<T> func)
        {
            var tcs = new TaskCompletionSource<T>();
            Device.BeginInvokeOnMainThread(() =>
            {
                var t = func();
                tcs.SetResult(t);
            });
            return tcs.Task.Result;
        }
    }
}
