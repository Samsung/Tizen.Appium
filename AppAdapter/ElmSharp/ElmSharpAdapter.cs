namespace Tizen.Appium
{
    public sealed class ElmSharpAdapter : IAppAdapter
    {
        EvasObjectList _objectList = new EvasObjectList();

        public IObjectList ObjectList => _objectList;

        public ElmSharpAdapter()
        {
        }
    }
}