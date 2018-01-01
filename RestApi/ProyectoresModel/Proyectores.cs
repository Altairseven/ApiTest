using System;
using System.Collections.Generic;

namespace RestApi.ProyectoresModel
{
    public partial class Proyectores
    {
        public decimal Id { get; set; }
        public string Marca { get; set; }
        public string Serial { get; set; }
        public decimal Hdmi { get; set; }
        public string Modelo { get; set; }
        public decimal Disponible { get; set; }
        public decimal Operativo { get; set; }
    }
}
