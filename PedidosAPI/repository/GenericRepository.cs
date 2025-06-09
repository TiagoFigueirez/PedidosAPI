using Microsoft.EntityFrameworkCore;
using PedidosAPI.Context;
using PedidosAPI.repository.Interface;
using System.Linq.Expressions;

namespace PedidosAPI.repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly PedidosDbContext context;
        public GenericRepository(PedidosDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await context.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T?> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return await context.Set<T>().FirstOrDefaultAsync(predicate);
        }

        public T Create(T entity)
        {
            context.Set<T>().Add(entity);
            return entity;
        }

        public T Update(T entity)
        {
            context.Set<T>().Update(entity);

            return entity;
        }
        public T Delete(T entity)
        {
            context.Remove(entity);
            context.SaveChanges();

            return entity;
        }
    }
}
