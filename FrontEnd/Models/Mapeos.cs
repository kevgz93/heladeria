using BackEnd.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrontEnd.Models
{
    public class Mapeos
    {
        public ProductoViewModel mapearPaPVM(T_productos producto)
        {
            ProductoViewModel pe = new ProductoViewModel
            {
                codigo = producto.codigo,
                categoria = producto.categoria,
                nombre = producto.nombre,
                descripcion = producto.descripcion,
                precio = producto.precio,
                fecha_ingreso = producto.fecha_ingreso,
                fecha_vencimiento = producto.fecha_vencimiento,
                cantidad = producto.cantidad,
                estado = producto.estado,
                proveedor_id = producto.proveedor_id
            };
            return pe;
        }


    }
}