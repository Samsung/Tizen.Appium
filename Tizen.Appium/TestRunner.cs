using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Tizen;
using Tizen.Appium.DBus;
using System.Collections.ObjectModel;
using ElmSharp;

namespace Tizen.Appium
{
    public class TestCompletedEventArgs : EventArgs
    {
        public string AutomationId { get; private set; }
        public string RequestId { get; private set; }
        public string Command { get; private set; }
        public object Data { get; set; }

        public TestCompletedEventArgs(string reqId, string autoId, string comm, object data = null)
        {
            AutomationId = autoId;
            RequestId = reqId;
            Command = comm;
            Data = data;
        }
    }

    public class TestResult
    {
        IDictionary<string, object> _data = null;

        public bool Result { get; private set; }

        public IReadOnlyDictionary<string, object> Data
        {
            get
            {
                return new ReadOnlyDictionary<string, object>(_data);
            }
        }

        public TestResult(bool result = false)
        {
            Result = result;
            _data = new Dictionary<string, object>();
        }

        public void SetResult(bool val)
        {
            Result = val;
        }

        public void ResetResult()
        {
            Result = false;
            if (_data != null)
            {
                _data.Clear();
                _data = null;
            }
        }

        public void SetData(string key, object obj)
        {
            if (_data != null)
            {
                _data[key] = obj;
            }
        }

        public void RemoveData(string key)
        {
            if (_data != null)
            {
                _data.Remove(key);
            }
        }
    }

    public class TestRunner
    {
        //public delegate TestResult TestFunc(RequestInfo info);

        Dictionary<string, Func<RequestInfo, TestResult>> _commands = new Dictionary<string, Func<RequestInfo, TestResult>>();

        //{
        //    { TestCommands.TestCommnad, RunTestCommand},
        //    { TestCommands.ClickCommand, RunClickCommand},
        //};
        List<EvasObjectEvent> _events = new List<EvasObjectEvent>();

        public event EventHandler<TestCompletedEventArgs> TestCompleted;

        public TestRunner()
        {
            Console.WriteLine("######### TestRunner ");
            _commands[TestCommands.TestCommnad] = RunTestCommand;
            _commands[TestCommands.GetPositionCommand] = GetPositionCommand;
            _commands[TestCommands.ClickCommand] = RunClickCommand;
        }

        public TestResult RunCommand(RequestInfo req)
        {
            Console.WriteLine("######### RunCommand: reqId={0}, autoId={1}, command={2}", req.RequestId, req.AutomationId, req.Command);

            if (_commands.ContainsKey(req.Command))
            {
                Console.WriteLine("######### Command Found");
                return _commands[req.Command].Invoke(req);
            }
            else
            {
                Console.WriteLine("#### Command Not Found");
                return new TestResult();
            }
        }

        TestResult RunTestCommand(RequestInfo req)
        {
            Console.WriteLine("######### RunTestCommand: automationId={0}, reqId={1}", req.AutomationId, req.RequestId);
            TestResult result = new TestResult();

            var element = TestHelper.GetTestableElement(req.AutomationId);
            if (element == null)
            {
                return result;
            }
            var arg = new TestCompletedEventArgs(req.RequestId, req.AutomationId, TestCommands.TestCommnad);
            TestCompleted?.Invoke(element, arg);

            result.SetResult(true);
            return result;
        }

        TestResult GetPositionCommand(RequestInfo req)
        {
            var result = new TestResult();

            var ve = TestHelper.GetTestableElement(req.AutomationId) as VisualElement;
            if (ve == null)
            {
                return result;
            }

            var nativeView = Platform.GetOrCreateRenderer(ve).NativeView;

            var x = nativeView.Geometry.X + (nativeView.Geometry.Width / 2);
            var y = nativeView.Geometry.Y + (nativeView.Geometry.Height / 2);

            result.SetData(TestResultKeys.X, x);
            result.SetData(TestResultKeys.Y, y);

            result.SetResult(true);

            return result;
        }

        TestResult RunClickCommand(RequestInfo req)
        {
            Console.WriteLine("######### RunTestCommand: automationId={0}, reqId={1}", req.AutomationId, req.RequestId);
            var result = new TestResult();

            var ve = TestHelper.GetTestableElement(req.AutomationId) as VisualElement;
            if (ve == null)
            {
                return result;
            }

            var mouseUpEvent = new EvasObjectEvent(Platform.GetOrCreateRenderer(ve).NativeView, EvasObjectCallbackType.MouseUp);
            EventHandler mouseUpHandle = null;
            mouseUpEvent.On += mouseUpHandle = (s, e) =>
            {
                Console.WriteLine("##### mouse up event!! automationId={0}, requestId={1}", req.AutomationId, req.RequestId);
                mouseUpEvent.On -= mouseUpHandle;
                _events.Remove(mouseUpEvent);
                var arg = new TestCompletedEventArgs(req.RequestId, req.AutomationId, req.Command);
                TestCompleted?.Invoke(ve, arg);
            };
            _events.Add(mouseUpEvent);

            result.SetResult(true);
            return result;
        }
    }
}
