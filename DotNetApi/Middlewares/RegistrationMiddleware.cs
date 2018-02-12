using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using CorePOC.DataLayer.Services;
using System.IO;
using Newtonsoft.Json;

namespace CorePOC.Middlewares
{
    public class RegistrationMiddleware : IMiddleware
    {
        private readonly IService _service;

        public RegistrationMiddleware(IService service)
        {
            _service = service;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var verb = context.Request.Method;
            var path = context.Request.Path;
            if (verb == "POST" && path == "/registration")
            {
                var request = context.Request;
                var stream = new StreamReader(request.Body);
                var body = stream.ReadToEnd();
                var result = await _service.AddConsumerAsync(JsonConvert.DeserializeObject<Model.Consumer>(body));
                //await context.Response.WriteJson<string>(result);
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(JsonConvert.SerializeObject(result));
            }
            else await next(context);
        }
    }
}