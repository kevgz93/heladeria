using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.BLL.Login
{
    public interface IUsersInRolesBLL
    {
        bool insertar(int userId, int roleId);
        bool update(int userId, int roleId);
    }
}
