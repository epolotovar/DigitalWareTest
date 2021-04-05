using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DigitalWareTest.Api.Models
{
    public class DetalleFactura
    {
        [Required]
        public int IdProduct { get; set; }
        [Required]
        public int Cantidad { get; set; }
    }
}