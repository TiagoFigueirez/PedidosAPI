using PedidosAPI.Context;
using PedidosAPI.Models;
using PedidosAPI.repository.Interface;

namespace PedidosAPI.repository
{
    public class CategoriaRepository : GenericRepository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(PedidosDbContext context) : base(context) { }
    }
}
