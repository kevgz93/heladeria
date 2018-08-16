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
    public class CatalogoController : Controller
    {
        private Mapeos mapeo = new Mapeos();
        IProductoBLL productoBLL;

        public CatalogoController()
        {
            productoBLL = new ProductoBLLImpl();
        }
        public ActionResult Index()
        {
            List<T_productos> productos = new List<T_productos>();
            List<ProductoViewModel> listaProductos = new List<ProductoViewModel>();
            productos = productoBLL.GetAll();

            foreach (T_productos producto in productos)
            {
                listaProductos.Add(mapeo.mapearPaPVM(producto));
            }

            return View(listaProductos);
        }

        public ActionResult Detalles(int id)
        {
            T_productos producto = new T_productos();
            producto = productoBLL.Get(id);


            return View(mapeo.mapearPaPVM(producto));
        }
        
        public ActionResult Agregar(int id)
        {
            T_productos producto = new T_productos();
            producto = productoBLL.Get(id);

            if (Session["cart"] == null)
            {
                List<ProductoViewModel> li = new List<ProductoViewModel>();

                li.Add(mapeo.mapearPaPVM(producto));
                Session["cart"] = li;
                ViewBag.cart = li.Count();


                Session["count"] = 1;


            }
            else
            {
                List<ProductoViewModel> li = (List<ProductoViewModel>)Session["cart"];
                li.Add(mapeo.mapearPaPVM(producto));
                Session["cart"] = li;
                ViewBag.cart = li.Count();
                Session["count"] = Convert.ToInt32(Session["count"]) + 1;

            }
            return RedirectToAction("Index", "Catalogo");
        }
    }
}