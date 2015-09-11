using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDFManager {
    class BitmapPage : IDisposable {
        public Bitmap Bitmap { get; set; }
        public int AvgContent {
            get {
                Bitmap bm = this.Bitmap;

                int count = 0;
                int width = bm.Width;
                int height = bm.Height;
                int red = 0;
                int green = 0;
                int blue = 0;
                long[] totals = new long[] { 0, 0, 0 };
                int bppModifier = bm.PixelFormat == System.Drawing.Imaging.PixelFormat.Format24bppRgb ? 3 : 4; // cutting corners, will fail on anything else but 32 and 24 bit images

                BitmapData srcData = bm.LockBits(new System.Drawing.Rectangle(0, 0, bm.Width, bm.Height), ImageLockMode.ReadOnly, bm.PixelFormat);
                int stride = srcData.Stride;
                IntPtr Scan0 = srcData.Scan0;

                unsafe {
                    byte* p = (byte*)(void*)Scan0;

                    for (int y = 0; y < height; y += 2) {
                        for (int x = 0; x < width; x += 2) {
                            int idx = (y * stride) + x * bppModifier;
                            red = p[idx + 2];
                            green = p[idx + 1];
                            blue = p[idx];

                            if (red + green + blue < 600) {
                                count++;
                            }
                        }
                    }
                }

                return (int)(count / (height / 2 * width / 2 * 1.0) * 10000);
            }
        }

        public void Dispose() {
            this.Bitmap.Dispose();
        }
    }
}
