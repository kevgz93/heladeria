using BackEnd.BLL.Generic;
using BackEnd.BLL;
using BackEnd.DAL.Generic;
using BackEnd.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.BLL.Personas
{
    public class PersonaBLLImpl : BLLGenericoImpl<T_personas>, IPersonaBLL
    {
        private UnidadDeTrabajo<T_personas> unidad;
        private HeladeriaContext context;

        public List<T_personas> buscarPorCedula(string cedula)
        {
            try
            {
                List<T_personas> resultado;
                using (unidad = new UnidadDeTrabajo<T_personas>(new HeladeriaContext()))
                {
                    Expression<Func<T_personas, bool>> consulta = (d => d.cedula == cedula);
                    resultado = unidad.genericDAL.Find(consulta).ToList();
                }
                return resultado;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<T_personas> buscarPorNombre(string nombre)
        {
            try
            {
                List<T_personas> resultado;
                using (unidad = new UnidadDeTrabajo<T_personas>(new HeladeriaContext()))
                {
                    Expression<Func<T_personas, bool>> consulta = (d => d.nombre == nombre);
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
