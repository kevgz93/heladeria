using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BackEnd.BLL.Usuarios;
using BackEnd.Model;
using System.Collections.Generic;

namespace UnitTests
{
    [TestClass]
    public class pruebasUsuario
    {
        [TestMethod]
        public void AgregarUsuario()
        {

            T_usuarios usuario = new T_usuarios();
            IUsuarioBLL usuarioBLL = new UsuarioBLLImpl();


            usuario.nombre = "Andres";
            usuario.apellido1 = "Zuñiga";
            usuario.apellido2 = "Umaña";
            usuario.cedula = "207820023";
            usuario.telefono = "85484223";
            usuario.correo = "andrezu1998@hotmail.es";
            usuario.sexo = "M";
            usuario.tipo = "admin";

            usuarioBLL.Add(usuario);
        }

        [TestMethod]
        public void BuscarUsuarioPorNombre()
        {

            List<T_usuarios> usuarios = new List<T_usuarios>();
            IUsuarioBLL usuarioBLL = new UsuarioBLLImpl();

            usuarios = usuarioBLL.buscarPorNombre("Andres");
        }

        [TestMethod]
        public void EliminarUsuario()
        {
            List<T_usuarios> usuarios = new List<T_usuarios>();
            IUsuarioBLL usuarioBLL = new UsuarioBLLImpl();

            usuarios = usuarioBLL.buscarPorNombre("Andres");

            foreach (T_usuarios usuario in usuarios)
            {
                if (usuario.apellido1 == "Zuñiga")
                {
                    usuarioBLL.Remove(usuario);
                }
            }
            
        }


        [TestMethod]
        public void ModificarUsuario()
        {
            List<T_usuarios> usuarios = new List<T_usuarios>();
            IUsuarioBLL usuarioBLL = new UsuarioBLLImpl();

            usuarios = usuarioBLL.buscarPorNombre("Andres");

            foreach (T_usuarios usuario in usuarios)
            {
                if (usuario.apellido1 == "Zuñiga")
                {
                    usuario.telefono = "85484223";

                    usuarioBLL.Update(usuario);
                }
            }

        }
    }
}
