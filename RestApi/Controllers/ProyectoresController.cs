using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestApi.ProyectoresModel;
using Microsoft.AspNetCore.Cors;

namespace RestApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Proyectores")]
    [EnableCors("SiteCorsPolicy")]
    public class ProyectoresController : Controller
    {
        ProyectoresDbContext _db;

        public ProyectoresController(ProyectoresDbContext db) {
            _db = db;
        }


        [HttpGet("{id=0}")]
        public JsonResult Get([FromQuery]decimal id) {
            if (id != 0) {
                return Json(_db.Proyectores.FirstOrDefault(x=> x.Id == id));
            }
            else
                return Json(_db.Proyectores.ToList());
        }



    }
}