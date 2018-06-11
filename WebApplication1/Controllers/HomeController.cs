using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using ServiceUsage;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private static WebApiServiceUsage _service = new WebApiServiceUsage(WebConfigurationManager.AppSettings["WebApiService"]);

        public async Task<ActionResult> Index()
        {
            var response = await _service.GetAsync("api/cinema");
            var r = response.Content.ReadAsStringAsync().Result;
            return View(await response.Content.ReadAsStringAsync());
        }
    }
}
