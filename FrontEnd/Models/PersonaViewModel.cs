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
        public int id_persona { get; set; }
        public string cedula { get; set; }
        public string nombre { get; set; }
        public string apellido1 { get; set; }
        public string apellido2 { get; set; }
        public string telefono { get; set; }
        public string correo { get; set; }
        public string sexo { get; set; }

        //User attribute

        public string UserName { get; set; }
        public string Password { get; set; }

        //Role
        public string role { get; set; }
        public int roleId { get; set; }

        [Display(Name = "Roles")]
        public virtual IEnumerable<RoleViewModel> Roles { get; set; }
    }
}
