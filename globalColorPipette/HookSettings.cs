using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using globalColorPipette;

namespace globalColorPipette
{
    class HookSettings
    {
        public static MouseHook mouseHook;
        public static void setHookOnCombinations()
        {
            mouseHook = new MouseHook();
            mouseHook.LeftButtonUp += new MouseHook.MouseHookCallback(mouseHook_KeyUp);
            mouseHook.LeftButtonDown += new MouseHook.MouseHookCallback(mouseHook_KeyDown);
            mouseHook.Install();
        }
        static bool canPippet = false;
        private static void mouseHook_KeyUp(MouseHook.MSLLHOOKSTRUCT key)
        {
            if (canPippet)
            {
                mouseHook.Uninstall();
                Program.MakeScreenshot(key.pt.x, key.pt.y);
                canPippet = false;
            }
        }
        private static void mouseHook_KeyDown(MouseHook.MSLLHOOKSTRUCT key)
        {
            canPippet = true;
        }
    }
}
