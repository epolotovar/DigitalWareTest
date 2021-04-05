using DigitalWareTest.Api.Entities;
using DigitalWareTest.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigitalWareTest.Api.Util
{
    public static class Transform
    {
        public static EncabezadoFactura ModelToEncabezado(Factura _factura) {
            return new EncabezadoFactura()
            {
                IdCliente = _factura.IdCliente,
                FechaFactura = _factura.FechaFactura,
                ValorTotal = _factura.ValorTotal
            };
        }

        public static List<DigitalWareTest.Api.Entities.DetalleFactura> ModelToDetalle(Factura _factura)
        {
            List<DigitalWareTest.Api.Entities.DetalleFactura> _detalle = new List<DigitalWareTest.Api.Entities.DetalleFactura>(); 
            _factura.Detalle.ForEach(item => {
                _detalle.Add(new Entities.DetalleFactura() { 
                    IdProduct = item.IdProduct,
                    Cantidad = item.Cantidad
                });
            });

            return _detalle;
        }
    }
}