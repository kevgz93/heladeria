using BackEnd.BLL.Generic;
using BackEnd.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.BLL.Facturas
{
    public interface IDetalleFacturaBLL : IBLLGenerico<T_detalle_factura>
    {

        List<T_detalle_factura> buscarPorFactura(int codigo);

    }
}
