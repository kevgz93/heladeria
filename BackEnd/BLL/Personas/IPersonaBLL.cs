using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackEnd.BLL.Generic;
using BackEnd.Model;

namespace BackEnd.BLL.Personas
{
    public interface IPersonaBLL : IBLLGenerico<T_personas>
    {

        List<T_personas> buscarPorNombre(string nombre);

        List<T_personas> buscarPorCedula(string cedula);

    }
}
