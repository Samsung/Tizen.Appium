using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Tizen.Appium.Dbus
{
    //public delegate Arguments DbusCallback(Arguments args);

    public class DbusConnection
    {
        static IntPtr _conn;
        static IntPtr _econn;

        static IntPtr _object;
        static IntPtr _interface;

        List<Interop.Edbus.MethodCallback> _methodHandlers = new List<Interop.Edbus.MethodCallback>();

        public DbusConnection()
        {
            Console.WriteLine(" #### DbusConnection");
            InitializeDbusConnection();
        }

        static void InitializeDbusConnection()
        {
            Console.WriteLine(" #### InitializeDbusConnection");
            IntPtr error;
            Interop.Edbus.dbus_error_init(out error);

            int ret = Interop.Edbus.e_dbus_init();
            if (ret == 0)
            {
                Console.WriteLine("#### Error: Failed to init dbus");
            }

            _conn = Interop.Edbus.dbus_bus_get_private(Interop.DbusBusType.DBUS_BUS_SYSTEM, error);
            if (_conn == null)
            {
                Console.WriteLine("#### Error: Failed to get dbus bus");
            }

            ret = Interop.Edbus.dbus_bus_request_name(_conn, Names.BusName, 0, error);
            if (ret == -1)
            {
                Console.WriteLine("#### Error: Failed to set dbus name");
            }

            _econn = Interop.Edbus.e_dbus_connection_setup(_conn);
            if (_econn == null)
            {
                Console.WriteLine("#### Error: Failed to setup connection");
            }

            _object = Interop.Edbus.e_dbus_object_add(_econn, Names.ObjectPath, IntPtr.Zero);
            _interface = Interop.Edbus.e_dbus_interface_new(Names.InterfaceName);

            Interop.Edbus.e_dbus_object_interface_attach(_object, _interface);

            Console.WriteLine("#### DbusConnection is initialized successfully!!");
        }

        public void Close()
        {
            Console.WriteLine(" #### dbus close !!!");
            _methodHandlers.Clear();

            //dbus_connection_close(), dbus_connection_unref(), will be called in e_dbus_connection_close()
            Interop.Edbus.e_dbus_connection_close(_econn);
        }

        public void AddMethod(IDbusMethod method)
        {
            Interop.Edbus.MethodCallback methodHandler = (obj, message) =>
            {
                Console.WriteLine("#### {0} method is invoked with {1}", method.Name, method.Params);
                var args = Arguments.MessageToArguments(message, method.Params);
                Console.WriteLine("#### args = {0}", args);
                var ret = method.Run(args);
                Console.WriteLine("#### ret = {0}", ret);

                IntPtr reply = Arguments.ArgumentsToReturnMessage(message, ret, method.ReturnSignature);

                return reply;
            };

            _methodHandlers.Add(methodHandler);

            Interop.Edbus.e_dbus_interface_method_add(_interface, method.Name, method.Signature, method.ReturnSignature, methodHandler);
        }

        public void BroadcaseSignal(string signalName, Arguments args, string sig)
        {
            Console.WriteLine("#### BroadcaseSignal: args={0}, signature={1}", args, sig);

            var message = Arguments.ArgumentsToSignalMessage(signalName, args, sig);

            if (_conn != null)
            {
                Interop.Edbus.e_dbus_message_send(_econn, message, SendCallback, -1, IntPtr.Zero);
                Console.WriteLine("#### sent!!");
            }
            else
            {
                Console.WriteLine("#### Dbus connection is not initialized");
            }
        }

        static IntPtr SendCallback(IntPtr data, IntPtr message, IntPtr error)
        {
            Console.WriteLine("#### Error occurs while signal is sent");
            return IntPtr.Zero;
        }
    }
}
