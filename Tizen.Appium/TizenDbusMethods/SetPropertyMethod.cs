using System;
using Tizen.Appium.Dbus;
using ElmSharp;

namespace Tizen.Appium
{
    public class SetPropertyMethod : IDbusMethod
    {
        public string Name => MethodNames.SetProperty;

        public string Signature => "sss";

        public string ReturnSignature => "b";

        public string[] Args => new string[] { Params.ElementId, Params.PropertyName, Params.Value };

        public Arguments Run(Arguments args)
        {
            Log.Debug(TizenAppium.Tag, "SetProperty");

            var elementId = (string)args[Params.ElementId];
            var propertyName = (string)args[Params.PropertyName];
            var newValue = (string)args[Params.Value];

            var ret = new Arguments();

            var element = ElementUtils.GetTestableElement(elementId);
            if (element == null)
            {
                Log.Debug(TizenAppium.Tag, "Not Found Element");
                ret.SetArgument(Params.Return, false);
                return ret;
            }

            element = (element is ItemObject) ? ((ItemObject)element).TrackObject : element;

            var property = element.GetType().GetProperty(propertyName);
            if (property == null)
            {
                Log.Debug(TizenAppium.Tag, elementId + " element does not have " + propertyName + " property.");
                ret.SetArgument(Params.Return, false);
                return ret;
            }

            try
            {
                if (property.GetValue(element) is Xamarin.Forms.Element)
                {
                    var obj = ElementUtils.GetTestableElement(newValue);
                    if (obj != null)
                    {
                        property.SetValue(element, obj);
                    }
                }
                else
                {
                    var valueType = property.GetValue(element).GetType();
                    var value = Convert.ChangeType(newValue, valueType);
                    Log.Debug(TizenAppium.Tag, newValue + " is converted to " + value + "(" + value.GetType() + ")");
                    property.SetValue(element, value);
                }

                ret.SetArgument(Params.Return, true);
                return ret;
            }
            catch (Exception e)
            {
                Log.Debug(TizenAppium.Tag, e.ToString());
                ret.SetArgument(Params.Return, false);
                return ret;
            }
        }
    }
}
