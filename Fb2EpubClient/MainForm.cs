using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fb2EpubClient
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            checkBoxToTheSameDir_CheckedChanged(checkBoxToTheSameDir, new EventArgs());
        }

        private void buttonInputBrowse_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialogInput.ShowDialog();
            
            if (result == DialogResult.OK)
            {
                foreach (string file in openFileDialogInput.FileNames)
                {
                    ListViewItem alreadyAddedItem = listViewFiles.FindItemWithText(file);
                    if (alreadyAddedItem == null)
                    {
                        listViewFiles.Items.Add(file);
                    }
                }
            }
        }

        private void buttonDeleteFromList_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listViewFiles.SelectedItems)
            {
                listViewFiles.Items.Remove(item);
            }
        }

        private void checkBoxToTheSameDir_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as CheckBox).Checked)
            {
                panelOutput.Enabled = false;
            }
            else
            {
                panelOutput.Enabled = true;
            }
        }

        private void buttonBrowsePath_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialogOutput.ShowDialog();
            if (result == DialogResult.OK)
            {
                textBoxOutputPath.Text = folderBrowserDialogOutput.SelectedPath;
            }
        }

        private void buttonConvert_Click(object sender, EventArgs e)
        {

            if (!checkBoxToTheSameDir.Checked && !Directory.Exists(textBoxOutputPath.Text))
            {
                MessageBox.Show(
                    "This directory does not exist!",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Asterisk);

                return;
            }

            List<string> files = new List<string>();
            foreach (ListViewItem item in listViewFiles.Items)
            {
                files.Add(item.Text);
            }

            buttonConvert.Enabled = false;
            panelOutput.Enabled = false;
            panelAddFiles.Enabled = false;
            labelResult.Text = "0%";
            backgroundWorkerUploadFile.RunWorkerAsync(files);
        }

        private void backgroundWorkerUploadFile_DoWork(object sender, DoWorkEventArgs e)
        {
            List<string> files = e.Argument as List<string>;
            BackgroundWorker worker = sender as BackgroundWorker;
            int i = 1;

            if (checkBoxToTheSameDir.Checked)
            {
                foreach (string file in files)
                {
                    try
                    {
                        HttpHelper.ConvertBookFb2Epub(file);
                    }
                    catch (Exception exc)
                    {
                        StreamWriter errorReportFile = new StreamWriter("C:\\temp\\fb2epub_error_reports.txt", true);
                        errorReportFile.WriteLine(DateTime.Now.ToString());
                        errorReportFile.WriteLine("Error with file: " + file);
                        errorReportFile.WriteLine("Details:");
                        errorReportFile.WriteLine(exc.ToString());
                        errorReportFile.WriteLine("\n\n");
                    }
                    worker.ReportProgress(i * 100 / files.Count);
                    i++;
                }
            }
            else
            {
                foreach (string file in files)
                {
                    try
                    {
                        HttpHelper.ConvertBookFb2Epub(file, textBoxOutputPath.Text);
                    }
                    catch (Exception exc)
                    {
                        StreamWriter errorReportFile = new StreamWriter("C:\\temp\\fb2epub_error_reports.txt", true);
                        errorReportFile.WriteLine(DateTime.Now.ToString());
                        errorReportFile.WriteLine("Error with file: " + file);
                        errorReportFile.WriteLine("Details:");
                        errorReportFile.WriteLine(exc.ToString());
                        errorReportFile.WriteLine("\n-------------------------------\n\n");
                    }
                    worker.ReportProgress(i * 100 / files.Count);
                    i++;
                }
            }
        }

        private void backgroundWorkerUploadFile_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            labelResult.Text = e.ProgressPercentage.ToString() + "%";
            progressBar.Value = e.ProgressPercentage;
        }

        private void backgroundWorkerUploadFile_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            buttonConvert.Enabled = true;
            panelAddFiles.Enabled = true;
            if (!checkBoxToTheSameDir.Checked)
            {
                panelOutput.Enabled = true;
            }

            if (e.Cancelled)
            {
                labelResult.Text = "Cancelled";
            }
            else if (e.Error != null)
            {
                labelResult.Text = "Error: " + e.Error.Message;
                return;
            }
            else
            {
                labelResult.Text = "Done!";
            }

            if (!checkBoxToTheSameDir.Checked)
            {
                System.Diagnostics.Process.Start(textBoxOutputPath.Text);
            }
        }
    }
}
