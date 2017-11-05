using System;
using System.Collections.Generic;

namespace RestApi.Models
{
    public partial class TiposDocumentos
    {
        public decimal Id { get; set; }
        public string Nombre { get; set; }
        public string CodigoAfip { get; set; }
    }
}
