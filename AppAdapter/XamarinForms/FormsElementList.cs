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
        IDictionary<string, FormsElementWrapper> _toolbarItems = new Dictionary<string, FormsElementWrapper>();

        public void AddToolbarItem(ToolbarItem item, ToolbarItemPosition position)
        {
            var wrapper = new FormsElementWrapper(item, position);
            _toolbarItems[wrapper.Id] = wrapper;
            Log.Debug("[Added][ToolbarItem] id=" + wrapper.Id + ", element=" + item.GetType() + ", _elements.Count=" + _elementList.Count);
        }

        public void ResetToolbarItems()
        {
            Log.Debug("[Reset][ToolbarItems]");
            _toolbarItems.Clear();
        }

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

            if (element is Element e)
            {
                id = e.GetId();
            }
            else if (element is ItemContext ic)
            {
                id = ic.Cell.GetId();
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
            return _elementList.Concat(_toolbarItems).FirstOrDefault(kv => kv.Value.Element == element).Key;
        }

        public IObject Get(string id)
        {
            FormsElementWrapper wrapper = null;
            var list = _elementList.Concat(_toolbarItems).ToDictionary(kv => kv.Key, kv => kv.Value);

            Log.Debug("[GetElement] objectList.ContainsKey? " + list.ContainsKey(id) + ", objectList.Count=" + list.Count);

            list.TryGetValue(id, out wrapper);

            if (wrapper != null && wrapper.Element != null)
                return wrapper;

            return null;
        }

        public IEnumerable<string> GetIdsByName(string name)
        {
            var selected = _elementList.Concat(_toolbarItems).Where(kv => kv.Value.Text == name && kv.Value.Element != null).Select(kv => kv.Value.Id);
            return selected;
        }

        public IEnumerable<string> GetFocusedElementIds()
        {
            var focused = _elementList.Where(kv => kv.Value.Focused).Select(kv => kv.Value.Id);
            return focused;
        }

        public void Clear()
        {
            _elementList.Clear();
        }
    }
}
