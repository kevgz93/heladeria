using BackEnd.BLL.Generic;
using BackEnd.DAL.Generic;
using BackEnd.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.BLL.Proveedores
{
    public class ProveedorBLLImpl : BLLGenericoImpl<T_proveedores>, IProveedorBLL
    {

        private UnidadDeTrabajo<T_proveedores> unidad;
        private HeladeriaContext context;

        public List<T_proveedores> buscarPorCedula(string cedula)
        {
            try
            {
                List<T_proveedores> resultado;
                using (unidad = new UnidadDeTrabajo<T_proveedores>(new HeladeriaContext()))
                {
                    Expression<Func<T_proveedores, bool>> consulta = (d => d.cedula == cedula);
                    resultado = unidad.genericDAL.Find(consulta).ToList();
                }
                return resultado;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<T_proveedores> buscarPorNombre(string nombre)
        {
            try
            {
                List<T_proveedores> resultado;
                using (unidad = new UnidadDeTrabajo<T_proveedores>(new HeladeriaContext()))
                {
                    Expression<Func<T_proveedores, bool>> consulta = (d => d.nombre == nombre);
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
