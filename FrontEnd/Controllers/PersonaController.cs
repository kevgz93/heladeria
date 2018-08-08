using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BackEnd.BLL.Personas;
using BackEnd.Model;
using FrontEnd.Models;

namespace FrontEnd.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class PersonaController : Controller
    {

        private IPersonaBLL personaBLL;

        public PersonaController()
        {
            personaBLL = new PersonaBLLImpl();

            ViewBag.sexo = new SelectList(new[] {
                new SelectListItem { Value = "1", Text = "Hombre" },
                new SelectListItem { Value = "2", Text = "Mujer" }
                                               }, "Value", "Text");
        }

        public List<PersonaViewModel> ListModelToView()
        {
            List<T_personas> model = personaBLL.GetAll();
            List<PersonaViewModel> view = new List<PersonaViewModel>();
            if (model == null)
            {
                view = null;

            }
            else
            {
                foreach (var item in model)
                {
                    PersonaViewModel convert = new PersonaViewModel
                    {
                        id_persona = item.id_persona,
                        nombre = item.nombre,
                        cedula = item.cedula,
                        apellido1 = item.apellido1,
                        apellido2 = item.apellido2,
                        telefono = item.telefono,
                        correo = item.correo,
                        sexo = item.sexo
                    };
                    view.Add(convert);
                }
            }

            return view;
        }


        public PersonaViewModel ModeltoView(T_personas persona)
        {
            PersonaViewModel personas = new PersonaViewModel
            {
                id_persona = persona.id_persona,
                cedula = persona.cedula,
                nombre = persona.nombre,
                apellido1 = persona.apellido1,
                apellido2 = persona.apellido2,
                telefono = persona.telefono,
                correo = persona.correo,
                sexo= persona.sexo
            };

            return personas;
        }


        public T_personas PersonaViewToModel(PersonaViewModel PersonasView)
        {

            T_personas personas = new T_personas
            {
                id_persona = PersonasView.id_persona,
                cedula = PersonasView.cedula,
                nombre = PersonasView.nombre,
                apellido1 = PersonasView.apellido1,
                apellido2 = PersonasView.apellido2,
                telefono = PersonasView.telefono,
                correo = PersonasView.correo,
                sexo = PersonasView.sexo
            };


            return personas;
        }

        // GET: Persona
        public ActionResult Index()
        {
            return View(ListModelToView());
        }


        public ActionResult Agregar()
        {
            PersonaViewModel persona = new PersonaViewModel();
            return View(persona);


        }

        [HttpPost]
        public ActionResult Agregar(PersonaViewModel persona)
        {
            personaBLL.Add(MapearRE(persona));
            return RedirectToAction("Index", "Persona");

        }

        public T_personas MapearRE(PersonaViewModel persona)
        {
            T_personas person = new T_personas
            {
                id_persona = persona.id_persona,
                cedula = persona.cedula,
                nombre = persona.nombre,
                apellido1 = persona.apellido1,
                apellido2 = persona.apellido2,
                telefono = persona.telefono,
                correo = persona.correo,
                sexo = persona.sexo
            };
            return person;
        }

        public ActionResult Editar(int id)
        {
            T_personas persona = personaBLL.Get(id);
            PersonaViewModel editar = ModeltoView(persona);
            return View(editar);
        }

        [HttpPost]
        public ActionResult Editar(PersonaViewModel personaView)
        {
            T_personas editar = PersonaViewToModel(personaView);
            personaBLL.Update(editar);

            return RedirectToAction("Index", "Persona");
        }

        public ActionResult Detalles(int id)
        {
            T_personas persona = personaBLL.Get(id);
            PersonaViewModel det = ModeltoView(persona);
            return View(det);
        }



        public ActionResult Eliminar(int id)
        {
            T_personas persona = personaBLL.Get(id);
            PersonaViewModel editar = ModeltoView(persona);
            return View(editar);
        }

        [HttpPost]
        public ActionResult Eliminar(PersonaViewModel personaView)
        {
            T_personas eliminar = PersonaViewToModel(personaView);
            personaBLL.Remove(eliminar);

            return RedirectToAction("Index", "Persona");
        }

    }
}