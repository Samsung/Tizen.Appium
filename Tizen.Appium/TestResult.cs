using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace Tizen.Appium
{
    public class TestResult
    {
        IDictionary<string, object> _data = null;

        public bool Result { get; private set; }

        public IReadOnlyDictionary<string, object> Data
        {
            get
            {
                return new ReadOnlyDictionary<string, object>(_data);
            }
        }

        public TestResult(bool result = false)
        {
            Result = result;
            _data = new Dictionary<string, object>();
        }

        public void SetResult(bool val)
        {
            Result = val;
        }

        public void ResetResult()
        {
            Result = false;
            if (_data != null)
            {
                _data.Clear();
                _data = null;
            }
        }

        public void SetData(string key, object obj)
        {
            if (_data != null)
            {
                _data[key] = obj;
            }
        }

        public void RemoveData(string key)
        {
            if (_data != null)
            {
                _data.Remove(key);
            }
        }

        public override string ToString()
        {
            var s = "{ " + Result;

            foreach (var p in _data)
            {
                s += String.Format(", {{{0}:{1}}}", p.Key, p.Value);
            }
            s += "}";

            return s;
        }
    }
}
