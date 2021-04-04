using System.Web;
using System.Web.Mvc;

namespace Norbit.CRM.Tyganov.Practic13.WebApiVesrion2
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
