namespace Tizen.Appium
{
    public interface ICommand
    {
        string Command { get; }

        Result Run(Request req, IObjectList objectList, IInputGenerator inputGen);
    }
}
