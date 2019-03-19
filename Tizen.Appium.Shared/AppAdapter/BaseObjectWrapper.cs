using System;
using ElmSharp;

namespace Tizen.Appium
{
    public abstract class BaseObjectWrapper<T> : IObjectWrapper
    {
        public abstract T Control { get; }
        public abstract string Id { get; }
        public abstract bool IsFocused { get; }
        public abstract bool IsShown { get; }
        public abstract string[] TextProperties { get; }
        public abstract string[] DisplayedTextProperies { get; }
        public abstract Geometry Geometry { get; }

        public abstract event EventHandler Deleted;

        public virtual string Text
        {
            get
            {
                return TizenAppium.RunOnMainThread<string>(() =>
                {
                    foreach (var prop in TextProperties)
                    {
                        var text = Control?.GetType().GetProperty(prop)?.GetValue(Control)?.ToString();
                        if (!string.IsNullOrEmpty(text))
                            return text;
                    }

                    return string.Empty;
                });
            }
        }

        public virtual bool HasProperty(string propertyName)
        {
            var property = Control?.GetType().GetProperty(propertyName);
            if (property == null)
                return false;

            return true;
        }

        public virtual object GetPropertyValue(string propertyName)
        {
            return TizenAppium.RunOnMainThread<object>(() =>
            {
                var value = Control?.GetType().GetProperty(propertyName)?.GetValue(Control);
                return value;
            });
        }

        public virtual bool SetPropertyValue(string propertyName, object value)
        {
            return TizenAppium.RunOnMainThread<bool>(() =>
            {
                var property = Control?.GetType().GetProperty(propertyName);
                if (property == null)
                {
                    Log.Debug(Id + " element does not have " + propertyName + " property.");
                    return false;
                }

                try
                {
                    var valueType = property.GetValue(Control).GetType();
                    var convertedValue = Convert.ChangeType(value, valueType);
                    property.SetValue(Control, convertedValue);
                }
                catch (Exception e)
                {
                    Log.Debug(e.ToString());
                    return false;
                }

                return true;
            });
        }

        public virtual bool ContainsText(string text)
        {
            return TizenAppium.RunOnMainThread<bool>(() =>
            {
                foreach (var prop in DisplayedTextProperies)
                {
                    var textValue = Control?.GetType().GetProperty(prop)?.GetValue(Control)?.ToString();
                    if (!string.IsNullOrEmpty(textValue))
                    {
                        if (textValue.Equals(text))
                        {
                            return true;
                        }
                    }
                }
                return false;
            });
        }

        public virtual bool EqualsTo(object obj)
        {
            if (Control != null)
                return Control.Equals(obj);

            return false;
        }
    }
}
