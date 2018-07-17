using System;
using BackEnd.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BackEnd.BLL.Productos;
using System.Collections.Generic;

namespace UnitTests
{
    [TestClass]
    public class pruebasProducto
    {
        [TestMethod]
        public void agregarProducto()
        {

            T_productos producto = new T_productos();
            IProductoBLL productoBLL = new ProductoBLLImpl();
            DateTime fecha = new DateTime(2018, 11, 24, 11, 19, 10, 560);

            producto.nombre = "Nieve limon";
            producto.categoria = "Nieves";
            producto.cantidad = 2;
            producto.descripcion = "Nieve de limon";
            producto.fecha_ingreso = DateTime.Today;
            producto.fecha_vencimiento = fecha;
            producto.precio = 3000;
            producto.proveedor_id = 1;
            producto.estado = "Activo";

            productoBLL.Add(producto);
        }

        [TestMethod]
        public void buscarProductoPorNombre()
        {

            T_productos producto = new T_productos();
            IProductoBLL productoBLL = new ProductoBLLImpl();

            productoBLL.buscarPorNombre("Nieve Limon");
        }


        [TestMethod]
        public void eliminarProducto()
        {
            List<T_productos> productos = new List<T_productos>();
            IProductoBLL productoBLL = new ProductoBLLImpl();

            productos = productoBLL.buscarPorNombre("Nieve Limon");

            foreach (T_productos producto in productos)
            {
                if (producto.codigo == 7)
                {
                    productoBLL.Remove(producto);
                }
            }
        }


        [TestMethod]
        public void modificarProducto()
        {
            List<T_productos> productos = new List<T_productos>();
            IProductoBLL productoBLL = new ProductoBLLImpl();

            productos = productoBLL.buscarPorNombre("Nieve Limon");

            foreach (T_productos producto in productos)
            {
                if (producto.codigo == 8)
                {

                    producto.estado = "Agotado";

                    productoBLL.Update(producto);
                }
            }
        }
    }
}
