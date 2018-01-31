using System;
using System.Collections.Generic;

namespace Tizen.Appium.Dbus
{
    public class DbusConnection
    {
        IntPtr _conn;
        IntPtr _econn;

        IntPtr _object;
        IntPtr _interface;

        List<Interop.Edbus.MethodCallback> _methodHandlers = new List<Interop.Edbus.MethodCallback>();

        public DbusConnection(string busName, string objectPath, string interfaceName)
        {
            Log.Debug(TizenAppium.Tag, " #### DbusConnection");

            InitializeDbusConnection(busName, objectPath, interfaceName);

        }

        void InitializeDbusConnection(string busName, string objectPath, string interfaceName)
        {
            Log.Debug(TizenAppium.Tag, " #### InitializeDbusConnection");
            IntPtr error;
            Interop.Edbus.dbus_error_init(out error);

            int ret = Interop.Edbus.e_dbus_init();
            if (ret == 0)
            {
                Log.Debug(TizenAppium.Tag, "#### Error: Failed to init dbus");
            }

            _conn = Interop.Edbus.dbus_bus_get_private(Interop.DbusBusType.DBUS_BUS_SYSTEM, error);
            if (_conn == null)
            {
                Log.Debug(TizenAppium.Tag, "#### Error: Failed to get dbus bus");
            }

            ret = Interop.Edbus.dbus_bus_request_name(_conn, busName, 0, error);
            if (ret == -1)
            {
                Log.Debug(TizenAppium.Tag, "#### Error: Failed to set dbus name");
            }

            _econn = Interop.Edbus.e_dbus_connection_setup(_conn);
            if (_econn == null)
            {
                Log.Debug(TizenAppium.Tag, "#### Error: Failed to setup connection");
            }

            _object = Interop.Edbus.e_dbus_object_add(_econn, objectPath, IntPtr.Zero);
            _interface = Interop.Edbus.e_dbus_interface_new(interfaceName);

            Interop.Edbus.e_dbus_object_interface_attach(_object, _interface);

            Log.Debug(TizenAppium.Tag, "#### DbusConnection is initialized successfully!!");
        }

        public void Close()
        {
            Log.Debug(TizenAppium.Tag, " #### dbus close !!!");
            _methodHandlers.Clear();
            if (_econn != null)
            {
                Interop.Edbus.e_dbus_connection_close(_econn);
                _econn = IntPtr.Zero;
                _conn = IntPtr.Zero;
            }
        }

        public void AddMethod(IDbusMethod method)
        {
            Interop.Edbus.MethodCallback methodHandler = (obj, message) =>
            {
                Log.Debug(TizenAppium.Tag, "#### " + method.Name + " method is invoked with " + method.Args);
                var args = Arguments.MessageToArguments(message, method.Args);

                Log.Debug(TizenAppium.Tag, "#### args = " + args.ToString());
                var ret = method.Run(args);
                Log.Debug(TizenAppium.Tag, "#### ret = " + ret.ToString());

                IntPtr reply = Arguments.ArgumentsToReturnMessage(message, ret, method.ReturnSignature);

                return reply;
            };

            _methodHandlers.Add(methodHandler);

            Interop.Edbus.e_dbus_interface_method_add(_interface, method.Name, method.Signature, method.ReturnSignature, methodHandler);
        }

        public void BroadcaseSignal(string signalName, Arguments args, string sig)
        {
            Log.Debug(TizenAppium.Tag, "#### BroadcaseSignal: args=" + args + ", signature=" + sig);

            var message = Arguments.ArgumentsToSignalMessage(signalName, args, sig);

            if (_conn != null)
            {
                Interop.Edbus.e_dbus_message_send(_econn, message, SendCallback, -1, IntPtr.Zero);
                Log.Debug(TizenAppium.Tag, "#### sent!!");
            }
            else
            {
                Log.Debug(TizenAppium.Tag, "#### Dbus connection is not initialized");
            }
        }

        static IntPtr SendCallback(IntPtr data, IntPtr message, IntPtr error)
        {
            Log.Debug(TizenAppium.Tag, "#### Error occurs while signal is sent");
            return IntPtr.Zero;
        }
    }
}
