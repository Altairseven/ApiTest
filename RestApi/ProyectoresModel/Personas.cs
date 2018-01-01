using System;
using System.Collections.Generic;

namespace RestApi.ProyectoresModel
{
    public partial class Personas
    {
        public decimal Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public decimal IdTipoDocumento { get; set; }
        public decimal Documento { get; set; }
        public decimal? Cuit { get; set; }
        public decimal IdLocalidad { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public decimal? IdTipoPersona { get; set; }
        public string Legajo { get; set; }
        public DateTime? FechaNacimiento { get; set; }
    }
}
