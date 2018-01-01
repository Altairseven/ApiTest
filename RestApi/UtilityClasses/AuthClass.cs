using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestApi.Models;
using System.Security.Cryptography;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace RestApi.UtilityClasses {
    public static class AuthClass {

        static ArcDbContext _db;

        public static void Init(ArcDbContext db) {
            _db = db;
        }

        public static Users CheckCredentials(string login, string password) {
                                                            //el login puede ser el username, o el mail
            Users Entity = _db.Users.FirstOrDefault(x=> x.Username.ToLower().Trim() == login.ToLower().Trim() 
                                                    || x.Email.ToLower().Trim() == login.ToLower().Trim() );

            if (Entity == null)
                return null;

            string hash = HashIt(password, Entity.Salt);

            if (hash == Entity.Password)
                return Entity;
            else
                return null;
        }
        
        public static string RegisterUser(Users Entity) {
            string response = "";

            if (_db.Users.Any(x => x.Username == Entity.Username))
                return string.Format("El nombre de usuario ya esta en uso.");

            if (_db.Users.Any(x => x.Email == Entity.Email))
                return string.Format("El Email ingresado corresponde a un usuario registrado," +
                    " si usted ya esta registrado, utilize la opcion 'Recuperar contraseña'.");

            Entity.Salt = NewSalt(10);
            Entity.Password = HashIt(Entity.Password, Entity.Salt);

            try {
                _db.Users.Add(Entity);
            }
            catch (Exception ex) {
                response = string.Format("Se produjo un error al registrar ({0})", ex.Message);
                throw;
            }
            return response;
        }

        public static string NewSalt(int size) {
            var rng = new RNGCryptoServiceProvider();
            var buff = new byte[size];
            rng.GetBytes(buff);
            return Convert.ToBase64String(buff);
        }

        public static string HashIt(string toHash) {
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(toHash);
            System.Security.Cryptography.SHA256Managed sha256String =
                            new System.Security.Cryptography.SHA256Managed();
            byte[] newhash = sha256String.ComputeHash(bytes);
            return Convert.ToBase64String(newhash);
        }
        //concatena un string y un salt y los hashea juntos.
        public static string HashIt(string toHash, string salt) {
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(toHash + salt);
            System.Security.Cryptography.SHA256Managed sha256String =
                            new System.Security.Cryptography.SHA256Managed();
            byte[] newhash = sha256String.ComputeHash(bytes);
            return Convert.ToBase64String(newhash);
        }

        public static object GenerateToken(string Username) {
            var claims = new[] {
                new Claim(ClaimTypes.Name, Username)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Sentis que la wea entra re potente y poderosa"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            DateTime expiration = DateTime.Now.AddMinutes(30);

            var token = new JwtSecurityToken(
                issuer: "ArcLan/api",
                audience: "ArclanAngularApp",
                claims: claims,
                expires: expiration,
                signingCredentials: creds);



            return new {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                Username = Username,
                expiration = expiration
            };



        }

    }
}
