using Microsoft.EntityFrameworkCore;
using PedidosAPI.Models;

namespace PedidosAPI.Context
{
    public class PedidosDbContext : DbContext
    {
        public PedidosDbContext(DbContextOptions<PedidosDbContext> options) : base(options) { }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<SubCategoria> SubCategorias { get; set; }
        public DbSet<Produto> Produtos { get; set; }

        public override int SaveChanges()
        {
            AtualizarBaseEntity();
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            AtualizarBaseEntity();
            return await base.SaveChangesAsync(cancellationToken);
        }

        private void AtualizarBaseEntity()
        {
            var entidades = ChangeTracker.Entries<BaseEntity>();

            foreach (var entidade in entidades)
            {
                //verifica se a entidade esta sendo criada
                if(entidade.State == EntityState.Added)
                {
                    entidade.Entity.DataCriacao = DateTime.UtcNow;
                    entidade.Entity.IsAtivo = true;
                }

                //verifica se a entidade está sendo modificada
                if(entidade.State == EntityState.Modified)
                {
                    entidade.Property("DataCriacao").IsModified = false;
                    entidade.Property("IsAtivo").IsModified = false;

                    entidade.Entity.DataAtualizacao = DateTime.UtcNow;
                }
            }
        }

    }
}
