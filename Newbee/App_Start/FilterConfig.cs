using System.Web;
using System.Web.Mvc;

namespace Newbee
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new ExceptionFilterAttribute());

        }
    }
}
