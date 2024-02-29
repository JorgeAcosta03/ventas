using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationVentas.Models
{
    public class Vendedores
    {

        public int id_vendedor { get; set; }
        public string nombre { get; set; }

        public string email { get; set; }
        public string telefono { get; set; }
        public string direccion { get; set; }
    }
}