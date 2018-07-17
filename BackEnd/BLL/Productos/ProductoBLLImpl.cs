using BackEnd.BLL.Generic;
using BackEnd.DAL.Generic;
using BackEnd.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.BLL.Productos
{
    public class ProductoBLLImpl : BLLGenericoImpl<T_productos>, IProductoBLL
    {

        private UnidadDeTrabajo<T_productos> unidad;
        private HeladeriaContext context;

        public List<T_productos> buscarPorNombre(string nombre)
        {
            try
            {
                List<T_productos> resultado;
                using (unidad = new UnidadDeTrabajo<T_productos>(new HeladeriaContext()))
                {
                    Expression<Func<T_productos, bool>> consulta = (d => d.nombre == nombre);
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
