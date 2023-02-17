using MercadoPago.Client.Preference;
using MercadoPago.Config;
using MercadoPago.Resource.Preference;
using Microsoft.AspNetCore.Mvc;
using PruebaMP.Models;
using System.Diagnostics;

namespace PruebaMP.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<JsonResult> CreateOrder() 
        {
            MercadoPagoConfig.AccessToken = "TEST-2781679229953676-021710-929b51994d8ef51c573b53e6293b4d5c-1045528840";
            var request = new PreferenceRequest
            {
                Items = new List<PreferenceItemRequest>
                    {
                        new PreferenceItemRequest
                        {
                            Title = "Mi producto",
                            Quantity = 1,
                            CurrencyId = "ARS",
                            UnitPrice = 75.56m,
                        },
                    },
            };

            // Crea la preferencia usando el client
            var client = new PreferenceClient();
            Preference preference = await client.CreateAsync(request);
            return Json(preference);
        }
    }
}