using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BackEnd.BLL.Personas;
using BackEnd.BLL;
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

            T_personas usuario = new T_personas();
            IPersonaBLL usuarioBLL = new PersonaBLLImpl();


            usuario.nombre = "Andres";
            usuario.apellido1 = "Zuñiga";
            usuario.apellido2 = "Umaña";
            usuario.cedula = "207820023";
            usuario.telefono = "85484223";
            usuario.correo = "andrezu1998@hotmail.es";
            usuario.sexo = "M";

            usuarioBLL.Add(usuario);
        }

        [TestMethod]
        public void BuscarUsuarioPorNombre()
        {

            List<T_personas> usuarios = new List<T_personas>();
            IPersonaBLL usuarioBLL = new PersonaBLLImpl();

            usuarios = usuarioBLL.buscarPorNombre("Mark");
        }

     

        [TestMethod]
        public void EliminarUsuario()
        {
            List<T_personas> usuarios = new List<T_personas>();
            IPersonaBLL usuarioBLL = new PersonaBLLImpl();

            usuarios = usuarioBLL.buscarPorNombre("11");

            foreach (T_personas usuario in usuarios)
            {
                if (usuario.apellido1 == "11")
                {
                    usuarioBLL.Remove(usuario);
                }
            }
            
        }


        [TestMethod]
        public void ModificarUsuario()
        {
            List<T_personas> usuarios = new List<T_personas>();
            IPersonaBLL usuarioBLL = new PersonaBLLImpl();

            usuarios = usuarioBLL.buscarPorNombre("Andres");

            foreach (T_personas usuario in usuarios)
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
