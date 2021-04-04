using Norbit.CRM.Tyganov.FinalTask.DbLibrary;
using System.Text;
using Newtonsoft.Json;
using System.Web.Mvc;
using System.Net;
using System.IO;

namespace Norbit.CRM.Tyganov.FinalTask.WebApplication.Controllers
{
    /// <summary>
    /// Переделанный HomeController. Реализаует контроллеры для вызова веб-сервиса из С#
    /// и JS(не реализовано) кода.
    /// </summary>
    [Authorize]
    public class HomeController : Controller
    {
        const string DefaultUri = "https://localhost:44364/api/values/lastTrade";

        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Реализация получения последней сделки через запрос к веб-сервису.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        //[Authorize]
        //[Route("api/UserAuthenticate")]
        public ActionResult CSharp()
        {
            var request = (HttpWebRequest)WebRequest.Create(DefaultUri);
            request.Method = "GET";
            var userName = User.Identity.Name;
            if (userName != null)
            {
                using (var response = (HttpWebResponse)request.GetResponse())
                {
                    var respStream = response.GetResponseStream();
                    using (var reader = new StreamReader(respStream, Encoding.UTF8))
                    {
                        var answer = reader.ReadToEnd();
                        var trade = JsonConvert.DeserializeObject<Trade>(answer);
                        ViewBag.Amount = trade.Amount;
                        ViewBag.Created = trade.Created;
                    }
                }
            }
            return View();
        }

        public ActionResult Js()
        {
            return View();
        }
    }
}