using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using RestApi.Models;
using System.Net.Http;
using System.Net;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [EnableCors("SiteCorsPolicy")]
    public class HeroesController : Controller {
        ArcDbContext _db;
        public HeroesController(ArcDbContext db) {
            _db = db;
        }

        //Get api/heroes => devuelve contenido completo de la tabla Heroes
        //Get api/heroes?id={id} devielve solamente 1 registro de la tabla heroes, por id
        [HttpGet("{id=0}")]
        
        public JsonResult Get([FromQuery]decimal id) {
            List<Heroes> listita = _db.Heroes.ToList();
           
            if (id != 0) { 
                listita = listita.Where(x => x.Id == id).ToList();
                return Json(listita.FirstOrDefault());
            }
            else
                return Json(listita);
        }

        //// POST api/values
        //[HttpPost]
        //public JsonResult Post([FromBody]string value) {
        //    return Json())
        //}

        // PUT api/values/5
        [HttpPut]
        public JsonResult Put([FromBody]Heroes hero) {
            try {
                Heroes Entity = _db.Heroes.Where(x => x.Id == hero.Id).FirstOrDefault();
                if (Entity == null)
                    return Json(HttpStatusCode.NotFound);

                Entity.Name = hero.Name;
                Entity.Alias = hero.Alias;
                Entity.Quirk = hero.Quirk;

                _db.SaveChanges();
                return Json (HttpStatusCode.OK);
            }
            catch (Exception) {
                return Json(HttpStatusCode.NotModified);
                throw;
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
