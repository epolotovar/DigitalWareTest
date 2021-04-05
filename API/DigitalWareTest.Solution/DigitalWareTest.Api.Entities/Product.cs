using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalWareTest.Api.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Reference { get; set; }
        public string Description { get; set; }
        public int Existencia { get; set; }
        public decimal Precio { get; set; }
    }
}
