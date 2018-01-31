using System;
using System.Collections.Generic;
using ElmSharp;

namespace Tizen.Appium
{
    // TODO : to be removed. It is a temporaty solution for item pressed event. because of bug in TrackObject.
    public static class ItemObjectExtensions
    {
        static IDictionary<string, EventHandler> _callbacks = new Dictionary<string, EventHandler>();

        public static void SetPressCallback(this ItemObject item, string id, EventHandler callback)
        {
            _callbacks[id] = callback;
        }

        public static void UnsetPressCallback(this ItemObject item, string id)
        {
            if (_callbacks.ContainsKey(id))
            {
                _callbacks.Remove(id);
            }
        }

        public static void InvokeCallback(this ItemObject item, string id)
        {
            if (_callbacks.ContainsKey(id))
            {
                _callbacks[id].Invoke(item, EventArgs.Empty);
            }
        }
    }
}
