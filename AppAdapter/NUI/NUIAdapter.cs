using System;
using System.Collections.Generic;
using Tizen.NUI;

namespace Tizen.Appium
{
    public sealed class NUIAdapter : IAppAdapter
    {
        NUIElementList _objectList = new NUIElementList();

        IObjectList IAppAdapter.ObjectList => _objectList;


        public NUIAdapter(NUIApplication app)
        {
            Log.Debug(" ------------------- init nui adapter");
        }
    }
}