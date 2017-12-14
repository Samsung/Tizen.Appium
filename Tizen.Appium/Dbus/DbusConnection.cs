using System;
using System.IO;
using System.Threading;

using System.Runtime.InteropServices;

namespace Tizen.Appium.DBus
{
    public class DbusConnection
    {
        static IntPtr _dbusConn;

        public DbusConnection()
        {
            Console.WriteLine("@@@ DbusConnection");

            Initialize();
            //var th = new Thread(ExecuteInForeground);
            //th.Start();
        }

        void Initialize()
        {
            Console.WriteLine("@@@ dbus initialized!!");
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

            IntPtr edbus_request_name = Interop.Edbus.e_dbus_request_name(_dbusConn, DBus.BusName,
                                                     Interop.NameFlags.ReplaceExisting, BusRequestHandler, IntPtr.Zero);

            IntPtr dbusObj = Interop.Edbus.e_dbus_object_add(_dbusConn, DBus.ObjectPath, IntPtr.Zero);
            IntPtr iface = Interop.Edbus.e_dbus_interface_new(DBus.Interface);

            Interop.Edbus.e_dbus_object_interface_attach(dbusObj, iface);

            Interop.Edbus.e_dbus_interface_method_add(iface, DBus.TestMethod, "si", "is", TestHandler);
            Interop.Edbus.e_dbus_interface_method_add(iface, DBus.GetMethod, "", "s", GetHandler);

            Console.WriteLine("@@@ done!!");
        }

        static void BusRequestHandler(IntPtr data, IntPtr msg, IntPtr error)
        {
            Console.WriteLine("@@@@ BusRequestHandler");
        }

        RequestInfo GetDbusRequestInfo(ref Interop.DBusMessageIter msgIter)
        {
            var type = Interop.Edbus.dbus_message_iter_get_arg_type(ref msgIter);
            string msg = "";
            if (type == DBusArgsType.String)
            {
                IntPtr ptr;
                Interop.Edbus.dbus_message_iter_get_basic(ref msgIter, out ptr);
                msg = Marshal.PtrToStringAnsi(ptr);
                Console.WriteLine("msg={0}", msg);
            }
            else
            {
                Console.WriteLine("@@@@ msg error");
            }

            char[] delimiter = { '/' };
            string[] args = msg.Split(delimiter);

            RequestInfo info;
            if (args.Length > 2)
            {
                info = new RequestInfo(args[0], args[1], args[2]);
            }
            else
            {
                info = new RequestInfo(args[0]);
            }

            Console.WriteLine("@@@ Request = {0}", info);

            return info;
        }

        IntPtr GetHandler(IntPtr obj, IntPtr message)
        {
            Console.WriteLine("@@@@ GetHandler");
            Interop.DBusMessageIter iter = new Interop.DBusMessageIter();

            //parsing arg : automationId
            Interop.Edbus.dbus_message_iter_init(message, ref iter);
            var reqInfo = GetDbusRequestInfo(ref iter);

            //run

            //reply
            IntPtr reply = Interop.Edbus.dbus_message_new_method_return(message);

            Interop.Edbus.dbus_message_iter_init_append(reply, ref iter);

            string msg = "reply";
            IntPtr msgPtr = Marshal.StringToHGlobalAnsi(msg);

            Console.WriteLine("@@@ reply={0}", Marshal.PtrToStringAnsi(msgPtr));
            Interop.Edbus.dbus_message_iter_append_basic(ref iter, DBusArgsType.String, ref msgPtr);

            return reply;
        }

        static IntPtr TestHandler(IntPtr obj, IntPtr message)
        {
            Console.WriteLine("@@@@ Callback");

            Interop.DBusMessageIter iter = new Interop.DBusMessageIter();

            //parsing args

            Interop.Edbus.dbus_message_iter_init(message, ref iter);
            var type = Interop.Edbus.dbus_message_iter_get_arg_type(ref iter);

            if (type == DBusArgsType.String)
            {
                IntPtr ptr;
                Interop.Edbus.dbus_message_iter_get_basic(ref iter, out ptr);
                Console.WriteLine("arg0={0}", Marshal.PtrToStringAnsi(ptr));
            }
            else
            {
                Console.WriteLine("@@@@ arg0 error");
            }

            Interop.Edbus.dbus_message_iter_next(ref iter);
            type = Interop.Edbus.dbus_message_iter_get_arg_type(ref iter);
            if (type == DBusArgsType.Int)
            {
                IntPtr ptr;
                Interop.Edbus.dbus_message_iter_get_basic(ref iter, out ptr);
                Console.WriteLine("arg1={0}", (int)ptr);
            }
            else
            {
                Console.WriteLine("@@@@ arg1 error");
            }

            //create return
            IntPtr reply = Interop.Edbus.dbus_message_new_method_return(message);
            Interop.Edbus.dbus_message_iter_init_append(reply, ref iter);
            var val = new IntPtr(999);
            Interop.Edbus.dbus_message_iter_append_basic(ref iter, DBusArgsType.Int, ref val);

            string sss = "reply333";
            IntPtr msg = Marshal.StringToHGlobalAnsi(sss);

            Console.WriteLine("@@@ reply={0}", Marshal.PtrToStringAnsi(msg));
            Interop.Edbus.dbus_message_iter_append_basic(ref iter, DBusArgsType.String, ref msg);

            //broadcast signal

            Console.WriteLine("@@@@ done");
            return reply;
        }

        public void BroadcaseSignal(string signalName, string msg)
        {
            Console.WriteLine("@@@ TEST signal");
            IntPtr signal = Interop.Edbus.dbus_message_new_signal(DBus.ObjectPath, DBus.Interface, signalName);
            Interop.DBusMessageIter iter = new Interop.DBusMessageIter();
            Interop.Edbus.dbus_message_iter_init_append(signal, ref iter);

            //var num = new IntPtr(123);
            //Interop.Edbus.dbus_message_iter_append_basic(ref iter, DBusType.Int, ref num);

            //string signalMsg = "SignalTest";
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
            Console.WriteLine("@@@ signal sendCallback");
            return IntPtr.Zero;
        }
    }
}
