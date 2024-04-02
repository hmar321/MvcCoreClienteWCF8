using Microsoft.AspNetCore.Mvc;
using MvcCoreClienteWCF8.Services;

namespace MvcCoreClienteWCF8.Controllers
{
    public class ConversorController : Controller
    {
        private ServiceConversor service;

        public ConversorController(ServiceConversor service)
        {
            this.service = service;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(string numeros)
        {
            string data = await this.service.ConverNumberToWordsAsync(numeros);
            ViewData["DATOS"] = data;
            return View();
        }
    }
}
