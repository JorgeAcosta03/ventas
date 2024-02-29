using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

using WebApplicationVentas.Models;

namespace WebApplicationVentas.Controllers
{
    public class ProductosController : ApiController
    {
        public HttpResponseMessage Get()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Venta"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SPSproductos";
                cmd.Connection = conn;
                conn.Open();
                DataTable table = new DataTable();
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                    conn.Close();
                }
                return Request.CreateResponse(HttpStatusCode.OK, table);
            }
        }

        public string Post(Productos pd)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Venta"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SPIproductos";
                cmd.Parameters.AddWithValue("@nombre", pd.nombre);
                cmd.Parameters.AddWithValue("@descripcion", pd.descripcion);
                cmd.Parameters.AddWithValue("@precio", pd.precio);
                cmd.Parameters.AddWithValue("@stock", pd.stock);
                cmd.Parameters.AddWithValue("@categoria", pd.categoria);
                cmd.Connection = conn;
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                return "Satisfactorio";
            }
        }

        public string Put(Productos pd)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Venta"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SPUproductos";
                cmd.Parameters.AddWithValue("@id_producto", pd.id_producto);
                cmd.Parameters.AddWithValue("@nombre", pd.nombre);
                cmd.Parameters.AddWithValue("@descripcion", pd.descripcion);
                cmd.Parameters.AddWithValue("@precio", pd.precio);
                cmd.Parameters.AddWithValue("@stock", pd.stock);
                cmd.Parameters.AddWithValue("@categoria", pd.categoria);
                cmd.Connection = conn;
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                return "Satisfactorio";
            }
        }


        public string Delete(int id)
        {
            try
            {
                string query = @"
                    delete from dbo.Productos
                    where id_producto=" + id + @"
                    ";

                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["Venta"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }

                return "Satisfactorio";
            }
            catch (Exception)
            {

                return "Error de Eliminación";
            }
        }

    }
}
