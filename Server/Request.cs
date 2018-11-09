using Newtonsoft.Json;

namespace Tizen.Appium
{
    public class Request
    {
        [JsonProperty("cmd")]
        public string Cmd { get; set; }

        [JsonProperty("action")]
        public string Action { get; set; }

        [JsonProperty("params")]
        public Parameters Params { get; set; }

        public class Parameters
        {
            [JsonProperty("strategy")]
            public string Strategy { get; set; }

            [JsonProperty("elementId")]
            public string ElementId { get; set; }

            [JsonProperty("x")]
            public int X { get; set; }

            [JsonProperty("y")]
            public int Y { get; set; }

            [JsonProperty("xDown")]
            public int XDown { get; set; }

            [JsonProperty("yDown")]
            public int YDown { get; set; }

            [JsonProperty("xUp")]
            public int XUp { get; set; }

            [JsonProperty("yUp")]
            public int YUp { get; set; }

            [JsonProperty("steps")]
            public int Steps { get; set; }

            [JsonProperty("xSpeed")]
            public int XSpeed { get; set; }

            [JsonProperty("ySpeed")]
            public int YSpeed { get; set; }

            [JsonProperty("attribute")]
            public string Attribute { get; set; }

            [JsonProperty("key")]
            public string Key { get; set; }

            [JsonProperty("keys")]
            public string[] Keys { get; set; }

            [JsonProperty("text")]
            public string Text { get; set; }

            [JsonProperty("replace")]
            public bool Replace { get; set; }

            [JsonProperty("value")]
            public string Value { get; set; }
        }
    }
}
