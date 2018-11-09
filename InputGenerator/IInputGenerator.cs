using System;

namespace Tizen.Appium
{
    public interface IInputGenerator : IDisposable
    {
        bool Click(int x, int y);

        bool TouchUp(int x, int y);

        bool TouchDown(int x, int y);

        bool TouchMove(int xDown, int yDown, int xUp, int yUp, int steps = 10);

        bool Drag(int xDown, int yDown, int xUp, int yUp, int steps = 50);

        bool SendKey(string key);

        bool SendKeys(string[] keys);

        bool PressKey(string key);

        bool ReleaseKey(string key);
    }
}
