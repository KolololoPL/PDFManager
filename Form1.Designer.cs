namespace PDFManager {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.groupBoxMain = new System.Windows.Forms.GroupBox();
            this.watchStopButton = new System.Windows.Forms.Button();
            this.srcDirOpenButton = new System.Windows.Forms.Button();
            this.splitProgressBar = new System.Windows.Forms.ProgressBar();
            this.srcDirPathTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.destDirOpenButton = new System.Windows.Forms.Button();
            this.destDirPathTextBox = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.maxSensitivityTextBox = new System.Windows.Forms.TextBox();
            this.minSensitivityTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.reportCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBoxMain.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxMain
            // 
            this.groupBoxMain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxMain.Controls.Add(this.watchStopButton);
            this.groupBoxMain.Controls.Add(this.srcDirOpenButton);
            this.groupBoxMain.Controls.Add(this.splitProgressBar);
            this.groupBoxMain.Controls.Add(this.srcDirPathTextBox);
            this.groupBoxMain.Location = new System.Drawing.Point(13, 13);
            this.groupBoxMain.Name = "groupBoxMain";
            this.groupBoxMain.Size = new System.Drawing.Size(389, 96);
            this.groupBoxMain.TabIndex = 0;
            this.groupBoxMain.TabStop = false;
            this.groupBoxMain.Text = "WatchDog";
            // 
            // watchStopButton
            // 
            this.watchStopButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.watchStopButton.Location = new System.Drawing.Point(323, 59);
            this.watchStopButton.Name = "watchStopButton";
            this.watchStopButton.Size = new System.Drawing.Size(60, 23);
            this.watchStopButton.TabIndex = 5;
            this.watchStopButton.Text = "Watch!";
            this.watchStopButton.UseVisualStyleBackColor = true;
            this.watchStopButton.Click += new System.EventHandler(this.watchStopButton_Click);
            // 
            // srcDirOpenButton
            // 
            this.srcDirOpenButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.srcDirOpenButton.Location = new System.Drawing.Point(355, 22);
            this.srcDirOpenButton.Name = "srcDirOpenButton";
            this.srcDirOpenButton.Size = new System.Drawing.Size(28, 20);
            this.srcDirOpenButton.TabIndex = 4;
            this.srcDirOpenButton.Text = ",,,";
            this.srcDirOpenButton.UseVisualStyleBackColor = true;
            this.srcDirOpenButton.Click += new System.EventHandler(this.srcDirOpenButton_Click);
            // 
            // splitProgressBar
            // 
            this.splitProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitProgressBar.Location = new System.Drawing.Point(7, 59);
            this.splitProgressBar.Name = "splitProgressBar";
            this.splitProgressBar.Size = new System.Drawing.Size(310, 23);
            this.splitProgressBar.TabIndex = 3;
            // 
            // srcDirPathTextBox
            // 
            this.srcDirPathTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.srcDirPathTextBox.Location = new System.Drawing.Point(7, 22);
            this.srcDirPathTextBox.Name = "srcDirPathTextBox";
            this.srcDirPathTextBox.Size = new System.Drawing.Size(342, 20);
            this.srcDirPathTextBox.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.destDirOpenButton);
            this.groupBox1.Controls.Add(this.destDirPathTextBox);
            this.groupBox1.Location = new System.Drawing.Point(14, 115);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(389, 50);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Miejsce zrzutu";
            // 
            // destDirOpenButton
            // 
            this.destDirOpenButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.destDirOpenButton.Location = new System.Drawing.Point(354, 19);
            this.destDirOpenButton.Name = "destDirOpenButton";
            this.destDirOpenButton.Size = new System.Drawing.Size(28, 20);
            this.destDirOpenButton.TabIndex = 5;
            this.destDirOpenButton.Text = ",,,";
            this.destDirOpenButton.UseVisualStyleBackColor = true;
            this.destDirOpenButton.Click += new System.EventHandler(this.destDirOpenButton_Click);
            // 
            // destDirPathTextBox
            // 
            this.destDirPathTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.destDirPathTextBox.Location = new System.Drawing.Point(6, 19);
            this.destDirPathTextBox.Name = "destDirPathTextBox";
            this.destDirPathTextBox.Size = new System.Drawing.Size(342, 20);
            this.destDirPathTextBox.TabIndex = 4;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.maxSensitivityTextBox);
            this.groupBox2.Controls.Add(this.minSensitivityTextBox);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.vScrollBar1);
            this.groupBox2.Location = new System.Drawing.Point(14, 171);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(201, 48);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Czułość [% * 100]";
            // 
            // maxSensitivityTextBox
            // 
            this.maxSensitivityTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::PDFManager.Properties.Settings.Default, "MaxSensitivity", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.maxSensitivityTextBox.Location = new System.Drawing.Point(134, 22);
            this.maxSensitivityTextBox.Name = "maxSensitivityTextBox";
            this.maxSensitivityTextBox.Size = new System.Drawing.Size(40, 20);
            this.maxSensitivityTextBox.TabIndex = 4;
            this.maxSensitivityTextBox.Text = "80";
            this.maxSensitivityTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.maxSensitivityTextBox_Validating);
            // 
            // minSensitivityTextBox
            // 
            this.minSensitivityTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::PDFManager.Properties.Settings.Default, "MinSensitivity", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.minSensitivityTextBox.Location = new System.Drawing.Point(46, 22);
            this.minSensitivityTextBox.Name = "minSensitivityTextBox";
            this.minSensitivityTextBox.Size = new System.Drawing.Size(40, 20);
            this.minSensitivityTextBox.TabIndex = 3;
            this.minSensitivityTextBox.Text = "10";
            this.minSensitivityTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.minSensitivityTextBox_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(92, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Max:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(8, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Min:";
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Location = new System.Drawing.Point(350, 118);
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(8, 8);
            this.vScrollBar1.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.reportCheckBox);
            this.groupBox3.Location = new System.Drawing.Point(218, 171);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(185, 48);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Wydruk zapełniania kartek";
            // 
            // reportCheckBox
            // 
            this.reportCheckBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.reportCheckBox.AutoSize = true;
            this.reportCheckBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportCheckBox.Location = new System.Drawing.Point(3, 16);
            this.reportCheckBox.Name = "reportCheckBox";
            this.reportCheckBox.Size = new System.Drawing.Size(179, 29);
            this.reportCheckBox.TabIndex = 0;
            this.reportCheckBox.Text = "Raportuj";
            this.reportCheckBox.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.ClientSize = new System.Drawing.Size(414, 231);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBoxMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(430, 270);
            this.MinimumSize = new System.Drawing.Size(430, 270);
            this.Name = "Form1";
            this.Text = "PDFManager";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.groupBoxMain.ResumeLayout(false);
            this.groupBoxMain.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxMain;
        private System.Windows.Forms.TextBox srcDirPathTextBox;
        private System.Windows.Forms.ProgressBar splitProgressBar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox destDirPathTextBox;
        private System.Windows.Forms.Button srcDirOpenButton;
        private System.Windows.Forms.Button destDirOpenButton;
        private System.Windows.Forms.Button watchStopButton;
        private System.Windows.Forms.TextBox maxSensitivityTextBox;
        private System.Windows.Forms.TextBox minSensitivityTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.VScrollBar vScrollBar1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox reportCheckBox;
    }
}

