using iText.Barcodes;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Borders;
using iText.Layout.Element;
using iText.Layout.Properties;
using System.IO;

namespace TestBarcode
{
    public static class PDF
    {
        public static void CreatePdf(string path)
        {
            PdfDocument pdfDoc = new PdfDocument(new PdfWriter(new FileStream(path, FileMode.Create)));
            Document doc = new Document(pdfDoc, PageSize.A4);

            //Create Barcode EAN13
            string code = "1234567890128";
            BarcodeEAN EAN13 = new BarcodeEAN(pdfDoc);
            EAN13.SetFont(null);
            EAN13.SetCode(code);
            EAN13.SetCodeType(BarcodeEAN.EAN13);

            Image image13 = new Image(EAN13.CreateFormXObject(pdfDoc));
            image13.SetHorizontalAlignment(HorizontalAlignment.CENTER);

            Paragraph name = new Paragraph("Product Name").SetTextAlignment(TextAlignment.CENTER);
            name.SetFontSize(10);
            Paragraph ProductCode = new Paragraph("1234567890128").SetTextAlignment(TextAlignment.CENTER);
            ProductCode.SetFontSize(10);

            //Create table
            float[] columnWidths = { 5, 5 };
            Table table = new Table(columnWidths);
            table.SetWidth(UnitValue.CreatePercentValue(100));

            for (int i = 0; i < 100; i++)
            {
                table.AddCell(new Cell().SetBorder(Border.NO_BORDER).SetTextAlignment(TextAlignment.CENTER).Add(name).Add(image13).Add(ProductCode));
            }

            doc.Add(table);
            doc.Close();
        }
    }
}
