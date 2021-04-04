using System.Web.Mvc;

namespace Norbit.CRM.Tyganov.FinalTask.WebApi.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            return View();
        }
    }
}