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
    [Route("api/[controller]")]
    [ApiController]
    public class OwnersController : ControllerBase
    {
        CatService service;

        public OwnersController()
        {
            service = new CatService();
        }
        // GET api/owners
        [HttpGet]
        public ActionResult<IEnumerable<Owner>> Get()
        {
            return service.GetOwners();
        }

        // POST api/owner
        [HttpPost]
        public void Post([FromBody] Owner value)
        {
            service.AddOwner(value);
        }

        // GET api/owners/5
        [HttpGet("{id}")]
        public ActionResult<Owner> Get(int id)
        {
            Owner myOwner = service.GetOwner(id);

            return myOwner;
        }

    }
}