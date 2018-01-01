using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authorization;
using RestApi.Models;
using RestApi.UtilityClasses;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestApi.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("SiteCorsPolicy")]
    public class AuthController : Controller {

        ArcDbContext _db;

        public AuthController(ArcDbContext db) {
            _db = db;
            AuthClass.Init(db);
        }




        // POST api/values
        //[HttpPost]
        //public void Post([FromBody]int value) {



        //}
        //POST api/values
        [HttpGet]
        public IActionResult Get([FromQuery]int id) {

            return new OkResult();
            //return new ObjectResult(GenerateToken("culo"));
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult RequestToken([FromBody] Userinfo userinfo) {


            Users Entity = AuthClass.CheckCredentials(userinfo.Login, userinfo.Password);

            if (Entity == null)
                return BadRequest("Credenciales Invalidas");

            if (!string.IsNullOrEmpty(Entity.Username)) {
                return Ok(AuthClass.GenerateToken(Entity.Username));
            }

            return BadRequest("Could not verify username and password");
        }






    }

    public class Userinfo {
        public string Login { get; set; }
        public string Password { get; set; }

        public Userinfo(string login, string password) {
            Login = login;
            Password = password;
        }
    }

}
