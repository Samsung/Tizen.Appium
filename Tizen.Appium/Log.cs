using System;
using System.Runtime.CompilerServices;
using T = Tizen;

namespace Tizen.Appium
{
    /// <summary>
    /// Provides logging functionality.
    /// </summary>
    public static class Log
    {
        static String Tag = "TizenAppium";

        public static void Debug(string message,
                [CallerFilePath] string file = "",
                [CallerMemberName] string func = "",
                [CallerLineNumber] int line = 0)
        {
            T.Log.Debug(Tag, message, file, func, line);
        }

        public static void Verbose(string message,
                [CallerFilePath] string file = "",
                [CallerMemberName] string func = "",
                [CallerLineNumber] int line = 0)
        {
            T.Log.Verbose(Tag, message, file, func, line);
        }

        public static void Info(string message,
                [CallerFilePath] string file = "",
                [CallerMemberName] string func = "",
                [CallerLineNumber] int line = 0)
        {
            T.Log.Info(Tag, message, file, func, line);
        }

        public static void Warn(string message,
                [CallerFilePath] string file = "",
                [CallerMemberName] string func = "",
                [CallerLineNumber] int line = 0)
        {
            T.Log.Warn(Tag, message, file, func, line);
        }

        public static void Error(string message,
                [CallerFilePath] string file = "",
                [CallerMemberName] string func = "",
                [CallerLineNumber] int line = 0)
        {
            T.Log.Error(Tag, message, file, func, line);
        }

        public static void Fatal(string message,
                [CallerFilePath] string file = "",
                [CallerMemberName] string func = "",
                [CallerLineNumber] int line = 0)
        {
            T.Log.Fatal(Tag, message, file, func, line);
        }
    }
}
