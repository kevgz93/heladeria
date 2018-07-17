using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BackEnd.BLL.Generic;
using BackEnd.DAL.Generic;
using BackEnd.Model;

namespace BackEnd.BLL.Facturas
{
    public class DetalleFacturaBLLImpl : BLLGenericoImpl<T_detalle_factura>, IDetalleFacturaBLL
    {
        private UnidadDeTrabajo<T_detalle_factura> unidad;
        private HeladeriaContext context;

        public List<T_detalle_factura> buscarPorFactura(int codigo)
        {
            try
            {
                List<T_detalle_factura> resultado;
                using (unidad = new UnidadDeTrabajo<T_detalle_factura>(new HeladeriaContext()))
                {
                    Expression<Func<T_detalle_factura, bool>> consulta = (d => d.factura_numero == codigo);
                    resultado = unidad.genericDAL.Find(consulta).ToList();
                }
                return resultado;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
