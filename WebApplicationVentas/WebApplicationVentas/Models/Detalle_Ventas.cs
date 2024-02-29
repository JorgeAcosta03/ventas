using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationVentas.Models
{
    public class Detalle_Ventas
    {
        public int id_venta { get; set; }
        public int id_producto { get; set; }
        public int cantidad { get; set; }
        public float precio_unitario{ get; set; }
        public float subtotal { get; set; }

    }
}