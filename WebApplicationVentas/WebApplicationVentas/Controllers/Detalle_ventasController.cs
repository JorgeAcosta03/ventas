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
    public class Detalle_ventasController : ApiController
    {
        public HttpResponseMessage Get()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Venta"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SPSdetalles";
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


        public string Post(Detalle_Ventas dv)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Venta"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SPIdetalles";
                cmd.Parameters.AddWithValue("@id_venta", dv.id_venta);
                cmd.Parameters.AddWithValue("@id_producto", dv.id_producto);
                cmd.Parameters.AddWithValue("@cantidad", dv.cantidad);
                cmd.Parameters.AddWithValue("@precio_unitario", dv.precio_unitario);
                cmd.Parameters.AddWithValue("@subtotal", dv.subtotal);
                cmd.Connection = conn;
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                return "Satisfactorio";
            }
        }

        public string Put(Detalle_Ventas dv)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Venta"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SPUdetalles";
                cmd.Parameters.AddWithValue("@id_venta", dv.id_venta);
                cmd.Parameters.AddWithValue("@id_producto", dv.id_producto);
                cmd.Parameters.AddWithValue("@cantidad", dv.cantidad);
                cmd.Parameters.AddWithValue("@precio_unitario", dv.precio_unitario);
                cmd.Parameters.AddWithValue("@subtotal", dv.subtotal);
                cmd.Connection = conn;
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                return "Satisfactorio";
            }
        }


        public string Delete(Detalle_Ventas dv)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Venta"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SPDdetalles";
                cmd.Parameters.AddWithValue("@id_venta", dv.id_venta);
                cmd.Connection = conn;
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                return "Satisfactorio";
            }
        }

    }



}
