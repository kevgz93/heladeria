using BackEnd.BLL.Generic;
using BackEnd.DAL.Generic;
using BackEnd.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.BLL.Usuarios
{
    public class UsuarioBLLImpl : BLLGenericoImpl<T_usuarios>, IUsuarioBLL
    {
        private UnidadDeTrabajo<T_usuarios> unidad;
        private HeladeriaContext context;

        public List<T_usuarios> buscarPorCedula(string cedula)
        {
            try
            {
                List<T_usuarios> resultado;
                using (unidad = new UnidadDeTrabajo<T_usuarios>(new HeladeriaContext()))
                {
                    Expression<Func<T_usuarios, bool>> consulta = (d => d.cedula == cedula);
                    resultado = unidad.genericDAL.Find(consulta).ToList();
                }
                return resultado;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<T_usuarios> buscarPorNombre(string nombre)
        {
            try
            {
                List<T_usuarios> resultado;
                using (unidad = new UnidadDeTrabajo<T_usuarios>(new HeladeriaContext()))
                {
                    Expression<Func<T_usuarios, bool>> consulta = (d => d.nombre == nombre);
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
