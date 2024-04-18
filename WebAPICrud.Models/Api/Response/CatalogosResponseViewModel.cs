using System;
using System.Collections.Generic;
using System.Text;

namespace WebAPICrud.Models.Api.Response
{
    public class ProductosResponseViewModel
    {
        public int id_producto { get; set; }
        public string nombre { get; set; }
        public decimal precio { get; set; }
        public int cantidad_stock { get; set; }
        public int IdProveedor { get; set; }


    }
}
