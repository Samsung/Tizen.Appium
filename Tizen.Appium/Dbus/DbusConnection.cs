using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Tizen.Appium.DBus
{
    public class DbusConnection
    {
        static IntPtr _dbusConn;
        static IntPtr _name;
        static IntPtr _object;
        static IntPtr _interface;

        List<Interop.Edbus.MethodCallback> _methods = new List<Interop.Edbus.MethodCallback>();

        public DbusConnection()
        {
            Console.WriteLine("@@@ DbusConnection");
            Interop.Edbus.dbus_threads_init_default();
            IntPtr error;
            Interop.Edbus.dbus_error_init(out error);

            int ret = Interop.Edbus.e_dbus_init();
            if (ret == 0)
            {
                Console.WriteLine("Error: Failed to init dbus");
            }

            _dbusConn = Interop.Edbus.e_dbus_bus_get(Interop.DBusBusType.DBUS_BUS_SYSTEM);
            if (_dbusConn == null)
            {
                Console.WriteLine("Error: Failed to get dbus bus");
            }

            _name = Interop.Edbus.e_dbus_request_name(_dbusConn, DbusNames.BusName,
                                                     Interop.NameFlags.ReplaceExisting, BusRequestHandler, IntPtr.Zero);

            _object = Interop.Edbus.e_dbus_object_add(_dbusConn, DbusNames.ObjectPath, IntPtr.Zero);
            _interface = Interop.Edbus.e_dbus_interface_new(DbusNames.InterfaceName);

            Interop.Edbus.e_dbus_object_interface_attach(_object, _interface);

            Console.WriteLine("@@@ done!!");
        }

        public void Close()
        {
            _methods.Clear();
            Interop.Edbus.e_dbus_shutdown();
            Interop.Edbus.e_dbus_connection_close(_dbusConn);
        }

        public void AddMethod(string name, Func<string, string> callback)
        {
            Interop.Edbus.MethodCallback methodHandler = (obj, message) =>
            {
                Interop.DBusMessageIter iter = new Interop.DBusMessageIter();
                Interop.Edbus.dbus_message_iter_init(message, ref iter);
                var type = Interop.Edbus.dbus_message_iter_get_arg_type(ref iter);

                var msg = "";
                if (type == DBusArgsType.String)
                {
                    IntPtr ptr;
                    Interop.Edbus.dbus_message_iter_get_basic(ref iter, out ptr);
                    msg = Marshal.PtrToStringAnsi(ptr);
                }
                else
                {
                    Console.WriteLine("@@@@ arg0 error");
                }
                Console.WriteLine("@@@ message={0}", msg);

                IntPtr reply = Interop.Edbus.dbus_message_new_method_return(message);
                Interop.Edbus.dbus_message_iter_init_append(reply, ref iter);
                string ret = callback(msg);
                Console.WriteLine("@@@ reply={0}", ret);

                IntPtr replyMsg = Marshal.StringToHGlobalAnsi(ret);
                Interop.Edbus.dbus_message_iter_append_basic(ref iter, DBusArgsType.String, ref replyMsg);

                return reply;
            };

            _methods.Add(methodHandler);

            Interop.Edbus.e_dbus_interface_method_add(_interface, name, "s", "s", methodHandler);
        }

        static void BusRequestHandler(IntPtr data, IntPtr msg, IntPtr error)
        {
            Console.WriteLine("@@@@ Error occurs during request for dbus name");
        }

        public void BroadcaseSignal(string signalName, string msg)
        {
            Console.WriteLine("@@@ BroadcaseSignal");
            IntPtr signal = Interop.Edbus.dbus_message_new_signal(DbusNames.ObjectPath, DbusNames.InterfaceName, signalName);
            Interop.DBusMessageIter iter = new Interop.DBusMessageIter();
            Interop.Edbus.dbus_message_iter_init_append(signal, ref iter);

            IntPtr msgPtr = Marshal.StringToHGlobalAnsi(msg);
            Console.WriteLine("@@@ signalMessage={0}", Marshal.PtrToStringAnsi(msgPtr));
            Interop.Edbus.dbus_message_iter_append_basic(ref iter, DBusArgsType.String, ref msgPtr);

            if (_dbusConn != null)
            {
                Interop.Edbus.e_dbus_message_send(_dbusConn, signal, SendCallback, -1, IntPtr.Zero);
            }
            else
            {
                Console.WriteLine(" @@@ Dbus connection is not initialized");
            }
        }

        static IntPtr SendCallback(IntPtr data, IntPtr message, IntPtr error)
        {
            Console.WriteLine("@@@ Error occurs while signal is sent");
            return IntPtr.Zero;
        }
    }
}
