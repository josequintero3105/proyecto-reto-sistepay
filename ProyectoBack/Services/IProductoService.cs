using ProyectoBack.Models;

namespace ProyectoBack.Services
{
    public interface IProductoService
    {
        Task InsertarProducto(Producto producto);
        Task ActualizarProducto(Producto producto);
        //Task EliminarProducto(string id);
        Task<List<Producto>> GetAllProductos();
        Task<Producto> GetProductoById(string id);
    }
}
