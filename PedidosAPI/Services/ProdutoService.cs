using PedidosAPI.Models;
using PedidosAPI.repository.Interface;
using PedidosAPI.Services.Interface;

namespace PedidosAPI.Services
{
    public class ProdutoService : BaseService, IProdutoService
    {
        private readonly IUnitOfWork _uof;

        public ProdutoService(IUnitOfWork uof)
        {
            _uof = uof;
        }

        public async Task<IEnumerable<Produto>> GetProdutosAsync()
        {
            var produtos = await _uof.ProdutoRepository.GetAllAsync();

            return produtos;
        }

        public async Task<Produto> GetProduto(int id)
        {
            var produto = await _uof.ProdutoRepository.GetAsync(p => p.Id == id);

            if (produto is null) throw new KeyNotFoundException("Produto não encontrado");

            return produto;
        }

        public async Task<Produto> CreateProduto(Produto produto)
        {
            if (produto is null) throw new KeyNotFoundException("Dados em branco");

            await ValidationEntityExisting(
                _uof.ProdutoRepository,
                p => p.Codigo == produto.Codigo,
                "O código já existe"
                );

            var ProdutoCriado = _uof.ProdutoRepository.Create(produto);
            await _uof.Commit();

            return produto;
        }

        public async Task<Produto> UpdateProdutoAsync(Produto produto)
        {
            await ValidationEntityExisting(
                _uof.ProdutoRepository,
                p => p.Codigo == produto.Codigo,
                "Já existe um produto com esse código "
                );

            var produtoAtualizado = _uof.ProdutoRepository.Update(produto);
            await _uof.Commit();
            return produto;
        }
        public async Task RemoverProdutoAsync(int id)
        {
            var produto = await _uof.ProdutoRepository.GetAsync(p => p.Id == id);

            if(produto is null) throw new KeyNotFoundException("Não foi encontrado o produto para excluir");
            _uof.ProdutoRepository.Delete(produto);

        }
    }
}
