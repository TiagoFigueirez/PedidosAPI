using PedidosAPI.Context;
using PedidosAPI.Models;
using PedidosAPI.repository.Interface;

namespace PedidosAPI.repository
{
    public class ProdutoRepository : GenericRepository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(PedidosDbContext context) : base(context) { }

    }
}
