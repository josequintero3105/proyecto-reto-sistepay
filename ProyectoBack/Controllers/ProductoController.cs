using Microsoft.AspNetCore.Mvc;
using ProyectoBack.Models;
using ProyectoBack.Services;
using ProyectoBack.Validator;
using FluentValidation.Results;
using AutoMapper;

namespace ProyectoBack.Controllers
{   /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoService _productoService = new ProductoService();

        [HttpGet]
        public async Task<IActionResult> GetAllProducts() 
        {
            return Ok(await _productoService.GetAllProductos());
        }

        /// <summary>
        /// Get the product by id http://localhost:30388/api/Producto/GetProductById/{id}
        /// </summary>
        /// <param name="_id"></param>
        /// <returns></returns>
        [HttpGet("{_id}")]
        public async Task<IActionResult> GetProductById(string _id)
        {
            return Ok(await _productoService.GetProductoById(_id));
        }
        /// <summary>
        /// Creating product using fluentvalidations http://localhost:30388/api/Producto/CreateProduct
        /// </summary>
        /// <param name="producto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] Producto producto)
        {
            var validator = new ProductoValidator();
            ValidationResult result = validator.Validate(producto);
            if (!result.IsValid)
            {
                foreach (var errors in result.Errors)
                {
                    ModelState.AddModelError($"{errors.PropertyName}", $"{errors.ErrorMessage}");
                }
                return Created("Not Created", false);
            }
            else
            {
                await _productoService.InsertarProducto(producto);
                return Created("Created", true);
            }
        }
        /// <summary>
        /// update the data of a product in specific http://localhost:30388/api/Producto/UpdateProduct?id={id}
        /// </summary>
        /// <param name="producto"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> UpdateProduct([FromBody] Producto producto, string id)
        {
            producto._id = new MongoDB.Bson.ObjectId(id);
            await _productoService.ActualizarProducto(producto);
            return Created("Updated", true);
        }
        /// <summary>
        /// Delete the product especifing the id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //[HttpDelete]
        //public async Task<IActionResult> DeleteProduct(string id)
        //{
        //    await _productoService.EliminarProducto(id);
        //    return NoContent();
        //}
    }
}
