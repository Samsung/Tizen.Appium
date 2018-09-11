
using System;

namespace Tizen.Appium
{
    public interface IInputGenerator : IDisposable
    {
        bool Click(int x, int y);

        bool TouchUp(int x, int y);

        bool TouchDown(int x, int y);

        bool TouchMove(int x, int y);

        bool Flick(int xSpeed, int ySpeed);

        bool Drag(int xDown, int yDown, int xUp, int yUp, int steps = 30);

        bool SendKey(string key);

        bool SendKeys(string[] keys);

        bool PressKey(string key);

        bool ReleaseKey(string key);
    }
}
