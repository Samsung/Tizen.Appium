using System;

namespace Tizen.Appium.Dbus
{
    public class GetPropertyMethod : IDbusMethod
    {
        public string Name => Dbus.Methods.GetProperty;

        public string Signature => "ss";

        public string ReturnSignature => "s";

        public string[] Params => new string[] { Dbus.Params.ElementId, Dbus.Params.PropertyName };

        public Arguments Run(Arguments args)
        {
            Console.WriteLine("#### GetProperty");

            var elementId = (string)args[Dbus.Params.ElementId];
            var propertyName = (string)args[Dbus.Params.PropertyName];

            var ret = new Arguments();

            var element = ElementUtils.GetTestableElement(elementId);
            if (element == null)
            {
                Console.WriteLine("### Not Found Element");
                ret.SetArgument(Dbus.Params.Return, string.Empty);
                return ret;
            }

            var value = element.GetType().GetProperty(propertyName)?.GetValue(element);
            object retVal = new object();

            if (value != null)
            {
                retVal = value;
            }
            else
            {
                Console.WriteLine("### {0} element does not have {1} property.", elementId, propertyName);
                retVal = string.Empty;
            }

            ret.SetArgument(Dbus.Params.Return, retVal.ToString());

            return ret;
        }
    }
}
