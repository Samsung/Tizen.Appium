using System;
using ElmSharp;

namespace Tizen.Appium
{
    public class ItemObjectWrapper : BaseObjectWrapper<ItemObject>
    {
        WeakReference<ItemObject> _ref;
        string _id;
        bool _isFocused;

        public override string[] TextProperties => new string[] { "Text", "Label" };
        public override string[] DisplayedTextProperies => new string[] { "Text", "Label" };
        string[] TextParts = { "elm.text", "elm.test.end", "elm.test.sub", "elm.test.sub.end", "elm.swallow.content" };

        public override string Id => _id;

        public override bool IsFocused => _isFocused;

        public override event EventHandler Deleted;

        public override bool IsShown
        {
            get
            {
                if (Control != null)
                {
                    var g = Geometry;

                    if ((g.X + g.Width) < 0 || (g.Y + g.Height) < 0 ||
                        g.X > ElmSharpAdapter.ScreenWidth ||
                        g.Y > ElmSharpAdapter.ScreenHeight)
                        return false;
                }

                return true;
            }
        }

        public ItemObjectWrapper(ItemObject item)
        {
            _ref = new WeakReference<ItemObject>(item);
            _id = item.GetHashCode().ToString();

            _isFocused = false;

            item.Deleted += (s, e) =>
            {
                Deleted?.Invoke(this, EventArgs.Empty);
            };
        }

        public override ItemObject Control
        {
            get
            {
                ItemObject item;
                if (_ref.TryGetTarget(out item))
                    return item;

                Deleted?.Invoke(this, EventArgs.Empty);
                return null;
            }
        }

        public override Geometry Geometry
        {
            get
            {
                return TizenAppium.RunOnMainThread<Geometry>(() =>
                {
                    if (Control != null)
                    {
                        var geometry = Control.TrackObject.Geometry;
                        return new Geometry(geometry.X, geometry.Y, geometry.Width, geometry.Height);
                    }

                    return new Geometry();
                });
            }
        }

        public override string Text
        {
            get
            {
                return TizenAppium.RunOnMainThread<string>(() =>
                {
                    foreach (var prop in TextProperties)
                    {
                        var text = Control?.GetType().GetProperty(prop)?.GetValue(Control);
                        if (text != null)
                            return text.ToString();
                    }

                    foreach (var part in TextParts)
                    {
                        string text = Control?.GetPartText(part);
                        if (!string.IsNullOrEmpty(text))
                            return text;
                    }
                    return string.Empty;
                });
            }
        }

        public override bool ContainsText(string text)
        {
            return TizenAppium.RunOnMainThread<bool>(() =>
            {
                string[] TextProperties = { "Text", "Label" };
                foreach (var prop in TextProperties)
                {
                    var value = Control?.GetType().GetProperty(prop)?.GetValue(Control).ToString();
                    if (value == text)
                    {
                        return true;
                    }
                }

                string[] TextParts = { "elm.text", "elm.test.end", "elm.test.sub", "elm.test.sub.end", "elm.swallow.content" };
                foreach (var part in TextParts)
                {
                    string str = Control?.GetPartText(part);
                    if (str == text)
                    {
                        return true;
                    }
                }

                return false;
            });
        }
    }
}
