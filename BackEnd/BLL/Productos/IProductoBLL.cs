using BackEnd.BLL.Generic;
using BackEnd.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.BLL.Productos
{
    public interface IProductoBLL : IBLLGenerico<T_productos>
    {

        List<T_productos> buscarPorNombre(string nombre);
        List<T_productos> buscarPorCategoria(string nombreCat);

    }
}
