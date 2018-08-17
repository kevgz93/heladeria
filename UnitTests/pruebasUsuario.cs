using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BackEnd.BLL.Personas;
using BackEnd.BLL;
using BackEnd.Model;
using System.Collections.Generic;
using BackEnd.BLL.Login;

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


            usuario.nombre = "Kevin";
            usuario.apellido1 = "Guerrero";
            usuario.apellido2 = "Zamora";
            usuario.cedula = "115560648";
            usuario.telefono = "88596802";
            usuario.correo = "kguerreroz93@gmail.com";
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

            usuarios = usuarioBLL.buscarPorNombre("Andres");

            foreach (T_personas usuario in usuarios)
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

        [TestMethod]
        public void getRoleForUser()
        {
            string[] usuarios;
            IUserBLL usuarioBLL = new UserBLLImpl();

            usuarios = usuarioBLL.gerRolesForUser("kevin");

            

        }

        [TestMethod]
        public void addRoleForUser()
        {
            bool result;
            IUsersInRolesBLL usersInRolesBLL = new UsersInRolesBLLImpl();

            result = usersInRolesBLL.insertar(2, 2);



        }
    }
}
