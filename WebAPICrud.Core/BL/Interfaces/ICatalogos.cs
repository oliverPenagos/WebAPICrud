using System;
using System.Collections.Generic;
using System.Text;
using WebAPICrud.Models.Api.Request;
using WebAPICrud.Models.Api.Response;

namespace WebAPICrud.Core.BL.Interfaces
{
    public interface ICatalogos
    {
        Task<List<ProductosResponseViewModel>> ObtenerProductos();

        Task<ProductoResponseViewModel> GuardarProducto(ProductoResponseViewModel P);

        Task<ProductoResponseViewModel> EliminarProducto(int idProducto);

        Task<ProductoResponseViewModel> EditarProducto(int idProducto, string nombre, decimal precio, int cantidadStock, int idProveedor);

    }
}
