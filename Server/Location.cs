using Newtonsoft.Json;

namespace Tizen.Appium
{
    public class Location
    {
        [JsonProperty("x")]
        public int X { get; set; }

        [JsonProperty("y")]
        public int Y { get; set; }

        [JsonProperty("centerx")]
        public int CenterX { get; set; }

        [JsonProperty("centery")]
        public int CenterY { get; set; }

        [JsonProperty("width")]
        public int Width { get; set; }

        [JsonProperty("height")]
        public int Height { get; set; }

        public Location(int x1 = -1, int y1 = -1, int x2 = -1, int y2 = -1, int width = -1, int height = -1)
        {
            X = x1;
            Y = y1;
            CenterX = x2;
            CenterY = y2;
            Width = width;
            Height = height;
        }
    }
}
