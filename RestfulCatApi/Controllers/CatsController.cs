using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestfulCatApi.Models;
using RestfulCatApi.Services;

namespace RestfulCatApi.Controllers
{
   // [Route("api/[controller]")]
    [ApiController]
    public class CatsController : ControllerBase
    {
        CatService service;
        public CatsController()
        {
            service = new CatService();
        }

        // GET api/owners/1/cats
        [HttpGet("api/owners/{id}/cats")]
        public ActionResult<List<Cat>> Get(string id)
        {
           return service.GetCatsforOwner(id);
        }

        // POST api/owners/{id}/cats
        [HttpPost("api/owners/{id}/cats")]
        public void Post([FromBody] Cat cat, string id)
        {
            service.AddCat(cat, id);
        }

        // GET api/cats/{id}
        [HttpGet("api/cats/{id}")]
        public ActionResult<Cat> GetCat(string id)
        {
            return service.GetCat(id);
        }

        // POST api/cats
        [HttpPost("api/cats")]
        public void PostCatToRandomOwner([FromBody] Cat cat)
        {
            service.AddCatToOwner(cat);
        }

    }
}