
using System;

namespace Tizen.Appium
{
    public interface IInputGenerator : IDisposable
    {
        bool Click(int x, int y);

        bool touchUp(int x, int y);

        bool touchDown(int x, int y);

        bool touchMove(int x, int y);

        bool Flick(int xSpeed, int ySpeed);

        bool Drag(int xDown, int yDown, int xUp, int yUp, int steps = 30);

        bool SendKey(string key);

        bool SendKeys(string[] keys);

        bool PressKey(string key);

        bool ReleaseKey(string key);
    }
}
