using AutoMapper;
using MongoDB.Bson;
using MongoDB.Driver;
using ProyectoBack.Models;
using ProyectoBack.Repositories;

namespace ProyectoBack.Services
{
    public class ProductoService : IProductoService
    {
        internal MongoConnect _connect = new MongoConnect();
        private IMongoCollection<Producto> Collection;

        public ProductoService()
        {
            Collection = _connect.Database.GetCollection<Producto>("Producto");
        }

        /// <summary>
        /// Insert a product into the inventory in the database
        /// </summary>
        /// <param name="producto"></param>
        /// <returns></returns>
        public async Task InsertarProducto(Producto producto)
        {
            await Collection.InsertOneAsync(producto);   
        }

        /// <summary>
        /// Update a product into the inventory in the database
        /// </summary>
        /// <param name="producto"></param>
        /// <returns></returns>
        public async Task ActualizarProducto(Producto producto)
        {
            var IdFinded = Builders<Producto>.Filter.Eq(s => s._id, producto._id);
            await Collection.ReplaceOneAsync(IdFinded, producto);
        }

        /// <summary>
        /// Delete a product from the database
        /// </summary>
        /// <param name="_id"></param>
        /// <returns></returns>
        public async Task EliminarProducto(string _id)
        {
            var IdFinded = Builders<Producto>.Filter.Eq(s => s._id, new ObjectId(_id));
            await Collection.DeleteOneAsync(IdFinded);
        }

        /// <summary>
        /// Select an especific product from the inventory
        /// </summary>
        /// <param name="_id"></param>
        /// <returns></returns>
        public async Task<Producto> GetProductoById(string _id)
        {
            return await Collection.FindAsync(
                new BsonDocument { { "_id", new ObjectId(_id) } }).Result.FirstOrDefaultAsync();
        }

        /// <summary>
        /// List all the products finded in the inventory 
        /// </summary>
        /// <returns></returns>
        public async Task<List<Producto>> GetAllProductos()
        {
            return await Collection.FindAsync(new BsonDocument()).Result.ToListAsync();
        }
    }
}
