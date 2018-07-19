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
            factura.total = 4000;
            factura.descuento = 0;
            factura.estado = "Correcta";
            facturaBLL.Add(factura);

            detallefactura.cantidad = 1;
            detallefactura.factura_numero = 2;
            detallefactura.producto_codigo = 1;
            detallefactura.precio = 3000;

            detallefacturaBLL.Add(detallefactura);

            detallefactura.cantidad = 1;
            detallefactura.factura_numero = 2;
            detallefactura.producto_codigo = 2;
            detallefactura.precio = 1000;


            detallefacturaBLL.Add(detallefactura);
        }


        [TestMethod]
        public void buscarFacturas()
        {
            T_facturas factura = new T_facturas();
            IFacturaBLL facturaBLL = new FacturaBLLImpl();

            facturaBLL.buscarFacturasAnuladas();
            facturaBLL.buscarFacturasCorrectas();
        }
    }
}
