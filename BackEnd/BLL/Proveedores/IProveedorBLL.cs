using BackEnd.BLL.Generic;
using BackEnd.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.BLL.Proveedores
{
    public interface IProveedorBLL : IBLLGenerico<T_proveedores>
    {

        List<T_proveedores> buscarPorNombre(string nombre);
        List<T_proveedores> buscarPorCedula(string cedula);

    }
}
