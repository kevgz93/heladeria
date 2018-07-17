using System;
using BackEnd.BLL.Facturas;
using BackEnd.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class pruebasFactura
    {
        [TestMethod]
        public void agregarFactura()
        {
            T_facturas factura = new T_facturas();
            IFacturaBLL facturaBLL = new FacturaBLLImpl();

            

        }
    }
}
