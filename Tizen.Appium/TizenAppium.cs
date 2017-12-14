using System;
using Tizen.Appium.DBus;
using Xamarin.Forms;

namespace Tizen.Appium
{
    public class TizenAppium
    {
        public static bool IsInitialized { get; private set; }

        public static AppSocket _socket;
        public static TestRunner _testRunner;
        public static DbusConnection _dbusConn;

        public static void Init()
        {
            if (IsInitialized)
                return;

            IsInitialized = true;
        }

        public static void StartService()
        {
            Console.WriteLine("### StartService");
            if (IsInitialized)
                return;

            _testRunner = new TestRunner();
            _socket = new AppSocket();
            _socket.StartListening();
            _socket.Accepted += SocketAccepted;
            _socket.Received += SocketReceived;

            IsInitialized = true;

            //TEST
            Console.WriteLine("@@@@@@@@@@@@@@@@@@@ Dbus TEST");
            //_dbusConn = new DbusConnection();
        }

        static void StopService()
        {
            Console.WriteLine("### StopService");
            _socket.StopListening();
        }

        static void SocketAccepted(object sender, EventArgs arg)
        {
            Console.WriteLine("### SocketAccepted");
            _testRunner.TestCompleted += (s, e) =>
            {
                Console.WriteLine(" ### TestCompleted");
                var message = e.RequestId + "/" + e.AutomationId + "/" + e.Command;
                _socket.Send(message);
            };
        }

        static void SocketReceived(object sender, ReceivedEventArgs arg)
        {
            Console.WriteLine("### SocketAccepted : {0}", arg.Data);
            char[] delimiter = { '/' };
            string[] msg = arg.Data.Split(delimiter);
            var request = msg[0];

            if (request.Equals("GetPosition"))
            {
                var reqInfo = new RequestInfo(automationId: msg[1], command: TestCommands.GetPositionCommand);
                Console.WriteLine("### GetPosition: reqInfo={0}", reqInfo);

                var ret = _testRunner.RunCommand(reqInfo);
                var message = "";

                if (ret.Result)
                {
                    if (ret.Data.ContainsKey(TestResultKeys.X) && ret.Data.ContainsKey(TestResultKeys.Y))
                    {
                        message = ret.Data[TestResultKeys.X] + "/" + ret.Data[TestResultKeys.Y];
                    }
                    Console.WriteLine("#### [{0}]request successfully processed!!", request);
                }
                else
                {
                    Console.WriteLine("#### [{0}]request is failed!!", request);
                    message = "False";
                }

                Console.WriteLine(message);
                _socket.Send(message);
            }
            else if (request.Equals("SetCommand"))
            {
                var reqInfo = new RequestInfo(requestId: msg[1], automationId: msg[2], command: msg[3]);
                Console.WriteLine("### SetCommand: reqInfo={0}", reqInfo);

                var ret = _testRunner.RunCommand(reqInfo);
                var message = "";

                if (ret.Result)
                {
                    Console.WriteLine("#### [{0}]request successfully processed!!", request);
                    message = "True";
                }
                else
                {
                    Console.WriteLine("#### [{0}]request is failed!!", request);
                    message = "False";
                }

                _socket.Send(message);
            }
        }

        //for testing
        public void test()
        {
            //getposition TEST
            Console.WriteLine(" ### test ");
            var reqInfo = new RequestInfo("1", "111", TestCommands.GetPositionCommand);
            var ret = _testRunner.RunCommand(reqInfo);

            if (ret.Result)
            {
                foreach (var p in ret.Data)
                {
                    Console.WriteLine("### [data]: key={0}, value={1}", p.Key, p.Value);
                }
            }
            else
            {
                Console.WriteLine("### request failed!! ");
            }

            //TEST for Button
            //var element = TestHelper.GetTestableElement("111");
            //var button = element as Xamarin.Forms.Button;

            //button.Clicked += (s, e) =>
            //{
            //    var ret2 = _testRunner.RunCommand(reqInfo);
            //    if (ret2.Result)
            //    {
            //        if (ret2.Data.ContainsKey(TestResultKeys.X) && ret2.Data.ContainsKey(TestResultKeys.Y))
            //        {
            //            var message = ret2.Data[TestResultKeys.X] + "/" + ret2.Data[TestResultKeys.Y];
            //            Console.WriteLine("### [message]: {0}", message);
            //        }
            //    }
            //};

            //TEST for Label
            var ve = TestHelper.GetTestableElement("111") as View;
            if (ve == null)
            {
                Console.WriteLine("### Not Found Element: 111");
                return;
            }

            var tap = new TapGestureRecognizer();
            tap.Tapped += (s, e) =>
            {
                var ret2 = _testRunner.RunCommand(reqInfo);

                if (ret2.Result)
                {
                    if (ret2.Data.ContainsKey(TestResultKeys.X) && ret2.Data.ContainsKey(TestResultKeys.Y))
                    {
                        var message = ret2.Data[TestResultKeys.X] + "/" + ret2.Data[TestResultKeys.Y];
                        Console.WriteLine("### [message]: {0}", message);
                    }
                }
            };
            ve.GestureRecognizers.Add(tap);

            // click TEST
            var reqInfo2 = new RequestInfo("2", "111", TestCommands.ClickCommand);
            ret = _testRunner.RunCommand(reqInfo2);

            if (ret.Result)
            {
                Console.WriteLine("### command is set successfully!!");
            }
            else
            {
                Console.WriteLine("#### request failed!! ");
            }
        }
    }
}