using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace CorePOC.Helper
{
    public static class HttpExtensions
    {
        public static Task WriteJson<T>(this HttpResponse response, T obj)
        {
            response.ContentType = "application/json";
            return response.WriteAsync(JsonConvert.SerializeObject(obj));
        }
    }
}