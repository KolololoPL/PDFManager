using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDFManager {
    class BitmapPDF : IEnumerator<BitmapPage>, IDisposable {
        private string _pdfPath;
        private int _pageNumber;
        private BitmapPage _currentBitmapPage;

        public BitmapPDF(string pdfPath) {
            this._pdfPath = pdfPath;
            this._currentBitmapPage = null;
            this.Reset();
        }

        public BitmapPage Current {
            get { return this._currentBitmapPage; }
        }

        public bool MoveNext() {
            if (this._currentBitmapPage != null)
                this._currentBitmapPage.Dispose();

            this._pageNumber++;

            Bitmap tmpBitmap = this.ExtractImage(this._pdfPath, this._pageNumber);
            if (tmpBitmap != null) {
                this._currentBitmapPage = new BitmapPage() { Bitmap = tmpBitmap };
                return true;
            }

            return false;
        }

        public void Reset() {
            this._pageNumber = 0;
            this.MoveNext();
        }

        public void Dispose() {
            if (this._currentBitmapPage != null)
                this._currentBitmapPage.Dispose();
        }

        //Funkcja zaczerpnięte od Dhivya X.P z stackoverflow.com
        //http://stackoverflow.com/questions/10689382/extract-image-from-a-particular-page-in-pdf-using-itextsharp-4-0
        private Bitmap ExtractImage(string pdfFile, int pageNumber) {
            if (pdfFile.Length == 0) {
                throw new FileNotFoundException();
            }

            PdfReader pdf = new PdfReader(pdfFile);
            if (pdf.NumberOfPages < pageNumber) {
                pdf.Dispose();
                return null;
            }

            PdfDictionary pg = pdf.GetPageN(pageNumber);
            PdfDictionary res = (PdfDictionary)PdfReader.GetPdfObject(pg.Get(PdfName.RESOURCES));
            PdfDictionary xobj = (PdfDictionary)PdfReader.GetPdfObject(res.Get(PdfName.XOBJECT));
            foreach (PdfName name in xobj.Keys) {
                PdfObject obj = xobj.Get(name);
                if (obj.IsIndirect()) {
                    PdfDictionary tg = (PdfDictionary)PdfReader.GetPdfObject(obj);
                    float width = float.Parse(tg.Get(PdfName.WIDTH).ToString());
                    float height = float.Parse(tg.Get(PdfName.HEIGHT).ToString());
                    if (width > 500 && height > 1000) {
                        ImageRenderInfo imgRI = ImageRenderInfo.CreateForXObject(new Matrix(width, height), (PRIndirectReference)obj, tg);
                        Bitmap bitmap = RenderImage(imgRI);

                        pdf.Dispose();
                        return bitmap;
                    }
                    Console.Write("UPS! o.O");
                }
            }
            
            pdf.Dispose();
            return null;
        }

        //Jak wyżej
        private Bitmap RenderImage(ImageRenderInfo renderInfo) {
            PdfImageObject image = renderInfo.GetImage();
            using (Image dotnetImg = image.GetDrawingImage()) {
                if (dotnetImg != null) {
                    using (MemoryStream ms = new MemoryStream()) {
                        dotnetImg.Save(ms, ImageFormat.Tiff);
                        Bitmap d = new Bitmap(dotnetImg);
                        return d;
                    }
                }
            }

            return null;
        }

        object System.Collections.IEnumerator.Current {
            get { throw new NotImplementedException(); }
        }
    }
}
