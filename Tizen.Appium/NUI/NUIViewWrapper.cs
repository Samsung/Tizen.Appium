using System;
using Tizen.NUI.BaseComponents;

namespace Tizen.Appium
{
    class NUIViewWrapper : BaseObjectWrapper<View>
    {
        WeakReference<View> _ref;
        string _id;
        bool _isShown;
        bool _isFocused;

        View _view;

        public override string[] TextProperties => new string[] { "Text", "LabelText" };
        public override string[] DisplayedTextProperies => new string[] { "Text", "LabelText" };

        public override string Id => _id;

        public override bool IsFocused => _isFocused;

        public override bool IsShown => _isShown;

        public override View Control
        {
            get
            {
                if (_view != null)
                    return _view;

                Deleted?.Invoke(this, EventArgs.Empty);
                return null;
            }
        }

        public override Geometry Geometry
        {
            get
            {
                if (Control is View v)
                {
                    return new Geometry((int)v.Position2D.X, (int)v.Position2D.Y, (int)v.Size2D.Width, (int)v.Size2D.Height);
                }

                return new Geometry();
            }
        }

        public override event EventHandler Deleted;

        public NUIViewWrapper(View view)
        {
            _ref = new WeakReference<View>(view);
            _view = view;
            _isShown = true;
            _isFocused = false;

            if (!string.IsNullOrEmpty((view).AutomationId))
            {
                _id = view.AutomationId;
            }
            else
            {
                _id = view.GetHashCode().ToString();
            }

            view.FocusGained += (s, e) =>
            {
                _isFocused = true;
            };

            view.FocusLost += (s, e) =>
            {
                _isFocused = false;
            };

            view.RemovedFromWindow += (s, e) =>
            {
                Deleted?.Invoke(this, EventArgs.Empty);
            };
        }
    }
}
