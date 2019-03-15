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

        public class Size
        {
            [JsonProperty("width")]
            public int Width { get; set; }

            [JsonProperty("height")]
            public int Height { get; set; }

            public Size(int width = 0, int height = 0)
            {
                Width = width;
                Height = height;
            }
            public override string ToString()
            {
                return "Width=" + Width + ", Height=" + Height;
            }
        }
        public class Location
        {
            [JsonProperty("x")]
            public int X { get; set; }

            [JsonProperty("y")]
            public int Y { get; set; }

            public Location(int x = 0, int y = 0)
            {
                X = x;
                Y = y;
            }

            public override string ToString()
            {
                return "X=" + X + ", Y=" + Y;
            }
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
