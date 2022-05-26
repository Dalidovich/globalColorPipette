namespace globalColorPipette
{
    internal class ProgramBase
    {

        public static MouseHook mouseHook;
        static bool canPippet = false;
        public static void setHookOnCombinations()
        {
            mouseHook = new MouseHook();
            mouseHook.LeftButtonUp += new MouseHook.MouseHookCallback(mouseHook_KeyUp);
            mouseHook.LeftButtonDown += new MouseHook.MouseHookCallback(mouseHook_KeyDown);
            mouseHook.Install();
        }
        private static void mouseHook_KeyDown(MouseHook.MSLLHOOKSTRUCT key)
        {
            canPippet = true;
        }
        private static void mouseHook_KeyUp(MouseHook.MSLLHOOKSTRUCT key)
        {
            if (canPippet)
            {
                mouseHook.Uninstall();
                Program.MakeScreenshot(key.pt.x, key.pt.y);
                canPippet = false;
            }
        }
    }
}