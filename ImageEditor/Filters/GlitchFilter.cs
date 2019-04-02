using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageEditor.Filters
{
    class GlitchFilter : Filter
    {
        private byte[] imageBytes;
    
        private Random random = new Random();
        private Random random2 = new Random();
        private Bitmap bitmap;
        private int xRange;
        private int yRange;

        public GlitchFilter()
        {
            
        }

        public override Image ApplyFilter(Image image)
        {
            bitmap = image as Bitmap;

            BitmapData imageData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);

            imageBytes = new byte[Math.Abs(imageData.Stride) * bitmap.Height];
            IntPtr scan0 = imageData.Scan0;

            Marshal.Copy(scan0, imageBytes, 0, imageBytes.Length);

            xRange = bitmap.Width * 4;
            yRange = bitmap.Height * 4;

            RandomGlitchHorizontal(imageBytes, true);
            RandomGlitchHorizontal(imageBytes, true);
            

            if (new Random().Next(1,3) == 1) RandomGlitchHorizontal(imageBytes, true);

            Marshal.Copy(imageBytes, 0, scan0, imageBytes.Length);

            bitmap.UnlockBits(imageData);

            return bitmap as Image;
        }

        private void RandomGlitchHorizontal(byte[] imageBytes, bool plus)
        {
            random = new Random();
            random2 = new Random();
            var range = xRange * random.Next(bitmap.Height / 2, bitmap.Height - 1);

            for (int i = xRange * random.Next(1, bitmap.Height / 3); i < range; i += 4)
            {
               


                var t = xRange * random2.Next(bitmap.Height / 2, bitmap.Height - 1);
                if (plus)
                {
                    imageBytes[i] = imageBytes[i + 8 * 5];
                    imageBytes[i + 1] = imageBytes[i + 9 * 5];
                    imageBytes[i + 2] = imageBytes[i + 10 * 5];
                    imageBytes[i + 3] = imageBytes[i + 11 * 5];
                }
                else
                {
              
                }


                // * 5 = glitch filter

            }
            
        }

        protected override byte[] CalculatePixel(byte r, byte g, byte b, byte a)
        {
            return new byte[]
            {
                Convert.ToByte(b),
                Convert.ToByte(r),
                Convert.ToByte(g),
                Convert.ToByte(a)
            };
        }
    }
}
