using System.Threading.Tasks;
using System.Web.Configuration;
using System.Web.Mvc;
using Cinema.Model;
using ServiceUsage;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private static WebApiServiceUsage _service = new WebApiServiceUsage(WebConfigurationManager.AppSettings["WebApiService"]);

        public async Task<ActionResult> Index()
        {
            var actors = await _service.GetActors();
            return View(actors);
            
        }

        
        public async Task<ActionResult> GetActor(int id)
        {
            var actor = await _service.GetActor(id);
            return View(actor);

        }

        [HttpGet]
        public async Task<ActionResult> AddActor()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> AddActor(Actor actor)
        {
            await _service.EditActor(actor);
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> RemoveActor(int id)
        {
            await _service.RemoveActor(id);
            
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<ActionResult> EditActor(int id)
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> EditActor(Actor actor)
        {
            await _service.EditActor(actor);
            
            return RedirectToAction("Index");
        }
    }
}
