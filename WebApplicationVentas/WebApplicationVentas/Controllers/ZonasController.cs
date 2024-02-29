using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplicationVentas.Models;

namespace WebApplicationVentas.Controllers
{
    public class ZonasController : ApiController
    {
        public HttpResponseMessage Get()
        {
            using(SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Venta"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SPSZonas";
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
        public string Post(Zonas zn)
        {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Venta"].ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "SPIzonas";
                    cmd.Parameters.AddWithValue("@nombre_zona", zn.nombre_zona) ;
                    cmd.Parameters.AddWithValue("@descripcion", zn.descripcion);
                    cmd.Connection = conn;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    return "Satisfactorio";     
            }
        }
        public string Put(Zonas zn)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Venta"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SPUzonas";
                cmd.Parameters.AddWithValue("@id_zona", zn.id_zona);
                cmd.Parameters.AddWithValue("@nombre_zona", zn.nombre_zona);
                cmd.Parameters.AddWithValue("@descripcion", zn.descripcion);
                cmd.Connection = conn;
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                return "Satisfactorio";
            }
        }

        public string Delete(Zonas zn)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Venta"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SPDzonas";
                cmd.Parameters.AddWithValue("@id_zona", zn.id_zona);
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
                    delete from dbo.Zonas
                    where id_zona=" + id + @"
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

        //[Route("api/Zonas/GetZonasID")]
        //[HttpGet]
        //public List<ZonasSinVentas> GetZonasID(Zonas z)
        //{
        //    List<ZonasSinVentas> lista = new List<ZonasSinVentas>();
        //    string query = @"select nombre_zona from Zonas where id_zona=" + z.id_zona + @"";
        //    using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Venta"].ConnectionString))
        //    {
        //        conn.Open();
        //        using (var cmd = new SqlCommand(query, conn))
        //        {
        //            cmd.CommandType = CommandType.Text;
        //            using (var dr = cmd.ExecuteReader())
        //            {
        //                while (dr.Read())
        //                {
        //                    ZonasSinVentas zs = new ZonasSinVentas();
        //                    zs.nombre_zona = dr["nombre_zona"].ToString();
        //                    lista.Add(zs);
        //                }
        //            }
        //        }
        //        conn.Close();
        //        return lista;
        //    }
        //}
    }
}
