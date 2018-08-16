using BackEnd.BLL.Generic;
using BackEnd.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.BLL
{
    public interface IUserBLL : IBLLGenerico<User>
    {

        bool insertar(int idRole, string login);
        bool insertar(string roleName, string login);
        bool insertar(User user);
        User getUser(string userName);
        User getUser(string userName, string password);
        User getUser(int EmpleadoId);
        User get(int id);
        List<User> getAll();
        bool isUserInRole(string userName, string roleName);
        string[] gerRolesForUser(string userName);
        List<User> getUsuariosRole(string roleName);
        List<Role> listarRoles();
        bool eliminar(string idRole, int idUsuario);
        User ObtenerPorID(int id);
    }
}
