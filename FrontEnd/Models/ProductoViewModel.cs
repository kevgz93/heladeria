using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BackEnd.Model;

namespace FrontEnd.Models
{
    public class ProductoViewModel
    {

        public int codigo { get; set; }
        public string categoria { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public double precio { get; set; }
        public System.DateTime fecha_ingreso { get; set; }
        public System.DateTime fecha_vencimiento { get; set; }
        public Nullable<int> cantidad { get; set; }
        public string estado { get; set; }
        public int proveedor_id { get; set; }

    }
}