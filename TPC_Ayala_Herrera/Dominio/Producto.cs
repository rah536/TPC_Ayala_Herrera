using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Producto
    {
        public int Id { get; set; }
        public int Codigo { get; set; }
        public int IdProveedor { get; set; }
        public string Descripcion { get; set; }
        public string Marca { get; set; }
        //public Marca Marca { get; set; }

        public string Categoria { get; set; }
        //public Categoria Categoria { get; set; }

        public float Costo { get; set; }
        public int StockActual { get; set; }
        public int StockMinimo { get; set; }
        public float PorcentajeGanancia { get; set; }
        public string UrlImagen { get; set; }
        public bool Estado { get; set; }
    }
}
