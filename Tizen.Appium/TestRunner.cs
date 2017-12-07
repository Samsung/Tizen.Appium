using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Tizen.Appium
{
    public class TestCompletedEventArgs : EventArgs
    {
        public string AutomationId { get; private set; }
        public string RequestId { get; private set; }
        public string Command { get; private set; }

        public TestCompletedEventArgs(string reqId, string autoId, string comm)
        {
            AutomationId = autoId;
            RequestId = reqId;
            Command = comm;
        }
    }

    public class TestRunner
    {
        Dictionary<string, Func<string, string, bool>> _commands = new Dictionary<string, Func<string, string, bool>>();
        //{
        //    { TestCommands.TestCommnad, RunTestCommand},
        //    { TestCommands.ClickCommand, RunClickCommand},
        //};

        public event EventHandler<TestCompletedEventArgs> TestCompleted;

        public TestRunner()
        {
            Console.WriteLine("######### TestRunner ");
            _commands[TestCommands.TestCommnad] = RunTestCommand;
            _commands[TestCommands.ClickCommand] = RunClickCommand;
        }

        public bool RunCommand(string reqId, string autoId, string command)
        {
            Console.WriteLine("######### RunCommand: reqId={0}, autoId={1}, command={2}", reqId, autoId, command);

            if (_commands.ContainsKey(command))
            {
                Console.WriteLine("######### Command Found");
                return _commands[command].Invoke(reqId, autoId);
            }
            else
            {
                Console.WriteLine("#### Command Not Found");
                return false;
            }
        }

        bool RunTestCommand(string reqId, string autoId)
        {
            Console.WriteLine("######### RunTestCommand: automationId={0}, reqId={1}", autoId, reqId);
            var element = TestHelper.GetTestableElement(autoId);
            if (element == null)
                return false;
            var arg = new TestCompletedEventArgs(reqId, autoId, TestCommands.TestCommnad);
            TestCompleted?.Invoke(element, arg);
            return true;
        }

        bool RunClickCommand(string reqId, string autoId)
        {
            Console.WriteLine("######### RunTestCommand: automationId={0}, reqId={1}", autoId, reqId);
            var element = TestHelper.GetTestableElement(autoId);

            if (element == null)
                return false;

            var clickEvent = element.GetType().GetEvent(PreDefinedEventNames.ClickEvent);

            if (clickEvent == null)
                return false;

            EventHandler handle = null;
            clickEvent.AddEventHandler(element, handle = (s, e) =>
            {
                Console.WriteLine("##### clicked event!! automationId={0}, requestId={1}", autoId, reqId);
                var arg = new TestCompletedEventArgs(reqId, autoId, TestCommands.ClickCommand);
                clickEvent.RemoveEventHandler(element, handle);
                TestCompleted?.Invoke(element, arg);
            });

            return true;
        }
    }
}
