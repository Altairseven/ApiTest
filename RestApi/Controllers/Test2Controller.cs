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
    
    [Route("api/[controller]")]
    [EnableCors("SiteCorsPolicy")]
    public class Test2Controller : Controller {
        ArcDbContext _db;
        public Test2Controller(ArcDbContext db) {
            _db = db;
        }

        //Get api/heroes => devuelve contenido completo de la tabla Heroes
        //Get api/heroes?id={id} devielve solamente 1 registro de la tabla heroes, por id
        [HttpGet("{id=0}")]
        
        public JsonResult Get([FromQuery]decimal id) {
            return Json("GGWP");
        }

        
    }
}
