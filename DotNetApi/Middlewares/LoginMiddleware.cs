
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace CorePOC.Middlewares
{
    public class LoginMiddleware
    {
        private readonly RequestDelegate _next;

        public LoginMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext context)
        {
            //var cultureQuery = context.Request.Query["userId"];
            
            // Call the next delegate/middleware in the pipeline
            return this._next(context);
        }
    }
}