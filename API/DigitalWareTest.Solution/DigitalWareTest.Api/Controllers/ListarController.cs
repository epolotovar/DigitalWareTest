using DigitalWareTest.Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DigitalWareTest.Api.Controllers
{
    public class ListarController : ApiController
    {
        // GET: api/Listar/Clientes
        [HttpGet]
        public IEnumerable<Client> GetClientesCompras()
        {
            try
            {
                return DigitalWareTest.Api.Business.Business.Instance.GetClientesCompras();
            }
            catch (Exception)
            {
                throw;
            }
        }

        // GET: api/Listar/Productos
        [HttpGet]
        public IEnumerable<Product> GetPreciosProductos()
        {
            try
            {
                return DigitalWareTest.Api.Business.Business.Instance.GetPreciosProductos();
            }
            catch (Exception)
            {
                throw;
            }
        }

        // GET: api/Listar
        [HttpGet]
        public IEnumerable<Product> GetExistenciaMinima()
        {
            try
            {
                return DigitalWareTest.Api.Business.Business.Instance.GetProductosExistenciaMinima();
            }
            catch (Exception)
            {
                throw;
            }
        }

        // GET: api/Listar
        [HttpGet]
        public IEnumerable<Product> GetValorTotalVendidoXProducto()
        {
            try
            {
                return DigitalWareTest.Api.Business.Business.Instance.GetProductosValorTotalVendido();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
