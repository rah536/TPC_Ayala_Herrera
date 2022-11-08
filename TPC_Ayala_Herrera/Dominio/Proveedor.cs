using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Proveedor : Persona
    {
        public int Id { get; set; }
        public int IdProducto { get; set; }
        public string RazonSocial { get; set; }
    }
}
