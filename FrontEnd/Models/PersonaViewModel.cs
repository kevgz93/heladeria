using BackEnd.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FrontEnd.Models
{
    public class PersonaViewModel
    {
        [Key]
        public int id_persona { get; set; }

        [Display(Name = "Cedula")]
        [Required(ErrorMessage = "No debe dejar el campo en blanco")]
        public string cedula { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "No debe dejar el campo en blanco")]
        public string nombre { get; set; }

        [Display(Name = "Primer Apellido")]
        [Required(ErrorMessage = "No debe dejar el campo en blanco")]
        public string apellido1 { get; set; }

        [Display(Name = "Segundo Apellido")]
        [Required(ErrorMessage = "No debe dejar el campo en blanco")]
        public string apellido2 { get; set; }

        [Display(Name = "Numero de telefono")]
        [Required(ErrorMessage = "No debe dejar el campo en blanco")]
        public string telefono { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "No debe dejar el campo en blanco")]
        public string correo { get; set; }

        [Display(Name = "Sexo")]
        [Required(ErrorMessage = "Debe elegir un sexo")]
        public string sexo { get; set; }

        public IEnumerable<Sexos> sexos { get; set; }

        [Display(Name = "Nombre de usuario")]
        [Required(ErrorMessage = "No debe dejar el campo en blanco")]
        public string UserName { get; set; }

        [Display(Name = "Contraseña")]
        [Required(ErrorMessage = "No debe dejar el campo en blanco")]
        [DataType(DataType.Password)]

        public string Password { get; set; }

        //Role
        public string role { get; set; }
        public int roleId { get; set; }

        [Display(Name = "Roles")]
        public virtual IEnumerable<RoleViewModel> Roles { get; set; }
    }
}
