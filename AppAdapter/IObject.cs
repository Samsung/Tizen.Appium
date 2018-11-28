
namespace Tizen.Appium
{
    public interface IObject
    {
        string Id { get; }

        Geometry Geometry { get; }

        string Text { get; }

        bool HasProperty(string property);

        bool HasTextPropertyByName(string name);

        object GetPropertyValue(string property);

        bool SetPropertyValue(string property, object value);
    }
}
