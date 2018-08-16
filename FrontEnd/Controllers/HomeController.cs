using BackEnd.BLL;
using BackEnd.BLL.Consultas;
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

    public class HomeController : Controller
    {

        IConsultaBLL consultaBLL;
        IPersonaBLL personaBLL;
        IUserBLL userBLL;
        Mapeos mapeo;

        public HomeController()
        {
            consultaBLL = new ConsultaBLLImpl();
            personaBLL = new PersonaBLLImpl();
            userBLL = new UserBLLImpl();
            mapeo = new Mapeos();
        }

        public List<Sexos> obtenerSexos()
        {
            List<Sexos> sexos = new List<Sexos>();
            Sexos sexo1 = new Sexos();
            Sexos sexo2 = new Sexos();
            Sexos sexo3 = new Sexos();

            sexo1.nombre = "Masculino";
            sexo1.codigo = "M";

            sexo2.nombre = "Femenino";
            sexo2.codigo = "F";

            sexo3.nombre = "Otro";
            sexo3.codigo = "O";

            sexos.Add(sexo1);
            sexos.Add(sexo2);
            sexos.Add(sexo3);

            return sexos;
        }


        public ActionResult Registro()
        {
            PersonaViewModel personaVM = new PersonaViewModel();
            personaVM.sexos = obtenerSexos();
            return View(personaVM);
        }

        [HttpPost]
        public ActionResult Registro(PersonaViewModel personaVM)
        {
            User usuario = new User();
            //personaVM.id_persona = personaBLL.obtenerIdPersona();

            //personaBLL.Add(mapeo.mapearPVMaP(personaVM));

            ////////////////////////////////////////////////////////
            usuario.UserName = personaVM.UserName;
            usuario.Password = personaVM.Password;
            usuario.nombre = personaVM.nombre;
            usuario.persona_id = personaVM.id_persona;
            //usuario.UserId = ;
            //userBLL.insertar(usuario, );
            ///////////////////////////////////////////////////////

            return View();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Contacto()
        {
            ViewBag.Message = "Contactenos";

            return View();
        }

        [HttpPost]
        public ActionResult Contacto(ConsultaViewModel consultaVM)
        {
            Mapeos mapeo = new Mapeos();
            T_Consultas consulta = new T_Consultas();
            consulta = mapeo.mapearCVMaC(consultaVM);

            consultaBLL.Add(consulta);

            return RedirectToAction("Contacto");
        }
    }
}