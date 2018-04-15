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
   [Route("[controller]")]
    public class LoginController : Controller
    {
        IRepository _repo;

        public LoginController(IRepository repo)
        {
            _repo = repo;
        }
        // GET api/values
        [HttpGet]
        [ResponseCache(Duration = 30)]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        [ResponseCache(Duration = 30)]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        [ResponseCache(Duration = 30)]
        public async Task<IActionResult>  Post([FromBody]Consumer consumer)
        {
            var result= await _repo.GetConsumerDetailsAsync(consumer);
            return Ok(result);
        }

        // PUT: api/Consumer/5
        [HttpPut("{id}")]
        [ResponseCache(Duration = 30)]
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