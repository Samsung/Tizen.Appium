using System;

namespace Tizen.Appium
{
    public class RequestInfo
    {
        public string RequestId { get; private set; }
        public string AutomationId { get; private set; }

        public string Command { get; private set; }

        public string Data { get; set; }

        public RequestInfo(string requestId = "", string automationId = "", string command = "")
        {
            RequestId = requestId;
            AutomationId = automationId;
            Command = command;
        }

        public override string ToString()
        {
            return String.Format("{{ RequestId={0}, AutomationId={1}, Command={2} }}", RequestId, AutomationId, Command);
        }
    }
}
