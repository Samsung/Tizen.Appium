using System;

namespace Tizen.Appium
{
    public abstract class BaseAdapter : IAppAdapter
    {
        IObjectList _objectList;

        public IObjectList ObjectList => _objectList;

        protected BaseAdapter()
        {
            _objectList = CreateObjectList();
            AdaptApp();
        }
        protected abstract IObjectList CreateObjectList();

        protected abstract void AdaptApp();
    }
}