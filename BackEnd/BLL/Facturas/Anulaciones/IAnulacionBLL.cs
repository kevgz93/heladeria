using BackEnd.BLL.Generic;
using BackEnd.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.BLL.Facturas.Anulaciones
{
    public interface IAnulacionBLL : IBLLGenerico<T_anulaciones>
    {

        void anularFacturaPorFactura(T_facturas factura, T_anulaciones anulacion);

    }
}
