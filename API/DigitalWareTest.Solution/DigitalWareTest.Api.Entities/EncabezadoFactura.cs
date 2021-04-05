using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalWareTest.Api.Entities
{
    public class EncabezadoFactura
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public DateTime FechaFactura { get; set; }
        public decimal ValorTotal { get; set; }
    }
}
