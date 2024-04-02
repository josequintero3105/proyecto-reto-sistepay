using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using ProyectoBack.Controllers;
using ProyectoBack.Models;
using ProyectoBack.Repositories;
using ProyectoBack.Services;
using Moq;

namespace ProyectoPrueba
{
    public class ProductoControllerTests
    {
        private ProductoController _productoController;
        private readonly IProductoService _productoService;
        private Producto producto;

        public ProductoControllerTests()
        {
            _productoController = new ProductoController();
            _productoService = new ProductoService();
        }

        /// <summary>
        /// Method validates an insertion of product
        /// </summary>
        [Fact]
        public void CreateProduct_ProductIsValid()
        {
            // Arrange
            var MockProductService = new Mock<IProductoService>();

            // Act
            MockProductService.Setup(sp => sp.InsertarProducto(producto));
            ProductoController _productoController = new ProductoController(MockProductService.Object);
            var result = _productoController.CreateProduct(producto);

            // Assert
            Assert.NotNull(result);
        }

        /// <summary>
        /// Method validates the update of product
        /// </summary>
        [Fact]
        public void UpdateProduct_ProductIsValid()
        {
            // Arrange
            var MockProductService = new Mock<IProductoService>();
            string _id = "660af41c80633da44e3a93e5";

            // Act
            MockProductService.Setup(sp => sp.ActualizarProducto(producto));
            ProductoController _productoController = new ProductoController(MockProductService.Object);
            var idFinded = _productoService.GetProductoById(_id);
            var result = _productoController.UpdateProduct(producto, _id);

            // Assert
            Assert.True(idFinded != null);
            Assert.NotNull(result);
        }

        /// <summary>
        /// Method gets all products inserted in the database
        /// </summary>
        [Fact]
        public async void Get_Products()
        {
            // Arrange
            var result = await _productoService.GetAllProductos();

            // Act & assert
            Assert.IsType<List<Producto>>(result);
        }

        /// <summary>
        /// Method comprobes the correct format of id
        /// </summary>
        [Fact]
        public async void GetById_Ok()
        {
            //Arrange
            var _id = "660af41c80633da44e3a93e5";

            //Act
            var result = await _productoController.GetProductById(_id);

            //Assert
            Assert.IsType<OkObjectResult>(result);
        }

        /// <summary>
        /// Method comprobes the existence of id
        /// </summary>
        [Fact]
        public async void GetById_Exists()
        {
            //Arrange
            var _id = "660af41c80633da44e3a93e5";

            //Act
            var result = await _productoService.GetProductoById(_id);

            // Assert
            Assert.True(result != null);
        }

        /// <summary>
        /// Method verifies an inexistant id
        /// </summary>
        [Fact]
        public async void GetById_NotFound()
        {
            //Arrange
            var _id = "660af41c80633da44e3a93e";

            //Act
            var result = await _productoService.GetProductoById(_id);

            //Assert
            Assert.True(result == null);
        }
    }
}
