using System;
using System.Runtime.InteropServices;

internal static partial class Interop
{
    internal static partial class Libraries
    {
        internal const string Edbus = "libedbus.so.1";
        internal const string dbus = "libdbus-1.so.3";
    }

    internal enum DBusBusType
    {
        DBUS_BUS_SESSION,
        DBUS_BUS_SYSTEM,
        DBUS_BUS_STARTER
    }

    internal enum DBusDataType
    {
        DBUS_TYPE_INT_32 = 0x69,
        DBUS_TYPE_UINT_32 = 0x75,
        DBUS_TYPE_STRING = 0x73,
        DBUS_TYPE_BOOLEAN = 0x62,
    }

    internal enum NameFlags
    {
        None,
        AllowReplacement,
        ReplaceExisting,
        DoNotQueue
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct DBusMessageIter
    {
        IntPtr dummy1;
        IntPtr dummy2;
        int dummy3;
        int dummy4;
        int dummy5;
        int dummy6;
        int dummy7;
        int dummy8;
        int dummy9;
        int dummy10;
        int dummy11;
        int pad1;
        IntPtr pad2;
        IntPtr pad3;
    }

    internal delegate void request_cb(IntPtr data, IntPtr msg, IntPtr error);

    internal delegate IntPtr method_cb(IntPtr obj, IntPtr message);

    internal delegate IntPtr method_return_cb(IntPtr data, IntPtr message, IntPtr error);

    internal static class Edbus
    {
        [DllImport(Libraries.Edbus)]
        internal static extern void dbus_threads_init_default();

        [DllImport(Libraries.Edbus)]
        internal static extern void dbus_error_init(out IntPtr error);

        [DllImport(Libraries.Edbus)]
        internal static extern int e_dbus_init();

        [DllImport(Libraries.Edbus)]
        internal static extern IntPtr e_dbus_bus_get(DBusBusType type);

        [DllImport(Libraries.Edbus)]
        internal static extern IntPtr e_dbus_request_name(IntPtr conn, string bus_name, NameFlags flags, request_cb callback, IntPtr date);

        [DllImport(Libraries.Edbus)]
        internal static extern IntPtr e_dbus_object_add(IntPtr conn, string path, IntPtr data);

        [DllImport(Libraries.Edbus)]
        internal static extern IntPtr e_dbus_interface_new(string iface);

        [DllImport(Libraries.Edbus)]
        internal static extern IntPtr e_dbus_object_interface_attach(IntPtr obj, IntPtr iface);

        [DllImport(Libraries.Edbus)]
        internal static extern IntPtr e_dbus_interface_method_add(IntPtr iface, string member, string signature, string reply_signature, method_cb callback);


        [DllImport(Libraries.Edbus)]
        internal static extern IntPtr dbus_message_new_signal(string path, string iface, string name);

        [DllImport(Libraries.Edbus)]
        internal static extern IntPtr e_dbus_message_send(IntPtr conn, IntPtr msg, method_return_cb callback, int timeout, IntPtr data);

        [DllImport(Libraries.dbus)]
        internal static extern bool dbus_message_iter_init(IntPtr msg, IntPtr iter);

        [DllImport(Libraries.Edbus)]
        internal static extern IntPtr dbus_message_new_method_return(IntPtr msg);

        [DllImport(Libraries.Edbus)]
        internal static extern void dbus_message_iter_init_append(IntPtr msg, IntPtr iter);

        [DllImport(Libraries.Edbus)]
        internal static extern bool dbus_message_iter_append_basic(out IntPtr iter, DBusDataType type, out IntPtr value);

        [DllImport(Libraries.Edbus)]
        internal static extern int dbus_message_iter_get_arg_type(out IntPtr iter);

        [DllImport(Libraries.Edbus)]
        internal static extern void dbus_message_iter_get_basic(out IntPtr iter, out IntPtr value);

        [DllImport(Libraries.Edbus)]
        internal static extern bool dbus_message_iter_next(out IntPtr iter);

        [DllImport(Libraries.Edbus)]
        internal static extern bool dbus_message_get_args(IntPtr msg, out IntPtr err, int type, out IntPtr data, int quit);
    }
}