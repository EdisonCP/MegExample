using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;

namespace MegExample.API.MessageFilters
{
    [AttributeUsage(AttributeTargets.All)]
    public class ExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            var response = GetResponseFromException(actionExecutedContext.Exception);

            if (response != null) actionExecutedContext.Response = response;
        }

        public static HttpResponseMessage GetResponseFromException(Exception ex)
        {
            HttpResponseMessage response = null;

            if (ex is ApplicationException)
            {
                response = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent(ex.Message)
                };
            }

            return response;

        }

    }
}