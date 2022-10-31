using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    class Proveedor
    {
        public int Id { get; set; }
        public int IdProducto { get; set; }
        public string RazonSocial { get; set; }
        public string Domicilio { get; set; }
        public string Mail { get; set; }
        public string Telefono { get; set; }
        public float Precio { get; set; }
        public bool Estado { get; set; }
    }
}
