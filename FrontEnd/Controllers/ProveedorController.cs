using BackEnd.BLL.Proveedores;
using BackEnd.Model;
using FrontEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FrontEnd.Controllers
{
    public class ProveedorController : Controller
    {
        private IProveedorBLL proveedorBLL;

        public List<ProveedorViewModel> MapeoToProveedorVM(List<T_proveedores> proveedores)
        {
            ProveedorViewModel proveedor;
            List<ProveedorViewModel> resultado = new List<ProveedorViewModel>();
            foreach (var item in proveedores)
            {
                proveedor = new ProveedorViewModel
                {
                    cedula = item.cedula,
                    correo = item.correo,
                    direccion = item.direccion,
                    id_proveedor = item.id_proveedor,
                    nombre = item.nombre,
                    telefono = item.telefono


                };
                resultado.Add(proveedor);
            }
            return resultado;
        }

        public T_proveedores MapeoFromProveedorVM(ProveedorViewModel proveedor)
        {
            T_proveedores proveedores;


            proveedores = new T_proveedores()
            {
                cedula = proveedor.cedula,
                correo = proveedor.correo,
                direccion = proveedor.direccion,
                id_proveedor = proveedor.id_proveedor,
                nombre = proveedor.nombre,
                telefono = proveedor.telefono

            };


            return proveedores;
        }

        public ProveedorController()
        {
            proveedorBLL = new ProveedorBLLImpl();
        }
        // GET: Address
        public ActionResult Index()
        {
            List<ProveedorViewModel> proveedores;
            List<T_proveedores> Lista = proveedorBLL.GetAll();
            if (Lista == null)
            {
                proveedores = new List<ProveedorViewModel>();
                TempData["msg"] = "<script>alert('There's no users to show');</script>";
                return View(proveedores);
            }
            proveedores = MapeoToProveedorVM(Lista);
            return View(proveedores);
        }

        [Authorize(Roles = "Administrador")]
        public ActionResult Create()
        {
            ProveedorViewModel proveedor = new ProveedorViewModel();



            return View(proveedor);
        }

        [HttpPost]
        public ActionResult Create(T_proveedores proveedor)
        {
            string response;
            response = proveedorBLL.Add(proveedor);
            return RedirectToAction("Index", "Proveedor");
        }

        [Authorize(Roles = "Administrador")]
        public ActionResult Edit(ProveedorViewModel proveedor)
        {

            return View(proveedor);
        }

        [HttpPost]
        public ActionResult Edit(T_proveedores proveedor)
        {
            proveedorBLL.Update(proveedor);
            return RedirectToAction("Index", "Proveedor");
        }

        public ActionResult Details(ProveedorViewModel proveedor)
        {
            return View(proveedor);
        }

        [Authorize(Roles = "Administrador")]
        public ActionResult Delete(ProveedorViewModel proveedor)
        {
            T_proveedores proveedores;
            proveedores = MapeoFromProveedorVM(proveedor);
            proveedorBLL.Remove(proveedores);
            return RedirectToAction("Index", "Proveedor");

        }
    }
}