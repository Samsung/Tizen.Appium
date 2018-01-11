namespace Tizen.Appium.Dbus
{
    public interface IDbusMethod
    {
        string Name { get; }

        string Signature { get; }

        string ReturnSignature { get; }

        string[] Params { get; }

        Arguments Run(Arguments args);
    }
}
