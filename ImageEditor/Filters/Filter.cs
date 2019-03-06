using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageEditor
{
    abstract class Filter
    {
        Bitmap bitmap;

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
                default:
                    return null;
            }
        }

        public Image ApplyFilter(Image image)
        {
            bitmap = image as Bitmap;
            
            for (var x = 0; x < bitmap.Width; x++)
            {
                for (var y = 0; y < bitmap.Height; y++)
                {
                    UpdatePixel(x, y);
                }
            }

            return bitmap as Image;
        }

        private void UpdatePixel(int x, int y)
        {
            Color pixel = bitmap.GetPixel(x, y);
            Color newColor = CalculatePixel(pixel);
            bitmap.SetPixel(x, y, newColor);
        }

        protected abstract Color CalculatePixel(Color pixel);
    }
}
