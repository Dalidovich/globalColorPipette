using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace globalColorPipette
{
    class Program
    {
        public static void MakeScreenshot(int x, int y)
        {
            Rectangle bounds = Screen.GetBounds(Point.Empty);
            using (var bitmap = new Bitmap(bounds.Width, bounds.Height))
            {
                using (var g = Graphics.FromImage(bitmap))
                {
                    g.CopyFromScreen(Point.Empty, Point.Empty, bounds.Size);
                }
                string hexColor = HexConverter(bitmap.GetPixel(x, y));
                addInClipBoard(hexColor);
            }
        }
        private static String HexConverter(System.Drawing.Color c)
        {
            return "#" + c.R.ToString("X2") + c.G.ToString("X2") + c.B.ToString("X2");
        }
        [STAThread]
        static void Main(string[] args)
        {
            HideConsoleWindow.hide();
            new Task(()=>
            {
                NotifyController.createNotify();
            }
            ).RunSynchronously();
        }
        public static void addInClipBoard(string s)
        {
            Clipboard.SetText(s);
            NotifyController.notificationIcon.BalloonTipTitle= "add to Clipboard";
            NotifyController.notificationIcon.BalloonTipText=s;
            NotifyController.notificationIcon.ShowBalloonTip(1500);
        }
        
    }
}
