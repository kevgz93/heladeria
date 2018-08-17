using BackEnd.BLL;
using BackEnd.BLL.Login;
using BackEnd.BLL.Personas;
using BackEnd.Model;
using FrontEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FrontEnd.Controllers
{
    public class PersonaController : Controller
    {
        private IPersonaBLL personaBLL;
        private IUserBLL userBLL;
        private IRoleBLL roleBLL;
        private IUsersInRolesBLL UsersInRolesBLL;

        private User ReturnUserObject(IEnumerable<User> users)
        {
            User user = new User();
            return user;

        }

        public List<PersonaViewModel> MapeoToPersonaVM(List<T_personas> personas, List<User> users)
        {
            PersonaViewModel persona;
            User user;
            string role;
            List<PersonaViewModel> resultado = new List<PersonaViewModel>();
            foreach (var item in personas)
            {
                
                user = users.Where(x => x.persona_id == item.id_persona).FirstOrDefault();
                role = userBLL.gerRolesForUser(user.UserName).FirstOrDefault();

                persona = new PersonaViewModel
                {
                    id_persona = item.id_persona,
                    apellido1 = item.apellido1,
                    apellido2 = item.apellido2,
                    cedula = item.cedula,
                    correo = item.correo,
                    nombre = item.nombre,
                    sexo = item.sexo,
                    telefono = item.telefono,
                    UserName = user.UserName,
                    Password = user.Password,
                    role = role



                };
                

                resultado.Add(persona);
            }
            return resultado;
        }

        public T_personas MapeoFromPersonaVMToPersona(PersonaViewModel persona)
        {
            T_personas personas;


            personas = new T_personas()
            {
                apellido1 = persona.apellido1,
                apellido2 = persona.apellido2,
                cedula = persona.cedula,
                correo = persona.correo,
                nombre = persona.nombre,
                sexo = persona.sexo,
                telefono = persona.telefono
                
            };


            return personas;
        }

        public Role MapeoFromRoleVMToRole(RoleViewModel role)
        { 
            Role roles;



            roles = new Role()
            {
                RoleId = role.RoleId,
                RoleName = role.RoleName

            };


            return roles;
        }

        public User MapeoFromPersonaVMToUser(PersonaViewModel persona)
        {
            User user;

            user = new User()
            {
                nombre = persona.nombre,
                persona_id = persona.id_persona,
                Password = persona.Password,
                UserName = persona.UserName

            };


            return user;
        }

        public List<RoleViewModel> MapeoToRoleVM(List<Role> roles)
        {
            RoleViewModel role;
            List<RoleViewModel> resultado = new List<RoleViewModel>();
            foreach (var item in roles)
            {
                role = new RoleViewModel
                {
                    RoleId = item.RoleId,
                    RoleName = item.RoleName
                };
                resultado.Add(role);
            }
            return resultado;
        }

        public PersonaController()
        {
            personaBLL = new PersonaBLLImpl();
            userBLL = new UserBLLImpl();
            roleBLL = new RoleBLLImpl();
            UsersInRolesBLL = new UsersInRolesBLLImpl();
        }
        // GET: Persona
        public ActionResult Index()
        {
            List<PersonaViewModel> personas;
            List<T_personas> Lista_personas = personaBLL.GetAll();
            if(Lista_personas == null)
            {
                personas = new List<PersonaViewModel>();
                TempData["msg"] = "<script>alert('There's no users to show');</script>";
                return View(personas);
            }
            List<User> Lista_users = userBLL.getAll();
            personas = MapeoToPersonaVM(Lista_personas, Lista_users);
            return View(personas);
        }

        [Authorize(Roles = "Administrador")]
        public ActionResult Create()
        {
            PersonaViewModel persona = new PersonaViewModel();


            List<RoleViewModel> roles = new List<RoleViewModel>();
            roles = MapeoToRoleVM(roleBLL.GetAll());
            persona.Roles = roles;
            return View(persona);
        }

        [HttpPost]
        public ActionResult Create(PersonaViewModel personaVM)
        {
            bool result;
            T_personas persona = new T_personas();
            User user = new User();
            persona = MapeoFromPersonaVMToPersona(personaVM);
            personaBLL.Add(persona);
            user = MapeoFromPersonaVMToUser(personaVM);
            persona = personaBLL.GetAll().LastOrDefault();
            user.persona_id = persona.id_persona;
            result = userBLL.insertar(user);
            if(result)
            {
                user = userBLL.getAll().LastOrDefault();
                result = UsersInRolesBLL.insertar( personaVM.roleId, user.UserId);
            }
            else
            {
                TempData["msg"] = "<script>alert('Error Ocurrs adding user');</script>";
                return View();
            }
            
            //response = personaBLL.Add(persona);
            return RedirectToAction("Index", "Persona");
        }

        [Authorize(Roles = "Administrador")]
        public ActionResult Edit(PersonaViewModel persona)
        {
            List<RoleViewModel> roles = new List<RoleViewModel>();
            roles = MapeoToRoleVM(roleBLL.GetAll());

            persona.Roles = roles;//MapeoToPersonaVM(persona, Lista_users);
            return View(persona);
        }

        [HttpPost]
        public ActionResult EditPersona(PersonaViewModel personaVM)
        {
            bool result;
            T_personas persona = new T_personas();
            User user = new User();
            User User_Id = new User();
            persona = MapeoFromPersonaVMToPersona(personaVM);
            personaBLL.Update(persona);
            user = MapeoFromPersonaVMToUser(personaVM);
            User_Id = userBLL.getUser(user.UserName);
            user.persona_id = personaVM.id_persona;
            user.UserId = User_Id.UserId;
            userBLL.Update(user);
            result = UsersInRolesBLL.update(user.UserId, personaVM.roleId);

            if (!result)
            {
                TempData["msg"] = "<script>alert('Error Ocurrs adding user in roles');</script>";
                return View();
            }

            //response = personaBLL.Add(persona);
            return RedirectToAction("Index", "Persona");
        }
    }
}