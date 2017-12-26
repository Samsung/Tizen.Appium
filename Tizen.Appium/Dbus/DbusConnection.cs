using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;

namespace Tizen.Appium.DBus
{
    public class DbusConnection
    {
        static IntPtr _conn;
        static IntPtr _econn;

        static IntPtr _object;
        static IntPtr _interface;

        List<Interop.Edbus.MethodCallback> _methods = new List<Interop.Edbus.MethodCallback>();

        public DbusConnection()
        {
            Console.WriteLine(" ################# DbusConnection");
            InitializeDbusConnection();
        }

        static void InitializeDbusConnection()
        {
            Console.WriteLine("DbusConnection a11111aaaaaaaaaa");
            IntPtr error;
            Interop.Edbus.dbus_error_init(out error);

            int ret = Interop.Edbus.e_dbus_init();
            Tizen.Log.Error("TEST", "connection:" + ret);
            if (ret == 0)
            {
                Console.WriteLine("Error: Failed to init dbus");
            }

            Tizen.Log.Error("TEST", "DbusConnection 111111111");
            //_conn = Interop.Edbus.e_dbus_bus_get(Interop.DBusBusType.DBUS_BUS_SYSTEM);
            _conn = Interop.Edbus.dbus_bus_get_private(Interop.DBusBusType.DBUS_BUS_SYSTEM, error);
            //_conn = Interop.Edbus.dbus_bus_get(Interop.DBusBusType.DBUS_BUS_SYSTEM, error);
            if (_conn == null)
            {
                Tizen.Log.Error("TEST", "Failed to get dbus bus");
                Console.WriteLine("Error: Failed to get dbus bus");
            }

            var aaa = Interop.Edbus.dbus_bus_request_name(_conn, DbusNames.BusName, 0, error);
            Tizen.Log.Error("TEST", "DbusConnection dbus_bus_request_name " + aaa);

            _econn = Interop.Edbus.e_dbus_connection_setup(_conn);
            Tizen.Log.Error("TEST", "DbusConnection e_dbus_connection_setup");
            if (_conn == null)
            {
                Tizen.Log.Error("TEST", "Failed to setup connection");
                Console.WriteLine("Error: Failed to setup connection");
            }

            Interop.Edbus.e_dbus_connection_ref(_econn);
            Tizen.Log.Error("TEST", "DbusConnection e_dbus_connection_ref");
            Tizen.Log.Error("TEST", "DbusConnection 333333333333333 :" + DbusNames.BusName);
            //_name = Interop.Edbus.e_dbus_request_name(edbus_conn, DbusNames.BusName,
            //                                         Interop.NameFlags.ReplaceExisting, BusRequestHandler, IntPtr.Zero);

            Tizen.Log.Error("TEST", "DbusConnection 444444444444444444");
            _object = Interop.Edbus.e_dbus_object_add(_econn, DbusNames.ObjectPath, IntPtr.Zero);
            Tizen.Log.Error("TEST", "DbusConnection 55555555555555555555555");
            _interface = Interop.Edbus.e_dbus_interface_new(DbusNames.InterfaceName);
            Tizen.Log.Error("TEST", "DbusConnection 66666666666666666666666");

            Interop.Edbus.e_dbus_object_interface_attach(_object, _interface);

            Tizen.Log.Error("TEST", "DbusConnection ddddddddddddd");
            Console.WriteLine("@@@ done!!");
        }

        public void Close()
        {
            _methods.Clear();
            Interop.Edbus.dbus_connection_close(_conn);
            Interop.Edbus.dbus_connection_unref(_conn);
            Interop.Edbus.e_dbus_connection_close(_econn);
            Interop.Edbus.e_dbus_shutdown();
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
            Tizen.Log.Error("TEST", "@@@@ BusRequestHandler error: " + error);

            Console.WriteLine("@@@@ Error occurs during request for dbus name ");
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

            if (_conn != null)
            {
                Interop.Edbus.e_dbus_message_send(_conn, signal, SendCallback, -1, IntPtr.Zero);
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
