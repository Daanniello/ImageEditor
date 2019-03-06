using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageEditor
{
    class ImageGrayscale
    {
        public ImageGrayscale()
        {

        }

        public Image ApplyFilter(Image image)
        {
            Bitmap bitmap = (Bitmap) image;

            // Loop through the images pixels to reset color.
            for (var x = 0; x < bitmap.Width; x++)
            {
                for (var y = 0; y < bitmap.Height; y++)
                {
                    Color pixelColor = bitmap.GetPixel(x, y);
                    int value = (pixelColor.R + pixelColor.G + pixelColor.B) / 3;
                    Color newColor = Color.FromArgb(pixelColor.A, value, value, value);
           


                    bitmap.SetPixel(x, y, newColor); // Now greyscale
                }
            }

            return bitmap as Image;
        }
    }
}
