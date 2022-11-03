using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Persona
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Dni { get; set; }
        public int Cuit { get; set; }
        public string Domicilio { get; set; }
        public string Mail { get; set; }
        public string Telefono { get; set; }
        public bool Estado { get; set; }
        public int IdRol { get; set; }
        public DateTime FechaAlta { get; set; }
    }
}
