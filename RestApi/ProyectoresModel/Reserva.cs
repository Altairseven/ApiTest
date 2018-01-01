using System;
using System.Collections.Generic;

namespace RestApi.ProyectoresModel
{
    public partial class Reserva
    {
        public decimal Id { get; set; }
        public decimal IdSalon { get; set; }
        public decimal IdPersona { get; set; }
        public DateTime FechaReserva { get; set; }
        public DateTime FechaAlta { get; set; }
        public DateTime? FechaBaja { get; set; }
        public decimal? IdMotivoBaja { get; set; }
        public DateTime HDesde { get; set; }
        public DateTime HHasta { get; set; }
    }
}
