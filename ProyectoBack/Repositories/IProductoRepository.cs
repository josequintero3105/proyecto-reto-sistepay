using ProyectoBack.Models;

namespace ProyectoBack.Repositories
{
    public interface IProductoRepository
    {
        Producto GetProducto(ProductoDTO productoDTO);
    }
}
