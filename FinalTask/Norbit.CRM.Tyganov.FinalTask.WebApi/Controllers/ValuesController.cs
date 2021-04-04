using System.Web.Http;
using System.Web.Http.Cors;
using Norbit.CRM.Tyganov.FinalTask.DbLibrary;
namespace Norbit.CRM.Tyganov.FinalTask.WebApi.Controllers
{
    /// <summary>
    /// Контроллер, создающий Get запрос. Используется для получения последней сделки пользователя.
    /// Авторизация отсутствует - работа лишь с фиксированным пользователем, т.е. мной.
    /// </summary>
    [EnableCors(origins: "https://localhost:44309/", headers: "*", methods: "*")]

    [Route("api/values/lastTrade")]

    public class ValuesController : ApiController
    {
        // GET api/values/lastTrade
        [HttpGet]
        [Authorize]
        public Trade Get()
        {
            var trade = new Linq2DbProvider();
            var name = User.Identity.Name;
            return trade.GetLastTrade("Ilya.Tyganov");
        }
    }
}
