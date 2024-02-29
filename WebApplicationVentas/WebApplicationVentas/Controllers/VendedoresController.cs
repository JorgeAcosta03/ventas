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
    public class VendedoresController : ApiController
    {
        public HttpResponseMessage Get()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Venta"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SPSvendedores";
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

        public string Post(Vendedores vd)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Venta"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SPIvendedores";
                cmd.Parameters.AddWithValue("@nombre", vd.nombre);
                cmd.Parameters.AddWithValue("@email", vd.email);
                cmd.Parameters.AddWithValue("@telefono", vd.telefono);
                cmd.Parameters.AddWithValue("@direccion", vd.direccion);
                cmd.Connection = conn;
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                return "Satisfactorio";
            }
        }


        public string Put(Vendedores vd)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Venta"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SPUvendedores";
                cmd.Parameters.AddWithValue("@id_vendedor", vd.id_vendedor);
                cmd.Parameters.AddWithValue("@nombre", vd.nombre);
                cmd.Parameters.AddWithValue("@email", vd.email);
                cmd.Parameters.AddWithValue("@telefono", vd.telefono);
                cmd.Parameters.AddWithValue("@direccion", vd.direccion);
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
                    delete from dbo.Vendedores
                    where id_vendedor=" + id + @"
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
