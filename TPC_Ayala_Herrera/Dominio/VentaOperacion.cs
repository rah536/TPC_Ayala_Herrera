using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class VentaOperacion
    {
        public int Id { get; set; }
        public Cliente Cliente { get; set; }
        public float Total { get; set; }
        public DateTime FechaVenta { get; set; }
    }
}
