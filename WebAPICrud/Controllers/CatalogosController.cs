using Microsoft.AspNetCore.Mvc;
using WebAPICrud.Core.BL.Interfaces;
using WebAPICrud.Models.Api.Request;


namespace WebAPICrud.Controllers
{
    public class CatalogosController : Controller
    {
        #region Propiedades
        /// <summary>
        /// Proporciona el manejo Coordinacion a travez 
        /// </summary>
        private readonly ICatalogos _catalogosService;

        #endregion

        #region Construtor
        /// <summary>
        /// Initializes a new instance of the <see cref="CatalogosController"/>
        /// </summary>
        /// ‹param name="catalogosService">The coordinacion service‹/param>
        public CatalogosController(ICatalogos catalogosService)
        {
            _catalogosService = catalogosService;

        }

        #endregion

        #region METODOS

        /// <summary>
        ///  Obtienen los productos
        /// </summary>
        /// <returns></returns>

        [HttpGet("ObtenerProductos")]
        public async Task<IActionResult> ObtenerProductos()
        {
            var resultado = await _catalogosService.ObtenerProductos();
            return Ok(resultado);
        }

        #endregion
        [HttpPost("GuardarProducto")]
        public async Task<IActionResult> GuardarProducto(ProductoResponseViewModel P)
        {
            try
            {
                var resultado = await _catalogosService.GuardarProducto (P);
                if (resultado.Exito)
                {
                    return Ok("El producto ha sido guardado con exito");
                }
                else
                {
                    return BadRequest(resultado.Mensaje); // Or a more specific error message
                }
            }
            catch (Exception ex)
            {
                // Log the exception details
                return StatusCode(500, "hola");
            }
        }
        [HttpDelete("EliminarProducto")]
        public async Task<IActionResult> EliminarProducto(int idProducto)
        {
            try
            {
                var resultado = await _catalogosService.EliminarProducto(idProducto);
                if (resultado.Exito)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest(resultado.Mensaje); // Or a more specific error message
                }
            }
            catch (Exception ex)
            {
                // Log the exception details
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPut("EditarProducto")]
        public async Task<IActionResult> EditarProducto(int idProducto, string nombre, decimal precio, int cantidadStock, int idProveedor)
        {
            try
            {
                var resultado = await _catalogosService.EditarProducto(idProducto, nombre, precio, cantidadStock, idProveedor);
                if (resultado.Exito)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest(resultado.Mensaje); // Or a more specific error message
                }
            }
            catch (Exception ex)
            {
                // Log the exception details
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}
