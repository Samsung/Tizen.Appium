using System;
using System.Collections.Generic;
using ElmSharp;
using System.Runtime.InteropServices;
using T = Tizen;

namespace Tizen.Appium
{
    public class Edbus
    {
        string LogTag = "Appium";
        string BusName = "org.tizen.system.restful";
        string ObjectPath = "/Org/Tizen/System/Restful/Systeminfo";
        string IfaceName = "org.tizen.system.restful.systeminfo";
        string SignalIfaceName = "tizen.restful.systeminfo";
        string EdbusMethodName = "Get";
        string GetPositionMethodName = "GetPosition";
        string SetCommandMethodName = "SetCommand";
        IntPtr edbus_conn = IntPtr.Zero;
        IntPtr iface = IntPtr.Zero;

        public Edbus()
        {
            T.Log.Debug(LogTag, "Enter");
            Interop.Edbus.dbus_threads_init_default();
            IntPtr error;
            Interop.Edbus.dbus_error_init(out error);

            int ret = Interop.Edbus.e_dbus_init();
            if (ret == 0)
            {
                T.Log.Error(LogTag, "Enter");
            }

            edbus_conn = Interop.Edbus.e_dbus_bus_get(Interop.DBusBusType.DBUS_BUS_SYSTEM);
            if (edbus_conn == null)
            {
                T.Log.Error(LogTag, "Enter");
            }

            IntPtr edbus_request_name = Interop.Edbus.e_dbus_request_name(edbus_conn, BusName,
                                                     Interop.NameFlags.ReplaceExisting, BusRequestHandler, IntPtr.Zero);

            IntPtr obj = Interop.Edbus.e_dbus_object_add(edbus_conn, ObjectPath, IntPtr.Zero);
            iface = Interop.Edbus.e_dbus_interface_new(IfaceName);
            Interop.Edbus.e_dbus_object_interface_attach(obj, iface);

            T.Log.Debug(LogTag, "Enter");
        }

        public void Initialize()
        {
            Interop.Edbus.e_dbus_interface_method_add(iface, GetPositionMethodName, string.Empty, string.Empty, GetPositionHandler);
            Interop.Edbus.e_dbus_interface_method_add(iface, SetCommandMethodName, string.Empty, string.Empty, SetCommandHandler);

            // For just test
            Interop.Edbus.e_dbus_interface_method_add(iface, EdbusMethodName, "i", string.Empty, method_cb);
        }

        public IntPtr GetPositionHandler(IntPtr obj, IntPtr message)
        {
            T.Log.Debug(LogTag, "Enter");
            return IntPtr.Zero;
        }

        public IntPtr SetCommandHandler(IntPtr obj, IntPtr message)
        {
            T.Log.Debug(LogTag, "Enter");
            return IntPtr.Zero;
        }

        public void BusRequestHandler(IntPtr data, IntPtr msg, IntPtr error)
        {
            T.Log.Debug(LogTag, "Enter");
            /*
            IntPtr err;
            Interop.Edbus.dbus_error_init(out err);
            IntPtr value;
            bool r = Interop.Edbus.dbus_message_get_args(msg, out error, (int)117, out value, (int)'\0');
            T.Log.Debug(LogTag, "Enter ");
            */
        }

        public IntPtr method_cb(IntPtr obj, IntPtr message)
        {
            T.Log.Debug(LogTag, "Enter");

            /*
            IntPtr error;
            Interop.Edbus.dbus_error_init(out error);

            IntPtr iter = Marshal.AllocHGlobal(56);
            Interop.Edbus.dbus_message_iter_init(message, iter);

            int type = Interop.Edbus.dbus_message_iter_get_arg_type(out iter);
            IntPtr data;
            Interop.Edbus.dbus_message_iter_get_basic(out iter, out data);
            Interop.Edbus.dbus_message_iter_next(out iter);
            string automationId = Marshal.PtrToStringAnsi(data);
            */

            IntPtr iter = Marshal.AllocHGlobal(56);

            IntPtr error;
            Interop.Edbus.dbus_error_init(out error);

            IntPtr reply = Interop.Edbus.dbus_message_new_method_return(message);

            /*
            Interop.Edbus.dbus_message_iter_init_append(reply, iter);
            IntPtr X;
            bool ret = Interop.Edbus.dbus_message_iter_append_basic(out iter, Interop.DBusDataType.DBUS_TYPE_INT_32, out X);
            */
            return reply;
        }

        public void BroadcastSignal()
        {
            T.Log.Debug(LogTag, "Enter");
            IntPtr msg = Interop.Edbus.dbus_message_new_signal(ObjectPath, SignalIfaceName, EdbusMethodName);
            Interop.Edbus.e_dbus_message_send(edbus_conn, msg, null, -1, IntPtr.Zero);
            T.Log.Debug(LogTag, "End");
        }
    }
}