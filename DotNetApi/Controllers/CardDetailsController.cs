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
    public class CardDetailsController : Controller
    {
        IRepository _repo;
        public CardDetailsController(IRepository repo)
        {
            _repo = repo;            
        }
        // GET api/values

        
        // GET api/values/5
        [HttpGet("{id}")]
        [ResponseCache(Duration = 30)]
        public async Task<IActionResult> Get(int id)
        {
            Card card =new Card(){userid = id};
            Auth objauth= new Auth()
            {
                Username=this.HttpContext.Request.Headers["key"],
                Passowrd=this.HttpContext.Request.Headers["password"]
            };
            if(_repo.IsAuthorised(objauth))
            {
                var result = await _repo.GetCardDetailsAsync(card);
                return Ok(result);
            }
            {
                return Ok(HttpStatusCode.BadRequest);
            }
        }

        // POST api/values
        [HttpPost]
        [ResponseCache(Duration = 30)]
        public async Task<IActionResult> Post([FromBody]Card card)
        {
            Auth objauth= new Auth()
            {
                Username=this.HttpContext.Request.Headers["key"],
                Passowrd=this.HttpContext.Request.Headers["password"]
            };
            if(_repo.IsAuthorised(objauth))
            {
              var result= await _repo.AddCardDetailsAsync(card);
              return Ok(result);
            }
            else
            {
                return Ok(HttpStatusCode.BadRequest);
            }
        }

        // PUT api/values/5
        [HttpPut]
        [ResponseCache(Duration = 30)]
        public async Task<IActionResult> Put([FromBody]Card card)
        {
            Auth objauth= new Auth()
            {
                Username=this.HttpContext.Request.Headers["key"],
                Passowrd=this.HttpContext.Request.Headers["password"]
            };
            if(_repo.IsAuthorised(objauth))
            {
                var result = await _repo.UpdateCardDetailsAsync(card);
                return Ok(result);
            }
            else
            {
                return Ok(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        [ResponseCache(Duration = 30)]
        public void Delete(int id)
        {
        }
    }
}