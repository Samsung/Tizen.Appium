using System;
using Tizen.Applications;

namespace Tizen.Appium
{
    public sealed class InputGenerator : IInputGenerator
    {
        readonly string portName = "tizen.appium.port";
        readonly string remoteAppId = "org.tizen.uiautomator";
        readonly string remotePortName = "uiautomator_port";

        bool _disposed = false;
        IpcConnection _connection;

        public InputGenerator()
        {
            _connection = new IpcConnection(portName);
            _connection.Register(remoteAppId, remotePortName);
        }

        public bool Click(int x, int y)
        {
            var data = new Bundle();
            data.AddItem("command", "click");
            data.AddItem("x", x.ToString());
            data.AddItem("y", y.ToString());

            return _connection.SendAsync(data).Result;
        }

        public bool touchUp(int x, int y)
        {
            var data = new Bundle();
            data.AddItem("command", "up");
            data.AddItem("x", x.ToString());
            data.AddItem("y", y.ToString());

            return _connection.SendAsync(data).Result;
        }

        public bool touchDown(int x, int y)
        {
            var data = new Bundle();
            data.AddItem("command", "down");
            data.AddItem("x", x.ToString());
            data.AddItem("y", y.ToString());

            return _connection.SendAsync(data).Result;
        }

        public bool touchMove(int x, int y)
        {
            var data = new Bundle();
            data.AddItem("command", "move");
            data.AddItem("x", x.ToString());
            data.AddItem("y", y.ToString());

            return _connection.SendAsync(data).Result;
        }

        public bool Flick(int xSpeed, int ySpeed)
        {
            return false;
        }

        public bool Drag(int xDown, int yDown, int xUp, int yUp, int steps = 30)
        {
            var data = new Bundle();
            data.AddItem("command", "drag");
            data.AddItem("xDown", xDown.ToString());
            data.AddItem("yDown", yDown.ToString());
            data.AddItem("xUp", xUp.ToString());
            data.AddItem("yUp", yUp.ToString());
            data.AddItem("step", yUp.ToString());

            return _connection.SendAsync(data).Result;
        }

        public bool SendKey(string key)
        {
            var data = new Bundle();
            data.AddItem("command", "sendkey");
            data.AddItem("key", key);

            return _connection.SendAsync(data).Result;
        }

        public bool SendKeys(string[] keys)
        {
            var data = new Bundle();
            data.AddItem("command", "sendkeys");
            data.AddItem("keys", keys);

            return _connection.SendAsync(data).Result;
        }

        public bool PressKey(string key)
        {
            var data = new Bundle();
            data.AddItem("command", "presskey");
            data.AddItem("key", key);

            return _connection.SendAsync(data).Result;
        }

        public bool ReleaseKey(string key)
        {
            var data = new Bundle();
            data.AddItem("command", "releasekey");
            data.AddItem("key", key);

            return _connection.SendAsync(data).Result;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~InputGenerator()
        {
            Dispose(false);
        }

        void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                _connection.Unregister();
            }

            _disposed = true;
        }
    }
}
