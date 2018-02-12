using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using CorePOC.DataLayer.Services;
using System.IO;
using Newtonsoft.Json;
using CorePOC.Model;

namespace CorePOC.Middlewares
{
    public class RouteHandler : IMiddleware
    {
        private readonly IService _service;

        public RouteHandler(IService service)
        {
            _service = service;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var verb = context.Request.Method;
            var path = context.Request.Path;
            switch (verb)
            {
                case "POST":
                    switch (path)
                    {
                        case "/registration":
                            var regStream = new StreamReader(context.Request.Body);
                            var regBody = regStream.ReadToEnd();
                            var regResult = await _service.AddConsumerAsync(JsonConvert.DeserializeObject<Model.Consumer>(regBody));
                            //await context.Response.WriteJson<string>(result);
                            context.Response.ContentType = "application/json";
                            await context.Response.WriteAsync(JsonConvert.SerializeObject(regResult));
                            break;
                        case "/login":

                            var loginStream = new StreamReader(context.Request.Body);
                            var body = loginStream.ReadToEnd();
                            var loginResult = await _service.GetConsumerDetailsAsync(JsonConvert.DeserializeObject<Model.Consumer>(body));
                            //await context.Response.WriteJson<string>(result);
                            context.Response.ContentType = "application/json";
                            await context.Response.WriteAsync(JsonConvert.SerializeObject(loginResult));
                            break;

                    }
                    break;
                case "GET":
                    if (path == "/cardDetails")
                    {
                        var userId = context.Request.Query["userId"];
                        Auth objauth = new Auth()
                        {
                            Username = context.Request.Headers["key"],
                            Passowrd = context.Request.Headers["password"]
                        };
                        if (_service.IsAuthorized(objauth))
                        {
                            var result = _service.GetCardDetailsAsync(userId);
                            //var result=_service.GetConsumerDetails();
                        }
                        else
                        {

                        }
                    }
                    break;
                case "PUT":
                    if (path == "/cardDetails")
                    {

                    }
                    break;
            }
        }
    }
}