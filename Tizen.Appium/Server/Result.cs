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
    }

    public class Location
    {
        [JsonProperty("x")]
        public double X { get; set; }

        [JsonProperty("y")]
        public double Y { get; set; }

        [JsonProperty("centerx")]
        public int CenterX { get; set; }

        [JsonProperty("centery")]
        public int CenterY { get; set; }

        public Location(double x1 = -1, double y1 = -1, int x2 = -1, int y2 = -1)
        {
            X = x1;
            Y = y1;
            CenterX = x2;
            CenterY = y2;
        }
    }
}
