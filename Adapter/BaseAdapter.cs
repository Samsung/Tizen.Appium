namespace Tizen.Appium
{
    public abstract class BaseAdapter
    {
        public IObjectList ObjectList { get; private set; }

        public Server Server { get; private set; }

        protected BaseAdapter()
        {
            ObjectList = InitObjectList();
            Server = InitServer();
            Server.Start();
        }

        protected abstract IObjectList InitObjectList();

        protected abstract Server InitServer();
    }
}