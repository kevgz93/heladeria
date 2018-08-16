using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FrontEnd.Models
{
    public class ConsultaViewModel
    {
        [Key]
        public int idConsulta { get; set; }

        [Display(Name = "Consulta")]
        [Required(ErrorMessage = "No debe dejar el campo en blanco")]       
        public string consulta { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "No debe dejar el campo en blanco")]
        public string nombre { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "No debe dejar el campo en blanco")]
        public string email { get; set; }

        [Display(Name = "Telefono")]
        [Required(ErrorMessage = "No debe dejar el campo en blanco")]
        public string telefono { get; set; }

    }
}