using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace TestBarcode
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCreatePdf_Click(object sender, EventArgs e)
        {
            string pdfFilePath = "C:\\Users\\chiraq.rasulov\\Desktop\\Default2.pdf";

            PDF.CreatePdf(pdfFilePath);

            Process.Start(pdfFilePath);
        }

        
    }
}
