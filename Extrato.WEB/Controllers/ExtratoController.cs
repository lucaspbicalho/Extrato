using Microsoft.AspNetCore.Mvc;
using Extrato.Services.Services;
using Extrato.Domain.ViewModel;
using Extrato.Domain.Entites;

namespace Extrato.Web.Controllers
{
    public class ExtratoController : Controller
    {
        private readonly RequestsHandlerService _requestsHandlerService;
        public ExtratoController(RequestsHandlerService requestsHandlerService)
        {
            this._requestsHandlerService = requestsHandlerService;
        }
        // GET: ExtratoController
        public ActionResult Index()
        {
            return View();
        }
        // GET: ExtratoController/Extratos
        public async Task<ActionResult> Extratos()
        {
            var queryString = Request.QueryString.Value;
            List<BankRecordFormatedViewModel> lista = await _requestsHandlerService.GetBankRecords(queryString);
            return View(lista);
        }
        // GET: ExtratoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ExtratoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ExtratoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(BankRecordViewModel record)
        {
            try
            {
                await _requestsHandlerService.CreateBankRecords(record);
                return RedirectToAction("Extratos", "Extrato");
            }
            catch
            {
                return View();
            }
        }

        // GET: ExtratoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ExtratoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ExtratoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ExtratoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
