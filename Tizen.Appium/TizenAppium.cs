using System;
using System.Threading;
using System.Threading.Tasks;
using Tizen.Applications;

namespace Tizen.Appium
{
    public enum AppType
    {
        Forms,
        ElmSharp,
        NUI,
        FormsWearable,

    }

    public partial class TizenAppium
    {
        public static bool IsInitialized { get; private set; }

        public static readonly string Tag = "TizenAppium";

        static SynchronizationContext s_context;

        internal static void Start(IAppAdapter adapter)
        {
            Log.Debug("Start Service : initialize");
            if (IsInitialized)
                return;

            if (SynchronizationContext.Current == null)
            {
                TizenSynchronizationContext.Initialize();
            }
            s_context = SynchronizationContext.Current;

            Server.Instance.Start(adapter);

            IsInitialized = true;
        }

        internal static void Stop()
        {
            Log.Debug("StopService");

            if (IsInitialized)
            {
                Server.Instance.Stop();

                IsInitialized = false;
            }
        }

        public static T RunOnMainThread<T>(Func<T> func)
        {
            var tcs = new TaskCompletionSource<T>();
            s_context.Post((o) =>
            {
                var t = func();
                tcs.SetResult(t);
            }, null);
            return tcs.Task.Result;
        }
    }
}