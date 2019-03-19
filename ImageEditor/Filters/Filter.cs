using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace ImageEditor
{
    abstract class Filter
    {
        private byte[] imageBytes;

        public static Filter MakeFilter(string type)
        {
            switch (type)
            {
                case "Grayscale":
                    return new GrayscaleFilter();
                case "Inverted":
                    return new InvertedFilter();
                case "Randomized":
                    return new RandomizedFilter();
                case "Cycled":
                    return new CycledFilter();
                default:
                    throw new InvalidOperationException();
            }
        }

        public Image ApplyFilter(Image image)
        {
            Bitmap bitmap = image as Bitmap;

            BitmapData imageData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);

            imageBytes = new byte[Math.Abs(imageData.Stride) * bitmap.Height];
            IntPtr scan0 = imageData.Scan0;

            Marshal.Copy(scan0, imageBytes, 0, imageBytes.Length);

            for (int i = 0; i < imageBytes.Length; i += 4)
            {
                UpdatePixel(i);
            }

            Marshal.Copy(imageBytes, 0, scan0, imageBytes.Length);

            bitmap.UnlockBits(imageData);

            return bitmap as Image;
        }

        private void UpdatePixel(int i)
        {
            byte[] pixel = CalculatePixel(
                imageBytes[i],
                imageBytes[i + 1],
                imageBytes[i + 2]
                );

            imageBytes[i] = pixel[0];
            imageBytes[i + 1] = pixel[1];
            imageBytes[i + 2] = pixel[2];
        }

        protected abstract byte[] CalculatePixel(byte r, byte g, byte b);
    }
}
