using System;
using ElmSharp;
using Tizen.Appium;

namespace Tizen.Appium
{
    public class EvasObjectWrapper : BaseObjectWrapper<EvasObject>
    {
        WeakReference<EvasObject> _ref;
        string _id;
        bool _isShown;
        bool _isFocused;

        public override string[] TextProperties => new string[] { "Text", "Label" };
        public override string[] DisplayedTextProperies => new string[] { "Text", "Label" };

        public EvasObjectWrapper(EvasObject evas)
        {
            _ref = new WeakReference<EvasObject>(evas);
            _isShown = true;
            _isFocused = false;

            if (!string.IsNullOrEmpty((evas).AutomationId))
            {
                _id = evas.AutomationId;
            }
            else
            {
                _id = evas.GetHashCode().ToString();
            }

            evas.Hidden += (s, e) =>
            {
                _isShown = false;
            };

            evas.Shown += (s, e) =>
            {
                _isShown = true;
            };

            evas.Deleted += (s, e) =>
            {
                Deleted?.Invoke(this, EventArgs.Empty);
            };

            if (evas is Widget w)
            {
                w.Focused += (s, e) =>
                {
                    _isFocused = true;
                };

                w.Unfocused += (s, e) =>
                {
                    _isFocused = false;
                };
            }
        }

        public override string Id => _id;
        public override bool IsFocused => _isFocused;

        public override bool IsShown => _isShown;

        public override Geometry Geometry
        {
            get
            {
                return TizenAppium.RunOnMainThread<Geometry>(() =>
                {
                    if (Control is EvasObject evas)
                    {
                        return new Geometry(evas.Geometry.X, evas.Geometry.Y, evas.Geometry.Width, evas.Geometry.Height);
                    }

                    return new Geometry();
                });
            }
        }

        public override EvasObject Control
        {
            get
            {
                EvasObject evas;
                if (_ref.TryGetTarget(out evas))
                    return evas;

                Deleted?.Invoke(this, EventArgs.Empty);
                return null;
            }
        }

        public override event EventHandler Deleted;
    }
}
