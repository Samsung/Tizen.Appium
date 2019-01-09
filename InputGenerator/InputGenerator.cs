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

        bool _touchTriggered = false;
        int _x = -1;
        int _y = -1;

        bool _keyPressed = false;
        string _key = "";

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

            try
            {
                return _connection.SendAsync(data).Result;
            }
            catch (AggregateException ae)
            {
                ae.Handle(e => {
                    if (e is TimeoutException)
                        throw e;
                    return e is TimeoutException;
                });
            }

            return false;
        }

        public bool TouchDown(int x, int y)
        {
            var data = new Bundle();
            data.AddItem("command", "down");
            data.AddItem("x", x.ToString());
            data.AddItem("y", y.ToString());

            try
            {
                var ret = _connection.SendAsync(data).Result;
                if (ret)
                {
                    _touchTriggered = true;
                    _x = x;
                    _y = y;

                    return ret;
                }
            }
            catch (AggregateException ae)
            {
                ae.Handle(e => {
                    if (e is TimeoutException)
                        throw e;
                    return e is TimeoutException;
                });
            }

            return false;
        }

        public bool TouchUp(int x, int y)
        {
            var data = new Bundle();
            data.AddItem("command", "up");

            try
            {
                if (_touchTriggered)
                {
                    data.AddItem("x", _x.ToString());
                    data.AddItem("y", _y.ToString());
                    var ret =  _connection.SendAsync(data).Result;
                    if (ret)
                    {
                        _touchTriggered = false;
                        return ret;
                    }
                }
                else
                {
                    data.AddItem("x", x.ToString());
                    data.AddItem("y", y.ToString());
                    return _connection.SendAsync(data).Result;
                }
            }
            catch (AggregateException ae)
            {
                ae.Handle(e => {
                    if (e is TimeoutException)
                        throw e;
                    return e is TimeoutException;
                });
            }

            return false;

        }

        public bool TouchMove(int xDown, int yDown, int xUp, int yUp, int steps = 10)
        {
            var data = new Bundle();
            data.AddItem("command", "move");
            data.AddItem("xDown", xDown.ToString());
            data.AddItem("yDown", yDown.ToString());
            data.AddItem("xUp", xUp.ToString());
            data.AddItem("yUp", yUp.ToString());
            data.AddItem("steps", steps.ToString());

            try
            {
                return _connection.SendAsync(data).Result;
            }
            catch (AggregateException ae)
            {
                ae.Handle(e => {
                    if (e is TimeoutException)
                        throw e;
                    return e is TimeoutException;
                });
            }

            return false;
        }

        public bool Drag(int xDown, int yDown, int xUp, int yUp, int steps = 30)
        {
#if WATCH
            steps = 100;
#endif
            var data = new Bundle();
            data.AddItem("command", "drag");
            data.AddItem("xDown", xDown.ToString());
            data.AddItem("yDown", yDown.ToString());
            data.AddItem("xUp", xUp.ToString());
            data.AddItem("yUp", yUp.ToString());
            data.AddItem("steps", steps.ToString());

            try
            {
                return _connection.SendAsync(data).Result;
            }
            catch (AggregateException ae)
            {
                ae.Handle(e => {
                    if (e is TimeoutException)
                        throw e;
                    return e is TimeoutException;
                });
            }

            return false;
        }

        public bool SendKey(string key)
        {
            var data = new Bundle();
            data.AddItem("command", "sendkey");
            data.AddItem("key", key);

            try
            {
                return _connection.SendAsync(data).Result;
            }
            catch (AggregateException ae)
            {
                ae.Handle(e => {
                    if (e is TimeoutException)
                        throw e;
                    return e is TimeoutException;
                });
            }

            return false;
        }

        public bool SendKeys(string[] keys)
        {
            var data = new Bundle();
            data.AddItem("command", "sendkeys");
            data.AddItem("keys", keys);

            try
            {
                return _connection.SendAsync(data).Result;
            }
            catch (AggregateException ae)
            {
                ae.Handle(e => {
                    if (e is TimeoutException)
                        throw e;
                    return e is TimeoutException;
                });
            }

            return false;

        }

        public bool PressKey(string key)
        {
            var data = new Bundle();
            data.AddItem("command", "presskey");
            data.AddItem("key", key);

            try
            {
                var ret = _connection.SendAsync(data).Result;
                if(ret)
                {
                    _key = key;
                    _keyPressed = true;
                    return ret;
                }
            }
            catch (AggregateException ae)
            {
                ae.Handle(e => {
                    if (e is TimeoutException)
                        throw e;
                    return e is TimeoutException;
                });
            }

            return false;
        }

        public bool ReleaseKey(string key)
        {
            var data = new Bundle();
            data.AddItem("command", "releasekey");

            try
            {
                if(_keyPressed)
                {
                    data.AddItem("key", _key);
                    var ret = _connection.SendAsync(data).Result;
                    if (ret)
                    {
                        _keyPressed = false;
                        return ret;
                    }
                }
                else
                {
                    data.AddItem("key", key);
                    return _connection.SendAsync(data).Result;
                }
            }
            catch (AggregateException ae)
            {
                ae.Handle(e => {
                    if (e is TimeoutException)
                        throw e;
                    return e is TimeoutException;
                });
            }

            return false;
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
