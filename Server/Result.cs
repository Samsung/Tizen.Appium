using Newtonsoft.Json;
using System;

namespace Tizen.Appium
{
    public class Result
    {
        [JsonProperty("status")]
        public int Status { get; set; }

        [JsonProperty("value")]
        public object Value { get; set; }

        public Result()
        {
            Status = 0;
            Value = String.Empty;
        }

        public class Element
        {
            [JsonProperty("ELEMENT")]
            public string Id { get; set; }

            public Element(string id = "")
            {
                Id = id;
            }
        }
    }
}
