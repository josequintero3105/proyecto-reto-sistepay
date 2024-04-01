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

namespace ProyectoPrueba
{
    public class ProductoControllerTests
    {
        private readonly ProductoController _productoController;
        private readonly IProductoService _productoService;

        public ProductoControllerTests()
        {
            _productoController = new ProductoController();
            _productoService = new ProductoService();
        }

        /// <summary>
        /// Method comprobes the quantity more than zero
        /// </summary>
        [Fact]
        public async void Get_Quantity()
        {
            // Arrange
            var result = await _productoController.GetAllProducts();

            // Act
            var productos = Assert.IsType<OkObjectResult>(result);

            // Assert
            Assert.True(!productos.Equals(0));
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
