using System;
using ItemContext = Xamarin.Forms.Platform.Tizen.Native.ListView.ItemContext;
using Xamarin.Forms;

namespace Tizen.Appium.Forms
{
    public class CellWrapper : BaseObjectWrapper<Cell>
    {
        WeakReference<ItemContext> _ref;
        string _id;

        public override string[] TextProperties => new string[] { "Text", "FormattedText" };
        public override string[] DisplayedTextProperies => new string[] { "Text", "Name", "FormattedText", "Title", "Placeholder", "Detail" };

        public override event EventHandler Deleted;

        public override string Id => _id;

        public override bool IsShown
        {
            get
            {
                return (Control != null) ? Control.GetIsShownProperty() : false;
            }
        }

        public override Cell Control
        {
            get
            {
                return Context?.Cell;
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
                        var trackObj = Context.Item.TrackObject;
                        if (trackObj != null)
                        {
                            return new Geometry(trackObj.Geometry.X, trackObj.Geometry.Y, trackObj.Geometry.Width, trackObj.Geometry.Height);
                        }
                    }

                    return new Geometry();
                });
            }
        }

        public override bool IsFocused
        {
            get
            {
                return (Control != null) ? Context.Item.IsSelected : false;
            }
        }

        ItemContext Context
        {
            get
            {
                ItemContext ic;
                if (_ref.TryGetTarget(out ic))
                {
                    return ic;
                }

                Deleted?.Invoke(this, EventArgs.Empty);
                return null;
            }
        }

        public CellWrapper(ItemContext ic)
        {
            _ref = new WeakReference<ItemContext>(ic);
            _id = ic.Cell.GetId();

            ic.Cell.Disappearing += (s, e) =>
            {
                Deleted?.Invoke(this, EventArgs.Empty);
            };

            ic.Item.Deleted += (s, e) =>
            {
                Deleted?.Invoke(this, EventArgs.Empty);
            };
        }
    }
}
