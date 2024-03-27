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
    public class ProductoTesting
    {
        private readonly ProductoController _productoController;
        private readonly IProductoService _productoService;

        public ProductoTesting()
        {
            _productoService = new ProductoService();
            _productoController = new ProductoController(_productoService);
        }

        /// <summary>
        /// Method comprobes the data or the products on database
        /// </summary>
        [Fact]
        public async Task Get_Ok()
        {
            // Arrange & Act
            var result = await _productoController.GetAllProductos();

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        /// <summary>
        /// Method comprobes the quantity more than zero
        /// </summary>
        [Fact]
        public async void Get_Quantity()
        {
            // Arrange
            var result = await _productoService.GetAllProductos();

            // Act
            var productos = Assert.IsType<List<Producto>>(result);

            // Assert
            Assert.True(productos.Count > 0);
        }

        /// <summary>
        /// Method comprobes the correct format of id
        /// </summary>
        [Fact]
        public async void GetById_Ok()
        {
            //Arrange
            var _id = "65fc1d71f058bd95b44cc502";

            //Act
            var result = await _productoController.GetProductoById(_id);

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
            var _id = "65fc1d71f058bd95b44cc502";

            //Act
            var result = await _productoService.GetProductoById(_id);

            // Assert
            var producto = Assert.IsType<Producto>(result);
            Assert.True(producto != null);
        }

        /// <summary>
        /// Method verifies an inexistant id
        /// </summary>
        [Fact]
        public async void GetById_NotFound()
        {
            //Arrange
            var _id = "65fc1d71f058bd95b44cc501";

            //Act
            var result = await _productoService.GetProductoById(_id);

            //Assert
            Assert.True(result == null);
        }
    }
}
