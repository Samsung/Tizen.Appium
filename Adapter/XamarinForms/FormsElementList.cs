using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using ItemContext = Xamarin.Forms.Platform.Tizen.Native.ListView.ItemContext;

namespace Tizen.Appium
{
    public class FormsElementList : IObjectList
    {
        IDictionary<string, FormsElementWrapper> _elementList = new Dictionary<string, FormsElementWrapper>();

        public void Add(object element)
        {
            var wrapper = new FormsElementWrapper(element);
            wrapper.Deleted += (s, e) =>
            {
                RemoveById(wrapper.Id);
            };

            _elementList[wrapper.Id] = wrapper;
            Log.Debug("[Added] id=" + wrapper.Id + ", element=" + element.GetType() + ", _elements.Count=" + _elementList.Count);
        }

        public void Remove(object element)
        {
            string id = "";

            if (element is Element)
            {
                id = ((Element)element).GetId();
            }
            else if (element is ItemContext)
            {
                id = ((ItemContext)element).Cell.GetId();
            }

            if (!String.IsNullOrEmpty(id) && _elementList.ContainsKey(id))
            {
                _elementList.Remove(id);
                Log.Debug("[Removed] id=" + id + ", element=" + element.GetType() + ", _elements.Count=" + _elementList.Count);
            }
        }

        public void RemoveById(string id)
        {
            if (_elementList.ContainsKey(id))
            {
                _elementList.Remove(id);
                Log.Debug("[Removed] id=" + id + ", _elements.Count=" + _elementList.Count);
            }
        }

        public string GetIdByObject(object element)
        {
            return _elementList.FirstOrDefault(kv => kv.Value.Element == element && kv.Value.IsShown).Key;
        }

        public object Get(string id)
        {
            var wrapper = GetObjectWrapper(id);
            return (wrapper != null) ? wrapper.Element : null;
        }

        public IEnumerable<string> GetIdsByName(string name)
        {
            Console.WriteLine("GetIdsByNames: " + name);
            var selected = _elementList.Where(kv => kv.Value.Name == name && kv.Value.IsShown == true).Select(kv => kv.Value.Id);

            Console.WriteLine("selected: " + selected.Count());

            foreach(var s in selected)
            {
                Console.WriteLine("id: " + s);
            }

            return selected;
        }

        public Location GetLocation(string id)
        {
            var nativeView = GetObjectWrapper(id)?.NativeView;

            if (nativeView != null)
                return new Location(nativeView.Geometry.X, nativeView.Geometry.Y, 0, 0, nativeView.Geometry.Width, nativeView.Geometry.Height);
            else
                return new Location();
        }

        public void Clear()
        {
            _elementList.Clear();
        }

        internal void ResetToolbarItems()
        {
            var oldItemKeys = _elementList.Where(kv => kv.Value.Element is ToolbarItem).Select(kv => kv.Key).ToList();

            Log.Debug("[Reset toolbar] oldKeys= " + oldItemKeys);

            foreach (var key in oldItemKeys)
            {
                _elementList.Remove(key);
            }
            Log.Debug("[Reset toolbar] _elements.Count=" + _elementList.Count);
        }

        FormsElementWrapper GetObjectWrapper(string id)
        {
            Log.Debug("[GetElement] _elements.ContainsKey? " + _elementList.ContainsKey(id) + ", _elements.Count=" + _elementList.Count);

            FormsElementWrapper wrapper = null;
            _elementList.TryGetValue(id, out wrapper);

            return wrapper;
        }
    }
}
