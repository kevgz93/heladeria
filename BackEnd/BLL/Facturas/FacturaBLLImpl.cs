using BackEnd.BLL.Generic;
using BackEnd.DAL.Generic;
using BackEnd.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.BLL.Facturas
{
    public class FacturaBLLImpl : BLLGenericoImpl<T_facturas>, IFacturaBLL
    {

        private UnidadDeTrabajo<T_facturas> unidad;
        private HeladeriaContext context;

        public List<T_facturas> buscarFacturasAnuladas()
        {
            try
            {
                List<T_facturas> resultado;
                using (unidad = new UnidadDeTrabajo<T_facturas>(new HeladeriaContext()))
                {
                    Expression<Func<T_facturas, bool>> consulta = (d => d.estado == "Anulada");
                    resultado = unidad.genericDAL.Find(consulta).ToList();
                }
                return resultado;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<T_facturas> buscarFacturasCorrectas()
        {
            try
            {
                List<T_facturas> resultado;
                using (unidad = new UnidadDeTrabajo<T_facturas>(new HeladeriaContext()))
                {
                    Expression<Func<T_facturas, bool>> consulta = (d => d.estado == "Correcta");
                    resultado = unidad.genericDAL.Find(consulta).ToList();
                }
                return resultado;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<T_facturas> buscarPorFecha(DateTime fecha)
        {
            try
            {
                List<T_facturas> resultado;
                using (unidad = new UnidadDeTrabajo<T_facturas>(new HeladeriaContext()))
                {
                    Expression<Func<T_facturas, bool>> consulta = (d => d.fecha == fecha);
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

