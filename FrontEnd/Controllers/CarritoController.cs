using BackEnd.BLL.Productos;
using BackEnd.Model;
using FrontEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FrontEnd.Controllers
{
    public class CarritoController : Controller
    {

        private Mapeos mapeo = new Mapeos();
        IProductoBLL productoBLL;


        public CarritoController()
        {

            productoBLL = new ProductoBLLImpl();
        }

        public ActionResult Index()
        {
            return View((List<ProductoViewModel>)Session["cart"]);
        }

        public ActionResult Eliminar(int id)
        {
            List<ProductoViewModel> li = (List<ProductoViewModel>)Session["cart"];
            Session["count"] = Convert.ToInt32(Session["count"]) - 1;

            T_productos producto = new T_productos();
            producto = productoBLL.Get(id);

            var itemToRemove = li.FirstOrDefault(r => r.codigo == id);
            li.Remove(itemToRemove);

            Session["cart"] = li;

            return RedirectToAction("Index");
        }
    }
}