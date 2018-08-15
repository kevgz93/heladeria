using BackEnd.BLL.Consultas;
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

        public HomeController()
        {
            consultaBLL = new ConsultaBLLImpl();
        }


        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

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