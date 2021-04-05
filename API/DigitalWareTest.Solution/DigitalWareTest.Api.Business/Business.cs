using DigitalWareTest.Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalWareTest.Api.Business
{
    public class Business
    {
        #region Atributos

        private static Business _instance = null;
        private DateTime DateTimeLastValidation { get; set; }

        #endregion

        #region [ Public Methods Instance ]

        /// <summary>
        /// Generación del constructor de la clase y validación de la instancia y condiciones de manejo.
        /// </summary>
        public static Business Instance
        {
            get
            {
                if (_instance == null || _instance.ValidateDate(_instance.DateTimeLastValidation))
                {
                    _instance = new Business();
                }

                return _instance;
            }
        }

        #endregion

        #region [ Private Methods ]

        /// <summary>
        /// Permite la validación de fechas del último cargue de datos, y asi es posible reactualizar cada hora con el lanzamiento de una transacción. 
        /// </summary>
        /// <param name="date">Fecha del ultimo cargue de datos.</param>
        /// <returns>validación de necesidad de actualización.</returns>
        private bool ValidateDate(DateTime date)
        {
            int hours = (int)(DateTime.Now - (date)).TotalHours;
            return (hours > 0 || hours < 0);
        }

        #endregion

        #region [ Get Methods ]

        public List<Client> GetClientesCompras() {
            try
            {
                return DigitalWareTest.Api.Data.DataAcces.Instance.GetClientesCompras();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Product> GetPreciosProductos() {
            try
            {
                return DigitalWareTest.Api.Data.DataAcces.Instance.GetPreciosProductos();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Product> GetProductosExistenciaMinima() {
            try
            {
                return DigitalWareTest.Api.Data.DataAcces.Instance.GetProductosExistenciaMinima();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Product> GetProductosValorTotalVendido() {
            try
            {
                return DigitalWareTest.Api.Data.DataAcces.Instance.GetProductosValorTotalVendido();
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region [ Insert Methods]

        public int Insert_Factura(EncabezadoFactura _encabezadoFactura, List<DetalleFactura> _detalleFactura) {
            try
            {
                int _IdEncabezado = DigitalWareTest.Api.Data.DataAcces.Instance.Insert_Encabezado(_encabezadoFactura);
                if (_IdEncabezado > 0) {
                    _detalleFactura.ForEach(item => {
                        DigitalWareTest.Api.Data.DataAcces.Instance.Insert_Detalle(item);
                    });
                }

                return _IdEncabezado;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion
    }
}
