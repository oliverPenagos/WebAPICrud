using Microsoft.Build.Experimental.FileAccess;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using WebAPICrud.Core.BL.Interfaces;
using WebAPICrud.Core.Helpers;
using WebAPICrud.Models.Api.Request;
using WebAPICrud.Models.Api.Response;

namespace WebAPICrud.Core.BL.Service
{
    public class CatalogoService : ICatalogos
    {
        public async Task<List<ProductosResponseViewModel>> ObtenerProductos()
        {
            
            
                using (var conexion = new SqlConnection(Helpers.ContextConfiguration.ConexionString))
                {
                    List<ProductosResponseViewModel> n = new List<ProductosResponseViewModel>();

                    var command = new SqlCommand();
                    command.Connection = conexion;

                    command.CommandText = "[Catalogos].[ObtenerProductos]";
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    conexion.Open();

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (reader.Read())
                        {
                            try
                            {
                                n.Add(new ProductosResponseViewModel()
                                {
                                    id_producto = reader.GetInt32(reader.GetOrdinal("id_producto")),
                                    nombre = reader.GetString(reader.GetOrdinal("nombre")),
                                    precio = reader.GetDecimal(reader.GetOrdinal("precio")),
                                    cantidad_stock = reader.GetInt32(reader.GetOrdinal("cantidad_stock")),
                                    IdProveedor = reader.GetInt32(reader.GetOrdinal("IdProveedor")),

                                });
                            }
                            catch (Exception ex)
                            {
                                var valor = ex.Message.ToString();
                            }
                        }
                    }

                    conexion.Close();
                    return n;
                }
        }

        public async Task<ProductoResponseViewModel> GuardarProducto(ProductoResponseViewModel P)
        {

            using (var conexion = new SqlConnection(Helpers.ContextConfiguration.ConexionString))
            {
                ProductoResponseViewModel n = new ProductoResponseViewModel();

                var command = new SqlCommand();
                command.Connection = conexion;

                var idproductoParameters = command.CreateParameter();
                idproductoParameters.ParameterName = "@IdProducto";
                idproductoParameters.Value = P.IdProducto;

                var nombreParameters = command.CreateParameter();
                nombreParameters.ParameterName = "@Nombre";
                nombreParameters.Value = P.Nombre;

                var precioParameters = command.CreateParameter();
                precioParameters.ParameterName = "@Precio";
                precioParameters.Value = P.Precio;

                var CantidadStockParameters = command.CreateParameter();
                CantidadStockParameters.ParameterName = "@CantidadStock";
                CantidadStockParameters.Value = P.CantidadStock;

                var IdProveedorParameters = command.CreateParameter();
                IdProveedorParameters.ParameterName = "@IdProveedor";
                IdProveedorParameters.Value = P.IdProveedor;

                command.Parameters.Add(idproductoParameters);
                command.Parameters.Add(nombreParameters);
                command.Parameters.Add(precioParameters);
                command.Parameters.Add(CantidadStockParameters);
                command.Parameters.Add(IdProveedorParameters);

                command.CommandText = "[Catalogos].[GuardarProducto]";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                conexion.Open();

                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (reader.Read())
                    {
                        try
                        {
                            n.Mensaje = reader.GetString(reader.GetOrdinal("Mensaje"));
                            n.Exito = reader.GetBoolean(reader.GetOrdinal("Exito"));
                        }
                        catch (Exception ex)
                        {
                            ex.Message.ToString();
                        }
                    }
                }
                conexion.Close();
                return n;
            }

        }
        public async Task<ProductoResponseViewModel> EliminarProducto(int idProducto)
        {
            using (var conexion = new SqlConnection(Helpers.ContextConfiguration.ConexionString))
            {
                ProductoResponseViewModel n = new ProductoResponseViewModel();

                var command = new SqlCommand();
                command.Connection = conexion;

                var idProductoParameter = command.CreateParameter();
                idProductoParameter.ParameterName = "@IdProducto";
                idProductoParameter.Value = idProducto;

                command.Parameters.Add(idProductoParameter);

                command.CommandText = "[Catalogos].[EliminarProducto]";
                command.CommandType = System.Data.CommandType.StoredProcedure;

                conexion.Open();

                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (reader.Read())
                    {
                        try
                        {
                            n.Mensaje = reader.GetString(reader.GetOrdinal("Mensaje"));
                            n.Exito = reader.GetBoolean(reader.GetOrdinal("Exito"));
                        }
                        catch (Exception ex)
                        {
                            ex.Message.ToString();
                        }
                    }
                }
                conexion.Close();
                return n;
            }
        }

        public async Task<ProductoResponseViewModel> EditarProducto(int idProducto, string nombre, decimal precio, int cantidadStock, int idProveedor)
        {
            using (var conexion = new SqlConnection(Helpers.ContextConfiguration.ConexionString))
            {
                ProductoResponseViewModel n = new ProductoResponseViewModel();

                var command = new SqlCommand();
                command.Connection = conexion;

                var idProductoParameter = command.CreateParameter();
                idProductoParameter.ParameterName = "@IdProducto";
                idProductoParameter.Value = idProducto;

                var nombreParameter = command.CreateParameter();
                nombreParameter.ParameterName = "@Nombre";
                nombreParameter.Value = nombre;

                var precioParameter = command.CreateParameter();
                precioParameter.ParameterName = "@Precio";
                precioParameter.Value = precio;

                var cantidadStockParameter = command.CreateParameter();
                cantidadStockParameter.ParameterName = "@CantidadStock";
                cantidadStockParameter.Value = cantidadStock;

                var idProveedorParameter = command.CreateParameter();
                idProveedorParameter.ParameterName = "@IdProveedor";
                idProveedorParameter.Value = idProveedor;

                command.Parameters.Add(idProductoParameter);
                command.Parameters.Add(nombreParameter);
                command.Parameters.Add(precioParameter);
                command.Parameters.Add(cantidadStockParameter);
                command.Parameters.Add(idProveedorParameter);

                command.CommandText = "[Catalogos].[EditarProducto]";
                command.CommandType = System.Data.CommandType.StoredProcedure;

                conexion.Open();

                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (reader.Read())
                    {
                        try
                        {
                            n.Mensaje = reader.GetString(reader.GetOrdinal("Mensaje"));
                            n.Exito = reader.GetBoolean(reader.GetOrdinal("Exito"));
                        }
                        catch (Exception ex)
                        {
                            ex.Message.ToString();
                        }
                    }
                }
                conexion.Close();
                return n;
            }
        }


    } 
}
