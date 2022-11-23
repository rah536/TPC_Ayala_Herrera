using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class CompraOperacionDetalle
    {
        public int IdCompra { get; set; }
        public Producto Producto { get; set; }
        //De producto necesitamos Descripcion y CostoUnidad
        public int Cantidad { get; set; }
        //public float Iva { get; set; }
        public float SubTotal { get; set; }
    }
}
