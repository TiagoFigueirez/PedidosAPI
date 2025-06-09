using PedidosAPI.Context;
using PedidosAPI.repository.Interface;

namespace PedidosAPI.repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public ICategoriaRepository? categoriaRepository;
        public ISubCategoriaRepository? subCategoriaRepository;
        public IProdutoRepository? produtoRepository;
        public PedidosDbContext context;

        public UnitOfWork(PedidosDbContext context)
        {
            this.context = context;
        }

        public ICategoriaRepository CategoriaRepository
        {
            get
            {
                return categoriaRepository = categoriaRepository ?? new CategoriaRepository(context);
            }
        }

        public ISubCategoriaRepository SubCategoriaRepository
        {
            get
            {
                return subCategoriaRepository = subCategoriaRepository ?? new SubCategoriaRepository(context);
            }
        }

        public IProdutoRepository ProdutoRepository
        {
            get
            {
                return produtoRepository = produtoRepository ?? new ProdutoRepository(context);
            }
        }

        public async Task Commit()
        {
           await context.SaveChangesAsync();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
