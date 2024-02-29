using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationVentas.Models
{
    public class Ventas
    {
        public int id_venta { get; set; }
        public int id_cliente { get; set; }
        public int id_vendedor { get; set; }
        public int id_zona { get; set; }
        public string fecha { get; set; }
        public float monto_total { get; set; }

        public string fecha1 { get; set; }
        public string fecha2 { get; set; }
    }
}