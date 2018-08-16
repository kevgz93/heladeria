using BackEnd.BLL.Generic;
using BackEnd.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.BLL.Login
{
    public class UsersInRolesBLLImpl : IUsersInRolesBLL
    {
        private HeladeriaContext context;
        public bool insertar(int userId, int roleId)
        {
            int result;

            using (context = new HeladeriaContext())
            {
                result = context.sp_AddUsersInRoles(userId, roleId);
            }

            if(result == 1)
            {
                return true;
            }

            return false;
            
        }

        public bool update(int userId, int roleId)
        {
            int result;

            using (context = new HeladeriaContext())
            {
                result = context.sp_updateRoleByUser(userId, roleId);
            }

            if (result == 1)
            {
                return true;
            }

            return false;
        }
    }
}
