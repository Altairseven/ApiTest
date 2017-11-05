using System;
using System.Collections.Generic;

namespace RestApi.Models
{
    public partial class SysMenu
    {
        public decimal Id { get; set; }
        public decimal IdPadre { get; set; }
        public decimal IdSistema { get; set; }
        public string Nombre { get; set; }
        public string Ruta { get; set; }
        public string Icono { get; set; }
        public string ColorHeader { get; set; }
        public decimal Orden { get; set; }
    }
}
