namespace Tizen.Appium.Dbus
{
    public interface IDbusMethod
    {
        string Name { get; }

        string Signature { get; }

        string ReturnSignature { get; }

        string[] Args { get; }

        Arguments Run(Arguments args);
    }
}
