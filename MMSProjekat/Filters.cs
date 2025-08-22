using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMSProjekat
{
    internal static class Filters
    {
        public static Bitmap BlackFilter(int blckFilterValue, Bitmap bitmap)
        {
            int width = bitmap.Width;
            int height = bitmap.Height;

            Rectangle velicina = new Rectangle(0, 0, width, height);
            BitmapData data = bitmap.LockBits(velicina, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int stride = data.Stride;

            unsafe
            {
                byte* ogPtr = (byte*)data.Scan0.ToPointer();

                for (int x = 0; x < height; x++)
                {
                    for (int y = 0; y < width; y++)
                    {
                        byte* pixelPtr = ogPtr + x * stride + y * 3;
                        int r = pixelPtr[2];
                        int g = pixelPtr[1];
                        int b = pixelPtr[0];

                        int L = (222 * r + 707 * g + 71 * b) / 1000;

                        r = Math.Abs(r - L) * blckFilterValue; // 2 je broj koji se uzima iz windowa od 1 -> 7
                        g = Math.Abs(g - L) * blckFilterValue; // 2 je broj koji se uzima iz windowa od 1 -> 7
                        b = Math.Abs(b - L) * blckFilterValue; // 2 je broj koji se uzima iz windowa od 1 -> 7

                        r = Math.Min(255, Math.Max(0, r));
                        g = Math.Min(255, Math.Max(0, g));
                        b = Math.Min(255, Math.Max(0, b));

                        pixelPtr[2] = (byte)r;
                        pixelPtr[1] = (byte)g;
                        pixelPtr[0] = (byte)b;
                    }
                }
            }
            bitmap.UnlockBits(data);

            return bitmap;

        }

        public static Bitmap MeanRemove(int kernelSize, Bitmap bitmap)
        {
            if (kernelSize % 2 == 0)
            {
                kernelSize--;
            }

            int minmax = kernelSize / 2;

            int width = bitmap.Width;
            int height = bitmap.Height;

            Bitmap srcBitmap = (Bitmap)bitmap.Clone();
            Rectangle rect = new Rectangle(0, 0, width, height);
            BitmapData srcData = srcBitmap.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
            BitmapData dstData = bitmap.LockBits(rect, ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);

            int strideSrc = srcData.Stride;
            int strideDst = dstData.Stride;

            unsafe
            {
                byte* srcPtr = (byte*)srcData.Scan0.ToPointer();
                byte* dstPtr = (byte*)dstData.Scan0.ToPointer();

                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < width; j++)
                    {
                        int nmbrEl = 0;
                        int rSum = 0;
                        int gSum = 0;
                        int bSum = 0;

                        for (int x = -minmax; x <= minmax; x++)
                        {
                            for (int y = -minmax; y <= minmax; y++)
                            {
                                if (i + x < 0 || i + x >= height)
                                    continue;

                                if (j + y < 0 || j + y >= width)
                                    continue;

                                byte* pPixel = srcPtr + (i + x) * strideSrc + (j + y) * 3;
                                bSum += pPixel[0]; // blue
                                gSum += pPixel[1]; // green
                                rSum += pPixel[2]; // red

                                nmbrEl++;
                            }
                        }

                        byte* pDst = dstPtr + i * strideDst + j * 3;
                        pDst[0] = (byte)Math.Min(255, bSum / nmbrEl); // blue
                        pDst[1] = (byte)Math.Min(255, gSum / nmbrEl); // green
                        pDst[2] = (byte)Math.Min(255, rSum / nmbrEl); // red

                    }
                }

            }
            srcBitmap.UnlockBits(srcData);
            bitmap.UnlockBits(dstData);

            return bitmap;
        }
    }
}
