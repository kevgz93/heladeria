using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackEnd.BLL.Generic;
using BackEnd.Model;

namespace BackEnd.BLL.Usuarios
{
    public interface IUsuarioBLL : IBLLGenerico<T_usuarios>
    {

        List<T_usuarios> buscarPorNombre(string nombre);

        List<T_usuarios> buscarPorCedula(string cedula);

    }
}
