namespace Tizen.Appium
{
    public interface ICommand
    {
        string Command { get; }

        Result Run(Request req);
    }
}
