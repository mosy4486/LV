using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;


namespace LVAgent
{
    public class ScreenManager
    {
        public static byte[] Capture()
        {
            Rectangle bounds = Screen.PrimaryScreen!.Bounds;

            using Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height);
            using Graphics g = Graphics.FromImage(bitmap);

            g.CopyFromScreen(bounds.Location, Point.Empty, bounds.Size);

            using MemoryStream ms = new MemoryStream();
            bitmap.Save(ms, ImageFormat.Jpeg);

            return ms.ToArray();
        }
    }
}
