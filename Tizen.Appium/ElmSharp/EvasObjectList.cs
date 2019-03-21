using ElmSharp;

namespace Tizen.Appium
{
    class EvasObjectList : BaseObjectList
    {
        protected override IObjectWrapper CreateWrapper(object obj)
        {
            if (obj is EvasObject evas)
            {
                return new EvasObjectWrapper(evas);
            }
            else if (obj is ItemObject item)
            {
                return new ItemObjectWrapper(item);
            }
            return null;
        }
    }
}
