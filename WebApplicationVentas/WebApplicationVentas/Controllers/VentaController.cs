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
    public class VentaController : ApiController
    {
        public HttpResponseMessage Get()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Venta"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SPSventas";
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


        public string Post(Ventas vt)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Venta"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SPIventas";
                cmd.Parameters.AddWithValue("@id_cliente", vt.id_cliente);
                cmd.Parameters.AddWithValue("@id_vendedor", vt.id_vendedor);
                cmd.Parameters.AddWithValue("@id_zona", vt.id_zona);
                cmd.Parameters.AddWithValue("@fecha", vt.fecha);
                cmd.Parameters.AddWithValue("@monto_total", vt.monto_total);
                cmd.Connection = conn;
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                return "Satisfactorio";
            }
        }

        public string Put(Ventas vt)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Venta"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SPUventas";
                cmd.Parameters.AddWithValue("@id_venta", vt.id_venta);
                cmd.Parameters.AddWithValue("@id_cliente", vt.id_cliente);
                cmd.Parameters.AddWithValue("@id_vendedor", vt.id_vendedor);
                cmd.Parameters.AddWithValue("@id_zona", vt.id_zona);
                cmd.Parameters.AddWithValue("@fecha", vt.fecha);
                cmd.Parameters.AddWithValue("@monto_total", vt.monto_total);
                cmd.Connection = conn;
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                return "Satisfactorio";
            }
        }

        public string Delete(Ventas vt)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Venta"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SPDventas";
                cmd.Parameters.AddWithValue("@id_venta", vt.id_venta);
                cmd.Connection = conn;
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                return "Satisfactorio";
            }
        }

        [Route("api/Venta/GetZonasxVentas")]
        [HttpGet]
        public HttpResponseMessage GetZonasxVentas()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Venta"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SPCantidadZonas";
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

        [Route("api/Venta/GetZonasSinVentas")]
        [HttpGet]
        public HttpResponseMessage GetZonasSinVentas(Ventas v)
        {
            string query = @"select z.nombre_zona
                    from Zonas z
                    where not exists (select id_vendedor
					from Ventas v
					where z.id_zona=v.id_zona
					and v.fecha between '" + v.fecha1 + @"' and '" + v.fecha2+ @"'); ";
            DataTable table = new DataTable();
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["Venta"].ConnectionString))
            using (var cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }
            return Request.CreateResponse(HttpStatusCode.OK, table);
        }

        [Route("api/Venta/GetVendedorSinVentas")]
        [HttpGet]
        public HttpResponseMessage GetVendedorSinVentas(Ventas v)
        {
            string query = @"select vend.nombre
                    from Vendedores vend
                    where not exists (select id_vendedor
					from Ventas v
					where vend.id_vendedor=v.id_vendedor
					and v.fecha between '" + v.fecha1 + @"' and '" + v.fecha2 + @"'); ";
            DataTable table = new DataTable();
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["Venta"].ConnectionString))
            using (var cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }
            return Request.CreateResponse(HttpStatusCode.OK, table);
        }


        [Route("api/Venta/GetVentasxCliente")]
        [HttpGet]
        public HttpResponseMessage GetVentasxCliente(Ventas v)
        {
            string query = @"select c.id_cliente,c.nombre,z.nombre_zona,count(v.id_venta) as Numero_Ventas,v.fecha
                    from Ventas v, Clientes c, Zonas z
                    where c.id_cliente=v.id_cliente
					and z.id_zona=v.id_zona
					and v.fecha between '" + v.fecha1 + @"' and '" + v.fecha2 + @"'
                    group by v.id_venta, c.id_cliente, c.nombre,z.nombre_zona,v.fecha; ";
            DataTable table = new DataTable();
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["Venta"].ConnectionString))
            using (var cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }
            return Request.CreateResponse(HttpStatusCode.OK, table);
        }
    }
}
