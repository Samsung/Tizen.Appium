using System.Collections.Generic;

namespace Tizen.Appium
{
    public interface IObjectList
    {
        void Add(object element);

        void Remove(object element);

        void RemoveById(string id);

        string GetIdByObject(object element);

        object Get(string id);

        IEnumerable<string> GetIdsByName(string name);

        Location GetLocation(string id);

        string GetTextbyId(string id);

        void Clear();
    }
}