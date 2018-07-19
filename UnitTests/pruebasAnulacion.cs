using System;
using BackEnd.BLL.Facturas;
using BackEnd.BLL.Facturas.Anulaciones;
using BackEnd.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class pruebasAnulacion
    {
        [TestMethod]
        public void anularFactura()
        {
            T_facturas factura = new T_facturas();
            T_anulaciones anulacion = new T_anulaciones();
            IFacturaBLL facturaBLL = new FacturaBLLImpl();
            IAnulacionBLL anulacionBLL = new AnulacionBLLImpl();

            factura = facturaBLL.Get(2);
            factura.estado = "Anulada";

            anulacion.fecha = DateTime.Today;
            anulacion.comentario = "Anulada porque si";
            anulacion.factura_numero = factura.numero_factura;
            anulacion.usuario_id = 1;

            anulacionBLL.anularFacturaPorFactura(factura, anulacion);
        }
    }
}
