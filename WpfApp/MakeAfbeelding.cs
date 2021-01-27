using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace WpfApp
{
    public static class MakeAfbeelding
    {

        private static Dictionary<string, Bitmap> dict = new Dictionary<string, Bitmap>();

        public static Bitmap GetDict(string s)
        {
            if (!dict.ContainsKey(s))
            {
                Bitmap b = new Bitmap(s);
                dict.Add(s, b);
            }
            return dict[s];
        }

        public static void Clear()
        {
            dict.Clear();
        }

        public static Bitmap Achtergrond(int i, int j)
        {
            if (dict.ContainsKey("empty"))
            {
                return (Bitmap)dict["empty"].Clone();
            }
            else
            {
                Bitmap b = new Bitmap(i, j);
                Graphics g = Graphics.FromImage(b);
                g.Clear(System.Drawing.Color.LightGray);
                dict.Add("empty", b);
                return (Bitmap)dict["empty"].Clone();
            }
        }
        public static BitmapSource CreateBitmapSourceFromGdiBitmap(Bitmap bitmap)
        {
            if (bitmap == null)
                throw new ArgumentNullException("bitmap");

            var rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);

            var bitmapData = bitmap.LockBits(
                rect,
                ImageLockMode.ReadWrite,
                System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            try
            {
                var size = (rect.Width * rect.Height) * 4;

                return BitmapSource.Create(
                    bitmap.Width,
                    bitmap.Height,
                    bitmap.HorizontalResolution,
                    bitmap.VerticalResolution,
                    PixelFormats.Bgra32,
                    null,
                    bitmapData.Scan0,
                    size,
                    bitmapData.Stride);
            }
            finally
            {
                bitmap.UnlockBits(bitmapData);
            }
        }
    }
}
