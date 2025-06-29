using PedidosAPI.Models;

namespace PedidosAPI.Services.Interface
{
    public interface ISubCategoriaService
    {
        public Task<IEnumerable<SubCategoria>> GetSubCategoriasAsync();
        public Task<SubCategoria> GetSubCategoria(int id);
        public Task<SubCategoria> CreateSubCategoria(SubCategoria categoria);
        public Task<SubCategoria> UpdateSubCategoriaAsync(SubCategoria categoria);
        public Task RemoverSubCategoriaAsync(int id);
    }
}
