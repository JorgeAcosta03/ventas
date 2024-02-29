using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationVentas.Models
{
    public class Clientes
    {
        public int id_cliente { get; set; }
        public string nombre { get; set; }

        public string email { get; set; }
        public string telefono { get; set; }
        public string direccion { get; set; }
    }
}