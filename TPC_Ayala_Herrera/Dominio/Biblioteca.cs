using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Biblioteca : Categoria
    {
        public string Autor { get; set; }
        public string Editorial { get; set; }
        public string Tapa { get; set; }
        public DateTime FechaPublicacion { get; set; }
    }
}
