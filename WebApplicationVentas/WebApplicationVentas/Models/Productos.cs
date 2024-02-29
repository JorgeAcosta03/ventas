using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationVentas.Models
{
    public class Productos
    {
        public int id_producto { get; set; }
        public string nombre { get; set; }

        public string descripcion { get; set; }
        public float precio { get; set; }
        public int stock { get; set; }
        public string categoria { get; set; }
    }
}