using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Microsoft.Extensions.Logging;


namespace TEST.Middlewares
{
    public class ResonseMiddleware
    {

        private readonly RequestDelegate _next;
        private readonly ILogger _loggerFactory;

        public ResonseMiddleware(RequestDelegate next,ILoggerFactory loggerFactory) {
            _next = next;
            _loggerFactory = loggerFactory.CreateLogger(typeof(ResonseMiddleware));


        }

        public async Task Invoke(HttpContext context) {
          

            var response =  context.Response.Body.ToString();
           
            context.Response.Redirect("api/Response/ResponseGet/hhh");

            await _next(context);

        }


        
       

    }
}
