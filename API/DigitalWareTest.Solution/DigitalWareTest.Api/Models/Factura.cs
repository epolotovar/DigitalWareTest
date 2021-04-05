using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DigitalWareTest.Api.Models
{
    public class Factura
    {
        public int Id { get; set; }
        [Required]
        public int IdCliente { get; set; }
        [Required]
        public DateTime FechaFactura { get; set; }
        [Required]
        public decimal ValorTotal { get; set; }
        public List<DetalleFactura> Detalle { get; set; }
    }
}