using TSystemInfo = Tizen.System.Information;

namespace Tizen.Appium
{
    public class Utils
    {
        public static int GetScreeenWidth()
        {
            int width;
            TSystemInfo.TryGetValue<int>("http://tizen.org/feature/screen.width", out width);
            return width;
        }

        public static int GetScreenHeight()
        {
            int height;
            TSystemInfo.TryGetValue<int>("http://tizen.org/feature/screen.height", out height);
            return height;
        }

    }
}
