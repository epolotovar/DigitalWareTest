using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalWareTest.Api.Entities
{
    public class DetalleFactura
    {
        public int Id { get; set; }
        public int IdEncabezado { get; set; }
        public int IdProduct { get; set; }
        public int Cantidad { get; set; }
    }
}
