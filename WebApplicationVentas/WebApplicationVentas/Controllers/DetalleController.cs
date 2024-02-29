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
    public class DetalleController : ApiController
    {
        [Route("api/Detalle/PostVenta")]
        [HttpPost]
        public string PostVenta(Ventas vt)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Venta"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SPabrir_factura";
                cmd.Parameters.AddWithValue("@id_cliente", vt.id_cliente);
                cmd.Parameters.AddWithValue("@id_vendedor", vt.id_vendedor);
                cmd.Parameters.AddWithValue("@id_zona", vt.id_zona);
                cmd.Connection = conn;
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                return "Satisfactorio";
            }
        }
        [Route("api/Detalle/PostDetalle")]
        [HttpPost]
        public string PostDetalle(Detalle_Ventas dv)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Venta"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SPsumar_Detalle";
                cmd.Parameters.AddWithValue("@id_producto", dv.id_producto);
                cmd.Parameters.AddWithValue("@cantidad", dv.cantidad);
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
