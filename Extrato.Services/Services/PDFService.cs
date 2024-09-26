using Extrato.Domain.Entites;
using iText.Html2pdf;
using iText.IO.Source;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using System.Text;

namespace Extrato.Services.Services
{
    public class PDFService
    {
        public byte[] BuildPdf(List<BankRecord> bankRecords)
        {
            //Building an HTML string.
            StringBuilder sb = new StringBuilder();

            //Table start.
            sb.Append("<table border='1' cellpadding='5' cellspacing='0' style='border: 1px solid #ccc;font-family: Arial;'>");

            //Building the Header row.
            sb.Append("<tr>");
            sb.Append("<th style='background-color: #B8DBFD;border: 1px solid #ccc'>Data</th>");
            sb.Append("<th style='background-color: #B8DBFD;border: 1px solid #ccc'>Tipo</th>");
            sb.Append("<th style='background-color: #B8DBFD;border: 1px solid #ccc'>Valor</th>");
            sb.Append("</tr>");

            //Building the Data rows.
            for (int i = 0; i < bankRecords.Count; i++)
            {
                sb.Append("<tr>");
                sb.Append("<td style='border: 1px solid #ccc'>");
                sb.Append(bankRecords[i].Data.ToString("dd/MM"));
                sb.Append("</td>");
                sb.Append("<td style='border: 1px solid #ccc'>");
                sb.Append(bankRecords[i].Tipo.ToString());
                sb.Append("</td>");
                sb.Append("<td style='border: 1px solid #ccc'>");
                sb.Append(bankRecords[i].Valor);
                sb.Append("</td>");
                sb.Append("</tr>");

                sb.Append("</tr>");
            }

            //Table end.
            sb.Append("</table>");
            using (MemoryStream stream = new MemoryStream(Encoding.ASCII.GetBytes(sb.ToString())))
            {
                ByteArrayOutputStream byteArrayOutputStream = new ByteArrayOutputStream();
                PdfWriter writer = new PdfWriter(byteArrayOutputStream);
                iText.Kernel.Pdf.PdfDocument pdfDocument = new iText.Kernel.Pdf.PdfDocument(writer);
                pdfDocument.SetDefaultPageSize(PageSize.A4);
                HtmlConverter.ConvertToPdf(stream, pdfDocument);
                pdfDocument.Close();
                return byteArrayOutputStream.ToArray();
            }
        }  
    }
}
