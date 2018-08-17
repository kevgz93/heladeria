using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using BackEnd.Model;

namespace FrontEnd.Models
{
    public class ProductoViewModel
    {
        [Key]
        public int codigo { get; set; }


        [Display(Name = "Categoria")]
        [Required(ErrorMessage = "No debe dejar el campo en blanco")]
        public string categoria { get; set; }


        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "No debe dejar el campo en blanco")]
        public string nombre { get; set; }


        [Display(Name = "Descripcion")]
        [Required(ErrorMessage = "No debe dejar el campo en blanco")]
        public string descripcion { get; set; }


        [Display(Name = "Precio")]
        [Required(ErrorMessage = "No debe dejar el campo en blanco")]
        public double precio { get; set; }
        [DataType(DataType.Date)]
        public System.DateTime fecha_ingreso { get; set; }
        [DataType(DataType.Date)]
        public System.DateTime fecha_vencimiento { get; set; }
        public Nullable<int> cantidad { get; set; }
        public string estado { get; set; }
        [Display(Name = "Proveedor")]
        public int proveedor_id { get; set; }

        public virtual ICollection<ProveedorViewModel> Proveedores { get; set; }

    }
}