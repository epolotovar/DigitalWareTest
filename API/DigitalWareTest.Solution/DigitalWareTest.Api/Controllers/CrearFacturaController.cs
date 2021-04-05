using DigitalWareTest.Api.Models;
using DigitalWareTest.Api.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DigitalWareTest.Api.Controllers
{
    public class CrearFacturaController : ApiController
    {
        // POST: api/CrearFactura
        [HttpPost]
        public IHttpActionResult Enviar([FromBody]Factura value)
        {
            if (ModelState.IsValid) {
                try
                {
                    var _encabezado = Transform.ModelToEncabezado(value);
                    var _detalle = Transform.ModelToDetalle(value);
                    var _factura = DigitalWareTest.Api.Business.Business.Instance.Insert_Factura(_encabezado, _detalle);
                    return Ok(_factura);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            } else {
                return BadRequest("Información Invalida");
            }
        }
    }
}
