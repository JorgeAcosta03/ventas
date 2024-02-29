using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplicationVentas.Models;

namespace WebApplicationVentas.Controllers
{
    public class ClientesController : ApiController
    {
        public HttpResponseMessage Get()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Venta"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SPSclientes";
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

        public string Post(Clientes cl)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Venta"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SPIclientes";
                cmd.Parameters.AddWithValue("@nombre", cl.nombre);
                cmd.Parameters.AddWithValue("@email", cl.email);
                cmd.Parameters.AddWithValue("@telefono", cl.telefono);
                cmd.Parameters.AddWithValue("@direccion", cl.direccion);
                cmd.Connection = conn;
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                return "Satisfactorio";
            }
        }

        public string Put(Clientes cl)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Venta"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SPUclientes";
                cmd.Parameters.AddWithValue("@id_cliente", cl.id_cliente);
                cmd.Parameters.AddWithValue("@nombre", cl.nombre);
                cmd.Parameters.AddWithValue("@email", cl.email);
                cmd.Parameters.AddWithValue("@telefono", cl.telefono);
                cmd.Parameters.AddWithValue("@direccion", cl.direccion);
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
                    delete from dbo.Clientes 
                    where id_cliente=" + id + @"
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
