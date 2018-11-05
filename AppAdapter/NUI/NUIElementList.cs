using System;
using System.Collections.Generic;

namespace Tizen.Appium
{
    public class NUIElementList : IObjectList
    {
        void IObjectList.Add(object element)
        {
            throw new NotImplementedException();
        }

        void IObjectList.Clear()
        {
            throw new NotImplementedException();
        }

        IObject IObjectList.Get(string id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<string> IObjectList.GetFocusedElementIds()
        {
            throw new NotImplementedException();
        }

        string IObjectList.GetIdByObject(object element)
        {
            throw new NotImplementedException();
        }

        IEnumerable<string> IObjectList.GetIdsByName(string name)
        {
            throw new NotImplementedException();
        }

        void IObjectList.Remove(object element)
        {
            throw new NotImplementedException();
        }

        void IObjectList.RemoveById(string id)
        {
            throw new NotImplementedException();
        }
    }
}