//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BackEnd.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class T_detalle_factura
    {
        public int id_detalle_factura { get; set; }
        public int factura_numero { get; set; }
        public int cantidad { get; set; }
        public double precio { get; set; }
    
        public virtual T_facturas T_facturas { get; set; }
    }
}