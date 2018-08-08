using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FrontEnd.Models
{
    public class PersonaViewModel
    {
        [Key]
        public int id_persona { get; set; }
        [Display(Name = "Cédula")]
        [Required]
        public string cedula { get; set; }
        [Display(Name = "Nombre")]
        [Required]
        public string nombre { get; set; }
        [Display(Name = "Primer Apellido")]
        [Required]
        public string apellido1 { get; set; }
        [Display(Name = "Segundo apellido")]
        [Required]
        public string apellido2 { get; set; }
        [Display(Name = "Télefono")]
        [Required]
        public string telefono { get; set; }
        [Display(Name = "Correo Electrónico")]
        [Required(ErrorMessage = "Correo electrónico es requerido")]
        [EmailAddress(ErrorMessage = "Correo invalido")]
        public string correo { get; set; }
        [Display(Name = "Sexo")]
        [Required]
        public string sexo { get; set; }
    }
}