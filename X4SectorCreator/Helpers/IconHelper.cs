using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;

namespace X4SectorCreator.Helpers
{
    public static class IconHelper
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern bool DestroyIcon(IntPtr handle);

        /// <summary>
        /// Creates an Icon from a PNG file by resizing to a square and converting the bitmap handle.
        /// The returned Icon is managed and safe to use without leaking native handles.
        /// </summary>
        public static Icon FromPng(string pngPath, int size = 32)
        {
            if (string.IsNullOrWhiteSpace(pngPath) || !File.Exists(pngPath))
                return null;

            using var bmp = new Bitmap(pngPath);
            using var resized = new Bitmap(bmp, new Size(size, size));
            IntPtr hIcon = resized.GetHicon();
            try
            {
                using var tmp = Icon.FromHandle(hIcon);
                return (Icon)tmp.Clone();
            }
            finally
            {
                _ = DestroyIcon(hIcon);
            }
        }
    }
}
