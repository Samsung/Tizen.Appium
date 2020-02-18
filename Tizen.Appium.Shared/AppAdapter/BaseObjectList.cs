using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace Tizen.Appium
{
    public class DefaultObjectList : BaseObjectList
    {
        protected override IObjectWrapper CreateWrapper(object obj)
        {
            return null;
        }
    }

    public abstract class BaseObjectList : IObjectList
    {
        ConcurrentDictionary<string, IObjectWrapper> _list = new ConcurrentDictionary<string, IObjectWrapper>();

        public void Add(object element)
        {
            var wrapper = CreateWrapper(element);

            if (wrapper == null)
                return;

            if (_list.TryAdd(wrapper.Id, wrapper))
            {
                wrapper.Deleted += (s, e) =>
                {
                    RemoveById(wrapper.Id);
                };

                Log.Debug("[Added] id=" + wrapper.Id + ", element=" + element.GetType() + ", _elements.Count=" + _list.Count);
            }
            else
            {
                _list.TryUpdate(wrapper.Id, wrapper, _list[wrapper.Id]);
                Log.Debug("[Updated] " + wrapper.Id + " object already exists. It wiill be updated to element=" + element.GetType() + ", _elements.Count=" + _list.Count);
            }
        }

        public void RemoveById(string id)
        {
            if (!string.IsNullOrEmpty(id) && _list.ContainsKey(id))
            {
                IObjectWrapper wrapper;
                _list.TryRemove(id, out wrapper);
                Log.Debug("[Removed][object] id= " + id + ", list.Count=" + _list.Count);
            }
        }

        public void Clear()
        {
            _list.Clear();
        }

        public IObjectWrapper Get(string id)
        {
            IObjectWrapper wrapper = null;
            _list.TryGetValue(id, out wrapper);
            Log.Debug("[GetElement] objectList.ContainsKey? " + _list.ContainsKey(id) + ", objectList.Count=" + _list.Count);

            if (wrapper == null)
            {
                wrapper = _list.FirstOrDefault(kv => (string)kv.Value.GetPropertyValue("AutomationId") == id).Value;
            }

            if (wrapper != null && wrapper.IsShown)
                return wrapper;

            return null;
        }

        public IEnumerable<string> GetIdsByName(string name)
        {
            var selected = _list.Where(kv => kv.Value.IsShown && kv.Value.ContainsText(name)).Select(kv => kv.Value.Id);
            return selected;
        }

        public IEnumerable<string> GetFocusedElementIds()
        {
            var focused = _list.Where(kv => kv.Value.IsShown && kv.Value.IsFocused).Select(kv => kv.Value.Id);
            return focused;
        }

        protected abstract IObjectWrapper CreateWrapper(object obj);
    }
}
