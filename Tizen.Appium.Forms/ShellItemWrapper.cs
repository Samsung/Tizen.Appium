using System;
using Xamarin.Forms;
using CShellItemContext = Tizen.Wearable.CircularUI.Forms.Renderer.NavigationView.ItemContext;

namespace Tizen.Appium.Forms
{
    public class ShellItemWrapper : BaseObjectWrapper<Element>
    {
        WeakReference<CShellItemContext> _ref;
        string _id;

        public override string[] TextProperties => new string[] { "Title", "Text", "FormattedText" };
        public override string[] DisplayedTextProperies => new string[] { "Text", "Name", "FormattedText", "Title", "Detail" };

        public override event EventHandler Deleted;

        public override string Id => _id;

        public override bool IsShown
        {
            get
            {
                return (Control != null) ? Control.GetIsShownProperty() : false;
            }
        }

        public override Element Control
        {
            get
            {
                return Context?.Source;
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

        CShellItemContext Context
        {
            get
            {
                CShellItemContext ic;
                if(_ref.TryGetTarget(out ic))
                {
                    return ic;
                }

                Deleted?.Invoke(this, EventArgs.Empty);
                return null;
            }
        }

        public ShellItemWrapper(CShellItemContext ic)
        {
            _ref = new WeakReference<CShellItemContext>(ic);
            _id = ic.Source.GetId();

            ic.Item.Deleted += (s, e) => Deleted?.Invoke(this, EventArgs.Empty);
        }
    }
}
