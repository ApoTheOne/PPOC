using CorePOC.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using CorePOC.DataLayer.Services;
using System.Web;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using CorePOC.DataLayer.Repositories;

namespace CorePOC.Controllers
{
    //[Produces("application/json")]
    [Route("[controller]")]
    public class RegistrationController : Controller
    {
        IRepository _repo;

        public RegistrationController(IRepository repo)
        {
            _repo = repo;
        }
        // GET: api/Consumer
        [HttpGet]
        [ResponseCache(Duration = 30)]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Consumer/5
        [HttpGet("{id}")]
        [ResponseCache(Duration = 30)]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/Consumer
        [HttpPost]
        [ResponseCache(Duration = 30)]
        public async Task<IActionResult> ConsumerRegistration([FromBody]Consumer consumer)
        {
              var result = await _repo.AddConsumerAsync(consumer);
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