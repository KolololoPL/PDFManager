using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PDFManager {
    class PDFSplitter : IDisposable {
        public ProgressBar ProgressBar { get; set; }
        public Button CancelButton { get; set; }
        public CheckBox ReportCheckBox { get; set; }

        private BackgroundWorker worker = null;
        
        //Logowanie odczytów (jeśli wciśniety klawisz Raportuj)
        private StreamWriter logsFile = null;

        public void Split(string pdfPath, string destPath, BackgroundWorker worker = null) {
            //Inicjalizacja raportowania
            if (this.ReportCheckBox.Checked) {
                this.logsFile = new StreamWriter(Path.Combine(destPath, DateTime.Now.ToString("yyyyMMddHHmmss") + "RAPORT.txt"));
            }

            #region Wstępne rozpoznawanie

            BitmapPDF pdfBitmap = new BitmapPDF(pdfPath);
            PdfReader pdfDoc = new PdfReader(pdfPath);

            int[] results = new int[pdfDoc.NumberOfPages];
            for (int i = 0; i < pdfDoc.NumberOfPages && !worker.CancellationPending; i++) {
                try {
                    results[i] = pdfBitmap.Current.AvgContent;
                    if (logsFile != null) {
                        logsFile.WriteLine(String.Format("Strona {0}: {1}", i + 1, results[i]));
                    }
                    
                    worker.ReportProgress(((i + 1) * 100) / pdfDoc.NumberOfPages);
                    pdfBitmap.MoveNext();
                } catch (Exception ex) {
                    //Będzie zawsze na końcu
                    Console.WriteLine(ex.Message);
                }
            }

            pdfDoc.Close();
            pdfBitmap.Dispose();
            if (logsFile != null)
                logsFile.Close();
            #endregion

            #region Właściwe rozdzielanie
            if (!worker.CancellationPending) {
                int j = 1;
                List<int> pages = new List<int>();

                foreach (int result in results) {
                    if (result > int.Parse(Properties.Settings.Default.MaxSensitivity)) {
                        if (pages.Count > 0) {
                            try {
                                string pdfDest = Path.Combine(destPath, DateTime.Now.ToString("yyyyMMddHHmmss") + j.ToString().PadLeft(4, '0') + ".pdf");
                                this.ExtractPages(pdfPath, pdfDest, pages.ToArray());
                            } catch (Exception ex) {
                                MessageBox.Show("Wystąpił błąd! " + ex.Message, "To jakiś straszny błąd!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                            pages.Clear();
                        }
                    } else if (result > int.Parse(Properties.Settings.Default.MinSensitivity)) {
                        pages.Add(j);
                    }

                    j++;
                }

                //Na wszelki wypadek, gdyby końcówka została
                if (pages.Count > 0) {
                    try {
                        string pdfDest = Path.Combine(destPath, DateTime.Now.ToString("yyyyMMddHHmmss") + j.ToString().PadLeft(4, '0') + ".pdf");
                        this.ExtractPages(pdfPath, pdfDest, pages.ToArray());
                    } catch (Exception ex) {
                        MessageBox.Show("Wystąpił błąd! " + ex.Message, "To jakiś straszny błąd!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            #endregion

            worker.ReportProgress(0);
        }

        private void CancelButton_Click(object sender, EventArgs e) {
            this.worker.CancelAsync();
        }

        //Thanks for John Atten from code project
        //http://www.codeproject.com/Articles/559380/Splitting-and-Merging-PDF-Files-in-Csharp-Using-iT#iTextExampleExtractPageRange
        private void ExtractPages(string sourcePdfPath, string outputPdfPath, int[] extractThesePages) {
            PdfReader reader = null;
            Document sourceDocument = null;
            PdfCopy pdfCopyProvider = null;
            PdfImportedPage importedPage = null;

            try {
                // Intialize a new PdfReader instance with the 
                // contents of the source Pdf file:
                reader = new PdfReader(sourcePdfPath);

                // For simplicity, I am assuming all the pages share the same size
                // and rotation as the first page:
                sourceDocument = new Document(reader.GetPageSizeWithRotation(extractThesePages[0]));

                // Initialize an instance of the PdfCopyClass with the source 
                // document and an output file stream:
                pdfCopyProvider = new PdfCopy(sourceDocument, new System.IO.FileStream(outputPdfPath, System.IO.FileMode.Create));

                sourceDocument.Open();

                // Walk the array and add the page copies to the output file:
                foreach (int pageNumber in extractThesePages) {
                    importedPage = pdfCopyProvider.GetImportedPage(reader, pageNumber);
                    pdfCopyProvider.AddPage(importedPage);
                }

                pdfCopyProvider.Dispose();
                sourceDocument.Close();
                reader.Close();
            } catch (Exception ex) {
                throw ex;
            }
        }

        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private bool isDisposed = false;
        protected void Dispose(bool disposing) {
            if (!this.isDisposed) {
                //Zwalnia niezarządzane zasoby...

                //...i te zarządzane
                if (disposing) {
                    this.ProgressBar = null;
                    this.CancelButton = null;
                    if (this.worker != null)
                        this.worker.Dispose();
                }
            }
            isDisposed = true;
        }

        ~PDFSplitter() {
            Dispose(false);
        }
    }
}
