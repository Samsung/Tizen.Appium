using System.Collections.Generic;

namespace Tizen.Appium
{
    public interface IObjectList
    {
        void Add(object element);

        void Remove(object element);

        void RemoveById(string id);

        string GetIdByObject(object element);

        IObject Get(string id);

        IEnumerable<string> GetFocusedElementIds();

        IEnumerable<string> GetIdsByName(string name);

        void Clear();
    }
}