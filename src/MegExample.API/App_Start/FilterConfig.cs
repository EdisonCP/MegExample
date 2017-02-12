using System.Web;
using System.Web.Http.Filters;
using System.Web.Mvc;
using MegExample.API.MessageFilters;

namespace MegExample.API
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Clear();
        }
        
        public static void RegisterHttpFilters(HttpFilterCollection filters)
        {
            //Used by WebAPI
            filters.Add(new ExceptionFilter());
        }
    }
}
