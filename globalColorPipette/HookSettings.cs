using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using globalColorPipette;

namespace globalColorPipette
{
    class HookSettings
    {
        public static MouseHook mouseHook;
        public static void setHookOnCombinations()
        {
            mouseHook = new MouseHook();
            mouseHook.LeftButtonUp += new MouseHook.MouseHookCallback(lMouseHook_KeyUp);
            mouseHook.LeftButtonDown += new MouseHook.MouseHookCallback(lMouseHook_KeyDown);

            mouseHook.RightButtonUp += new MouseHook.MouseHookCallback(rMouseHook_KeyDown);
            mouseHook.Install();
        }
        static bool canPippet = false;
        private static void lMouseHook_KeyUp(MouseHook.MSLLHOOKSTRUCT key)
        {
            if (canPippet)
            {
                mouseHook.Uninstall();
                Program.MakeScreenshot(key.pt.x, key.pt.y);
                canPippet = false;
            }
        }
        private static void lMouseHook_KeyDown(MouseHook.MSLLHOOKSTRUCT key)
        {
            canPippet = true;
        }
        private static void rMouseHook_KeyDown(MouseHook.MSLLHOOKSTRUCT key)
        {
            mouseHook.Uninstall();
            canPippet = false;
            //NotifyController.showTips("pipette drop", "!");
        }
    }
}
