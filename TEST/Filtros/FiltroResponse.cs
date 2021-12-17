using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
//using System.Web.Http.Filters;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
namespace TEST.Filtros
{
    public class FiltroResponse:ActionFilterAttribute
    {


        private readonly ILogger<FiltroResponse> _logger;


        public FiltroResponse(ILogger<FiltroResponse> logger) {
            _logger = logger; 
        
        }


        public override void OnActionExecuted(ActionExecutedContext actionExecutedContext)
        {

            var response = (OkObjectResult)actionExecutedContext.Result;
            var routeValues = new RouteValueDictionary(new
            {
                action = "ResponseGet",
                controller = "Response",
                h = response.Value


            });

            actionExecutedContext.Result = new RedirectToRouteResult(routeValues);
            base.OnActionExecuted(actionExecutedContext);
        }


    }
}
