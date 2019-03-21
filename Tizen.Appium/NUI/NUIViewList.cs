using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Tizen.NUI.BaseComponents;

namespace Tizen.Appium
{
    public class NUIViewList : IObjectList
    {
        ConcurrentDictionary<string, NUIViewWrapper> _list = new ConcurrentDictionary<string, NUIViewWrapper>();

        public void Add(object element)
        {
            NUIViewWrapper wrapper;
            if (element is View v)
            {
                wrapper = new NUIViewWrapper(v);
            }
            else
            {
                return;
            }

            if (_list.TryAdd(wrapper.Id, wrapper))
            {
                wrapper.Deleted += (s, e) =>
                {
                    RemoveById(wrapper.Id);
                };
                Log.Debug("[Added][object] id=" + wrapper.Id + ", type=" + element?.GetType() + ", list.Count=" + _list.Count);
            }
        }

        public void Clear()
        {
            _list.Clear();
        }

        public IObjectWrapper Get(string id)
        {
            NUIViewWrapper wrapper = null;
            _list.TryGetValue(id, out wrapper);

            if (wrapper == null)
            {
                wrapper = _list.Where(kv => (string)kv.Value.GetPropertyValue("AutomationId") == id).FirstOrDefault().Value;
            }

            if (wrapper != null && wrapper.IsShown)
                return wrapper;

            return null;
        }

        public IEnumerable<string> GetFocusedElementIds()
        {
            var selected = _list.Where(kv => kv.Value.IsShown && kv.Value.IsFocused == true).Select(kv => kv.Value.Id);
            return selected;
        }

        public string GetIdByObject(object element)
        {
            var key = _list.Where(kv => kv.Value == element).FirstOrDefault().Key;
            return key;
        }

        public IEnumerable<string> GetIdsByName(string name)
        {
            Log.Debug("_list.count=" + _list.Count);
            foreach (var kv in _list)
            {
                Log.Debug($"{kv.Key}.{kv.Value}");
            }

            var selected = _list.Where(kv => kv.Value.IsShown && kv.Value.Text == name).Select(kv => kv.Value.Id);
            return selected;
        }

        public void Remove(object element)
        {
            var key = _list.Where(kv => kv.Value.Control == element).FirstOrDefault().Key;
            RemoveById(key);
        }

        public void RemoveById(string id)
        {
            if (_list.ContainsKey(id))
            {
                NUIViewWrapper wrapper;
                _list.TryRemove(id, out wrapper);
                Log.Debug("[Removed][object] id= " + id + ", list.Count=" + _list.Count);
            }
        }
    }
}
