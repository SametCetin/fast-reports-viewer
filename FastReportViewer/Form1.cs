using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Title = "Select file";
            //fileDialog.InitialDirectory = @"C:\";
            //fileDialog.Filter = "All files (*.*)|*.*|All files (*.*)|*.*";
            fileDialog.Filter = "frx files(*.frx)|*.frx";

            //Example: "Text files (*.txt)|*.txt|All files (*.*)|*.*";

            fileDialog.FilterIndex = 2;
            fileDialog.RestoreDirectory = true;

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                if (string.IsNullOrEmpty(fileDialog.FileName))
                    ;
                else
                    txtFileName.Text = fileDialog.FileName;
            }
            
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            try
            {
                barcodeView = new FastReport.Report();
                barcodeView.PrintSettings.ShowDialog = false;
                barcodeView.PrintSettings.Printer = "Pr0";
                barcodeView.Load(txtFileName.Text);
                barcodeView.Design();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK);

            }
        }

        private void txtFileName_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Haffner Barcode Designer, V18.01";
        }
    }
}
