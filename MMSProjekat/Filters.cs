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

                        r = Math.Abs(r - L) * blckFilterValue; // blckValue je broj koji se uzima iz windowa od 1 -> 7
                        g = Math.Abs(g - L) * blckFilterValue; // blckValue je broj koji se uzima iz windowa od 1 -> 7
                        b = Math.Abs(b - L) * blckFilterValue; // blckValue je broj koji se uzima iz windowa od 1 -> 7

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

        public static Bitmap HistogramEqualization(Bitmap bitmap)
        {
            /* HISTOGRAM Y (ne radim za RGB jer se boje  pokvare) */

            int width = bitmap.Width;
            int height = bitmap.Height;

            Rectangle rect = new Rectangle(0, 0, width, height);
            BitmapData data = bitmap.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int stride = data.Stride;
            int totalPixels = width * height;

            /* NAPRAVITI HISTOGRAM ZA Y */
            int[] histY = new int[256];
            int[] histCr = new int[256];
            int[] histCb = new int[256];

            unsafe
            {
                byte* ptr = (byte*)data.Scan0.ToPointer();

                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        byte* pixelPtr = ptr + y * stride + x * 3;

                        int b = pixelPtr[0];
                        int g = pixelPtr[1];
                        int r = pixelPtr[2];

                        /* Pretvorimo u YCrCb format ali samo izracunamo Y */
                        int Y = (int)(0.299 * r + 0.587 * g + 0.114 * b);

                        histY[Y]++;
                    }
                }
            }

            /* PROVERITI LUT */
            /* Pravimo CDF i LUT (Cumulative Distribution Function i LookUp Table) */
            byte[] lutY = BuildEqualizationLUT(histY, totalPixels);

            /* VREDNOST iz lutY vracamo u Bitmapu */
            unsafe
            {
                byte* ptr = (byte*)data.Scan0.ToPointer();

                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        byte* pixelPtr = ptr + y * stride + x * 3;

                        int b = pixelPtr[0];
                        int g = pixelPtr[1];
                        int r = pixelPtr[2];

                        double Y = 0.299 * r + 0.587 * g + 0.114 * b;
                        double Cb = 128 - 0.168736 * r - 0.331264 * g + 0.5 * b;
                        double Cr = 128 + 0.5 * r - 0.418688 * g - 0.081312 * b;

                        int newY = lutY[(int)Y];

                        int newR = (int)(newY + 1.402 * (Cr - 128));
                        int newG = (int)(newY - 0.344136 * (Cb - 128) - 0.714136 * (Cr - 128));
                        int newB = (int)(newY + 1.772 * (Cb - 128));

                        newR = Math.Min(255, Math.Max(0, newR));
                        newG = Math.Min(255, Math.Max(0, newG));
                        newB = Math.Min(255, Math.Max(0, newB));

                        pixelPtr[0] = (byte)newB;
                        pixelPtr[1] = (byte)newG;
                        pixelPtr[2] = (byte)newR;
                    }
                }
            }

            bitmap.UnlockBits(data);
            return bitmap;
        }

        /* POMOCNA FUNKCIJA ZA KREIRANJE CDF-a I LUT-a za HEq */
        private static byte[] BuildEqualizationLUT(int[] hist, int totalPixels)
        {
            int[] cdf = new int[256];
            cdf[0] = hist[0];
            for (int i = 1; i < 256; i++)
            {
                cdf[i] = cdf[i - 1] + hist[i];
            }

            int cdfMin = cdf.First(val => val > 0);
            byte[] lut = new byte[256];

            for (int i = 0; i < 256; i++)
            {
                lut[i] = (byte)Math.Round(((double)(cdf[i] - cdfMin) / (totalPixels - cdfMin)) * 255);
            }

            return lut;
        }

        public static Bitmap GaussianBlur(Bitmap bitmap, int kernelSize, double sigma)
        {

            if (kernelSize % 2 == 0)
            {
                kernelSize--;
            }

            double[,] kernel = GenerateGaussianKernel(kernelSize, sigma);

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
                        double rSum = 0;
                        double gSum = 0;
                        double bSum = 0;

                        for (int x = -minmax; x <= minmax; x++)
                        {
                            for (int y = -minmax; y <= minmax; y++)
                            {

                                int srcY = i + x;
                                int srcX = j + y;

                                if (srcY < 0) srcY = -srcY;
                                if (srcY >= height) srcY = 2 * height - srcY - 2;

                                if (srcX < 0) srcX = -srcX;
                                if (srcX >= width) srcX = 2 * width - srcX - 2;

                                byte* pPixel = srcPtr + srcY * strideSrc + srcX * 3;
                                double kValue = kernel[x + minmax, y + minmax];

                                bSum += pPixel[0] * kValue;
                                gSum += pPixel[1] * kValue;
                                rSum += pPixel[2] * kValue;
                            }
                        }

                        byte* pDst = dstPtr + i * strideDst + j * 3;
                        pDst[0] = (byte)Math.Min(255, Math.Max(0, (int)Math.Round(bSum)));
                        pDst[1] = (byte)Math.Min(255, Math.Max(0, (int)Math.Round(gSum)));
                        pDst[2] = (byte)Math.Min(255, Math.Max(0, (int)Math.Round(rSum)));

                    }
                }

            }
            srcBitmap.UnlockBits(srcData);
            bitmap.UnlockBits(dstData);

            return bitmap;
        }
        private static double[,] GenerateGaussianKernel(int kernelSize, double sigma)
        {
            double[,] kernel = new double[kernelSize, kernelSize];
            double sum = 0.0;

            int half = kernelSize / 2;
            double sigma2 = 2 * sigma * sigma;

            for (int y = -half; y <= half; y++)
            {
                for (int x = -half; x <= half; x++)
                {
                    double exponent = -(x * x + y * y) / sigma2;
                    double value = Math.Exp(exponent) / (Math.PI * sigma2);

                    kernel[y + half, x + half] = value;
                    sum += value;
                }
            }

            for (int y = 0; y < kernelSize; y++)
            {
                for (int x = 0; x < kernelSize; x++)
                {
                    kernel[y, x] /= sum;
                }
            }

            return kernel;
        }

    }
}
