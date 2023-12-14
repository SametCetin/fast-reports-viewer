using FastReport.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;



namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            this.Text = Application.ProductName + " | " + Application.ProductVersion;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Title = "Select file";
            fileDialog.Filter = "frx files(*.frx)|*.frx";
            fileDialog.FilterIndex = 2;
            fileDialog.RestoreDirectory = true;

            if (fileDialog.ShowDialog() == DialogResult.OK)
                txtFileName.Text = fileDialog.FileName;
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFrxFile(txtFileName.Text);
        }

        private void OpenFrxFile(string frxPath)
        {
            if (string.IsNullOrEmpty(frxPath)) return;

            try
            {
                barcodeView = new FastReport.Report();
                barcodeView.PrintSettings.ShowDialog = false;
                //barcodeView.PrintSettings.Printer = "Pr0";
                barcodeView.Load(frxPath);
                //barcodeView.RegisterData();
                barcodeView.Design();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK);

            }
        }
        
    }
}
