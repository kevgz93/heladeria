//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BackEnd.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class T_anulaciones
    {
        public int id_anulacion { get; set; }
        public System.DateTime fecha { get; set; }
        public string comentario { get; set; }
        public int factura_numero { get; set; }
        public int persona_id { get; set; }
    
        public virtual T_facturas T_facturas { get; set; }
        public virtual T_personas T_personas { get; set; }
    }
}
