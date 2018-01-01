using System;
using System.Collections.Generic;

namespace RestApi.Models
{
    public partial class Users
    {
        public decimal Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public string Userfirstname { get; set; }
        public string Userlastname { get; set; }
        public string Email { get; set; }
        public decimal IdPermissions { get; set; }
        public string RecoveryQ { get; set; }
        public string RecoveryA { get; set; }
    }
}
