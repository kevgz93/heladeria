using BackEnd.DAL;
using BackEnd.BLL.Generic;
using BackEnd.DAL.Generic;
using BackEnd.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.BLL
{
    public class UserBLLImpl : BLLGenericoImpl<User>, IUserBLL
    {
        private UnidadDeTrabajo<User> unidad;
        private HeladeriaContext context;
        public bool eliminar(string idRole, int idUsuario)
        {
            throw new NotImplementedException();
        }

        public string[] gerRolesForUser(string userName)
        {
            string[] result;
            using (context = new HeladeriaContext())
            {
                result = context.sp_getRolesForUser(userName).ToArray();
            }
            
            
            return result;

        }

        public User get(int id)
        {
            throw new NotImplementedException();
        }

        public List<User> getAll()
        {
            return this.getAll();
        }

        public User getUser(string userName)
        {
            try
            {
                User resultado;
                using (unidad = new UnidadDeTrabajo<User>(new HeladeriaContext()))
                {
                    Expression<Func<User, bool>> consulta = (u => u.UserName.Equals(userName));
                    resultado = unidad.genericDAL.Find(consulta).ToList().FirstOrDefault();
                }
                return resultado;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public User getUser(string userName, string password)
        {
            try
            {
                User resultado;
                using (unidad = new UnidadDeTrabajo<User>(new HeladeriaContext()))
                {
                    Expression<Func<User, bool>> consulta = (u => u.UserName.Equals(userName) && u.Password.Equals(password));
                    resultado = unidad.genericDAL.Find(consulta).ToList().FirstOrDefault();
                }
                return resultado;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public User getUser(int EmpleadoId)
        {
            throw new NotImplementedException();
        }

        public List<User> getUsuariosRole(string roleName)
        {
            List<User> result = new List<User>();
            List<string> lista;

            using (context = new HeladeriaContext())
            {
                lista = context.sp_getUsuariosRole(roleName).ToList();
                User user;
                foreach (var item in lista)
                {
                    user = this.getUser(item);
                    result.Add(user);
                }


            }

            return result;
        }

        public bool insertar(int idRole, string login)
        {
            throw new NotImplementedException();
        }

        public bool insertar(string roleName, string login)
        {
            throw new NotImplementedException();
        }

        public bool isUserInRole(string userName, string roleName)
        {
            
            bool result = false;
            
            
            using (context = new HeladeriaContext())
            {
                result = context.sp_isUserInRole(userName, roleName) != 0;
                
            }
            
            return result;
        }

        public List<Role> listarRoles()
        {
            throw new NotImplementedException();
        }

        public User ObtenerPorID(int id)
        {
            throw new NotImplementedException();
        }
    }
}
