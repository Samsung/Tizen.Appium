using System;
using System.Threading;
using System.Threading.Tasks;
using Tizen.Applications.Messages;
using Bundle = Tizen.Applications.Bundle;

namespace Tizen.Appium
{
    public class IpcConnection
    {
        MessagePort _port;
        string _portName;
        string remoteAppId;
        string _remotePort;

        public IpcConnection(string portName)
        {
            _portName = portName;
            _port = new MessagePort(_portName, false);
        }

        public void Register(string appId, string portName)
        {
            remoteAppId = appId;
            _remotePort = portName;

            _port.Listen();
            Log.Debug("Register...");
        }

        public void Unregister()
        {
            _port.StopListening();
            Log.Debug("Unregister...");
        }

        public bool SenMessageAndWaitReply(Bundle message)
        {
            var tcs = new TaskCompletionSource<bool>();
            var ct = new CancellationTokenSource(3000);
            EventHandler<MessageReceivedEventArgs> handler = null;

            _port.MessageReceived += handler = (sender, args) =>
            {
                _port.MessageReceived -= handler;
                var result = args.Message.GetItem("result");
                try
                {
                    tcs.SetResult(Convert.ToBoolean(result));
                }
                catch (Exception e)
                {
                    Log.Debug("[Error] Converting error: result=" + result);
                    tcs.SetResult(false);
                }
            };

            try
            {
                _port.Send(message, remoteAppId, _remotePort);
                message.Dispose();
                Log.Debug("Send");

                ct.Token.Register(() =>
                {
                    Log.Debug("cancelled");
                    _port.MessageReceived -= handler;
                    tcs.TrySetCanceled();
                });

                return tcs.Task.Result;
            }
            catch (Exception ex)
            {
                Log.Debug("[Error] " + ex);
            }
            return false;
        }

        public void SendMessage(Bundle message)
        {
            try
            {
                _port.Send(message, remoteAppId, _remotePort);
                message.Dispose();
                Log.Debug("Send");
            }
            catch (Exception ex)
            {
                Log.Debug("[Error] " + ex);
            }
        }
    }
}
