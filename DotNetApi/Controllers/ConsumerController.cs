using CorePOC.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using CorePOC.DataLayer.Services;
using System.Web;
using System.Net;
using System.Net.Http;

namespace CorePOC.Controllers
{
    //[Produces("application/json")]
    [Route("api/Consumer")]
    public class ConsumerController : Controller
    {
        IService _service;

        public ConsumerController(IService service)
        {
            _service = service;
        }
        // GET: api/Consumer
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Consumer/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/Consumer
        [HttpPost]
        public IActionResult ConsumerRegistration([FromBody]Consumer consumer)
        {
              var result =_service.AddConsumer(consumer);
              return Ok(result);         
        }

        // PUT: api/Consumer/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}