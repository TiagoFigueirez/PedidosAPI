using PedidosAPI.Models;

namespace PedidosAPI.Services.Interface
{
    public interface ICategoriaService
    {
        public Task<IEnumerable<Categoria>> GetCategoriasAsync();
        public Task<Categoria> GetCategoria(int id);
        public Task<Categoria> CreateCategoria(Categoria categoria);
        public Task<Categoria> UpdateCategoriaAsync(Categoria categoria);
        public Task RemoverCategoriaAsync(int id);
    }
}
