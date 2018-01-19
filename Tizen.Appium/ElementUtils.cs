using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Tizen.Appium
{
    public class ElementUtils
    {
        static IDictionary<string, WeakReference> _testObjects = new Dictionary<string, WeakReference>();

        public static Element GetTestableElement(string id)
        {
            Log.Debug(TizenAppium.Tag,"#### _testObjects.ContainsKey?"+ _testObjects.ContainsKey(id) + ", _testObjects.Count="+_testObjects.Count);
            WeakReference value;
            _testObjects.TryGetValue(id, out value);
            if (value != null && value.IsAlive)
            {
                return value.Target as Element;
            }
            else
            {
                return null;
            }
        }

        public static void AddTestableElement(string id, Element element)
        {
            Log.Debug(TizenAppium.Tag,"#### add object="+ id + ", type="+element.GetType());
            if (_testObjects.ContainsKey(id) || String.IsNullOrEmpty(id))
                return;

            _testObjects.Add(id, new WeakReference(element));
        }
    }
}
