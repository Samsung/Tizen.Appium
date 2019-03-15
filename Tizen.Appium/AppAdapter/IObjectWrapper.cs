using System;
using ElmSharp;

namespace Tizen.Appium
{
    public interface IObjectWrapper
    {
        string Id { get; }

        Geometry Geometry { get; }

        string Text { get; }

        bool IsFocused { get; }

        bool IsShown { get; }

        event EventHandler Deleted;

        bool HasProperty(string propertyName);

        object GetPropertyValue(string propertyName);

        bool SetPropertyValue(string propertyName, object value);

        bool ContainsText(string text);

        bool EqualsTo(object obj);
    }
}
