using BackEnd.BLL.Generic;
using BackEnd.DAL.Generic;
using BackEnd.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.BLL.Facturas.Anulaciones
{
    public class AnulacionBLLImpl : BLLGenericoImpl<T_anulaciones>, IAnulacionBLL
    {

        private UnidadDeTrabajo<T_facturas> unidad;
        private UnidadDeTrabajo<T_anulaciones> unidadAnulacion;
        private HeladeriaContext context;


        public void anularFacturaPorFactura(T_facturas factura, T_anulaciones anulacion)
        {
            try
            {
                using (unidad = new UnidadDeTrabajo<T_facturas>(new HeladeriaContext()))
                {
                    unidad.genericDAL.Update(factura);
                    unidad.Complete();
                }
                using (unidadAnulacion = new UnidadDeTrabajo<T_anulaciones>(new HeladeriaContext()))
                {
                    unidadAnulacion.genericDAL.Add(anulacion);
                    unidadAnulacion.Complete();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
