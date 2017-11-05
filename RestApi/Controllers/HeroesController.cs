using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using RestApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestApi.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("SiteCorsPolicy")]
    public class HeroesController : Controller
    {
        ArcDbContext _db;
        public HeroesController(ArcDbContext db) {
            _db = db;
        }


        //Default GET: api/values
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/values/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        [HttpGet("{id=0}")]
        public IEnumerable<Localidades> Get([FromQuery]decimal id) {
            List<Localidades> listita = _db.Localidades.ToList();
            if (id != 0)
                listita = listita.Where(x => x.Id == id).ToList();
            if (listita.Count == 0)
                throw new InvalidOperationException("Localidad no encontrada");


            return listita;
        }


        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
