using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Tizen.Appium
{
    class TestHelper
    {
        static IDictionary<string, WeakReference> _testObjects = new Dictionary<string, WeakReference>();

        public static Element GetTestableElement(string id)
        {
            Console.WriteLine("################## _testObjects.ContainsKey?{0}, _testObjects.Count={1}", _testObjects.ContainsKey(id), _testObjects.Count);
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
            Console.WriteLine("############# add object={0}, type={1} ", id, element.GetType());
            if (_testObjects.ContainsKey(id) || String.IsNullOrEmpty(id))
                return;

            _testObjects.Add(id, new WeakReference(element));
        }
    }
}
