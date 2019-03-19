using System;
using Newtonsoft.Json;

namespace Tizen.Appium
{
    public class Geometry
    {
        int MinisumSize = 2;

        [JsonProperty("x")]
        public int X { get; set; }

        [JsonProperty("y")]
        public int Y { get; set; }

        [JsonIgnore]
        public int CenterX
        {
            get
            {
                return GetCenterX();
            }
        }

        [JsonIgnore]
        public int CenterY
        {
            get
            {
                return GetCenterY();
            }
        }

        [JsonProperty("width")]
        public int Width { get; set; }

        [JsonProperty("height")]
        public int Height { get; set; }

        public Geometry(int x = -1, int y = -1, int width = -1, int height = -1)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        int GetCenterX()
        {
            var screenWidth = Utils.GetScreeenWidth();            

            if ((X > screenWidth) || (X + Width) < 0)
            {
                return -1;
            }

            var x1 = Math.Max(0, X);
            var x2 = Math.Min(screenWidth, X + Width);

            if ((x2 - x1) < MinisumSize)
            {
                return -1;
            }
            else
            {
                return (int)((x1 + x2) / 2);
            }
        }

        int GetCenterY()
        {
            var screenHeight = Utils.GetScreenHeight();

            if ((Y > screenHeight) || (Y + Height) < 0)
            {
                return -1;
            }

            var x1 = Math.Max(0, Y);
            var x2 = Math.Min(screenHeight, Y + Height);

            if ((x2 - x1) < MinisumSize)
            {
                return -1;
            }
            else
            {
                return (int)((x1 + x2) / 2);
            }
        }
    }
}
