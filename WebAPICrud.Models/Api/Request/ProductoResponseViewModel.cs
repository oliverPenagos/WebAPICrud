using System;
using System.Collections.Generic;
using System.Text;

namespace WebAPICrud.Models.Api.Request
{
    public class ProductoResponseViewModel
    {
        internal string Mensaje;
        internal bool Exito;

        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int CantidadStock { get; set; }
        public int IdProveedor { get; set; }
        public string patito { get; set; }
    }
}
