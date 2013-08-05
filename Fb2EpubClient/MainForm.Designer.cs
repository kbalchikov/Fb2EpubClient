namespace Fb2EpubClient
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonAddFiles = new System.Windows.Forms.Button();
            this.openFileDialogInput = new System.Windows.Forms.OpenFileDialog();
            this.buttonConvert = new System.Windows.Forms.Button();
            this.backgroundWorkerUploadFile = new System.ComponentModel.BackgroundWorker();
            this.labelResult = new System.Windows.Forms.Label();
            this.listViewFiles = new System.Windows.Forms.ListView();
            this.buttonDeleteFromList = new System.Windows.Forms.Button();
            this.textBoxOutputPath = new System.Windows.Forms.TextBox();
            this.checkBoxToTheSameDir = new System.Windows.Forms.CheckBox();
            this.labelOutputDir = new System.Windows.Forms.Label();
            this.folderBrowserDialogOutput = new System.Windows.Forms.FolderBrowserDialog();
            this.buttonBrowsePath = new System.Windows.Forms.Button();
            this.labelAddBooks = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.panelAddFiles = new System.Windows.Forms.Panel();
            this.panelOutput = new System.Windows.Forms.Panel();
            this.panelAddFiles.SuspendLayout();
            this.panelOutput.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonAddFiles
            // 
            this.buttonAddFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAddFiles.Location = new System.Drawing.Point(368, 23);
            this.buttonAddFiles.Margin = new System.Windows.Forms.Padding(4);
            this.buttonAddFiles.Name = "buttonAddFiles";
            this.buttonAddFiles.Size = new System.Drawing.Size(98, 26);
            this.buttonAddFiles.TabIndex = 0;
            this.buttonAddFiles.Text = "Add files";
            this.buttonAddFiles.UseVisualStyleBackColor = true;
            this.buttonAddFiles.Click += new System.EventHandler(this.buttonInputBrowse_Click);
            // 
            // openFileDialogInput
            // 
            this.openFileDialogInput.Filter = "fb2 files (*.fb2)|*.fb2|All files (*.*)|(*.*)";
            this.openFileDialogInput.Multiselect = true;
            // 
            // buttonConvert
            // 
            this.buttonConvert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonConvert.Location = new System.Drawing.Point(373, 318);
            this.buttonConvert.Margin = new System.Windows.Forms.Padding(4);
            this.buttonConvert.Name = "buttonConvert";
            this.buttonConvert.Size = new System.Drawing.Size(98, 26);
            this.buttonConvert.TabIndex = 1;
            this.buttonConvert.Text = "Convert";
            this.buttonConvert.UseVisualStyleBackColor = true;
            this.buttonConvert.Click += new System.EventHandler(this.buttonConvert_Click);
            // 
            // backgroundWorkerUploadFile
            // 
            this.backgroundWorkerUploadFile.WorkerReportsProgress = true;
            this.backgroundWorkerUploadFile.WorkerSupportsCancellation = true;
            this.backgroundWorkerUploadFile.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerUploadFile_DoWork);
            this.backgroundWorkerUploadFile.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorkerUploadFile_ProgressChanged);
            this.backgroundWorkerUploadFile.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerUploadFile_RunWorkerCompleted);
            // 
            // labelResult
            // 
            this.labelResult.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelResult.AutoSize = true;
            this.labelResult.Location = new System.Drawing.Point(13, 324);
            this.labelResult.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelResult.Name = "labelResult";
            this.labelResult.Size = new System.Drawing.Size(55, 15);
            this.labelResult.TabIndex = 2;
            this.labelResult.Text = "Progress:";
            // 
            // listViewFiles
            // 
            this.listViewFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewFiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listViewFiles.Location = new System.Drawing.Point(10, 23);
            this.listViewFiles.Margin = new System.Windows.Forms.Padding(4);
            this.listViewFiles.Name = "listViewFiles";
            this.listViewFiles.Size = new System.Drawing.Size(353, 185);
            this.listViewFiles.TabIndex = 3;
            this.listViewFiles.UseCompatibleStateImageBehavior = false;
            this.listViewFiles.View = System.Windows.Forms.View.List;
            // 
            // buttonDeleteFromList
            // 
            this.buttonDeleteFromList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDeleteFromList.Location = new System.Drawing.Point(368, 57);
            this.buttonDeleteFromList.Margin = new System.Windows.Forms.Padding(4);
            this.buttonDeleteFromList.Name = "buttonDeleteFromList";
            this.buttonDeleteFromList.Size = new System.Drawing.Size(98, 26);
            this.buttonDeleteFromList.TabIndex = 4;
            this.buttonDeleteFromList.Text = "Delete files";
            this.buttonDeleteFromList.UseVisualStyleBackColor = true;
            this.buttonDeleteFromList.Click += new System.EventHandler(this.buttonDeleteFromList_Click);
            // 
            // textBoxOutputPath
            // 
            this.textBoxOutputPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxOutputPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxOutputPath.Font = new System.Drawing.Font("Segoe UI Symbol", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxOutputPath.Location = new System.Drawing.Point(10, 24);
            this.textBoxOutputPath.Name = "textBoxOutputPath";
            this.textBoxOutputPath.Size = new System.Drawing.Size(353, 22);
            this.textBoxOutputPath.TabIndex = 5;
            // 
            // checkBoxToTheSameDir
            // 
            this.checkBoxToTheSameDir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBoxToTheSameDir.AutoSize = true;
            this.checkBoxToTheSameDir.Location = new System.Drawing.Point(15, 226);
            this.checkBoxToTheSameDir.Name = "checkBoxToTheSameDir";
            this.checkBoxToTheSameDir.Size = new System.Drawing.Size(176, 19);
            this.checkBoxToTheSameDir.TabIndex = 6;
            this.checkBoxToTheSameDir.Text = "Save files to source directory";
            this.checkBoxToTheSameDir.UseVisualStyleBackColor = true;
            this.checkBoxToTheSameDir.CheckedChanged += new System.EventHandler(this.checkBoxToTheSameDir_CheckedChanged);
            // 
            // labelOutputDir
            // 
            this.labelOutputDir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelOutputDir.AutoSize = true;
            this.labelOutputDir.Location = new System.Drawing.Point(8, 6);
            this.labelOutputDir.Name = "labelOutputDir";
            this.labelOutputDir.Size = new System.Drawing.Size(139, 15);
            this.labelOutputDir.TabIndex = 7;
            this.labelOutputDir.Text = "Choose output directory:";
            // 
            // buttonBrowsePath
            // 
            this.buttonBrowsePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBrowsePath.Location = new System.Drawing.Point(368, 24);
            this.buttonBrowsePath.Margin = new System.Windows.Forms.Padding(4);
            this.buttonBrowsePath.Name = "buttonBrowsePath";
            this.buttonBrowsePath.Size = new System.Drawing.Size(98, 23);
            this.buttonBrowsePath.TabIndex = 8;
            this.buttonBrowsePath.Text = "Browse...";
            this.buttonBrowsePath.UseVisualStyleBackColor = true;
            this.buttonBrowsePath.Click += new System.EventHandler(this.buttonBrowsePath_Click);
            // 
            // labelAddBooks
            // 
            this.labelAddBooks.AutoSize = true;
            this.labelAddBooks.Location = new System.Drawing.Point(8, 4);
            this.labelAddBooks.Name = "labelAddBooks";
            this.labelAddBooks.Size = new System.Drawing.Size(178, 15);
            this.labelAddBooks.TabIndex = 9;
            this.labelAddBooks.Text = "Add books you\'d like to convert:";
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.ForeColor = System.Drawing.Color.LimeGreen;
            this.progressBar.Location = new System.Drawing.Point(68, 318);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(300, 26);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.TabIndex = 10;
            // 
            // panelAddFiles
            // 
            this.panelAddFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelAddFiles.Controls.Add(this.buttonDeleteFromList);
            this.panelAddFiles.Controls.Add(this.labelAddBooks);
            this.panelAddFiles.Controls.Add(this.buttonAddFiles);
            this.panelAddFiles.Controls.Add(this.listViewFiles);
            this.panelAddFiles.Location = new System.Drawing.Point(5, 4);
            this.panelAddFiles.Name = "panelAddFiles";
            this.panelAddFiles.Size = new System.Drawing.Size(472, 216);
            this.panelAddFiles.TabIndex = 11;
            // 
            // panelOutput
            // 
            this.panelOutput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelOutput.Controls.Add(this.labelOutputDir);
            this.panelOutput.Controls.Add(this.buttonBrowsePath);
            this.panelOutput.Controls.Add(this.textBoxOutputPath);
            this.panelOutput.Location = new System.Drawing.Point(5, 251);
            this.panelOutput.Name = "panelOutput";
            this.panelOutput.Size = new System.Drawing.Size(472, 57);
            this.panelOutput.TabIndex = 12;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 361);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.checkBoxToTheSameDir);
            this.Controls.Add(this.labelResult);
            this.Controls.Add(this.buttonConvert);
            this.Controls.Add(this.panelAddFiles);
            this.Controls.Add(this.panelOutput);
            this.Font = new System.Drawing.Font("Segoe UI Symbol", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(500, 400);
            this.Name = "MainForm";
            this.Text = "Fb2Epub";
            this.panelAddFiles.ResumeLayout(false);
            this.panelAddFiles.PerformLayout();
            this.panelOutput.ResumeLayout(false);
            this.panelOutput.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonAddFiles;
        private System.Windows.Forms.OpenFileDialog openFileDialogInput;
        private System.Windows.Forms.Button buttonConvert;
        private System.ComponentModel.BackgroundWorker backgroundWorkerUploadFile;
        private System.Windows.Forms.Label labelResult;
        private System.Windows.Forms.ListView listViewFiles;
        private System.Windows.Forms.Button buttonDeleteFromList;
        private System.Windows.Forms.TextBox textBoxOutputPath;
        private System.Windows.Forms.CheckBox checkBoxToTheSameDir;
        private System.Windows.Forms.Label labelOutputDir;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogOutput;
        private System.Windows.Forms.Button buttonBrowsePath;
        private System.Windows.Forms.Label labelAddBooks;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Panel panelAddFiles;
        private System.Windows.Forms.Panel panelOutput;
    }
}

