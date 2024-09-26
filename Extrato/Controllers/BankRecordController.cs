using Extrato.Api.ViewModel;
using Extrato.Domain.Entites;
using Extrato.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Data;
using System.Text;
using iText.IO.Source;
using iText.Kernel.Pdf;
using iText.Html2pdf;
using iText.Kernel.Geom;

namespace Extrato.Api.Controllers
{
    [Route("api/extrato")]
    [ApiController]
    public class BankRecordController : ControllerBase
    {
        private readonly ExtratoDbContext _context;
        public BankRecordController(ExtratoDbContext context)
        {
            this._context = context;
        }
        [HttpGet]
        public IActionResult GetAll([BindRequired] FiltroDiasExtrato date)
        {
            DateTime dateNow = DateTime.Now;
            var bankRecords = _context.BankRecords
                .Where(w => (dateNow - w.Data).TotalDays < (int)date)
                .Select(s => new { s.Id, data = s.Data.ToString("dd/MM"), s.Valor })
                .ToList();
            return Ok(bankRecords);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id, [BindRequired] FiltroDiasExtrato date)
        {
            DateTime dateNow = DateTime.Now;
            var bankRecords = _context.BankRecords
                .Where(w => (dateNow - w.Data).TotalDays < (int)date)
                .Select(s => new { s.Id, s.Data, s.Valor })
                .SingleOrDefault(p => p.Id == id);
            if (bankRecords == null)
            {
                return NotFound();
            }
            return Ok(bankRecords);
        }
        [HttpPost]
        public IActionResult Post([FromBody] BankRecordViewModel recordVM)
        {
            _context.BankRecords.Add(recordVM);
            _context.SaveChanges();
            return Created();
        }

        [HttpGet]
        [Route("GetPdf")]
        public IActionResult GetPdf()
        {
            var bankRecords = _context.BankRecords
                .ToList();

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
                return File(byteArrayOutputStream.ToArray(), "application/pdf", "Grid.pdf");
            }
        }
       
    }
}
