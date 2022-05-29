using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace globalColorPipette
{
    class NotifyController
    {

        public static ContextMenu menu;
        public static MenuItem mnuExit;
        public static NotifyIcon notificationIcon;
        public static void createNotify()
        {
            menu = new ContextMenu();
            mnuExit = new MenuItem("Exit");
            mnuExit.Click += mnuExit_Click;
            menu.MenuItems.Add(0, mnuExit);

            notificationIcon = new NotifyIcon()
            {
                Icon = IconsController.createPipetteIconForNotify(),
                ContextMenu = menu
            };
            notificationIcon.MouseDoubleClick += new MouseEventHandler(ni_Click);
            notificationIcon.Visible = true;
            Application.Run();
        }
        
        static void mnuExit_Click(object sender, EventArgs e)
        {
            notificationIcon.Visible = false;
            notificationIcon.Dispose();
            Application.Exit();
            Environment.Exit(0);
        }

        static void ni_Click(object sender, EventArgs e)
        {
            HookSettings.setHookOnCombinations();
        }
        public static void showTips(string s,string t= "add to Clipboard")
        {
            NotifyController.notificationIcon.BalloonTipTitle = t;
            NotifyController.notificationIcon.BalloonTipText = s;
            NotifyController.notificationIcon.ShowBalloonTip(1500);
        }
    }
}
