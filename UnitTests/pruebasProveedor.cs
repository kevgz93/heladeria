using System;
using BackEnd.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BackEnd.BLL.Proveedores;
using System.Collections.Generic;

namespace UnitTests
{
    [TestClass]
    public class pruebasProveedor
    {
        [TestMethod]
        public void agregarProveedor()
        {
            T_proveedores proveedor = new T_proveedores();
            IProveedorBLL proveedorBLL = new ProveedorBLLImpl();

            proveedor.nombre = "Dos Pinos";
            proveedor.correo = "contacto@dospinos.com";
            proveedor.cedula = "123456789";
            proveedor.direccion = "Alajuela,Alajuela";
            proveedor.telefono = "12312321312";

            proveedorBLL.Add(proveedor);
        }

        [TestMethod]
        public void buscarProveedorPorNombre()
        {
            T_proveedores proveedor = new T_proveedores();
            IProveedorBLL proveedorBLL = new ProveedorBLLImpl();
            List<T_proveedores> proveedores = new List<T_proveedores>();

            proveedores = proveedorBLL.buscarPorNombre("Dos Pinos");

        }


        [TestMethod]
        public void eliminarProveedor()
        {
            IProveedorBLL proveedorBLL = new ProveedorBLLImpl();
            List<T_proveedores> proveedores = new List<T_proveedores>();

            proveedores = proveedorBLL.buscarPorNombre("Dos Pinos");

            foreach(T_proveedores proveedor in proveedores)
            {

                if (proveedor.cedula == "123456789")
                {
                    proveedorBLL.Remove(proveedor);
                }

            }

        }


        [TestMethod]
        public void modificarProveedor()
        {
            IProveedorBLL proveedorBLL = new ProveedorBLLImpl();
            List<T_proveedores> proveedores = new List<T_proveedores>();

            proveedores = proveedorBLL.buscarPorNombre("Dos Pinos");

            foreach (T_proveedores proveedor in proveedores)
            {

                if (proveedor.cedula == "123456789")
                {
                    proveedor.telefono = "10203040";


                    proveedorBLL.Update(proveedor);
                }

            }

        }
    }
}
