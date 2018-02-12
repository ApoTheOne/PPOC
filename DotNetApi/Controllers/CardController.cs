using CorePOC.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using CorePOC.DataLayer.Services;
using System.Web;
using System.Net;
using System.Net.Http;
namespace CorePOC.Controllers
{
    [Route("api/[controller]")]
    public class CardController : Controller
    {
        IService _service;
        public CardController(IService service)
        {
            _service = service;            
        }
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet]
        public IActionResult Get([FromBody]Card card)
        {
            Auth objauth= new Auth()
            {
                Username=this.HttpContext.Request.Headers["key"],
                Passowrd=this.HttpContext.Request.Headers["password"]
            };
            if(_service.IsAuthorized(objauth))
            {
                var result =_service.GetCardDetails(card);
                return Ok(result);
            }
            {
                return Ok(HttpStatusCode.BadRequest);
            }
        }

        // POST api/values
        [HttpPost]
        public IActionResult  Post([FromBody]Card card)
        {
            Auth objauth= new Auth()
            {
                Username=this.HttpContext.Request.Headers["key"],
                Passowrd=this.HttpContext.Request.Headers["password"]
            };
            if(_service.IsAuthorized(objauth))
            {
              var result=_service.AddCardDetails(card);
              return Ok(result);
            }
            else
            {
                return Ok(HttpStatusCode.BadRequest);
            }
        }

        // PUT api/values/5
        [HttpPut()]
        public IActionResult Put([FromBody]Card card)
        {
            Auth objauth= new Auth()
            {
                Username=this.HttpContext.Request.Headers["key"],
                Passowrd=this.HttpContext.Request.Headers["password"]
            };
            if(_service.IsAuthorized(objauth))
            {
                var result=_service.UpdateCardDetails(card);
                return Ok(result);
            }
            else
            {
                return Ok(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}