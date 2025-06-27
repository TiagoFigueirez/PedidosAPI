using PedidosAPI.repository.Interface;
using System.Linq.Expressions;

namespace PedidosAPI.Services
{
    public class BaseValidationService
    {
        protected async Task ValidationEntityExisting<TDependente>(IGenericRepository<TDependente> repository,
            Expression<Func<TDependente, bool>> foreignKeySelector, string messege) where  TDependente : class
        {
            var existente = await repository.GetAsync(foreignKeySelector);

            if (existente != null) throw new InvalidOperationException(messege);

        }
    }
}
