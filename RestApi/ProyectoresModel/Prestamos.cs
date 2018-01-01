using System;
using System.Collections.Generic;

namespace RestApi.ProyectoresModel
{
    public partial class Prestamos
    {
        public decimal Id { get; set; }
        public decimal IdProyector { get; set; }
        public decimal IdSalon { get; set; }
        public decimal IdPersona { get; set; }
        public decimal? IdReserva { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime HDesde { get; set; }
        public DateTime HHasta { get; set; }
        public int Activo { get; set; }
    }
}
