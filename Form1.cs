using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PDFManager {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void watchStopButton_Click(object sender, EventArgs e) {
            if (this.watchStopButton.Text == "Watch!") {
                WatchDog watchDog = new WatchDog() { ProgressBar = this.splitProgressBar, CancelButton = this.watchStopButton, ReportCheckBox = this.reportCheckBox };
                watchDog.Start(this.srcDirPathTextBox.Text, this.destDirPathTextBox.Text);

                //Blokada zmiany katalogów
                this.destDirOpenButton.Enabled = false;
                this.srcDirOpenButton.Enabled = false;
            } else {
                this.watchStopButton.Enabled = false;

                //Odblokowanie zmiany katalogów
                this.destDirOpenButton.Enabled = true;
                this.srcDirOpenButton.Enabled = true;
            }
        }

        private void srcDirOpenButton_Click(object sender, EventArgs e) {
            FolderBrowserDialog dialog = new FolderBrowserDialog();

            if (dialog.ShowDialog() == DialogResult.OK) {
                srcDirPathTextBox.Text = dialog.SelectedPath;
            }
        }

        private void destDirOpenButton_Click(object sender, EventArgs e) {
            FolderBrowserDialog dialog = new FolderBrowserDialog();

            if (dialog.ShowDialog() == DialogResult.OK) {
                destDirPathTextBox.Text = dialog.SelectedPath;
            }
        }

        private class OutOfRangeException : Exception {
            public string NewValue { get; set; }
        }

        private void minSensitivityTextBox_Validating(object sender, CancelEventArgs e) {
            try {
                int num;
                if (int.TryParse(this.minSensitivityTextBox.Text, out num)) {
                    if (num < 0) {
                        throw new OutOfRangeException { NewValue = "0" };
                    } else if (num > 9999) {
                        throw new OutOfRangeException { NewValue = "9999" };
                    }
                } else {
                    throw new OutOfRangeException { NewValue = "-1" };
                }
            } catch (OutOfRangeException ex) {
                this.minSensitivityTextBox.Text = ex.NewValue;
            } finally {
                Properties.Settings.Default.MinSensitivity = this.minSensitivityTextBox.Text;
            }
        }

        private void maxSensitivityTextBox_Validating(object sender, CancelEventArgs e) {
            try {
                int num;
                if (int.TryParse(this.minSensitivityTextBox.Text, out num)) {
                    if (num < 1) {
                        throw new OutOfRangeException { NewValue = "1" };
                    } else if (num > 10000) {
                        throw new OutOfRangeException { NewValue = "10000" };
                    }
                } else {
                    throw new OutOfRangeException { NewValue = "-1" };
                }
            } catch (OutOfRangeException ex) {
                this.maxSensitivityTextBox.Text = ex.NewValue;
            } finally {
                Properties.Settings.Default.MaxSensitivity = this.maxSensitivityTextBox.Text;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e) {
            Properties.Settings.Default.Save();
        }
    }
}
