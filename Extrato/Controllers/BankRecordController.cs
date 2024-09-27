using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

using Extrato.Services.Services;
using Extrato.Domain.ViewModel;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Extrato.Api.Controllers
{
    [Route("api/extrato")]
    [ApiController]
    public class BankRecordController : ControllerBase
    {
        private readonly BankRecordService _bankRecordService;
        private readonly PDFService _pdfService;
        public BankRecordController(BankRecordService bankRecordService, PDFService pdfService)
        {
            this._bankRecordService = bankRecordService;
            this._pdfService = pdfService;
        }
        [HttpGet]
        public IActionResult Get([BindRequired] FiltroDiasExtrato date)
        {
            var bankRecords = _bankRecordService.Listar(date);
            return Ok(bankRecords);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var bankRecord = _bankRecordService.GetById(id);

            if (bankRecord == null)
            {
                return NotFound();
            }
            return Ok(bankRecord);
        }
        [HttpPost]
        public IActionResult Post([FromBody] BankRecordViewModel recordVM)
        {
            _bankRecordService.Save(recordVM);

            return Created();
        }

        [HttpGet]
        [Route("getPdf")]
        public IActionResult GetPdf()
        {
            return File(_pdfService.BuildPdf(_bankRecordService.Listar()), "application/pdf", "Grid.pdf");
        }
    }
}
