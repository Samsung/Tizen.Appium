using System;
using Tizen.Applications;

namespace Tizen.Appium
{
    class InputGenerator
    {
        static InputGenerator _generator;
        IpcConnection _connection;

        public static InputGenerator Instance
        {
            get
            {
                if (_generator == null)
                    _generator = new InputGenerator();

                return _generator;
            }
        }

        InputGenerator() { }

        public void Register()
        {
            _connection = new IpcConnection("tizen.appium.port");
            _connection.Register("org.example.uiautomator", "uiautomator_port");
        }

        public void Unregister()
        {
            _connection.Unregister();
        }

        public bool Click(int x, int y)
        {
            var data = new Bundle();
            data.AddItem("command", "click");
            data.AddItem("x", x.ToString());
            data.AddItem("y", y.ToString());

            return _connection.SenMessageAndWaitReply(data);
        }

        public bool Drag(int xDown, int yDown, int xUp, int yUp)
        {
            var data = new Bundle();
            data.AddItem("command", "drag");
            data.AddItem("xDown", xDown.ToString());
            data.AddItem("yDown", yDown.ToString());
            data.AddItem("xUp", xUp.ToString());
            data.AddItem("yUp", yUp.ToString());

           return _connection.SenMessageAndWaitReply(data);
        }

        public bool SendKey(string key)
        {
            var data = new Bundle();
            data.AddItem("command", "sendkey");
            data.AddItem("key", key);

            return _connection.SenMessageAndWaitReply(data);
        }

        public bool PressKey(string key)
        {
            var data = new Bundle();
            data.AddItem("command", "presskey");
            data.AddItem("key", key);

            return _connection.SenMessageAndWaitReply(data);
        }

        public bool ReleaseKey(string key)
        {
            var data = new Bundle();
            data.AddItem("command", "releasekey");
            data.AddItem("key", key);

            return _connection.SenMessageAndWaitReply(data);
        }
    }
}
