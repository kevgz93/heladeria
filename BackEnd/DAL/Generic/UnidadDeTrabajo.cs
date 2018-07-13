using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackEnd.Model;

namespace BackEnd.DAL.Generic
{
    public class UnidadDeTrabajo<T> : IDisposable where T : class
    {
        private readonly HeladeriaContext context;
        //public IDALGenerico<Queja> quejaDAL;
        //public IDALGenerico<TablaGeneral> tablaDAL;
        public IDALGenerico<T> genericDAL;


        public UnidadDeTrabajo(HeladeriaContext _context)
        {
            context = _context;
            genericDAL = new DALGenericoImpl<T>(context);
            //    quejaDAL = new DALGenericoImpl<Queja>(context);
            //    tablaDAL = new DALGenericoImpl<TablaGeneral>(context);
        }

        public void Complete()
        {
            context.SaveChanges();
        }


        public void Dispose()
        {
            context.Dispose();
        }
    }
}
