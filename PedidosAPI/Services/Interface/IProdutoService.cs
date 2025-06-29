using PedidosAPI.Models;

namespace PedidosAPI.Services.Interface
{
    public interface IProdutoService
    {
        public Task<IEnumerable<Produto>> GetProdutosAsync();
        public Task<Produto> GetProduto(int id);
        public Task<Produto> CreateProduto(Produto produto);
        public Task<Produto> UpdateProdutoAsync(Produto produto);
        public Task RemoverProdutoAsync(int id);
    }
}
