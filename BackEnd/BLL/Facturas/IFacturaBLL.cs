using BackEnd.BLL.Generic;
using BackEnd.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.BLL.Facturas
{
    public interface IFacturaBLL : IBLLGenerico<T_facturas>
    {

        List<T_facturas> buscarPorFecha(DateTime fecha);

    }
}
