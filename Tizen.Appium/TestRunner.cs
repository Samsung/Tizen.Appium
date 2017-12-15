using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Tizen;
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

    public class TestRunner
    {
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
            _commands[TestCommands.GetPositionCommand] = RunGetPositionCommand;
            _commands[TestCommands.ClickCommand] = RunClickCommand;
        }

        public TestResult RunCommand(RequestInfo req)
        {
            Console.WriteLine("######### RunCommand: {0}", req);

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
            Console.WriteLine("######### RunTestCommand: {0}", req);
            TestResult result = new TestResult();

            var element = TestHelper.GetTestableElement(req.AutomationId);
            if (element == null)
            {
                Console.WriteLine("### Not Found Element");
                return result;
            }
            var arg = new TestCompletedEventArgs(req.RequestId, req.AutomationId, TestCommands.TestCommnad);
            TestCompleted?.Invoke(element, arg);

            result.SetResult(true);
            return result;
        }

        TestResult RunGetPositionCommand(RequestInfo req)
        {
            Console.WriteLine("######### RunGetPositionCommand: {0}", req);
            var result = new TestResult();

            var ve = TestHelper.GetTestableElement(req.AutomationId) as VisualElement;
            if (ve == null)
            {
                Console.WriteLine("### Not Found Element");
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
            Console.WriteLine("######### RunClickCommand: {0}", req);
            var result = new TestResult();

            var ve = TestHelper.GetTestableElement(req.AutomationId) as VisualElement;
            if (ve == null)
            {
                Console.WriteLine("### Not Found Element");
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
