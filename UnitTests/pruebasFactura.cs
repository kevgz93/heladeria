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
            T_detalle_factura detallefactura = new T_detalle_factura();
            IFacturaBLL facturaBLL = new FacturaBLLImpl();
            IDetalleFacturaBLL detallefacturaBLL = new DetalleFacturaBLLImpl();

            factura.fecha = DateTime.Today;
            factura.usuario_id = 1;
            factura.total = 3000;
            factura.descuento = 0;
            factura.estado = "Correcta";
            facturaBLL.Add(factura);

            detallefactura.cantidad = 1;
            detallefactura.factura_numero = 1;
            detallefactura.producto_codigo = 1;
            detallefactura.precio = 3000;

        }
    }
}
