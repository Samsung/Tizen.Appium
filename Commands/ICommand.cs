namespace Tizen.Appium
{
    internal interface ICommand
    {
        string Command { get; }

        Result Run(Request req);
    }
}
