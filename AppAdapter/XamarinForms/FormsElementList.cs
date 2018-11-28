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
        object _objcetLock = new object();

        public void Add(object element)
        {
            var wrapper = new FormsElementWrapper(element);
            wrapper.Deleted += (s, e) =>
            {
                RemoveById(wrapper.Id);
            };

            lock (_objcetLock)
            {
                _elementList[wrapper.Id] = wrapper;
                Log.Debug("[Added] id=" + wrapper.Id + ", element=" + element.GetType() + ", _elements.Count=" + _elementList.Count);
            }
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
            else
            {
                id = element.GetHashCode().ToString();
            }


            if (!String.IsNullOrEmpty(id) && _elementList.ContainsKey(id))
            {
                lock(_objcetLock)
                {
                    _elementList.Remove(id);
                    Log.Debug("[Removed] id=" + id + ", element=" + element.GetType() + ", _elements.Count=" + _elementList.Count);
                }
            }
        }

        public void RemoveById(string id)
        {
            if (_elementList.ContainsKey(id))
            {
                lock(_objcetLock)
                {
                    _elementList.Remove(id);
                    Log.Debug("[Removed] id=" + id + ", _elements.Count=" + _elementList.Count);
                }
            }
        }

        public string GetIdByObject(object element)
        {
            return _elementList.FirstOrDefault(kv => kv.Value.Element == element).Key;
        }

        public IObject Get(string id)
        {
            FormsElementWrapper wrapper = null;
            Log.Debug("[GetElement] objectList.ContainsKey? " + _elementList.ContainsKey(id) + ", objectList.Count=" + _elementList.Count);

            _elementList.TryGetValue(id, out wrapper);

            if (wrapper != null && wrapper.Element != null)
                return wrapper;

            return null;
        }

        public IEnumerable<string> GetIdsByName(string name)
        {
            var selected = _elementList.Where(kv => kv.Value.Element != null && kv.Value.HasTextPropertyByName(name)).Select(kv => kv.Value.Id);
            return selected;
        }

        public IEnumerable<string> GetFocusedElementIds()
        {
            var focused = _elementList.Where(kv => kv.Value.Focused).Select(kv => kv.Value.Id);
            return focused;
        }

        public void Clear()
        {
            lock(_objcetLock)
            {
                _elementList.Clear();
            }
        }
    }
}
