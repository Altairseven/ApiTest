using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi.Entidades {
    public class TestEntity {
        public decimal ID { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        public TestEntity() {

        }
        public TestEntity(decimal _id, string _nombre, string _apellido) {
            ID = _id;
            Nombre = _nombre;
            Apellido = _apellido;
        }

    }
}
