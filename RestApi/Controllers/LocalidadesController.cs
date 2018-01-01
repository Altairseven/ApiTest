using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RestApi.Entidades;
using RestApi.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authorization;

namespace RestApi.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("SiteCorsPolicy")]
    public class LocalidadesController : Controller {

        ArcDbContext _db;

        public LocalidadesController(ArcDbContext db) {
            _db = db;
        }

        [Authorize]
        [HttpGet("{id=0}")]
        public IEnumerable<Localidades> Get([FromQuery]decimal id) {
            List<Localidades> listita = _db.Localidades.ToList();
            if (id != 0)
                listita = listita.Where(x => x.Id == id).ToList();
            if (listita.Count == 0)
                throw new InvalidOperationException("Localidad no encontrada");


            return listita;
        }

        [HttpPost] //create
        
        public string Post([FromBody]Localidades value) {
            string response = "Se ha guardado Correctamente";

            Localidades Entity = new Localidades();
            Entity.Nombre = value.Nombre;
            Entity.CodPostal = value.CodPostal;
            Entity.IdProvincia = value.IdProvincia;

            try {
                _db.Localidades.Add(Entity);
                _db.SaveChanges();
            }
            catch (Exception ex) {
                response = "Una Wea mala ha ocurrido";
                throw ex;
            }
            return response;
        }

        [HttpPut]
        public void Put([FromBody]Localidades value) {
            
        }




        [HttpDelete]
        public void Delete([FromQuery]decimal id) {

        }
    }
}
