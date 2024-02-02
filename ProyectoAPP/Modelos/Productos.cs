using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ProyectoAPP.Modelos
{
    public class Productos
    {
        public int IdProducto { get; set; }

        public string NameProducto { get; set; }

        public int StockProducto { get; set; }

        public double PrecioProducto { get; set; }
    }
}
