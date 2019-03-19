using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;
using Tizen.Applications.Messages;
using Bundle = Tizen.Applications.Bundle;

namespace Tizen.Appium
{
    public class IpcConnection
    {
        readonly string idKey = "id";
        readonly string resultKey = "result";

        readonly ConcurrentDictionary<int, Action<bool>> _handlerMap = new ConcurrentDictionary<int, Action<bool>>();
        readonly object _requestLock = new object();
        MessagePort _localPort;
        RemotePort _remotePort;
        int _reqId;

        public IpcConnection(string portName)
        {
            _localPort = new MessagePort(portName, false);
        }

        public void Register(string appId, string portName)
        {
            _remotePort = new RemotePort(appId, portName, false);
            _localPort.MessageReceived += OnMessageReceived;
            _localPort.Listen();
            Log.Debug("Register...");
        }

        public void Unregister()
        {
            _localPort.MessageReceived -= OnMessageReceived;
            _localPort.StopListening();
            Log.Debug("Unregister...");
        }

        public Task<bool> SendAsync(Bundle message, int timeout = 3000)
        {
            Log.Debug(" send async");
            if (!_remotePort.IsRunning())
                return Task.FromResult(false);

            var tcs = new TaskCompletionSource<bool>();
            int id = 0;
            lock (_requestLock)
            {
                id = _reqId++;
            }

            Timer timer = new Timer((state) =>
            {
                _localPort.StopListening();
                _localPort.Listen();

                Action<bool> handler;
                _handlerMap.TryRemove(id, out handler);
                tcs.SetException(new TimeoutException());

            }, null, timeout, Timeout.Infinite);

            _handlerMap.TryAdd(id, (result) =>
            {
                timer.Dispose();
                // Waiting to re-layout by input
                Thread.Sleep(300);
                tcs.TrySetResult(result);
            });

            try
            {
                message.AddItem(idKey, id.ToString());
                _localPort.Send(message, _remotePort.AppId, _remotePort.PortName);
                message.Dispose();
            }
            catch (Exception e)
            {
                Log.Debug("[Error] " + e);
                tcs.TrySetResult(false);
            }

            return tcs.Task;
        }

        void InvokeHandler(int id, bool result)
        {
            if (!_handlerMap.ContainsKey(id))
                return;

            Action<bool> handler;
            _handlerMap.TryRemove(id, out handler);
            handler?.Invoke(result);
        }

        void OnMessageReceived(object sender, MessageReceivedEventArgs args)
        {
            try
            {
                var message = args.Message;
                var id = Convert.ToInt32(message.GetItem(idKey));
                var result = Convert.ToBoolean(message.GetItem(resultKey));

                InvokeHandler(id, result);
            }
            catch (Exception e)
            {
                Log.Debug("[Error]" + e);
            }
        }
    }
}
