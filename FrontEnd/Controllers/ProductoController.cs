using BackEnd.BLL.Productos;
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
    public class ProductoController : Controller
    {
        private IProductoBLL productoBLL;
        private IProveedorBLL proveedorBLL;

        public List<ProductoViewModel> MapeoToProductoVM(List<T_productos> productos)
        {
            ProductoViewModel producto;
            List<ProductoViewModel> resultado = new List<ProductoViewModel>();
            foreach (var item in productos)
            {
                producto = new ProductoViewModel
                {
                    cantidad = item.cantidad,
                    categoria = item.categoria,
                    codigo = item.codigo,
                    descripcion = item.descripcion,
                    estado = item.estado,
                    fecha_ingreso = item.fecha_ingreso,
                    fecha_vencimiento = item.fecha_vencimiento,
                    nombre = item.nombre,
                    precio = item.precio,
                    proveedor_id = item.proveedor_id


                };
                resultado.Add(producto);
            }
            return resultado;
        }

        public T_productos MapeoFromProductoVM(ProductoViewModel productoVM)
        {
            T_productos producto;


            producto = new T_productos()
            {
                cantidad = productoVM.cantidad,
                categoria = productoVM.categoria,
                codigo = productoVM.codigo,
                descripcion = productoVM.descripcion,
                estado = productoVM.estado,
                fecha_ingreso = productoVM.fecha_ingreso,
                fecha_vencimiento = productoVM.fecha_vencimiento,
                nombre = productoVM.nombre,
                precio = productoVM.precio,
                proveedor_id = productoVM.proveedor_id

            };


            return producto;
        }

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


        public ProductoController()
        {
            productoBLL = new ProductoBLLImpl();
            proveedorBLL = new ProveedorBLLImpl();
        }
        // GET: Address
        public ActionResult Index()
        {
            List<ProductoViewModel> productos;
            List<T_productos> Lista = productoBLL.GetAll();
            if (Lista == null)
            {
                productos = new List<ProductoViewModel>();
                TempData["msg"] = "<script>alert('There's no users to show');</script>";
                return View(productos);
            }
            productos = MapeoToProductoVM(Lista);
            return View(productos);
        }

        [Authorize(Roles = "Administrador")]
        public ActionResult Create()
        {
            ProductoViewModel producto = new ProductoViewModel();


            List<ProveedorViewModel> proveedores = new List<ProveedorViewModel>();
            proveedores = MapeoToProveedorVM(proveedorBLL.GetAll());
            producto.Proveedores = proveedores;
            return View(producto);
        }

        [HttpPost]
        public ActionResult Create(T_productos producto)
        {
            string response;
            response = productoBLL.Add(producto);
            return RedirectToAction("Index", "Producto");
        }

        [Authorize(Roles = "Administrador")]
        public ActionResult Edit(ProductoViewModel producto)
        {
            List<ProveedorViewModel> proveedores = new List<ProveedorViewModel>();
            proveedores = MapeoToProveedorVM(proveedorBLL.GetAll());
            producto.Proveedores = proveedores;
            return View(producto);
        }

        [HttpPost]
        public ActionResult Edit(T_productos producto)
        {
            productoBLL.Update(producto);
            return RedirectToAction("Index", "Producto");
        }

        public ActionResult Details(ProductoViewModel producto)
        {
            return View(producto);
        }

        [Authorize(Roles = "Administrador")]
        public ActionResult Delete(ProductoViewModel productoVM)
        {
            T_productos producto;
            producto = MapeoFromProductoVM(productoVM);
            productoBLL.Remove(producto);
            return RedirectToAction("Index", "Producto");

        }
    }
}