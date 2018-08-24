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
        public Params Params { get; set; }
    }

    public class Params
    {
        [JsonProperty("strategy")]
        public string Strategy { get; set; }

        [JsonProperty("elementId")]
        public string ElementId { get; set; }

        [JsonProperty("attribute")]
        public string Attribute { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }
}
