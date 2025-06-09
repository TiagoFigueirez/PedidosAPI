using PedidosAPI.Context;
using PedidosAPI.Models;
using PedidosAPI.repository.Interface;

namespace PedidosAPI.repository
{
    public class SubCategoriaRepository : GenericRepository<SubCategoria>, ISubCategoriaRepository
    {
        public SubCategoriaRepository(PedidosDbContext context) : base (context) { }

    }
}
