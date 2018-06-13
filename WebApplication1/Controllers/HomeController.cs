using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ServiceUsage;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private static WebApiServiceUsage _service = new WebApiServiceUsage(WebConfigurationManager.AppSettings["WebApiService"]);

        public async void Index()
        {
           var d=await  _service.getCinemaInfo();
        }

        //public async Task<ActionResult> Index()
        //{
            //var response = await _service.GetAsync("api/cinema");
            //var wr = response.Content;
            //var r = response.Content.ReadAsStringAsync().Result;
            ////Read response content result into string variable
            //string strJson = response.Content.ReadAsStringAsync().Result;
            ////Deserialize the string to JSON object
            //return View(await response.Content.ReadAsStringAsync());
       // }
    }
}
