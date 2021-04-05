using DigitalWareTest.Api.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalWareTest.Api.Data
{
    public class DataAcces
    {
        #region Atributos

        private static DataAcces _instance = null;
        private DateTime DateTimeLastValidation { get; set; }

        #endregion

        #region [ Public Methods Instance ]

        /// <summary>
        /// Generación del constructor de la clase y validación de la instancia y condiciones de manejo.
        /// </summary>
        public static DataAcces Instance
        {
            get
            {
                if (_instance == null || _instance.ValidateDate(_instance.DateTimeLastValidation))
                {
                    _instance = new DataAcces();
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

        #region [ Get Metodos ]

        public List<Client> GetClientesCompras()
        {
            try
            {
                string SqlStringConnection = System.Configuration.ConfigurationManager.ConnectionStrings["BaseDatos"].ConnectionString;

                DataTable dt = new DataTable();
                List<Client> Registros = new List<Client>();
                using (SqlConnection Conn = new SqlConnection(SqlStringConnection))
                {
                    using (SqlDataAdapter Da = new SqlDataAdapter("Cons_ListarClientesCompras", Conn))
                    {
                        Da.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        Da.SelectCommand.Connection.Open();
                        Da.Fill(dt);
                        Da.SelectCommand.Connection.Close();
                    }
                }

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow item in dt.Rows)
                    {
                        Client Registro = new Client();
                        Registro.Id = (int)item["Id"];
                        Registro.Cedula = string.IsNullOrEmpty(item["Cedula"].ToString()) ? "" : (string)item["Cedula"];
                        Registro.Nombres = string.IsNullOrEmpty(item["Nombres"].ToString()) ? "" : (string)item["Nombres"];
                        Registro.Edad = (int)item["Edad"];
                        Registro.FechaFactura = Convert.ToDateTime(item["FechaFactura"]);

                        Registros.Add(Registro);
                    }
                }

                return Registros;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Product> GetPreciosProductos()
        {
            try
            {
                string SqlStringConnection = System.Configuration.ConfigurationManager.ConnectionStrings["BaseDatos"].ConnectionString;

                DataTable dt = new DataTable();
                List<Product> Registros = new List<Product>();
                using (SqlConnection Conn = new SqlConnection(SqlStringConnection))
                {
                    using (SqlDataAdapter Da = new SqlDataAdapter("Cons_ListarPreciosProductos", Conn))
                    {
                        Da.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        Da.SelectCommand.Connection.Open();
                        Da.Fill(dt);
                        Da.SelectCommand.Connection.Close();
                    }
                }

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow item in dt.Rows)
                    {
                        Product Registro = new Product();
                        Registro.Id = (int)item["Id"];
                        Registro.Reference = string.IsNullOrEmpty(item["Reference"].ToString()) ? "" : (string)item["Reference"];
                        Registro.Description = string.IsNullOrEmpty(item["Description"].ToString()) ? "" : (string)item["Description"];
                        Registro.Existencia = (int)item["existencia"];
                        Registro.Precio = (decimal)item["Precio"]; ;

                        Registros.Add(Registro);
                    }
                }

                return Registros;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Product> GetProductosExistenciaMinima ()
        {
            try
            {
                string SqlStringConnection = System.Configuration.ConfigurationManager.ConnectionStrings["BaseDatos"].ConnectionString;

                DataTable dt = new DataTable();
                List<Product> Registros = new List<Product>();
                using (SqlConnection Conn = new SqlConnection(SqlStringConnection))
                {
                    using (SqlDataAdapter Da = new SqlDataAdapter("Cons_ListarProductosExistenciaMinima", Conn))
                    {
                        Da.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        Da.SelectCommand.Connection.Open();
                        Da.Fill(dt);
                        Da.SelectCommand.Connection.Close();
                    }
                }

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow item in dt.Rows)
                    {
                        Product Registro = new Product();
                        Registro.Id = (int)item["Id"];
                        Registro.Reference = string.IsNullOrEmpty(item["Reference"].ToString()) ? "" : (string)item["Reference"];
                        Registro.Description = string.IsNullOrEmpty(item["Description"].ToString()) ? "" : (string)item["Description"];
                        Registro.Existencia = (int)item["existencia"];
                        Registro.Precio = (decimal)item["Precio"]; ;

                        Registros.Add(Registro);
                    }
                }

                return Registros;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Product> GetProductosValorTotalVendido()
        {
            try
            {
                string SqlStringConnection = System.Configuration.ConfigurationManager.ConnectionStrings["BaseDatos"].ConnectionString;

                DataTable dt = new DataTable();
                List<Product> Registros = new List<Product>();
                using (SqlConnection Conn = new SqlConnection(SqlStringConnection))
                {
                    using (SqlDataAdapter Da = new SqlDataAdapter("Cons_ListarValorTotalXProducto", Conn))
                    {
                        Da.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        Da.SelectCommand.Connection.Open();
                        Da.Fill(dt);
                        Da.SelectCommand.Connection.Close();
                    }
                }

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow item in dt.Rows)
                    {
                        Product Registro = new Product();
                        Registro.Id = (int)item["Id"];
                        Registro.Description = string.IsNullOrEmpty(item["Description"].ToString()) ? "" : (string)item["Description"];
                        Registro.Existencia = (int)item["existencia"];
                        Registro.Precio = (decimal)item["Valor"]; ;

                        Registros.Add(Registro);
                    }
                }

                return Registros;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region [ Insert Metodos ]

        public int Insert_Encabezado(EncabezadoFactura _encabezadoFactura)
        {
            try
            {
                string SqlStringConnection = System.Configuration.ConfigurationManager.ConnectionStrings["BaseDatos"].ConnectionString;
                int IdEncabezado = 0;
                using (SqlConnection Conn = new SqlConnection(SqlStringConnection))
                {
                    using (SqlCommand cmd = new SqlCommand("Ins_FacEncabezado", Conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@IdCliente", System.Data.SqlDbType.Int)).Value = _encabezadoFactura.IdCliente;
                        cmd.Parameters.Add(new SqlParameter("@FechaFactura", System.Data.SqlDbType.DateTime)).Value = _encabezadoFactura.FechaFactura;
                        cmd.Parameters.Add(new SqlParameter("@ValorTotal", System.Data.SqlDbType.Decimal)).Value = _encabezadoFactura.ValorTotal;
                        cmd.Parameters.Add(new SqlParameter("@Id", System.Data.SqlDbType.Int)).Direction = System.Data.ParameterDirection.Output;

                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                        IdEncabezado = (cmd.Parameters["@Id"].Value == null) ? -1 : Convert.ToInt32(cmd.Parameters["@Id"].Value.ToString());
                        cmd.Connection.Close();
                    }
                }

                return IdEncabezado;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void Insert_Detalle(DetalleFactura _detalleFactura)
        {
            try
            {
                string SqlStringConnection = System.Configuration.ConfigurationManager.ConnectionStrings["BaseDatos"].ConnectionString;

                using (SqlConnection Conn = new SqlConnection(SqlStringConnection))
                {
                    using (SqlCommand cmd = new SqlCommand("Ins_FacDetalleFactura", Conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@IdEncabezado", System.Data.SqlDbType.Int)).Value = _detalleFactura.IdEncabezado;
                        cmd.Parameters.Add(new SqlParameter("@IdProduct", System.Data.SqlDbType.Int)).Value = _detalleFactura.IdProduct;
                        cmd.Parameters.Add(new SqlParameter("@Cantidad", System.Data.SqlDbType.Int)).Value = _detalleFactura.Cantidad;

                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                        cmd.Connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #endregion

    }
}
