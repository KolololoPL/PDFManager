using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PDFManager {
    class WatchDog : IDisposable {
        public ProgressBar ProgressBar { get; set; }
        public Button CancelButton { get; set; }
        public CheckBox ReportCheckBox { get; set; }

        private BackgroundWorker worker = null;

        public void Start(string pdfPath, string destPath) {
            //Start
            if (this.CancelButton != null) {
                this.CancelButton.Click += new EventHandler(CancelButton_Click);
            }

            this.worker = new BackgroundWorker();

            this.worker.WorkerReportsProgress = true;
            this.worker.WorkerSupportsCancellation = true;

            this.worker.DoWork += this.DoWork;
            this.worker.ProgressChanged += this.ProgressChanged;
            this.worker.RunWorkerCompleted += this.RunWorkerCompleted;

            this.worker.RunWorkerAsync(new WorkParams { PdfPath = pdfPath, DestPath = destPath });
            this.CancelButton.Text = "Stop..";
        }

        private void DoWork(object sender, DoWorkEventArgs e) {
            WorkParams workParams = e.Argument as WorkParams;
            BackgroundWorker worker = sender as BackgroundWorker;
            
            while (!worker.CancellationPending) {
                System.Threading.Thread.Sleep(500);
                DirectoryInfo info = new DirectoryInfo(workParams.PdfPath);
                FileInfo[] files = info.GetFiles("*.pdf").OrderBy(p => p.LastWriteTime).ToArray();

                if (files.Length > 0) {
                    foreach (var file in files) {
                        try {
                            using (PDFSplitter splitter = new PDFSplitter() { ProgressBar = this.ProgressBar, CancelButton = this.CancelButton, ReportCheckBox = this.ReportCheckBox }) {
                                splitter.Split(file.FullName, workParams.DestPath, worker);
                            }

                            if (!worker.CancellationPending) {
                                string destPath = Path.Combine(workParams.DestPath, "Oryginalne");
                                Directory.CreateDirectory(destPath);
                                destPath = Path.Combine(destPath, file.Name);
                                Directory.Move(file.FullName, destPath);
                            }
                        } catch (IOException) {
                            //Występuje gdy inny proces działa na pliku, chcemy w takim wypadku przejść dalej
                        }
                    }
                }
            }
        }

        private void ProgressChanged(object sender, ProgressChangedEventArgs e) {
            if (this.ProgressBar != null) {
                this.ProgressBar.Value = e.ProgressPercentage;
            }
        }


        private void RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            if (e.Error != null) {
                if (e.Error is FileNotFoundException) {
                    MessageBox.Show("Błędna ścieżka do pliku!", "To jakiś straszny błąd!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                } else {
                    MessageBox.Show("Wystąpił błąd!\n" + e.Error.Message, "To jakiś straszny błąd!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            this.Dispose();
        }

        private void CancelButton_Click(object sender, EventArgs e) {
            this.worker.CancelAsync();
        }

        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private bool isDisposed = false;
        protected void Dispose(bool disposing) {
            if (!this.isDisposed) {
                //Zwalnia niezarządzane zasoby...
                if (this.CancelButton != null) {
                    this.CancelButton.Text = "Watch!";
                    this.CancelButton.Enabled = true;
                    this.CancelButton.Click -= new EventHandler(CancelButton_Click);
                }

                if (this.ProgressBar != null) {
                    this.ProgressBar.Value = 0;
                }

                //...i te zarządzane
                if (disposing) {
                    this.ProgressBar = null;
                    this.CancelButton = null;
                    this.worker.Dispose();
                }
            }
            isDisposed = true;
        }

        ~WatchDog() {
            Dispose(false);
        }
    }
}
