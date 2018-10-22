using System;

namespace Tizen.Appium
{
    public sealed class ElmSharpAdapter : IAppAdapter
    {
        IObjectList IAppAdapter.ObjectList => throw new NotImplementedException();
    }
}