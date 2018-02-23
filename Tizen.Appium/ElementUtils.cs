using ElmSharp;
using System;
using System.Collections.Generic;

namespace Tizen.Appium
{
    public class ElementUtils
    {
        static IDictionary<string, WeakReference> _testObjects = new Dictionary<string, WeakReference>();

        static IDictionary<string, WeakReference> _testItems = new Dictionary<string, WeakReference>();

        public static object GetTestableElement(string id)
        {
            Log.Debug(TizenAppium.Tag, "_testObjects.ContainsKey?" + _testObjects.ContainsKey(id) + ", _testObjects.Count=" + _testObjects.Count);
            WeakReference value;
            _testObjects.TryGetValue(id, out value);
            if (value != null && value.IsAlive)
            {
                return value.Target;
            }
            else
            {
                return null;
            }
        }

        public static string GetTestableElementId(object obj)
        {
            Log.Debug(TizenAppium.Tag, "_testObjects.Count = " + _testObjects.Count);
            foreach (var p in _testObjects)
            {
                if (p.Value.Target == obj && p.Value.IsAlive)
                {
                    Log.Debug(TizenAppium.Tag, "element id: " + p.Key);
                    return p.Key;
                }
            }
            Log.Debug(TizenAppium.Tag, "Not Found ID: ");
            return String.Empty;
        }

        public static void AddTestableElement(string id, object element)
        {
            Log.Debug(TizenAppium.Tag, "add object=" + id + ", type=" + element.GetType());
            if (!String.IsNullOrEmpty(id))
            {
                _testObjects[id] = new WeakReference(element);
            }
        }

        public static void AddTestableItem(string key, ItemObject item)
        {
            Log.Debug(TizenAppium.Tag, "add cell=" + key);
            if (!String.IsNullOrEmpty(key))
            {
                key = key.TrimStart().TrimEnd();
                _testItems[key] = new WeakReference(item);
                AddTestableElement(item.GetHashCode().ToString(), item);
            }
        }

        public static ItemObject GetTestableItem(string id)
        {
            Log.Debug(TizenAppium.Tag, "_testCells.ContainsKey?" + _testItems.ContainsKey(id) + ", _testCells.Count=" + _testItems.Count);

            WeakReference value;
            _testItems.TryGetValue(id, out value);
            if (value != null && value.IsAlive)
            {
                return value.Target as ItemObject;
            }
            else
            {
                return null;
            }
        }
    }
}
