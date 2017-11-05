using System;
using System.Collections.Generic;

namespace RestApi.Models
{
    public partial class Localidades
    {
        public decimal Id { get; set; }
        public decimal CodPostal { get; set; }
        public string Nombre { get; set; }
        public decimal? IdProvincia { get; set; }
    }
}
